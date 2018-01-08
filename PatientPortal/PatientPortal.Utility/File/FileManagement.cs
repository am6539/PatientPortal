using PatientPortal.Utility.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;

namespace PatientPortal.Utility.Files
{
    public static class FileManagement
    {
        #region [WebImage]
        public static byte[] ImageToByteArray(HttpPostedFileBase file)
        {
            // Read the file and convert it to Byte Array
            //string filePath = file.FileName;
            //string filename = Path.GetFileName(filePath);
            //string ext = Path.GetExtension(filename);
            //string contenttype = FileExtension(ext);
            //if(contenttype != null && contenttype.Length > 0)
            //{
               Stream fs = file.InputStream;
                BinaryReader br = new BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                return bytes;
            //}


        }
        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public static string ByteArrayToImageBase64(byte[] byteArrayIn)
        {
            return String.Format("data:image/png;base64,{0}", Convert.ToBase64String(byteArrayIn)); 
        }

        private static string FileExtension(string ext)
        {
            var contenttype = string.Empty;
            //Set the content type based on File Extension
            switch (ext)
            {
                case ".doc":
                    contenttype = "application/vnd.ms-word";
                    break;
                case ".docx":
                    contenttype = "application/vnd.ms-word";
                    break;
                case ".xls":
                    contenttype = "application/vnd.ms-excel";
                    break;
                case ".xlsx":
                    contenttype = "application/vnd.ms-excel";
                    break;
                case ".jpg":
                    contenttype = "image/jpg";
                    break;
                case ".png":
                    contenttype = "image/png";
                    break;
                case ".gif":
                    contenttype = "image/gif";
                    break;
                case ".pdf":
                    contenttype = "application/pdf";
                    break;
            }
            return contenttype;
        }

