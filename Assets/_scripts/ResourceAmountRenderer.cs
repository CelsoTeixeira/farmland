using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Farmland.Interface
{
    public class ResourceAmountRenderer : MonoBehaviour
    {
        public TextMeshProUGUI Name;
        public TextMeshProUGUI Amount;
        public Image Icon;

        public void Setup(Resource.Resource resource)
        {
            Name.text = resource.Name;
            Amount.text = "0";

            Icon.sprite = resource.Icon;
        }
    }
}