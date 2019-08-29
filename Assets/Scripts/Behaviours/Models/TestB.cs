using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldBuilder.Behaviours.Tests
{
	public class TestB : MonoBehaviour
	{
        public TestBehaviourable item;

        private void Start()
        {
            item.AttachBehaviour<TestBehaviour>(this);

            item.AttachBehaviour<TestBehaviour>(item);

            item.DetachAllBehaviours(item);

            Debug.Log(item.HasBehaviour<TestBehaviour>(item));

            item.AttachBehaviour<TestBehaviour>(item);

            Debug.Log(item.HasBehaviour<TestBehaviour>(this));
        }
    }
}
