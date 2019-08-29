using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace WorldBuilder.Blueprints
{
	public class Blueprint
	{
        #region Properties
        public string Name { get; private set; }
        public Vector2Int Dimensions { get; private set; }
        public List<Version> Versions { get; private set; }
        #endregion

        #region Constructors
        public Blueprint(string name, Vector2Int dimensions)
        {
            Name = name;
            Dimensions = dimensions;
            Versions = new List<Version>();
            Versions.Add(new Version(this));
        }
        #endregion

        #region Internal Classes
        [Serializable]
        public class Version
        {
            #region Public Variables
            public BlueprintDatas datas;
            #endregion

            #region Properties
            public string Name { get; private set; }
            public int Order { get; private set; }
            #endregion

            #region Constructors
            public Version(Blueprint blueprint)
            {
                Order = blueprint.Versions.Count + 1;
                Name = string.Format("{0}_v{1}", blueprint.Name, Order);

                datas = new BlueprintDatas(blueprint.Dimensions);
            }
            #endregion
        }
        #endregion
    }
}
