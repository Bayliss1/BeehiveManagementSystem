using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    class HoneyManufacturer : Bee
    {
        private const float NECTAR_PROCESSED_PER_SHIFT = 33.15f;
        protected override float CostPerShift
        {
            get
            {
                return 1.7f;
            }
        }

        public HoneyManufacturer(string job = "Honey Manufacturer") : base("Honey Manufacturer") { }

        protected override void DoJob()
        {
            HoneyVault.ConvertNectarToHoney(NECTAR_PROCESSED_PER_SHIFT);
        }
    }
}
