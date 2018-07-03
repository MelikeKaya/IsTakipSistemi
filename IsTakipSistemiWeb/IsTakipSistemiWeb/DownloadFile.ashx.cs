using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace IsTakipSistemiWeb
{
    /// <summary>
    /// Summary description for DownloadFile
    /// </summary>
    public class DownloadFile : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            System.Web.HttpRequest request = System.Web.HttpContext.Current.Request;

            string filePath = request.QueryString["filePath"];
            string fileExtension = Path.GetExtension(filePath);
            string fileName = Guid.NewGuid().ToString("N");
            string fullName = fileName + fileExtension;

            response.ClearContent();
            response.Clear();
            response.ContentType = "text/plain";
            response.AddHeader("Content-Disposition", "attachment; filename=" + fullName + ";");
            response.TransmitFile(HttpContext.Current.Server.MapPath("/Uploads/" + filePath));
            response.Flush();
            response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}