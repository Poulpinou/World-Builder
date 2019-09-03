using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace WorldBuilder.Behaviours
{
    /// <summary>
    /// An <see cref="IBehaviourable"/> can have <see cref="Behaviour"/> attached to it
    /// </summary>
    public interface IBehaviourable
    {
        GameObject gameObject { get; }
    }

    public static class IBehaviourableExtensions {
        /// <summary>
        /// Returns every <see cref="Behaviour"/> attached to this
        /// </summary>
        public static Behaviour[] GetBehaviours(this IBehaviourable behaviourable)
        {
            return behaviourable.gameObject.GetComponents<Behaviour>();
        }

        /// <summary>
        /// Returns every <see cref="Behaviour"/> attached to this by <paramref name="origin"/>
        /// </summary>
        public static Behaviour[] GetBehaviours(this IBehaviourable behaviourable, object origin)
        {
            return GetBehaviours(behaviourable).Where(b => b.Origin == origin).ToArray();
        }

        /// <summary>
        /// Returns every <typeparamref name="TBehaviour"/> attached to this
        /// </summary>
        public static TBehaviour[] GetBehaviours<TBehaviour>(this IBehaviourable behaviourable) where TBehaviour : Behaviour
        {
            return behaviourable.gameObject.GetComponents<TBehaviour>();
        }

        /// <summary>
        /// Returns every <typeparamref name="TBehaviour"/> attached to this by <paramref name="origin"/>
        /// </summary>
        public static TBehaviour[] GetBehaviours<TBehaviour>(this IBehaviourable behaviourable, object origin) where TBehaviour : Behaviour
        {
            return GetBehaviours<TBehaviour>(behaviourable).Where(b => b.Origin == origin).ToArray();
        }

        /// <summary>
        /// Returns a <typeparamref name="TBehaviour"/> attached to this
        /// </summary>
        public static TBehaviour GetBehaviour<TBehaviour>(this IBehaviourable behaviourable) where TBehaviour : Behaviour
        {
            return behaviourable.gameObject.GetComponent<TBehaviour>();
        }

        /// <summary>
        /// Returns a <typeparamref name="TBehaviour"/> attached to this by <paramref name="origin"/>
        /// </summary>
        public static TBehaviour GetBehaviour<TBehaviour>(this IBehaviourable behaviourable, object origin) where TBehaviour : Behaviour
        {
            return GetBehaviours<TBehaviour>(behaviourable, origin).FirstOrDefault();
        }

        /// <summary>
        /// Attaches a <see cref="Behaviour"/> of type <typeparamref name="TBehaviour"/> to this
        /// </summary>
        /// <typeparam name="TBehaviour">The type of the <see cref="Behaviour"/></typeparam>
        /// <param name="origin">The object that asked to attach the behaviour</param>
        /// <returns>The attached <typeparamref name="TBehaviour"/></returns>
        public static TBehaviour AttachBehaviour<TBehaviour>(this IBehaviourable behaviourable, object origin) where TBehaviour : Behaviour
        {
            return Behaviour.Attach<TBehaviour>(behaviourable, origin);
        }

        /// <summary>
        /// Attaches a <see cref="Behaviour"/> of type <typeparamref name="TBehaviour"/> to this and set its <typeparamref name="TParams"/>
        /// </summary>
        /// <typeparam name="TBehaviour">The type of the <see cref="Behaviour"/></typeparam>
        /// /// <typeparam name="TParams">The type of the expected params</typeparam>
        /// /// <param name="inputParams">The value of the params</param>
        /// <param name="origin">The object that asked to attach the behaviour</param>
        /// <returns>The attached <typeparamref name="TBehaviour"/></returns>
        public static TBehaviour AttachBehaviour<TBehaviour, TParams>(this IBehaviourable behaviourable, TParams inputParams, object origin) where TBehaviour : Behaviour<TParams>
        {
            return Behaviour.Attach<TBehaviour, TParams>(behaviourable, inputParams, origin);
        }

        /// <summary>
        /// Removes a single <typeparamref name="TBehaviour"/> from this
        /// </summary>
        public static void DetachBehaviour<TBehaviour>(this IBehaviourable behaviourable) where TBehaviour : Behaviour {
            GetBehaviour<TBehaviour>(behaviourable).Detach();
        }

        /// <summary>
        /// Removes a single <typeparamref name="TBehaviour"/> from this that was attached by <paramref name="origin"/>
        /// </summary>
        public static void DetachBehaviour<TBehaviour>(this IBehaviourable behaviourable, object origin) where TBehaviour : Behaviour
        {
            GetBehaviour<TBehaviour>(behaviourable, origin).Detach();
        }

        /// <summary>
        /// Removes every <see cref="Behaviour"/> from this
        /// </summary>
        public static void DetachAllBehaviours(this IBehaviourable behaviourable)
        {
            foreach(Behaviour behaviour in GetBehaviours(behaviourable))
            {
                behaviour.Detach();
            }
        }

        /// <summary>
        /// Removes every <see cref="Behaviour"/> from this that were attached by <paramref name="origin"/>
        /// </summary>
        public static void DetachAllBehaviours(this IBehaviourable behaviourable, object origin)
        {
            foreach (Behaviour behaviour in GetBehaviours(behaviourable, origin))
            {
                behaviour.Detach();
            }
        }

        /// <summary>
        /// Removes every <typeparamref name="TBehaviour"/> from this
        /// </summary>
        public static void DetachAllBehaviours<TBehaviour>(this IBehaviourable behaviourable) where TBehaviour : Behaviour
        {
            foreach (Behaviour behaviour in GetBehaviours<TBehaviour>(behaviourable))
            {
                behaviour.Detach();
            }
        }

        /// <summary>
        /// Removes every <typeparamref name="TBehaviour"/> from this that were attached by <paramref name="origin"/>
        /// </summary>
        public static void DetachAllBehaviours<TBehaviour>(this IBehaviourable behaviourable, object origin) where TBehaviour : Behaviour
        {
            foreach (Behaviour behaviour in GetBehaviours<TBehaviour>(behaviourable, origin))
            {
                behaviour.Detach();
            }
        }

        /// <summary>
        /// True if this item has a <typeparamref name="TBehaviour"/> attached to it
        /// </summary>
        public static bool HasBehaviour<TBehaviour>(this IBehaviourable behaviourable) where TBehaviour : Behaviour {
            return GetBehaviours<TBehaviour>(behaviourable).Any(b => b is TBehaviour);
        }

        /// <summary>
        /// True if this item has a <typeparamref name="TBehaviour"/>  that was attached by <paramref name="origin"/> attached to it
        /// </summary>
        public static bool HasBehaviour<TBehaviour>(this IBehaviourable behaviourable, object origin) where TBehaviour : Behaviour
        {
            return GetBehaviours<TBehaviour>(behaviourable, origin).Any(b => b is TBehaviour);
        }
    }
}
