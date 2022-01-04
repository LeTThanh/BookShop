using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BookShopOnline.Areas.Admin.Controllers
{
    public class PublisherController : BaseController
    {
        // GET: Admin/User
        BookStoreDbContext db = new BookStoreDbContext();
        public ActionResult Index()
        {
            IEnumerable<NhaXB> lstNhaXB;
            HttpResponseMessage reponse = GlobalVariables.WebAPIClient.GetAsync("NhaXB").Result;
            lstNhaXB = reponse.Content.ReadAsAsync<IEnumerable<NhaXB>>().Result;
            return View(lstNhaXB);
        }

        // Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new NhaXB());
        }

        [HttpPost]
        public ActionResult Create(NhaXB tt)
        {
             HttpResponseMessage reponse = GlobalVariables.WebAPIClient.PostAsJsonAsync("NhaXB", tt).Result;
            TempData["SuccessMessage"] = "Saved Successfully!";
            return RedirectToAction("Index");
        }

        // edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebAPIClient.GetAsync("NhaXB/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<NhaXB>().Result);
        }

        [HttpPost]
        public ActionResult Edit(NhaXB xb)
        {
            HttpResponseMessage reponse = GlobalVariables.WebAPIClient.PutAsJsonAsync("NhaXB/" + xb.MaNXB, xb).Result;
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage reponse = GlobalVariables.WebAPIClient.DeleteAsync("NhaXB/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}