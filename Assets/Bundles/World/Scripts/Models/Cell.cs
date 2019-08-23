using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldBuilder
{
	public struct Cell
	{
        public Vector2 position;

        public float? height;

        public Cell(Vector2 position) {
            this.position = position;
            height = null;
        }

        public Cell(Vector2 position, float height):this(position)
        {
            this.height = height;
        }
    }
}
