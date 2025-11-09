using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfindingSimulator
{
    public class Risk
    {
        private float val;

        public Risk(float val)
        {
            this.val = val;
        }

        public float RiskAtTime(float time)
        {
            time = (time * Convert.ToSingle(Math.PI)) / 180;
            return Math.Abs(Convert.ToSingle(Math.Sin(Convert.ToDouble(time))));
        }

        public float RiskVal
        {
            get { return this.val; }
            set { this.val = value; }
        }
    }
}
