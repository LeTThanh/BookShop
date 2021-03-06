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
    public class CategoryController : BaseController
    {
        // GET: Admin/User
        BookStoreDbContext db = new BookStoreDbContext();
        public ActionResult Index()
        {
            IEnumerable<DanhMucSP> lstDM;
            HttpResponseMessage reponse = GlobalVariables.WebAPIClient.GetAsync("DanhMucSP").Result;
            lstDM = reponse.Content.ReadAsAsync<IEnumerable<DanhMucSP>>().Result;
            return View(lstDM);
        }

        // Create

        public ActionResult Create()
        {
            return View(new DanhMucSP());
        }
        [HttpPost]
        public ActionResult Create(DanhMucSP tt)
        {
            //if (ModelState.IsValid)
            //{
            //    var dao = new CategoryDao();
            //    long id = dao.Insert(tt);
            //    if (id > 0)
            //    {
            //        SetAlert("Thêm danh mục sản phẩm thành công", "success");
            //        return RedirectToAction("Index", "Category");
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", "Thêm danh mục không thành công");
            //    }
            //}
            HttpResponseMessage reponse = GlobalVariables.WebAPIClient.PostAsJsonAsync("DanhMucSP", tt).Result;
            TempData["SuccessMessage"] = "Saved Successfully!";
            return RedirectToAction("Index");
        }

        // edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            //var xb = new CategoryDao().ViewDetail(id);
            HttpResponseMessage response = GlobalVariables.WebAPIClient.GetAsync("DanhMucSP/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<DanhMucSP>().Result);
        }

        [HttpPost]
        public ActionResult Edit(DanhMucSP xb)
        {
            //if (ModelState.IsValid)
            //{
            //    var dao = new CategoryDao();
            //    var result = dao.Update(xb);
            //    if (result)
            //    {
            //        SetAlert("Sửa thông tin danh mục thành công", "success");
            //        return RedirectToAction("Index", "Category");
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", "Cập nhật thông tin danh mục không thành công");
            //    }
            //}
            HttpResponseMessage reponse = GlobalVariables.WebAPIClient.PutAsJsonAsync("DanhMucSP/" + xb.MaDM, xb).Result;
            return RedirectToAction("Index");
        }

        // delete acc
        //[HttpDelete]
        //public ActionResult Delete(int id)
        //{
        //    new CategoryDao().Delete(id);
        //    return RedirectToAction("Index");
        //}
        //[HttpPost]
        //public JsonResult Delete(int id)
        //{
        //    bool result = false;
        //    Sach ct = db.Saches.Where(x => x.MaDM == id).FirstOrDefault();
        //    if (ct == null)
        //    {
        //        DanhMucSP s = db.DanhMucSPs.Where(x => x.MaDM == id).SingleOrDefault();
        //        if (s != null)
        //        {
        //            new CategoryDao().Delete(id);
        //            db.SaveChanges();
        //            result = true;
        //        }
        //    }
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
        public ActionResult Delete(int id)
        {
            HttpResponseMessage reponse = GlobalVariables.WebAPIClient.DeleteAsync("DanhMucSP/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}