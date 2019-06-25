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
            var img = new Bitmap(@"D:\aaa.png");

            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            path = Path.Combine(path, "tessdata");
            path = path.Replace("file:\\", "");

            var ocr = new TesseractEngine(path, "eng", EngineMode.TesseractAndCube);

            string str = ocr.Process(img).GetText();

            //ViewBag.Message = "Your contact page.";

            ViewBag.Message = str;

            return View();
        }
        #endregion
    }
}