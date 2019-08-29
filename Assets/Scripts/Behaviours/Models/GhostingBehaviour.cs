using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldBuilder.Behaviours
{
	public class GhostingBehaviour : TempMaterialBehaviour
	{
        protected override void Enter()
        {
            /* Maybe a good idea for some cases...
            try
            {
                Color color = inputParams.GetColor("_MainColor");
                if (color.a == 1)
                {
                    color.a = 0.5f;
                    inputParams.SetColor("_MainColor", color);
                }
            }
            catch { }
            */

            base.Enter();

            Target.gameObject.GetComponent<Collider>().enabled = false;
        }

        protected override void Exit()
        {
            base.Exit();

            Target.gameObject.GetComponent<Collider>().enabled = true;
        }
    }
}
