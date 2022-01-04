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
    public class NewsController : BaseController
    {
        // GET: Admin/User
        BookStoreDbContext db = new BookStoreDbContext();
        public ActionResult Index()
        {
            IEnumerable<TinTuc> lstTinTuc;
            HttpResponseMessage reponse = GlobalVariables.WebAPIClient.GetAsync("TinTuc").Result;
            lstTinTuc = reponse.Content.ReadAsAsync<IEnumerable<TinTuc>>().Result;
            return View(lstTinTuc);
        }

        // Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new TinTuc());
        }

        [HttpPost]
        public ActionResult Create(TinTuc tt)
        {
            HttpResponseMessage reponse = GlobalVariables.WebAPIClient.PostAsJsonAsync("TinTuc", tt).Result;
            TempData["SuccessMessage"] = "Saved Successfully!";
            return RedirectToAction("Index");
        }

        // edit

        public ActionResult Edit(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebAPIClient.GetAsync("TinTuc/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<TinTuc>().Result);
        }

        [HttpPost]
        public ActionResult Edit(TinTuc tt)
        {
            //if (ModelState.IsValid)
            //{
            //    var dao = new NewsDao();
            //    var result = dao.Update(tt);
            //    if (result)
            //    {
            //        SetAlert("Sửa tin tức thành công", "success");
            //        return RedirectToAction("Index", "News");
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", "Cập nhật tin tức không thành công");
            //    }
            //}
            HttpResponseMessage reponse = GlobalVariables.WebAPIClient.PutAsJsonAsync("TinTuc/" + tt.MaTinTuc, tt).Result;
            return RedirectToAction("Index");
        }

        // delete acc
        //[HttpPost]
        //public JsonResult Delete(int id)
        //{
        //    bool result = false;

        //        TinTuc s = db.TinTucs.Where(x => x.MaTinTuc == id).SingleOrDefault();
        //        if (s != null)
        //        {
        //            new NewsDao().Delete(id);
        //            db.SaveChanges();
        //            result = true;
        //        }

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
        public ActionResult Delete(int id)
        {
            HttpResponseMessage reponse = GlobalVariables.WebAPIClient.DeleteAsync("TinTuc/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}