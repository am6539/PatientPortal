using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PatientPortal.Domain.LogManager;
using PatientPortal.Utility.Common;
using PatientPortal.Internal.Models;
using WebMarkupMin.AspNet4.Mvc;

namespace PatientPortal.Internal.Controllers
{
    [Authorize]
    [AppHandleError]
    //[CompressContent]
    //[MinifyHtml]
    public class LibraryController : Controller
    {
        public void UploadNow(HttpPostedFileWrapper upload, string folder)
        {
            string nameFolder = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00");
            string path = ValueConstant.IMAGE_PATH + ValueConstant.IMAGE_POST_PATH + nameFolder;
            var fullPath = string.Empty;
            if (!Directory.Exists(path))
            {
                fullPath = CreateFolder();
            }
            else
            {
                fullPath = ValueConstant.IMAGE_PATH + ValueConstant.IMAGE_POST_PATH + folder;
            }
            if (upload != null && upload.ContentType.Contains("image"))
            {
                string imageName = upload.FileName;
                string filePath = Path.Combine(Server.MapPath(fullPath), imageName);
                upload.SaveAs(filePath);
            }
            else
            {
                string fileName = upload.FileName;
                string filePath = Path.Combine(Server.MapPath(fullPath), fileName);
                upload.SaveAs(filePath);
            }
        }

        public ActionResult UploadPartial(string folder)
        {
            var fullPath = string.Empty;
            // Vì MVC không cho phép truyền param là đường dẫn nên phải check 2 trường hợp
            if (!folder.Contains('\\'))
            {
                fullPath = ValueConstant.IMAGE_PATH + ValueConstant.IMAGE_POST_PATH + folder + ValueConstant.FOLDER_SEPARATOR;
                var appData = Server.MapPath(fullPath);
                var image = Directory.GetFiles(appData).Select(x => new FileViewModel
                {
                    Url = Url.Content(fullPath + Path.GetFileName(x))
                });
                return PartialView(image);
            }
            else
            {
                var appData = Server.MapPath(folder);
                var image = Directory.GetFiles(appData).Select(x => new FileViewModel
                {
                    Url = Url.Content(folder + Path.GetFileName(x))
                });
                return PartialView("ListImagePartial",image);
            }
            
        }

        public void PopulateTree(string dir, JsTreeModel node)
        {
            if (node.children == null)
            {
                node.children = new List<JsTreeModel>();
            }

            DirectoryInfo directory = new DirectoryInfo(dir);

            foreach (DirectoryInfo d in directory.GetDirectories())
            {
                JsTreeModel t = new JsTreeModel();

                string path = ValueConstant.FOLDER_SEPARATOR;
                string[] arr = d.FullName.Split('\\');
                int index = Array.IndexOf(arr, ValueConstant.ROOT_FOLDER);
                for (int i = index; i < arr.Length; i++)
                {
                    path += arr[i].ToString() + ValueConstant.FOLDER_SEPARATOR;
                }

                t.id = path;
                t.text = d.Name.ToString();
                t.state = new StateNode();
                t.state.opened = true;

                PopulateTree(d.FullName, t);
                node.children.Add(t);
            }
        }

        [HttpPost]
        public JsonResult GetTreeData()
        {
            JsTreeModel rootNode = new JsTreeModel();
            rootNode.text = "Hình ảnh";
            rootNode.state = new StateNode();
            rootNode.state.opened = true;

            string rootPath = Request.MapPath(ValueConstant.IMAGE_POST_FULL_PATH);
            rootNode.id = rootPath;
            PopulateTree(rootPath, rootNode);
            return Json(rootNode, JsonRequestBehavior.AllowGet);
        }

        private string CreateFolder()
        {
            try
            {
                string nameFolder = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00");
                string path = ValueConstant.IMAGE_PATH + ValueConstant.IMAGE_POST_PATH + nameFolder;
                string mapPath = Server.MapPath(path);
                if (!Directory.Exists(mapPath))
                {
                    Directory.CreateDirectory(mapPath);
                    return path;
                }
                else
                    return path;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }
    }
}