using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    static class HoneyVault
    {
        private static float honey = 25f;
        private static float nectar = 100f;

        private const float NECTAR_CONVERSION_RATIO = 0.19f;
        private const float LOW_LEVEL_WARNING = 10f;

        private static string statusReport;
        public static string StatusReport
        {
            get
            {
                string honeyAmount = Convert.ToString(honey);
                string nectarAmount = Convert.ToString(nectar);

                // adds warning if honey levels are low
                string honeyWarning;
                if (honey < LOW_LEVEL_WARNING)
                {
                    honeyWarning = "LOW HONEY - ADD A HONEY MANUFACTURER";
                }
                else honeyWarning = "No honey warnings";

                // adds warning if nectar levels are low
                string nectarWarning;
                if (nectar < LOW_LEVEL_WARNING)
                {
                    nectarWarning = "LOW NECTAR - ADD A NECTAR COLLECTOR";
                }
                else nectarWarning = "No nectar warnings";

                // returns the 4 strings above combined into one string, with new lines seperating them
                return statusReport = honeyAmount + "\n" + nectarAmount + "\n" + honeyWarning + "\n" + nectarWarning;
            }
        }

        public static void CollectNectar(float amount)
        {
            if (amount > 0) { nectar += amount; }
            else return;
        }

        public static void ConvertNectarToHoney(float amount)
        {
            if (amount <= nectar)
            {
                honey += (nectar - amount) * NECTAR_CONVERSION_RATIO;
            }
            else
            {
                nectar = amount;
                honey += (nectar - amount) * NECTAR_CONVERSION_RATIO;
            }
        }

        public static bool ConsumeHoney(float amount)
        {
            if (amount <= honey)
            {
                honey -= amount;
                return true;
            }
            else { return false; }
        }
    }
}
