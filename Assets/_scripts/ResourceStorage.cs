using System;
using System.Collections.Generic;
using System.Text;
using Farmland.Controller;
using UnityEngine;

namespace Farmland.Resource
{
    
    [Serializable]
    public class ResourceStorage
    {
        private Dictionary<string, float> resourceStorage;

        public event Action<string, float> OnResourceUpdate; 
        
        public ResourceStorage(List<ResourceDetails> resources)
        {
            resourceStorage = new Dictionary<string, float>();
            
            foreach (var resource in resources)
            {
                resourceStorage.Add(resource.Name, 0);
            }
        }
        
        public void InitialSetup(List<GameSetupValues> initialValues)
        {
            for (var i = 0; i < initialValues.Count; i++)
            {
                if (resourceStorage.ContainsKey(initialValues[i].Name) == false)
                {
                    Debug.LogErrorFormat("Initial value contains key that have not been initialized! - {0}",  initialValues[i].Name );
                    continue;
                }

                Debug.Log(initialValues[i].Name);
                
                resourceStorage[initialValues[i].Name] = initialValues[i].Value;
                OnResourceUpdate?.Invoke(initialValues[i].Name, resourceStorage[initialValues[i].Name]);
            }
        }

        public void UpdateStorageItem(string resourceName, float amountToChange)
        {
            if (resourceStorage.ContainsKey(resourceName) == false)
            {
                Debug.LogErrorFormat("Initial value contains key that have not been initialized! - {0}", resourceName);
                return;
            }
            
            var newResourceValue = resourceStorage[resourceName];
            newResourceValue += amountToChange;
            newResourceValue = Mathf.Clamp(newResourceValue, 0, newResourceValue);
            resourceStorage[resourceName] = newResourceValue;
            
            Debug.LogFormat("Updating Resource Storage - {0} - {1}", resourceName, newResourceValue);
            
            OnResourceUpdate?.Invoke(resourceName, resourceStorage[resourceName]);
        }

        public float GetResourceAmount(string resource)
        {
            return resourceStorage[resource];
        }
        
        public void DebugStorage()
        {
            var builder = new StringBuilder();
            builder.Append("Storage").AppendLine();

            foreach (var detail in resourceStorage)
            {
                builder.Append(detail.Key).Append(": ").Append(detail.Value).AppendLine();
            }
            
            Debug.Log(builder.ToString());
        }
    }
}