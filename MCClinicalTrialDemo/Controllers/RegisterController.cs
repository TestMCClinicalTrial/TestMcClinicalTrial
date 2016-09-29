using MCClinicalTrialDemo.Models;
using MultiChainLib;
using MultiChainLib.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MCClinicalTrialDemo.Controllers
{
    public class RegisterController : BaseController
    {
        //
        // GET: /Register/
        public ActionResult Index()
        {
            return View("Index");
        }

        //
        // GET: /Register/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Register/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Register/Create
        [HttpPost]
        public ActionResult Create(TrialViewModel trialViewModel)
        {
            TrialModel trialModel = new TrialModel();
            try
            {
                string fileRelativePath = "~/files/" + trialViewModel.TrialKey + "_" + Path.GetFileName(trialViewModel.Document.FileName);
                string path = Path.Combine(Server.MapPath(fileRelativePath));
                trialViewModel.DocumentUrl = fileRelativePath;
                trialViewModel.DocumentHash = Utility.GetHash(trialViewModel.Document.InputStream);
                trialViewModel.Document.SaveAs(path);
                trialViewModel.Document = null;

                //populate trial-model by trial-view-model
                trialModel = GetTrialModel(trialViewModel);
                var info = GetMultiChainClient().PublishStream(GetTrialStream(), trialModel.TrialKey, trialModel.TrialData);
                info.AssertOk();

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.ToString();
                return View();
            }
        }

        private TrialModel GetTrialModel(TrialViewModel trialViewModel)
        {
            //Populate from collection
            //a. Generate Json without trial-key
            string jsonTrialModel = JsonConvert.SerializeObject(trialViewModel);
            //b. Generate Hex from json as source
            string hexString = Utility.HexadecimalEncoding.ToHexString(jsonTrialModel);

            return new TrialModel()
            {
                TrialKey = trialViewModel.TrialKey, // + "-" + Guid.NewGuid(),
                TrialData = hexString
            };
        }

        //
        // GET: /Register/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Register/Edit/5
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
        // GET: /Register/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Register/Delete/5
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
