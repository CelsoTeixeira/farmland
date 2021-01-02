using System.Collections.Generic;
using UnityEngine;

namespace Terrain
{
    [CreateAssetMenu(menuName = "Farmland/Create BuildingCollection", fileName = "BuildingCollection", order = 1)]
    public class BuildingCollection : ScriptableObject
    {
        public List<BuildingDetails> Buildings;

        public BuildingDetails GetBuilding(string name)
        {
            return Buildings.Find(i => i.Name == name);
        }
    }
}