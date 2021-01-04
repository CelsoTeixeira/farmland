using Farmland.Resource;
using UnityEngine;

namespace Farmland.Controller
{
    public class GameController : MonoBehaviour
    {
        public GameSetup GameSetup;
        
        public ResourceStorage ResourceStorage { get; private set; }

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

        }


        public void Update()
        {
            //ResourceStorage.DebugStorage();
        }
        
    }
}