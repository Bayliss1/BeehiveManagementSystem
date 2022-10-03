using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    class Bee
    {
        // property storing job, assigned using constructor
        public string Job { get; }
        public Bee(string assignedJob)
        {
            Job = assignedJob;
        }

        // subclasses set their CostPerShift as it differs for each, so it is set to read-only in this base class
        protected virtual float CostPerShift { get; }

        /// <summary>
        /// Checks whether there is enough honey in the vault for the bee's CostPerShift, if there is then it calls DoJob, if not then it returns.
        /// </summary>
        public void WorkTheNextShift()
        {
            if (HoneyVault.ConsumeHoney(CostPerShift)) DoJob();
            else { return; }
        }

        protected virtual void DoJob()
        {
            // subclasses will override this method
        }
    }
}
