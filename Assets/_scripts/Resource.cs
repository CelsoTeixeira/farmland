using System;
using System.Collections.Generic;
using UnityEngine;

namespace Farmland.Resource
{
    [Serializable]
    public struct Resource
    {
        public string Name;
        public Sprite Icon;
    }


    [CreateAssetMenu(menuName = "Farmland/Create ResourceCollection", fileName = "ResourceCollection", order = 0)]
    public class ResourceCollection : ScriptableObject
    {
        public List<Resource> Resources;

        public Resource GetResourceByName(string name)
        {
            return Resources.Find(i => string.Equals(i.Name, name, StringComparison.CurrentCultureIgnoreCase));
        }

        public List<Resource> GetAllResources()
        {
            return Resources;
        }
    }
}