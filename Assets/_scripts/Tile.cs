using System;
using System.Collections;
using System.Text;
using Interface;
using UnityEngine;

namespace Terrain
{
    public enum TileType
    {
        None, 
        Grass, 
        Dirt,
        Sand
    }
    
    public class Tile : MonoBehaviour
    {
        public TileType TileType;
        public SpriteRenderer Sprite;

        private void Awake()
        {
            Sprite = GetComponent<SpriteRenderer>();
        }

        public void SetType(TileDetails details)
        {
            if (Sprite == null) Sprite = GetComponent<SpriteRenderer>();
            
            TileType = details.Type;
            Sprite.sprite = details.Sprite;
        }
        
        public TooltipInformation GetTooltipInformation()
        {
            var positionText = new StringBuilder();
            positionText.Append("X: ").Append(Mathf.RoundToInt(transform.position.x)).Append(" / Y: ")
                .Append(Mathf.RoundToInt(transform.position.y));

            var detailsText = new StringBuilder();
            detailsText.Append("Terreno - ").Append(TileType);
            
            return new TooltipInformation()
            {
                PositionText = positionText.ToString(),
                DetailsText = detailsText.ToString()
            };
        }
    }

    [Serializable]
    public struct TileDetails
    {
        public TileType Type;
        public Sprite Sprite;
    }
}


