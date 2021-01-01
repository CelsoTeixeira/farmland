using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Terrain
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
        private Tile[,] buildings;
        
        
        public TileCollection TileCollection;
        

        public GenerationSettings GenerationSettings;
        
        void Start()
        {
            Initialize();
        }
        
        public void Initialize()
        {
            tiles = new Tile[GenerationSettings.XSize,GenerationSettings.YSize];
            buildings = new Tile[GenerationSettings.XSize,GenerationSettings.YSize];
            
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
        }
        
        public Tile GetTile(int xPosition, int yPosition)
        {
            return tiles[xPosition, yPosition];
        }

        public bool CanConstruct(int xPosition, int yPosition)
        {
            return false;
        }
    }
}