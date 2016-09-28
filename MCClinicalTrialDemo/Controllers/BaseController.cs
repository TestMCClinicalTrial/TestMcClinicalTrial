using MultiChainLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCClinicalTrialDemo.Controllers
{
    public class BaseController : Controller
    {
        private MultiChainClient mcClient = null;
        protected MultiChainClient GetMultiChainClient(string chainName = "")
        {
            if (string.IsNullOrEmpty(chainName)) {
                chainName = "TrialRepository";
            }
            mcClient = new MultiChainClient("54.234.132.18", 2766, false, "multichainrpc", "testmultichain", chainName);
            return mcClient;
        }
    }
}