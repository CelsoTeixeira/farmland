using Farmland.Selection;
using Farmland.Terrain;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Farmland.Interface
{
    public class BuildingInterface : MonoBehaviour
    {
        public Transform ScrollRoot;
        public Button ButtonPrefab;
        
        private BuildingCollection collection;

        private void Awake()
        {
            collection = Resources.Load<BuildingCollection>("BuildingCollection");
            PopulateList();
        }

        private void Start()
        {
            Hide();
        }

        private void PopulateList()
        {
            foreach (var building in collection.Buildings)
            {
                var button = GameObject.Instantiate(ButtonPrefab, ScrollRoot);
                button.transform.localScale = new Vector3(1, 1, 1);
                button.GetComponentInChildren<TextMeshProUGUI>().text = building.Name;
                
                button.onClick.AddListener(() =>
                {
                    Debug.Log("Click!");
                    
                    var selectionController = GameObject.FindObjectOfType<SelectionController>();
                    selectionController.SetTemporaryBuilding(building);
                });
            }            
        }

        public void Show()
        {
            this.gameObject.SetActive(true);
        }

        public void Hide()
        {
            this.gameObject.SetActive(false);
        }
    }
}