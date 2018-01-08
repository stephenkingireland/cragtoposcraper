using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebController.Code._27Crags
{
    public class _27CragsProperties
    {
        public string SiteUrl { get => "https://27crags.com/"; }




        public string LoginButtonTop { get => throw new NotImplementedException(); }

        public string LoginButtonMain { get => throw new NotImplementedException(); }

        public string UserNameField { get => throw new NotImplementedException(); }

        public string PasswordField { get => throw new NotImplementedException(); }

        public string ClimbNameSelector { get => ".route-block a"; }

        public string CragPaginatorSelector { get => ".pagination"; }


        public string GetCragUrl(String cragName)
        {
            return String.Format("https://27crags.com/crags/{0}/routelist", cragName).Replace(" ", "-");
        }

        public string GetClimbUrl(String climbName)
        {
            return String.Format("https://27crags.com/crags/cloghoge/routes/{0}", climbName).Replace(" ", "-");
        }

    }
}
