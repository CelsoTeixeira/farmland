using System;
using System.Text;
using Interface;
using UnityEngine;

namespace Terrain
{
    [Serializable]
    public struct BuildingDetails
    {
        public string Name;
        public int Width;
        public int Height;

        public Building Prefab;
    }

    public class Building : MonoBehaviour
    {
        public BuildingDetails Details;

        public TooltipInformation GetTooltipInformation()
        {
            var detailsText = new StringBuilder();
            detailsText.Append(Details.Name);

            return new TooltipInformation()
            {
                DetailsText = detailsText.ToString(),
            };
        }
        
        private void OnDrawGizmos()
        {
            DebugExtension.DrawBounds(new Bounds(transform.position, new Vector3(1, 1, 1)), Color.yellow);
        }
    }
}