        public static string ImageBase64(string file)
        {
            if (file == null || file.Length < 1) return string.Empty;
            file = HttpContext.Current.Server.MapPath(file);

            using (Image image = Image.FromFile(file))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String
                    string base64String = Convert.ToBase64String(imageBytes);
                    return String.Format("data:image/png;base64,{0}", base64String); 
                }
            }
        }

        public static string ImageBase64(HttpPostedFileBase file)
        {
            string theFileName = Path.GetFileName(file.FileName);
            byte[] thePictureAsBytes = new byte[file.ContentLength];
            using (BinaryReader theReader = new BinaryReader(file.InputStream))
            {
                thePictureAsBytes = theReader.ReadBytes(file.ContentLength);
            }
            string base64String = Convert.ToBase64String(thePictureAsBytes);
            return String.Format("data:image/png;base64,{0}", base64String);
        }

        public static string ImageURLBase64(string file, string urlHostname)
        {
            if (file == null || file.Length < 1) return string.Empty;
            var url = urlHostname + file;


            // Convert byte[] to Base64 String

            Byte[] _byte = GetImage(url);

            string base64String = Convert.ToBase64String(_byte, 0, _byte.Length);
            return String.Format("data:image/png;base64,{0}", base64String);
        }

        private static byte[] GetImage(string url)
        {
            Stream stream = null;
            byte[] buf;

            try
            {
                WebProxy myProxy = new WebProxy();
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                stream = response.GetResponseStream();

                using (BinaryReader br = new BinaryReader(stream))
                {
                    int len = (int)(response.ContentLength);
                    buf = br.ReadBytes(len);
                    br.Close();
                }

                stream.Close();
                response.Close();
            }
            catch (Exception exp)
            {
                buf = null;
            }

            return (buf);
        }

        public static bool UploadImage(HttpPostedFileBase file, string folder, ref string savedFile)
        {
            //Check file name
            if (file == null || file.FileName.Length < 1)
            {
                return false;
            }

            string _file = Path.Combine(folder);
            string _path = HttpContext.Current.Server.MapPath(_file);

            //Create folder
            if (!Directory.Exists(_path))
                Directory.CreateDirectory(_path);

            _file = Path.Combine(folder, Path.GetFileName(file.FileName));
            _path = Path.Combine(_path, Path.GetFileName(file.FileName));

            if (!File.Exists(_path))
            {
                try
                {
                    WebImage image = new WebImage(file.InputStream);
                    image.Save(_path);
                    savedFile = _file;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                savedFile = _file;
            }

            return true;
        }

        public static bool UploadImageTst(HttpPostedFileBase file, string folder, string path, ref string savedFile)
        {
            //Check file name
            if (file == null || file.FileName.Length < 1)
            {
                return false;
            }

            string _file = Path.Combine(folder);
            //string _path = HttpContext.Current.Server.MapPath(_file);

            //Create folder
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            _file = Path.Combine(path, Path.GetFileName(file.FileName));
            string _path = Path.Combine(folder, Path.GetFileName(file.FileName));

            if (!File.Exists(_path))
            {
                try
                {
                    WebImage image = new WebImage(file.InputStream);
                    image.Save(_path);
                    savedFile = _file;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                savedFile = _file;
            }

            return true;
        }

        public static bool UploadImage(HttpPostedFileBase file, string folder)
        {
            //Check file name
            if (file == null || file.FileName.Length < 1)
            {
                return false;
            }

            string _file = Path.Combine(folder);
            string _path = HttpContext.Current.Server.MapPath(_file);

            //Create folder
            if (!Directory.Exists(_path))
                Directory.CreateDirectory(_path);

            _file = Path.Combine(folder, Path.GetFileName(file.FileName));
            _path = Path.Combine(_path, Path.GetFileName(file.FileName));

            if (!File.Exists(_path))
            {
                try
                {
                    WebImage image = new WebImage(file.InputStream);
                    image.Save(_path);
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool UploadImage(HttpPostedFileBase file, string folder, ref string savedFile, int width, int height, string WatermarkText = "")
        {
            //Check file name
            if (file == null || file.FileName.Length < 1)
            {
                return false;
            }

            string _file = Path.Combine(ValueConstant.IMAGE_PATH + folder);
            string _path = HttpContext.Current.Server.MapPath(_file);

            //Create folder
            if (!Directory.Exists(_path))
                Directory.CreateDirectory(_path);

            _file = Path.Combine(_file, Path.GetFileName(file.FileName));
            _path = Path.Combine(_path, Path.GetFileName(file.FileName));

            if (!File.Exists(_path))
            {
                try
                {
                    WebImage image = new WebImage(file.InputStream);
                    if (width > 0)
                    {
                        if (height == 0)
                            height = width;
                        image.Resize(width, height);
                    }
                    if (WatermarkText.Length > 0)
                    {
                        image.AddTextWatermark(WatermarkText);
                    }
                    image.Save(_path);

                    savedFile = _file;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                savedFile = _file;
            }

            return true;
        }
        public static bool DeleteImage(string file)
        {
            bool _ret = true;

            if (file.Length < 1)
                return _ret;
            file = HttpContext.Current.Server.MapPath(file);
            if (File.Exists(file))
            {
                try
                {
                    File.Delete(file);
                }
                catch (Exception ex)
                {
                    _ret = false;
                }
            }
            return _ret;
        }
        #endregion

        #region [Other File]
        public static bool UploadFile(HttpPostedFileBase file, string folder, ref string savedFile)
        {
            //Check file name
            if (file == null || file.FileName.Length < 1)
            {
                return false;
            }

            string _file = Path.Combine(folder);
            string _path = HttpContext.Current.Server.MapPath(_file);

            //Create folder
            if (!Directory.Exists(_path))
                Directory.CreateDirectory(_path);

            _file = Path.Combine(folder, Path.GetFileName(file.FileName));
            _path = Path.Combine(_path, Path.GetFileName(file.FileName));

            if (!File.Exists(_path))
            {
                try
                {
                    file.SaveAs(_path);
                    savedFile = _file;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                savedFile = _file;
            }

            return true;
        }
        #endregion
    }
}