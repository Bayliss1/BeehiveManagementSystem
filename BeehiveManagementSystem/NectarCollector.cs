using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    class NectarCollector : Bee
    {
        private const float NECTAR_COLLECTED_PER_SHIFT = 33.15f;
        protected override float CostPerShift
        {
            get
            {
                return 1.95f;
            }
        }

        public NectarCollector(string job = "Nectar Collector") : base("Nectar Collector") { }

        protected override void DoJob()
        {
            HoneyVault.CollectNectar(NECTAR_COLLECTED_PER_SHIFT);
        }
    }
}
