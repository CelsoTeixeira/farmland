using System;
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

        private void Awake()
        {
            
        }

        private void OnDrawGizmos()
        {
            DebugExtension.DrawBounds(new Bounds(transform.position, new Vector3(1, 1, 1)), Color.yellow);
            
            
        }
    }
}