using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BookShopOnline.Areas.Admin.Controllers
{
    public class OrderController : BaseController
    {
        // GET: Admin/Order
        BookStoreDbContext db = new BookStoreDbContext();
        public ActionResult Index()
        {
            IEnumerable<DonHang> lstDonHang;
            HttpResponseMessage reponse = GlobalVariables.WebAPIClient.GetAsync("DonHang").Result;
            lstDonHang = reponse.Content.ReadAsAsync<IEnumerable<DonHang>>().Result;
            return View(lstDonHang);
        }

        // GET: Admin/Order/Details/
        public ActionResult Details(int id)
        {
            var order = new OrderDao().ViewDetail(id);
            return View(order);
        }

        // detail month
        public ActionResult DetailsMonth(int month)
        {
            var order = new OrderDao();
            var model = order.ListMonth(month);
            return View(model);
        }
        // edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebAPIClient.GetAsync("DonHang/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<DonHang>().Result);
        }

        [HttpPost]
        public ActionResult Edit(DonHang tt)
        {
            //if (ModelState.IsValid)
            //{
            //    var dao = new OrderDao();
            //    var result = dao.Update(tt);
            //    if (result)
            //    {
            //        SetAlert("Cập nhật đơn hàng thành công", "success");
            //        return RedirectToAction("Index", "Order");
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", "Cập nhật đơn hàng không thành công");
            //    }
            //}
            HttpResponseMessage reponse = GlobalVariables.WebAPIClient.PutAsJsonAsync("DonHang/" + tt.MaDH, tt).Result;
            return RedirectToAction("Index");
        }
        // delete
        public ActionResult Delete(int id)
        {
            HttpResponseMessage reponse = GlobalVariables.WebAPIClient.DeleteAsync("DonHang/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}
