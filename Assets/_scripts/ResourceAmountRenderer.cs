using Farmland.Controller;
using Farmland.Resource;
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

        public void Setup(Resource.ResourceDetails resource)
        {
            Name.text = resource.Name;
            Amount.text = "0";

            Icon.sprite = resource.Icon == null ? Resources.Load<Sprite>("Interface/MissingIcon") : resource.Icon;

            var gameController = GameObject.FindObjectOfType<GameController>();
            gameController.ResourceStorage.OnResourceUpdate += AutoUpdate;

            Amount.text = gameController.ResourceStorage.GetResourceAmount(Name.text).ToString();
        }

        private void AutoUpdate(string name, float value)
        {
            if (Name.text == name)
            {
                Amount.text = value.ToString();
            }
        }
    }
}