using UnityEngine;

namespace Farmland.Terrain
{
    [CreateAssetMenu(menuName = "Farmland/Production/Create ProductionDetails", fileName = "ProductionDetails", order = 0)]
    public class ProductionDetails : ScriptableObject
    {
        public string ResourceName;
        public float OutputAmount;
        public float ProductionTicks;
    }
}