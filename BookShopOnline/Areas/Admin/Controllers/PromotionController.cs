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
    public class PromotionController : BaseController
    {
        // GET: Admin/User
        BookStoreDbContext db = new BookStoreDbContext();
        public ActionResult Index()
        {
            IEnumerable<KhuyenMai> lstKhuyenMai;
            HttpResponseMessage reponse = GlobalVariables.WebAPIClient.GetAsync("KhuyenMai").Result;
            lstKhuyenMai = reponse.Content.ReadAsAsync<IEnumerable<KhuyenMai>>().Result;
            return View(lstKhuyenMai);
        }

        // Create

        public ActionResult Create()
        {
            return View(new KhuyenMai());
        }

        [HttpPost]
        public ActionResult Create(KhuyenMai tt)
        {
            HttpResponseMessage reponse = GlobalVariables.WebAPIClient.PostAsJsonAsync("KhuyenMai", tt).Result;
            TempData["SuccessMessage"] = "Saved Successfully!";
            return RedirectToAction("Index");
        }

        // edit

        public ActionResult Edit(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebAPIClient.GetAsync("KhuyenMai/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<KhuyenMai>().Result);
        }

        [HttpPost]
        public ActionResult Edit(KhuyenMai km)
        {
            HttpResponseMessage reponse = GlobalVariables.WebAPIClient.PutAsJsonAsync("KhuyenMai/" + km.MaKM, km).Result;
            return RedirectToAction("Index");
        }

        // delete acc
        public ActionResult Delete(int id)
        {
            HttpResponseMessage reponse = GlobalVariables.WebAPIClient.DeleteAsync("KhuyenMai/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}