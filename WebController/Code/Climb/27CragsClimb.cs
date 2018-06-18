using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebController.Code.Climb
{
    public class _27CragsClimb
    {
        public string name      { get; set; }
        public string grade     { get; set; }
        public string type   { get; set; }
        public string sector { get; set; }
    }

    public enum ClimbType
    {
        Unknown = 0,
        Boulder = 1,
        Trad = 2,
        Sport = 3
    }
}
