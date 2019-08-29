using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldBuilder.Behaviours
{
    public class TempMaterialBehaviour : Behaviour<Material>
    {
        protected Material initialMaterial;
        protected Renderer targetRenderer;

        protected override void Enter()
        {
            targetRenderer = GetComponent<Renderer>();
            if (targetRenderer == null)
            {
                Debug.Log(string.Format("Impossible to attach {0} to {1} because it has no Renderer attached to it", GetType(), Target.gameObject.name));
                Detach();
            }

            initialMaterial = targetRenderer.material;

            targetRenderer.material = inputParams;
        }

        protected override void Exit()
        {
            if (targetRenderer == null) return;

            targetRenderer.material = initialMaterial;
        }

        public void ChangeMaterial(Material newMaterial) {
            targetRenderer.material = newMaterial;
        }
    }
}
