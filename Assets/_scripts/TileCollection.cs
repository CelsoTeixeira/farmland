using System.Collections.Generic;
using UnityEngine;

namespace Farmland.Terrain
{
    [CreateAssetMenu(menuName = "Farmland/Create TileCollection", fileName = "TileCollection", order = 0)]
    public class TileCollection : ScriptableObject
    {
        public List<TileDetails> TileDictionary;
        
        public TileDetails GetTile(TileType type)
        {
            return TileDictionary.Find(i => i.Type == type);
        }
    }
}