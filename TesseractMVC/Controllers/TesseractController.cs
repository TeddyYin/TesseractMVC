using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Tesseract;

namespace TesseractMVC.Controllers
{
    public class TesseractController : Controller
    {
        #region Index
        public ActionResult Index()
        {
            var img = new Bitmap(@"C:\inlove.png");

            #region get in bin folder path
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            path = Path.Combine(path, "tessdata");
            path = path.Replace("file:\\", "");
            #endregion

            var ocr = new TesseractEngine(path, "eng", EngineMode.TesseractAndCube);

            string str = ocr.Process(img).GetText();

            ViewBag.Message = str;

            return View();
        }
        #endregion

        //public void ProcessRequest(HttpContext context)
        //{
        //    context.Response.ContentType = "text/plain";
        //    string base64String = context.Request["data"];
        //    Image img = this.Base64ToImage(base64String);
        //    img.Save(@"D:\ccc.jpg");//儲存圖片
        //}

        //public bool IsReusable
        //{
        //    get
        //    {
        //        return false;
        //    }
        //}

        ////把base64字串轉成Image物件
        //public Image Base64ToImage(string base64String)
        //{
        //    // Convert Base64 String to byte[]
        //    byte[] imageBytes = Convert.FromBase64String(base64String);
        //    MemoryStream ms = new MemoryStream(imageBytes, 0,
        //      imageBytes.Length);

        //    // Convert byte[] to Image
        //    ms.Write(imageBytes, 0, imageBytes.Length);
        //    Image image = Image.FromStream(ms, true);
        //    return image;
        //}
    }
}