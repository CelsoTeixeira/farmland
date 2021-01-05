using System;
using System.Collections.Generic;
using Farmland.Resource;
using Farmland.Terrain;
using UnityEngine;

namespace Farmland.Controller
{
    [Serializable]
    public class ProductionController
    {
        private List<IProduction> productions;

        public ProductionController(BuildingController controller)
        {
            productions = new List<IProduction>();
            controller.OnConstruct += OnConstructed;
        }

        private void OnConstructed(Building building)
        {
            Debug.Log("We have a new building constructed!");
            var production = building.GetComponent<IProduction>();
            if (production != null) productions.Add(production);
        }

        public void ControlProductions(float deltaTime)
        {
            
            
            foreach (var production in productions)
            {
                production.Produce(deltaTime);
                // production.DebugProduction();
            }
        }
    }
    
    public class GameController : MonoBehaviour
    {
        public GameSetup GameSetup;
        
        public ResourceStorage ResourceStorage { get; private set; }
        public ProductionController ProductionController { get; private set; }
        
        private void Awake()
        {
            //Get Resource Collection
            var resourceCollections = Resources.Load<ResourceCollection>("ResourceCollection");
            
            //Get Game Setup values.
            var initialValues = GameSetup.GetInitialValues();
                        
            //Initialize a new Storage for resources.
            ResourceStorage = new ResourceStorage(resourceCollections.GetAllResources());
            //Pass Initial values to Storage
            ResourceStorage.InitialSetup(initialValues);

            var buildingController = GameObject.FindObjectOfType<BuildingController>();
            ProductionController = new ProductionController(buildingController);
        }


        public void Update()
        {
            //ResourceStorage.DebugStorage();
            ProductionController.ControlProductions(Time.deltaTime);
        }
        
    }
}