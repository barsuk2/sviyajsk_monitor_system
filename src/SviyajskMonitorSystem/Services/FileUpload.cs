using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Services
{
    public class FileUpload
    {
        private static string UploadDestination { get; set; }
        private static string[] AllowedExtensions { get; set; }

        public FileUpload(string destination)
        {
            //upload config
          //  AllowedExtensions = new string[] { ".jpg", ".png", ".gif" };
            UploadDestination = destination;
        }

       
        public void SavePhoto(string DataUrl,int photoid)
        {
            if (!Directory.Exists(UploadDestination))
            {
                Directory.CreateDirectory(UploadDestination);
            }
            string filename = photoid.ToString() + ".image";
            var filestream = File.CreateText(UploadDestination + filename);
            filestream.WriteLine(DataUrl);
            filestream.Close();
        }
       
        
        public void RemovePhoto(int photoid)
        {
            string filename = photoid.ToString() + ".image";
            File.Delete(UploadDestination + filename);
        }

        public string GetDataUrl(int photoid)
        {
            return File.ReadAllText(UploadDestination + photoid.ToString() + ".image"); 
        }


        public string SaveFile(IFormFile file,string photoid)
        {
            string Filename = "";
            if (file.ContentDisposition != null)
            {
                //parse uploaded file
                var parsedContentDisposition = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                string extention = Path.GetExtension(file.FileName);
                //  Filename = parsedContentDisposition.FileName.Trim('"');
               
                string uploadPath = UploadDestination + photoid + extention;
                Filename = uploadPath;
                FileStream fs = new FileStream(uploadPath, FileMode.CreateNew);
                file.CopyTo(fs);
            }
            return Filename;
        }
    }
}
