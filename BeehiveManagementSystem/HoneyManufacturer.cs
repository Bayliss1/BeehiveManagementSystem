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

        // amount of honey used per shift worked
        protected override float CostPerShift
        {
            get
            {
                return 1.7f;
            }
        }
    }
}
