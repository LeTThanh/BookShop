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
    public class FeedbackController : Controller
    {
        // GET: Admin/Feedback
        public ActionResult Index()
        {
            IEnumerable<DanhGia> lstDanhGia;
            HttpResponseMessage reponse = GlobalVariables.WebAPIClient.GetAsync("DanhGia").Result;
            lstDanhGia = reponse.Content.ReadAsAsync<IEnumerable<DanhGia>>().Result;
            return View(lstDanhGia);
        }
    }
}