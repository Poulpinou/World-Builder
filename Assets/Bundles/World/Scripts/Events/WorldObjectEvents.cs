using System.Collections.Generic;
using UnityEngine.Events;
using System;

namespace WorldBuilder.World
{
    [Serializable] public class WorldObjectEvent : UnityEvent<WorldObject> { }

    [Serializable] public class WorldObjectListEvent : UnityEvent<List<WorldObject>> { }
}
