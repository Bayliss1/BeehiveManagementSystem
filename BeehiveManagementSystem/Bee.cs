﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    class Bee
    {
        // subclasses set their CostPerShift as it differs for each, so it is set to read-only in this base class
        protected virtual float CostPerShift { get; }

        // property storing jobs, assigned using constructor
        public string Job { get; }
        public Bee(string assignedJob)
        {
            Job = assignedJob;
        }

        /// <summary>
        /// Checks whether there is enough honey in the vault for the bee's CostPerShift, if there is then it calls DoJob, if not then it returns.
        /// </summary>
        public void WorkTheNextShift()
        {
            if (HoneyVault.ConsumeHoney(CostPerShift)) Dojob();
            else { return; }
        }

        protected virtual void Dojob()
        {
            // subclasses will override this method
        }
    }
}
