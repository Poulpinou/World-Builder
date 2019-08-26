using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace WorldBuilder.Behaviours
{
    public abstract class Behaviour : MonoBehaviour
    {
        #region Enums
        public enum UnicityConstraintType { unique, uniqueByOrigin, multiple }
        #endregion

        #region Properties
        public object Origin { get; private set; }

        public IBehaviourable Target { get; private set; }

        public virtual UnicityConstraintType UnicityConstraint => UnicityConstraintType.unique;

        public virtual Type[] TypeRestrictions => new Type[]{typeof(MonoBehaviour)};
        #endregion

        #region Static Methods
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
        public virtual void Detach() {
            Exit();
            DestroyImmediate(this);
        }
        #endregion

        #region Private Methods
        bool CheckUnicityConstraint()
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

        bool CheckTypeConstraint()
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
