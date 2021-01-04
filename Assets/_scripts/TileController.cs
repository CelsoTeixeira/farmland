using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Farmland.Terrain
{
    [Serializable]
    public struct GenerationSettings
    {
        public int XSize;
        public int YSize;
    }

    
    public class TileController : MonoBehaviour
    {
        public Tile TilePrefab;
        private Tile[,] tiles;

        public TileCollection TileCollection;
        
        public GenerationSettings GenerationSettings;

        private void Awake()
        {
            TileCollection = Resources.Load<TileCollection>("TileCollection");
        }
        
        void Start()
        {
            Initialize();
        }
        
        [ContextMenu("Generate Board")]
        public void Initialize()
        {
            tiles = new Tile[GenerationSettings.XSize,GenerationSettings.YSize];

            for (var x = 0; x < GenerationSettings.XSize; x++)
            {
                for (var y = 0; y < GenerationSettings.YSize; y++)
                {
                    var rng = Random.Range(0, 100);
                    var tileType = rng <= 50 ? TileType.Grass : TileType.Dirt;
                    var details = TileCollection.GetTile(tileType);
                    
                    var location = new Vector2(x, y);
                    var tile = GameObject.Instantiate(TilePrefab, location, Quaternion.identity, this.gameObject.transform);
                    
                    tile.SetType(details);
                    tiles[x, y] = tile;
                }
            }
            
            //Initialize Buildings board
            GameObject.FindObjectOfType<BuildingController>().GenerateBoard(GenerationSettings.XSize, GenerationSettings.YSize);
        }
        
        public Tile GetTile(int xPosition, int yPosition)
        {
            return tiles[xPosition, yPosition];
        }

        [ContextMenu("Clear Board")]
        public void Delete()
        {
            var toDelete = transform.GetComponentsInChildren<Tile>();
            if (toDelete.Length == 0) return;
            foreach (var tile in toDelete)
            {
                DestroyImmediate(tile.gameObject);
            }
        }
        
        
    }
}