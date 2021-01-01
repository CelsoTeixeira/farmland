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

        private void Awake()
        {
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
                
                var tooltipInformation = tileController.GetTile((int)roundedPosition.x, (int)roundedPosition.y).GetTooltipInformation();
                tooltip?.ShowTooltip(tooltipInformation);
            }
        }
    }
}