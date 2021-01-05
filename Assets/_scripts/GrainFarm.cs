using System;
using System.Text;
using Farmland.Controller;
using UnityEngine;

namespace Farmland.Terrain
{
    public class GrainFarm : Building, IProduction
    {
        public ProductionDetails Production;
        private float currentTicks;

        private GameController controller;

        private void Awake()
        {
            controller = GameObject.FindObjectOfType<GameController>();
        }

        public void Produce(float deltaTime)
        {
            
            
            currentTicks += deltaTime;

            if (currentTicks >= Production.ProductionTicks)
            {
                Debug.Log("We have spent enough time for production!");
                controller.ResourceStorage.UpdateStorageItem(Production.ResourceName, Production.OutputAmount);
                currentTicks = 0;
            }
        }

        public void DebugProduction()
        {
            var builder = new StringBuilder();
            builder.Append("Grain Farm - Production").AppendLine();
            builder.Append("Ticks: ").Append(currentTicks).Append(" / ").Append(Production.ProductionTicks)
                .AppendLine();
            builder.Append("Output: ").Append(Production.OutputAmount).AppendLine();
            
            Debug.Log(builder.ToString());
        }
    }
}