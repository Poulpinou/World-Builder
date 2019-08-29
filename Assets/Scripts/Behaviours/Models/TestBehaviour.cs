using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldBuilder.Behaviours.Tests
{
    public class TestBehaviour : Behaviour
    {
        public override Type[] TypeRestrictions => new Type[]{typeof(TestBehaviourable)};

        public override UnicityConstraintType UnicityConstraint => UnicityConstraintType.uniqueByOrigin;

        protected override void Enter()
        {
            Debug.Log("Enter " + Target.gameObject.name);
        }

        protected override void Exit()
        {
            Debug.Log("Exit " + Target.gameObject.name);
        }
    }
}
