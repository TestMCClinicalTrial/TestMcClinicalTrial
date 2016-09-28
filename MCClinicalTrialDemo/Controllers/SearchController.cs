using MCClinicalTrialDemo.Models;
using MultiChainLib;
using MultiChainLib.Helper;
using MultiChainLib.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCClinicalTrialDemo.Controllers
{
    public class SearchController : BaseController
    {
        //
        // GET: /Search/
        public ActionResult Index()
        {
            MultiChainClient mcClient = GetMultiChainClient();
            var info = mcClient.ListStreamItems("TrialStream");
            info.AssertOk();
            return View(info);
        }

        //
        // GET: /Search/Details/5
        public ActionResult Details(string transactionId)
        {
            return View();
        }

        //
        // GET: /Search/Details/5
        public ActionResult Download(string streamStr)
        {
            var stream = JsonConvert.DeserializeObject<StreamResponse>(streamStr);
            var downloadViewModel = new DownloadViewModel()
            {
                DownloadDate = DateTime.UtcNow,
                ResearcherName = "TestUser1", //TODO: Get logged in Researcher name from UserContext
                TrialKey = stream.Key,
            };
            var trialModel = GetTrialModel(stream.Publishers[0], downloadViewModel);

            //TODO: Uncomment once Download stream is created
            //MultiChainClient mcClient = GetMultiChainClient();
            //var info = mcClient.PublishStream("TrialDownloadStream", trialModel.TrialKey, trialModel.TrialData);
            //info.AssertOk();

            //var ms = new System.IO.MemoryStream();
            var bytes = System.Text.Encoding.UTF8.GetBytes(streamStr);
            //ms.Write(bytes, 0, bytes.Count());
            return File(bytes, "application/json", stream.Publishers[0] + "_ResearchDetails.txt");
        }

        private TrialModel GetTrialModel(string key, DownloadViewModel downloadViewModel)
        {
            //Populate from collection
            //a. Generate Json without trial-key
            string jsonDownloadModel = JsonConvert.SerializeObject(downloadViewModel);
            //b. Generate Hex from json as source
            string hexString = Utility.HexadecimalEncoding.ToHexString(jsonDownloadModel);

            return new TrialModel()
            {
                TrialKey = key,
                TrialData = hexString
            };
        }

        //
        // GET: /Search/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Search/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Search/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Search/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Search/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Search/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
