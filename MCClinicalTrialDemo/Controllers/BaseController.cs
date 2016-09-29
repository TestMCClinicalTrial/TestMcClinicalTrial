using MultiChainLib;
using System;
using System.Configuration;
using System.Web.Mvc;

namespace MCClinicalTrialDemo.Controllers
{
    public class BaseController : Controller
    {
        private MultiChainClient mcClient = null;
        protected MultiChainClient GetMultiChainClient(string chainName = "")
        {
            if (string.IsNullOrEmpty(chainName)) {
                chainName = ConfigurationManager.AppSettings["TrialRepository"];
            }
            var multiChainIP = ConfigurationManager.AppSettings["MultiChainIPAddress"];
            var multiChainPort = Convert.ToInt32(ConfigurationManager.AppSettings["MultiChainPort"]);
            var multiChainUsername = ConfigurationManager.AppSettings["MultiChainUsername"];
            var multiChainPassword = ConfigurationManager.AppSettings["MultiChainPassword"];
            mcClient = new MultiChainClient(multiChainIP, multiChainPort, false, multiChainUsername, multiChainPassword, chainName);
            return mcClient;
        }

        protected string GetTrialStream()
        {
            return ConfigurationManager.AppSettings["TrialStream"];
        }
        protected string GetTrialDownloadStream()
        {
            return ConfigurationManager.AppSettings["TrialDownloadStream"];
        }

    }
}