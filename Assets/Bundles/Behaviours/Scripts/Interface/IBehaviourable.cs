using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace WorldBuilder.Behaviours
{
    public interface IBehaviourable
    {
        GameObject gameObject { get; }
    }

    public static class IBehaviourableExtensions {
        public static Behaviour[] GetBehaviours(this IBehaviourable behaviourable)
        {
            return behaviourable.gameObject.GetComponents<Behaviour>();
        }

        public static Behaviour[] GetBehaviours(this IBehaviourable behaviourable, object origin)
        {
            return GetBehaviours(behaviourable).Where(b => b.Origin == origin).ToArray();
        }

        public static TBehaviour[] GetBehaviours<TBehaviour>(this IBehaviourable behaviourable) where TBehaviour : Behaviour
        {
            return behaviourable.gameObject.GetComponents<TBehaviour>();
        }

        public static TBehaviour[] GetBehaviours<TBehaviour>(this IBehaviourable behaviourable, object origin) where TBehaviour : Behaviour
        {
            return GetBehaviours<TBehaviour>(behaviourable).Where(b => b.Origin == origin).ToArray();
        }

        public static TBehaviour GetBehaviour<TBehaviour>(this IBehaviourable behaviourable) where TBehaviour : Behaviour
        {
            return behaviourable.gameObject.GetComponent<TBehaviour>();
        }

        public static TBehaviour GetBehaviour<TBehaviour>(this IBehaviourable behaviourable, object origin) where TBehaviour : Behaviour
        {
            return GetBehaviours<TBehaviour>(behaviourable, origin).FirstOrDefault();
        }

        public static TBehaviour AttachBehaviour<TBehaviour>(this IBehaviourable behaviourable, object origin) where TBehaviour : Behaviour
        {
            return Behaviour.Attach<TBehaviour>(behaviourable, origin);
        }

        public static void DetachBehaviour<TBehaviour>(this IBehaviourable behaviourable) where TBehaviour : Behaviour {
            GetBehaviour<TBehaviour>(behaviourable).Detach();
        }

        public static void DetachBehaviour<TBehaviour>(this IBehaviourable behaviourable, object origin) where TBehaviour : Behaviour
        {
            GetBehaviour<TBehaviour>(behaviourable, origin).Detach();
        }

        public static void DetachAllBehaviours(this IBehaviourable behaviourable)
        {
            foreach(Behaviour behaviour in GetBehaviours(behaviourable))
            {
                behaviour.Detach();
            }
        }

        public static void DetachAllBehaviours(this IBehaviourable behaviourable, object origin)
        {
            foreach (Behaviour behaviour in GetBehaviours(behaviourable, origin))
            {
                behaviour.Detach();
            }
        }

        public static void DetachAllBehaviours<TBehaviour>(this IBehaviourable behaviourable) where TBehaviour : Behaviour
        {
            foreach (Behaviour behaviour in GetBehaviours<TBehaviour>(behaviourable))
            {
                behaviour.Detach();
            }
        }

        public static void DetachAllBehaviours<TBehaviour>(this IBehaviourable behaviourable, object origin) where TBehaviour : Behaviour
        {
            foreach (Behaviour behaviour in GetBehaviours<TBehaviour>(behaviourable, origin))
            {
                behaviour.Detach();
            }
        }

        public static bool HasBehaviour<TBehaviour>(this IBehaviourable behaviourable) where TBehaviour : Behaviour {
            return GetBehaviours<TBehaviour>(behaviourable).Any(b => b is TBehaviour);
        }

        public static bool HasBehaviour<TBehaviour>(this IBehaviourable behaviourable, object origin) where TBehaviour : Behaviour
        {
            return GetBehaviours<TBehaviour>(behaviourable, origin).Any(b => b is TBehaviour);
        }
    }
}
