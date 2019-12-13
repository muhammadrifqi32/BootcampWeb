using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebASP_Ajax.Models;

namespace WebASP_Ajax.Controllers
{
    public class SuppliersController : Controller
    {
        Bootcamp32Entities myContext = new Bootcamp32Entities();
        readonly HttpClient client = new HttpClient();

        public SuppliersController()
        {
            client.BaseAddress = new Uri("http://localhost/51938/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: Suppliers
        public ActionResult Index()
        {
            return View(List());
        }

        public ActionResult GetSuppliers()
        {
            using (Bootcamp32Entities b32 = new Bootcamp32Entities())
            {
                var suppliers = b32.tb_m_supplier.OrderBy(a => a.Name).ToList();
                return Json(new { data = suppliers }, JsonRequestBehavior.AllowGet);
            }
        }
        public async Task<JsonResult> List()
        {
            HttpResponseMessage response = await client.GetAsync("api/suppliers");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<tb_m_supplier[]>();
                var json = JsonConvert.SerializeObject(data, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                });
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            return Json("Internal Server Error", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Save(int id)
        {
            var view = myContext.tb_m_supplier.Where(s => s.Id == id).FirstOrDefault();
            return View(view);
        }
        [HttpPost]
        public ActionResult Save(tb_m_supplier tbs)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (Bootcamp32Entities b32 = new Bootcamp32Entities())
                {
                    if (tbs.Id > 0)
                    {
                        var view = b32.tb_m_supplier.Where(s => s.Id == tbs.Id).FirstOrDefault();
                        if (view != null)
                        {
                            view.Name = tbs.Name;
                            view.Email = tbs.Email;
                            view.CreateDate = tbs.CreateDate;
                        }
                    }
                    else
                    {
                        b32.tb_m_supplier.Add(tbs);
                    }
                    b32.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}