using UnityEngine;

namespace Terrain
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
 
        public bool CanBuild(int xPosition, int yPosition)
        {
            
            
            var building = buildings[xPosition, yPosition];
            return building == null;
        }
    }
}