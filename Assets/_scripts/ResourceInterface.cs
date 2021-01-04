using System.Collections.Generic;
using Farmland.Resource;
using UnityEngine;

namespace Farmland.Interface
{
    public class ResourceInterface : MonoBehaviour
    {
        public ResourceAmountRenderer Prefab;
        public Transform UIRoot;

        private List<ResourceAmountRenderer> resourceRenderList;

        private void Awake()
        {
            var collection = Resources.Load<ResourceCollection>("ResourceCollection");
            var allResources = collection.GetAllResources();
            for (var i = 0; i < allResources.Count; i++)
            {
                var render = GameObject.Instantiate(Prefab, UIRoot);
                render.transform.localScale = new Vector3(1, 1, 1);
                render.Setup(allResources[i]);
                
                resourceRenderList.Add(render);
            }
        }
    }
}