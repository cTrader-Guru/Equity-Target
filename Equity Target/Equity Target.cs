using System;
using System.Linq;
using cAlgo.API;
using cAlgo.API.Indicators;
using cAlgo.API.Internals;
using cAlgo.Indicators;

namespace cAlgo.Robots
{
    [Robot(TimeZone = TimeZones.UTC, AccessRights = AccessRights.None)]
    public class EquityTarget : Robot
    {

        [Parameter("$$$ Equity Target", Group = "Params", DefaultValue = 0, MinValue = 0, Step = 0.1)]
        public double EquityMoneyTarget { get; set; }

        protected override void OnStart()
        {

            if (EquityMoneyTarget <= Account.Equity) {

                Print("The entered Equity Target is lower than the nominal value of the Equity.");

                Stop();
                return;

            }

        }

        protected override void OnTick()
        {

            if (Account.Equity >= EquityMoneyTarget)
            {

                Position[] all = Positions.FindAll(null);

                foreach (Position position in all)
                {

                    position.Close();

                }

                Print("I closed all trades because I reached the equity Target and stopped the cBot");

                Stop();
                return;

            }

        }

        protected override void OnStop()
        {
            


        }

    }

}
