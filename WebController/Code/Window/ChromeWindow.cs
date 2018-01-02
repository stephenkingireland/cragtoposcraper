using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebController.Code.Window
{
    public class ChromeWindow : WindowBase
    {

        public ChromeWindow()
        {
            base.driver = new ChromeDriver();
        }


    }
}
