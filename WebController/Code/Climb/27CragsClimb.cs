using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebController.Code.Climb
{
    class _27CragsClimb
    {
        public String Name      { get; set; }
        public String Grade     { get; set; }
        public ClimbType Type   { get; set; }

    }

    public enum ClimbType
    {
        Unknown = 0,
        Boulder = 1,
        Trad = 2,
        Sport = 3
    }
}
