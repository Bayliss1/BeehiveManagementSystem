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
        public void AssignBee(int requestedJob)
        {
            if (unassignedWorkers >= 1)
            {
                unassignedWorkers--;
                Array.Resize(ref workers, workers.Length + 1);
                switch (requestedJob)
                {
                    case '0':
                        string assignedJob0 = "NectarCollector";
                        workers[workers.Length - 1] = new NectarCollector(assignedJob0);
                        break;
                    case '1':
                        string assignedJob1 = "HoneyManufacturer";
                        workers[workers.Length - 1] = new HoneyManufacturer(assignedJob1);
                        break;
                    case '2':
                        string assignedJob2 = "EggCare";
                        workers[workers.Length - 1] = new EggCare(assignedJob2);
                        break;
                    default:
                        return;
                }
            }
        }

        private void DoJob()
        {
            eggs += EGGS_PER_SHIFT;
            
            foreach (Bee worker in workers)
            {
                // I have absolutely no clue how to make this work
            }
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
