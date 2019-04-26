using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web;


namespace UploadPicture.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult UploadImage()
        {
            return View();
        }
       
        public ActionResult ProcessUpload()
        {
           
            HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            string[] path = new string[files.Count];
            for (var i = 0; i < files.Count; i++)
            {
                HttpPostedFile file = files[i];
                string roothPath = "~/Upload/" + file.FileName;
                path[i] = roothPath.Substring(1);
                file.SaveAs(System.Web.HttpContext.Current.Server.MapPath(roothPath));
                
            }
            //Validate 
            return RedirectToAction("UploadImage");
            // Xử lí Upload
            //AnhPost.SaveAs(Server.MapPath("~/Content/images/" + AnhPost.FileName));// lưu vào thư mục đường dẫn muốn lưu 
            //return "/Content/images/" + AnhPost.FileName;
        }
    }
}