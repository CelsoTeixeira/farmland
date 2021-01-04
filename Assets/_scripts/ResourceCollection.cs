using System;
using System.Collections.Generic;
using UnityEngine;

namespace Farmland.Resource
{
    [CreateAssetMenu(menuName = "Farmland/Create ResourceCollection", fileName = "ResourceCollection", order = 0)]
    public class ResourceCollection : ScriptableObject
    {
        public List<ResourceDetails> Resources;

        public ResourceDetails GetResourceByName(string name)
        {
            return Resources.Find(i => string.Equals(i.Name, name, StringComparison.CurrentCultureIgnoreCase));
        }

        public List<ResourceDetails> GetAllResources()
        {
            return Resources;
        }
    }
}