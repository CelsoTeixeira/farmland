using TMPro;
using UnityEngine;

namespace Interface
{
    public struct TooltipInformation
    {
        public string PositionText;
        public string DetailsText;
    }
    
    public class Tooltip : MonoBehaviour
    {
        public TextMeshProUGUI DetailsText;
        public TextMeshProUGUI PositionText;
        
        public void ShowTooltip(TooltipInformation info)
        {
            PositionText.text = info.PositionText;
            DetailsText.text = info.DetailsText;
        }
    }
}