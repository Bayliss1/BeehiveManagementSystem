﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    class NectarCollector : Bee
    {
        public NectarCollector(string assignedJob) : base(assignedJob) { /* uses base class constructor */ }

        private const float NECTAR_COLLECTED_PER_SHIFT = 33.15f;

        // amount of honey used per shift worked
        protected override float CostPerShift
        {
            get
            {
                return 1.95f;
            }
        }

        protected override void DoJob()
        {
            HoneyVault.CollectNectar(NECTAR_COLLECTED_PER_SHIFT);
        }
    }
}
