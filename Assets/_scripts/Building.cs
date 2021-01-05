using System;
using System.Text;
using Farmland.Controller;
using Farmland.Interface;
using UnityEngine;

namespace Farmland.Terrain
{
    public interface IProduction
    {
        void Produce(float deltaTime);
        void DebugProduction();
    }
    
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