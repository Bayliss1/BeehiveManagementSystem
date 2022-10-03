using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    class HoneyManufacturer : Bee
    {
        public HoneyManufacturer(string assignedJob) : base(assignedJob) { /* uses base class constructor */ }

        private const float NECTAR_PROCESSED_PER_SHIFT = 33.15f;

        // amount of honey used per shift worked
        protected override float CostPerShift
        {
            get
            {
                return 1.7f;
            }
        }

        protected override void DoJob()
        {
            HoneyVault.ConvertNectarToHoney(NECTAR_PROCESSED_PER_SHIFT);
        }
    }
}
