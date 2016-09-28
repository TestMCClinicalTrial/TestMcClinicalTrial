using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCClinicalTrialDemo.Controllers
{
    public class DownloadController : BaseController
    {
        // GET: Download
        public ActionResult Index()
        {
            var publishersList = GetMultiChainClient().ListStreamKeys("TrialStream");
            //var publishersList = GetMultiChainClient().ListStreamKeys("TrialDownloadStream");
            return View(publishersList);
        }
        
        public ActionResult Details(string publisherKey)
        {
            var client = GetMultiChainClient();
            var downloadDetails = client.ListStreamKeyItems("TrialStream", publisherKey);
            //var downloadDetails = client.ListStreamKeyItems("TrialDownloadStream", publisherKey);
            return PartialView(downloadDetails);
        }
    }
}