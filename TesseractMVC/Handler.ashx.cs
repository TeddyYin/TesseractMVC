using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace TesseractMVC
{
    /// <summary>
    /// Summary description for Handler
    /// </summary>
    public class Handler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string base64String = context.Request["data"];

            Guid guid = Guid.NewGuid();

            string file_name = guid.ToString();

            Image img = this.Base64ToImage(base64String);
            img.Save(@"D:\Tesseract\" + file_name + ".jpg");//儲存圖片
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        #region base64 string to Image object
        public Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0,
              imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }
        #endregion
    }
}