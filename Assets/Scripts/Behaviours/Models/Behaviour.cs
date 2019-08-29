using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace WorldBuilder.Behaviours
{
    /// <summary>
    /// A <see cref="Behaviour"/> can be attached to any <see cref="IBehaviourable"/> that verifies <see cref="TypeRestrictions"/> and add a specific behaviour
    /// </summary>
    public abstract class Behaviour : MonoBehaviour
    {
        #region Enums
        public enum UnicityConstraintType {
            /// <summary>
            /// This constraint allows only one <see cref="Behaviour"/> of this type attached per object
            /// </summary>
            unique,
            /// <summary>
            /// This constraint allows only one <see cref="Behaviour"/> of this type attached to an object per <see cref="Origin"/>
            /// </summary>
            uniqueByOrigin,
            /// <summary>
            /// This contraint doesn't check number of attached <see cref="Behaviour"/> of same type
            /// </summary>
            multiple
        }
        #endregion

        #region Properties
        /// <summary>
        /// The object that has attached the <see cref="Behaviour"/> to the <see cref="Target"/>
        /// </summary>
        public object Origin { get; private set; }

        /// <summary>
        /// The <see cref="IBehaviourable"/> item that will be affected by the <see cref="Behaviour"/>
        /// </summary>
        public IBehaviourable Target { get; private set; }

        /// <summary>
        /// The <see cref="Behaviour"/>'s <see cref="UnicityConstraintType"/> (override this to change the value)
        /// </summary>
        public virtual UnicityConstraintType UnicityConstraint => UnicityConstraintType.unique;

        /// <summary>
        /// An array of type that are allowed for <see cref="Target"/> (override this to change the value, null => everything allowed)
        /// </summary>
        public virtual Type[] TypeRestrictions => new Type[]{typeof(MonoBehaviour)};
        #endregion

        #region Static Methods
        /// <summary>
        /// Attaches a <see cref="Behaviour"/> of type <typeparamref name="TBehaviour"/> to the <paramref name="target"/>
        /// </summary>
        /// <typeparam name="TBehaviour">The type of the <see cref="Behaviour"/></typeparam>
        /// <param name="target">The <see cref="IBehaviourable"/> which the <see cref="Behaviour"/> will be attached</param>
        /// <param name="origin">The object that has attached the <see cref="Behaviour"/> to the <see cref="Target"/></param>
        /// <returns>The attached <see cref="Behaviour"/></returns>
        public static TBehaviour Attach<TBehaviour>(IBehaviourable target, object origin) where TBehaviour : Behaviour
        {
            TBehaviour behaviour = target.gameObject.AddComponent<TBehaviour>();

            behaviour.Origin = origin;
            behaviour.Target = target;

            if (!behaviour.CheckUnicityConstraint() || !behaviour.CheckTypeConstraint())
            {
                Destroy(behaviour);
                return null;
            }
            
            behaviour.Enter();

            return behaviour;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Detach the behaviour from its <see cref="Target"/>
        /// </summary>
        public virtual void Detach() {
            Exit();
            DestroyImmediate(this);
        }
        #endregion

        #region Private Methods
        protected virtual bool CheckUnicityConstraint()
        {
            switch (UnicityConstraint)
            {
                case UnicityConstraintType.unique:
                    if (GetComponents(GetType()).Length > 1)
                    {
                        Debug.Log(string.Format("Tried to attach a {0} that has a UnicityConstraintType.unique twice : aborted", GetType().Name));
                        return false;
                    }
                    break;
                case UnicityConstraintType.uniqueByOrigin:
                    foreach(Behaviour behaviour in GetComponents(GetType()))
                    {
                        if(behaviour != this && behaviour.Origin == Origin)
                        {
                            Debug.Log(string.Format("Tried to attach a {0} that has a UnicityConstraintType.uniqueByOrigin twice with the same origin ({1}) : aborted", GetType().Name, Origin));
                            return false;
                        }
                    }
                    break;
                case UnicityConstraintType.multiple:
                    break;
            }
            return true;
        }

        protected virtual bool CheckTypeConstraint()
        {
            if (TypeRestrictions == null || TypeRestrictions.Length == 0) return true;

            if(!TypeRestrictions.Any(t => t.IsAssignableFrom(Target.GetType())))
            {
                Debug.Log(string.Format("Tried to attach a {0} to a {1}, but TypeRestriction doesn't allow this : aborted", GetType().Name, Target.GetType().Name));
                return false;
            }
            return true;
        }
        #endregion

        #region Abstract Methods
        protected abstract void Enter();

        protected abstract void Exit();
        #endregion

        #region Runtime Methods
        private void OnDestroy()
        {
            Exit();
        }
        #endregion
#if UNITY_EDITOR
        #region Editor Method
        protected virtual void Reset()
        {
            if (Target == null)
            {
                Target = GetComponent<IBehaviourable>();
                if(Target == null)
                {
                    Debug.Log(string.Format("{0} should have a script that implements IBehaviourable to have a {1} attached to it", gameObject.name, GetType().Name));
                    DestroyImmediate(this);
                    return;
                }
            }

            if (!CheckUnicityConstraint() || !CheckTypeConstraint())
            {
                DestroyImmediate(this);
                return;
            }
        }
        #endregion
#endif
    }
}
