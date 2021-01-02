using System;
using Interface;
using Terrain;
using UnityEngine;

namespace Selection
{
    public class SelectionController : MonoBehaviour
    {
        private Tooltip tooltip;
        
        private TileController tileController;
        private BuildingController buildingController;

        private void Awake()
        {
            buildingController = GameObject.FindObjectOfType<BuildingController>();
            tileController = GameObject.FindObjectOfType<TileController>();
            tooltip = GameObject.FindObjectOfType<Tooltip>();
        }
        
        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var mouseWorldPosition = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var roundedPosition = new Vector2(Mathf.RoundToInt(mouseWorldPosition.x),
                    Mathf.RoundToInt(mouseWorldPosition.y));

                int xPosition = (int)roundedPosition.x;
                int yPosition = (int)roundedPosition.y;

                if (xPosition >= tileController.GenerationSettings.XSize ||
                    xPosition < 0 ||
                    yPosition >= tileController.GenerationSettings.YSize ||
                    yPosition < 0)
                {
                    Debug.Log("Clicking out of bounds!");
                    return;
                }
                
                var tooltipInformation = tileController.GetTile(xPosition, yPosition).GetTooltipInformation();
                tooltip?.ShowTooltip(tooltipInformation);

                if (buildingController.CanBuild(xPosition, yPosition))
                {
                    Debug.Log("We can build!");
                }
                else
                {
                    Debug.Log("We cant build!");
                }   
            }
        }
    }
}