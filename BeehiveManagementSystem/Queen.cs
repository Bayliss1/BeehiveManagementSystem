using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    class Queen : Bee
    {
        // constructor, assigns a bee to each job automatically
        public Queen(string assignedJob) : base(assignedJob) 
        {
            AssignBee("Nectar Collector");
            AssignBee("Honey Manufacturer");
            AssignBee("EggCare");
        }

        // fields
        public Bee[] workers = new Bee[0];
        private float unassignedWorkers = 3f;
        private float eggs = 0;
        private const float EGGS_PER_SHIFT = 0.45f;
        private const float HONEY_PER_UNASSIGNED_WORKER = 0f;
        private int nectarCollectorAmount = 0;
        private int honeyManufacturerAmount = 0;
        private int eggCareAmount = 0;

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
        /// <param name="Job">The requested job to assign to the new worker.</param>
        public void AssignBee(string job)
        {
            if (unassignedWorkers >= 1)
            {
                unassignedWorkers--;
                Array.Resize(ref workers, workers.Length + 1);
                switch (job)
                {
                    case "Nectar Collector":
                        workers[workers.Length - 1] = new NectarCollector();
                        nectarCollectorAmount++;
                        break;
                    case "Honey Manufacturer":
                        workers[workers.Length - 1] = new HoneyManufacturer();
                        honeyManufacturerAmount++;
                        break;
                    case "EggCare":
                        workers[workers.Length - 1] = new EggCare(this);
                        eggCareAmount++;
                        break;
                    default:
                        return;
                }
            }
            UpdateStatusReport();
        }
        
        /// <summary>
        /// Lays some eggs, demands the worker beers to do their next shift, takes some honey for the unassigned workers, updates the status report.
        /// </summary>
        protected override void DoJob()
        {
            eggs += EGGS_PER_SHIFT;
            
            foreach (Bee bee in workers)
            {
                bee.WorkTheNextShift();
            }

            HoneyVault.ConsumeHoney(HONEY_PER_UNASSIGNED_WORKER * unassignedWorkers);

            UpdateStatusReport();
        }


        public string StatusReport { get; private set; }
        /// <summary>
        /// Updates status report with most up to date data.
        /// </summary>
        private void UpdateStatusReport()
        {
            string eggsAmount = Convert.ToString(eggs);
            string unassignedWorkersAmount = Convert.ToString(unassignedWorkers);
            StatusReport = HoneyVault.StatusReport + "\n" + "Egg count: " + eggsAmount + "\n" + "Unassigned workers: " + unassignedWorkersAmount + "\n" + nectarCollectorAmount + " Nectar Collector bees" + "\n" + honeyManufacturerAmount + " Honey Manufacturer bees" + "\n" + eggCareAmount + " Egg Care bees" + "\n" + "TOTAL WORKERS: " + workers.Length;
        }

        /// <summary>
        /// If there are enough eggs, it converts them to unassignedWorkers.
        /// </summary>
        public void CareForEggs(float eggsToConvert)
        {
            if (eggs >= eggsToConvert) unassignedWorkers += eggs - eggsToConvert;
        }
    }
}
