using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    class Queen : Bee
    {
        public Queen(string assignedJob) : base(assignedJob) { /* uses base class constructor */ }

        public Bee[] workers = new Bee[1];
        private float unassignedWorkers;
        private float eggs;
        private const float EGGS_PER_SHIFT = 0.45f;
        private const float HONEY_PER_UNASSIGNED_WORKER = 0f;

        // amount of honey used per shift worked
        protected override float CostPerShift
        {
            get
            {
                return 2.15f;
            }
        }

        /// <summary>
        /// If there is an unassigned worker, it creates a new object of the chosen bee subclass inside worker array.
        /// </summary>
        /// <param name="requestedJob">The requested job to assign to the new worker.</param>
        public void AssignBee(string requestedJob)
        {
            if (unassignedWorkers >= 1)
            {
                unassignedWorkers--;
                Array.Resize(ref workers, workers.Length + 1);
                switch (requestedJob)
                {
                    case "Nectar Collector":
                        workers[workers.Length - 1] = new NectarCollector(requestedJob);
                        break;
                    case "Honey Manufacturer":
                        workers[workers.Length - 1] = new HoneyManufacturer(requestedJob);
                        break;
                    case "EggCare":
                        workers[workers.Length - 1] = new EggCare(requestedJob);
                        break;
                    default:
                        return;
                }
            }
        }
                
        protected override void DoJob()
        {
            eggs += EGGS_PER_SHIFT;
            
            foreach (Bee bee in workers)
            {
                bee.WorkTheNextShift();
            }

            HoneyVault.ConsumeHoney(HONEY_PER_UNASSIGNED_WORKER * unassignedWorkers);
        }

        /// <summary>
        /// Converts eggs to unassignedWorkers and then resets eggs to 0
        /// </summary>
        public void CareForEggs()
        {
            unassignedWorkers += eggs;
            eggs = 0;
        }
    }
}
