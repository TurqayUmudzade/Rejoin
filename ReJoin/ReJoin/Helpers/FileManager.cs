using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace ReJoin.Helpers
{
    public class FileManager
    {
        public static string UploadPath = HttpContext.Current.Server.MapPath("~/Public/uploads");

        public static string Upload(HttpPostedFileBase file,
            string allowedTypes = " image / png | image / jpeg | image / gif",
            int maxSize = 1024)
        {
            if (file == null)
            {
                throw new NullReferenceException("File cannot be null");
            }

            if (file.ContentLength / 1024 > maxSize) {
                throw new Exception("File size max be 1024kb");
            }

            if (!allowedTypes.Split('|').Contains(file.ContentType))
            {
                throw new Exception("File type is not acceptable");
            }


            string filename = Path.Combine(CreatePath(), Guid.NewGuid().ToString() + "-" + file.FileName);
            file.SaveAs(Path.Combine(UploadPath, filename));

            return filename;
        }

        public static void Delete(string filename)
        {
            if (string.IsNullOrEmpty(filename))
            {
                throw new NullReferenceException("Filename cannot be null");
            }


            if (File.Exists(Path.Combine(UploadPath, filename)))
            {
                File.Delete(Path.Combine(UploadPath, filename));
            }
        }

        private static string CreatePath()
        {
            DateTime now = DateTime.Now;

            if (!Directory.Exists(Path.Combine(UploadPath, now.Year.ToString())))
            {
                Directory.CreateDirectory(Path.Combine(UploadPath, now.Year.ToString()));
            }

            if (!Directory.Exists(Path.Combine(UploadPath, now.Year.ToString(), now.Month.ToString())))
            {
                Directory.CreateDirectory(Path.Combine(UploadPath, now.Year.ToString(), now.Month.ToString()));
            }

            return Path.Combine(now.Year.ToString(), now.Month.ToString());
        }

    }
}