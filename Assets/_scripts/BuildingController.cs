using UnityEngine;

namespace Farmland.Terrain
{
    public class BuildingController : MonoBehaviour
    {
        public BuildingCollection BuildingCollection;
        private Building[,] buildings;

        private void Awake()
        {
            BuildingCollection = Resources.Load<BuildingCollection>("BuildingCollection");
        }
        
        public void GenerateBoard(int xSize, int ySize)
        {
            buildings = new Building[xSize, ySize];
        }

        public void SetBuilding(Building toBuild, int xPosition, int yPosition)
        {
            buildings[xPosition, yPosition] = toBuild;
        }

        public Building GetBuilding(int xPosition, int yPosition)
        {
            return buildings[xPosition, yPosition];
        }
        
        public bool CanBuild(int xPosition, int yPosition)
        {
            var building = buildings[xPosition, yPosition];
            return building == null;
        }
    }
}