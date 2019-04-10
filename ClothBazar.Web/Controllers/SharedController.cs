using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothBazar.Web.Controllers
{
    public class SharedController : Controller
    {
        public JsonResult UploadImage()
        {
            JsonResult jsonResult = new JsonResult();
            jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            try
            {
                var file = Request.Files[0];
                var fileName = file.FileName;
                var path = Path.Combine(Server.MapPath("~/content/images/"),fileName);
                file.SaveAs(path);
                jsonResult.Data = new {Success=true, ImageUrl=path };
            }
            catch (Exception ex)
            {
                jsonResult.Data = new { Success = false, Message=ex.Message };
            }
            return jsonResult;
        }
    }
}