using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebController.Code.Climb
{
    public class _27CragsClimb
    {
        public string Name      { get; set; }
        public string Grade     { get; set; }
        public string Type   { get; set; }
        public string Sector { get; internal set; }
    }

    public enum ClimbType
    {
        Unknown = 0,
        Boulder = 1,
        Trad = 2,
        Sport = 3
    }
}
