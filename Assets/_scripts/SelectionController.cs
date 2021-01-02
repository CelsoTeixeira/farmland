using System;
using System.Text;
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

        private Building temporaryBuild;
        
        private void Awake()
        {
            buildingController = GameObject.FindObjectOfType<BuildingController>();
            tileController = GameObject.FindObjectOfType<TileController>();
            tooltip = GameObject.FindObjectOfType<Tooltip>();

            temporaryBuild = null;
        }
        
        public void Update()
        {
            var mouseWorldPosition = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var roundedPosition = new Vector2(Mathf.RoundToInt(mouseWorldPosition.x),
                Mathf.RoundToInt(mouseWorldPosition.y));

            int xPosition = Mathf.Clamp((int)roundedPosition.x, 0, tileController.GenerationSettings.XSize - 1) ;
            int yPosition = Mathf.Clamp((int)roundedPosition.y, 0, tileController.GenerationSettings.YSize - 1);
            
            if (temporaryBuild != null)
            {
                temporaryBuild.transform.position = new Vector3(xPosition, yPosition);
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (temporaryBuild != null)
                {
                    if (buildingController.CanBuild(xPosition, yPosition))
                    {
                        temporaryBuild.transform.position = new Vector2(xPosition, yPosition);
                        buildingController.SetBuilding(temporaryBuild, xPosition, yPosition);
                        temporaryBuild = null;
                    }
                    else
                    {
                        Debug.Log("We cant build!");
                        // Show error
                    }                       
                }
                
                var terrainInformation = tileController.GetTile(xPosition, yPosition).GetTooltipInformation();
                var buildInformation = buildingController.GetBuilding(xPosition, yPosition)?.GetTooltipInformation();

                var info = new StringBuilder();
                info.Append(terrainInformation.DetailsText).AppendLine();
                info.Append(buildInformation?.DetailsText);

                var tooltipInfo = new TooltipInformation()
                {
                    DetailsText = info.ToString(),
                    PositionText = terrainInformation.PositionText
                };
                
                tooltip?.ShowTooltip(tooltipInfo);
            }

            if (Input.GetMouseButtonDown(1))
            {
                if (temporaryBuild != null)
                {
                    Destroy(temporaryBuild.gameObject);
                    temporaryBuild = null;
                }
            }
        }

        public void SetTemporaryBuilding(BuildingDetails toBuild)
        {
            var temporary = GameObject.Instantiate(toBuild.Prefab, Vector3.zero, Quaternion.identity);
            temporaryBuild = temporary;
        }
    }
}