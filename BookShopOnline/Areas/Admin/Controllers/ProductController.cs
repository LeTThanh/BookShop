using Model.DAO;
using Model.EF;
using System;
using PagedList;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace BookShopOnline.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        BookStoreDbContext db = new BookStoreDbContext();

        // GET: Admin/User

        public ActionResult Index()
        {
            IEnumerable<Sach> lstSach;
            HttpResponseMessage reponse = GlobalVariables.WebAPIClient.GetAsync("Sach").Result;
            lstSach = reponse.Content.ReadAsAsync<IEnumerable<Sach>>().Result;
            return View(lstSach);
        }

        // Create
        public ActionResult Create()
        {
            SetViewBag();
            return View(new Sach());
        }
        public void SetViewBag(long? selectedId = null)
        {
            var dao1 = new AuthorDao();
            ViewBag.MaTG = new SelectList(dao1.ListAll(), "MaTG", "TenTG", selectedId);
            var dao2 = new CategoryDao();
            ViewBag.MaDM = new SelectList(dao2.ListAll(), "MaDM", "TenDM", selectedId);
            var dao3 = new PublisherDao();
            ViewBag.MaNXB = new SelectList(dao3.ListAll(), "MaNXB", "TenNXB", selectedId);
            var dao4 = new PromotionDao();
            ViewBag.MaKM = new SelectList(dao4.ListAl(), "MaKM", "MaKM", selectedId);

        }
        [HttpPost]
        public ActionResult Create(Sach tt)
        {
            //    if (ModelState.IsValid)
            //    {
            //        var dao = new ProductDao();
            //        long id = dao.Insert(tt);
            //        if (id > 0)
            //        {
            //            SetAlert("Thêm sản phẩm thành công", "success");
            //            return RedirectToAction("Index", "Product");
            //        }
            //        else
            //        {
            //            ModelState.AddModelError("", "Thêm sản phẩm không thành công");
            //        }
            //    }

            SetViewBag();
            HttpResponseMessage reponse = GlobalVariables.WebAPIClient.PostAsJsonAsync("Sach", tt).Result;
            TempData["SuccessMessage"] = "Saved Successfully!";
            return RedirectToAction("Index");
        }

        // edit
        public ActionResult Edit(int id)
        {
            SetViewBag();
            HttpResponseMessage response = GlobalVariables.WebAPIClient.GetAsync("Sach/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<Sach>().Result);
        }

        [HttpPost]
        public ActionResult Edit(Sach tt)
        {
            //if (ModelState.IsValid)
            //{
            //    var dao = new ProductDao();
            //    var result = dao.Update(tt);
            //    if (result)
            //    {
            //        SetAlert("Cập nhật thông tin sản phẩm thành công", "success");
            //        return RedirectToAction("Index", "Product");
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", "Cập nhật thông tin sản phẩm không thành công");
            //    }
            //}
            SetViewBag();
            HttpResponseMessage reponse = GlobalVariables.WebAPIClient.PutAsJsonAsync("Sach/" + tt.MaSach, tt).Result;
            return RedirectToAction("Index");
        }

        // delete
        //[HttpPost]
        //public JsonResult Delete(int id)
        //{
        //    bool result = false;
        //    ChiTietDH ct = db.ChiTietDHs.Where(x => x.MaSach == id).SingleOrDefault();
        //    if(ct == null)
        //    {
        //        Sach s = db.Saches.Where(x => x.MaSach == id).SingleOrDefault();
        //        if (s != null)
        //        {
        //            new ProductDao().Delete(id);
        //            db.SaveChanges();
        //            result = true;
        //        }
        //    }            
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult Delete(int id)
        {
            HttpResponseMessage reponse = GlobalVariables.WebAPIClient.DeleteAsync("Sach/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}