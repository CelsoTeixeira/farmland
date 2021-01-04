using System.Collections.Generic;
using UnityEngine;

namespace Farmland.Controller
{
    [CreateAssetMenu(menuName = "Farmland/Create GameSetup", fileName = "GameSetup", order = 0)]
    public class GameSetup : ScriptableObject
    {
        public List<GameSetupValues> InitialSetup;

        public List<GameSetupValues> GetInitialValues()
        {
            return InitialSetup;
        }
    }
}