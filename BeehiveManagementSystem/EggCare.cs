using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    class EggCare : Bee
    {
        public EggCare(string assignedJob) : base(assignedJob)
        {
            Queen queen = new Queen("Queen");
        }

        private const float CARE_PROGRESS_PER_SHIFT = 0.15f;

        // amount of honey used per shift worked
        protected override float CostPerShift
        {
            get
            {
                return 1.35f;
            }
        }

        protected override void DoJob()
        {
            queen.CareForEggs(CARE_PROGRESS_PER_SHIFT);
        }
    }
}
