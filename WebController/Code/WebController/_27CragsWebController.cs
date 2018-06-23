using System.Collections.Generic;
using WebController.Code._27Crags;
using WebController.Code.Window;
using System.Linq;
using OpenQA.Selenium;
using System;
using WebController.Scripts;

namespace WebController.Code
{
    public class _27CragsWebController : WebControllerBase
    {
        _27CragsProperties properties = new _27CragsProperties();
        ScriptManager scriptManager = new ScriptManager();

        public _27CragsWebController(WindowBase windowBase) : base(windowBase)
        {
        }

        public void Cleanup()
        {
            window.Close();
        }

        public void GotoCragPage(string cragName)
        {
            window.GoTo(new WindowProperty() { Pattern = properties.GetCragUrl(cragName) });
        }

        public IEnumerable<Climb._27CragsCrag> GetCrags()
        {

            var crags =  ScrapeGragsByCountry();

            var areaCrags = ScrapeCragsByArea();


            crags = crags.Concat(areaCrags);

            //Removing any duplicates
            crags = crags.GroupBy(x => x.name).Select(x => x.FirstOrDefault()).ToList();

            return crags;

        }

        private IEnumerable<Climb._27CragsCrag> ScrapeCragsByArea()
        {
            window.GoTo(new WindowProperty() { Pattern = properties.GetAreaUrl("NorthIre") });

            var rawData = new List<Object>();

            while(rawData.Count() == 0)
            {
                rawData = window.RunJS<IEnumerable<Object>>(scriptManager.GetScript("_27CragsAreaScraper")).ToList();
            }


            return ConvertToCragObject( rawData);
        }

        private IEnumerable<Climb._27CragsCrag> ScrapeGragsByCountry()
        {
            var crags = new List<Climb._27CragsCrag>();
            var run = true;
            var count = 1;

            do
            {
                window.GoTo(new WindowProperty() { Pattern = properties.GetCragListUrl("Ireland", count) });

                var rawData = window.RunJS<IEnumerable<Object>>(scriptManager.GetScript("_27CragsCragsScraper"));

                crags.AddRange(ConvertToCragObject(rawData));

                if (rawData.Count() == 0)
                {
                    run = false;
                }

                count++;
            } while (run);


            return crags;
        }

        private IEnumerable<Climb._27CragsCrag> ConvertToCragObject(IEnumerable<object> rawData)
        {
            return
                                 rawData.Select(obj => new Climb._27CragsCrag
                                 {
                                     name = ((string)(obj as IDictionary<String, Object>)["name"]).Trim(),
                                     url = ((string)(obj as IDictionary<String, Object>)["url"]).Trim().Replace("/crags/", "")
                                 });
                           
        }

        public IEnumerable<Climb._27CragsClimb> GetClimbsOnPage()
        {

            var climbs = window.RunJS<IEnumerable<Object>>(scriptManager.GetScript("_27CragsClimbsScraper"));


            return climbs.Select(obj => new Climb._27CragsClimb
            {
                name = ((string)(obj as IDictionary<String,Object>)["name"]).Trim(),
                grade = ((string)(obj as IDictionary<String, Object>)["grade"]).Trim(),
                sector = ((string)(obj as IDictionary<String, Object>)["sector"]).Trim(),
                type = ((string)(obj as IDictionary<String, Object>)["type"]).Trim()

            });
        }
    }

}
