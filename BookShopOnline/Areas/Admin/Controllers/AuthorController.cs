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
    public class AuthorController : BaseController
    {
        // GET: Admin/User
        BookStoreDbContext db = new BookStoreDbContext();

        public ActionResult Index()
        {
            IEnumerable<TacGia> lstTG;
            HttpResponseMessage reponse = GlobalVariables.WebAPIClient.GetAsync("TacGia").Result;
            lstTG= reponse.Content.ReadAsAsync<IEnumerable<TacGia>>().Result;
            return View(lstTG);
        }

        // Create
        public ActionResult Create()
        {
            return View(new TacGia());
        }

        [HttpPost]
        public ActionResult Create(TacGia tt)
        {
            //if (ModelState.IsValid)
            //{
            //    var dao = new AuthorDao();
            //    long id = dao.Insert(tt);
            //    if (id > 0)
            //    {
            //        SetAlert("Thêm tác giả thành công", "success");
            //        return RedirectToAction("Index", "Author");
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", "Thêm tác giả không thành công");
            //    }
            //}
            HttpResponseMessage reponse = GlobalVariables.WebAPIClient.PostAsJsonAsync("TacGia", tt).Result;
            TempData["SuccessMessage"] = "Saved Successfully!";
            return RedirectToAction("Index");
        }

        // edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            //var xb = new AuthorDao().ViewDetail(id);
            //return View(xb);
            HttpResponseMessage response = GlobalVariables.WebAPIClient.GetAsync("TacGia/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<TacGia>().Result);
        }

        [HttpPost]
        public ActionResult Edit(TacGia xb)
        {
            //if (ModelState.IsValid)
            //{
            //    var dao = new AuthorDao();
            //    var result = dao.Update(xb);
            //    if (result)
            //    {
            //        SetAlert("Sửa thông tin tác giả thành công", "success");
            //        return RedirectToAction("Index", "Author");
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", "Cập nhật thông tin tác giả không thành công");
            //    }
            //}
            HttpResponseMessage reponse = GlobalVariables.WebAPIClient.PutAsJsonAsync("TacGia/" + xb.MaTG, xb).Result;
            return RedirectToAction("Index");
        }

        // delete acc
        //[HttpPost]
        //public JsonResult Delete(int id)
        //{
        //    bool result = false;
        //    Sach ct = db.Saches.Where(x => x.MaTG == id).FirstOrDefault();
        //    if (ct == null)
        //    {
        //        TacGia s = db.TacGias.Where(x => x.MaTG == id).FirstOrDefault();
        //        if (s != null)
        //        {
        //            new AuthorDao().Delete(id);
        //            db.SaveChanges();
        //            result = true;
        //        }
        //    }
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
        public ActionResult Delete(int id)
        {
            HttpResponseMessage reponse = GlobalVariables.WebAPIClient.DeleteAsync("TacGia/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}