using PatientPortal.CMS.Common;
using PatientPortal.CMS.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PatientPortal.Utility.Files;
using PatientPortal.Utility.Application;
using PatientPortal.Domain.LogManager;
using PatientPortal.Provider.Common;
//using WebMarkupMin.AspNet4.Mvc;

namespace PatientPortal.CMS.Controllers
{
    [Authorize]
    [AppHandleError]
    //[CompressContent]
    //[MinifyHtml]
    public class VideoLibraryController : Controller
    {
        private static string folderUpload = string.Empty;

        // GET: Video
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListVideoPartial(string fullPath)
        {
            if (!string.IsNullOrEmpty(fullPath))
            {
                string path = ValueConstant.FOLDER_SEPARATOR;
                string[] arr = fullPath.Split('\\');
                int index = Array.IndexOf(arr, ValueConstant.ROOT_FOLDER_VIDEO);
                for (int i = index; i < arr.Length -1; i++)
                {
                    path += arr[i].ToString() + ValueConstant.FOLDER_SEPARATOR;
                }
                folderUpload = path;

                var appData = Server.MapPath(ValueConstant.THUMBNAIL_VIDEO_FOLDER);
                var image = Directory.GetFiles(appData).Select(x => new FileViewModel
                {
                    Url = Url.Content(ValueConstant.THUMBNAIL_VIDEO_FOLDER + Path.GetFileName(x)),
                });
                return PartialView(image);
            }
            else
            {
                var model = new FileViewModel();
                return PartialView(model);
            }
        }

        public ActionResult MenuFileManagerPartial()
        {
            return PartialView();
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
                int index = Array.IndexOf(arr, ValueConstant.ROOT_FOLDER_VIDEO);
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

        public bool AlreadyPopulated
        {
            get
            {
                return (Session["AlreadyPopulated"] == null ? false : (bool)Session["AlreadyPopulated"]);
            }
            set
            {
                Session["AlreadyPopulated"] = (bool)value;
            }

        }

        [HttpPost]
        public ActionResult CreateFolder(string path, string newname)
        {
            try
            {
                string strpath = ValueConstant.FOLDER_SEPARATOR;
                string[] arr = path.Split('\\');
                int index = Array.IndexOf(arr, ValueConstant.ROOT_FOLDER);
                for (int i = index; i < arr.Length; i++)
                {
                    strpath += arr[i].ToString() + ValueConstant.FOLDER_SEPARATOR;
                }

                string mapPath = Server.MapPath(strpath + newname);
                Directory.CreateDirectory(mapPath);
                AlreadyPopulated = false;
                return null;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }

        [HttpPost]
        public ActionResult RenameFolder(string path, string newname, string oldname)
        {
            try
            {
                if (!string.IsNullOrEmpty(newname))
                {
                    //string oldDirectory = Server.MapPath(path + ValueConstant.FOLDER_SEPARATOR + oldname);
                    //string newDirectory = Server.MapPath(path + ValueConstant.FOLDER_SEPARATOR + newname);
                    Directory.Move(path + ValueConstant.FOLDER_SEPARATOR + oldname, path + ValueConstant.FOLDER_SEPARATOR + newname);
                    AlreadyPopulated = false;
                    return null;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase fileUpload)
        {
            try
            {
                if (!string.IsNullOrEmpty(folderUpload))
                {
                    if (fileUpload != null)
                    {
                        string name = "";
                        FileManagement.UploadFile(fileUpload, folderUpload, ref name);
                        string pathVideo = Server.MapPath(name);

                        // Get thumbnail video
                        string pathThumbnail = Server.MapPath(ValueConstant.THUMBNAIL_VIDEO_FOLDER);
                        var ffMpeg = new NReco.VideoConverter.FFMpegConverter();
                        string[] arrTemp = fileUpload.FileName.Split('.');
                        string fileName = pathThumbnail + arrTemp[0] + ".jpg";
                        ffMpeg.GetVideoThumbnail(pathVideo, fileName, 10.0f);

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["Alert"] = ApplicationGenerator.RenderResult(ApplicationGenerator.TypeResult.FAIL, ApplicationGenerator.GeneralActionMessage(APIConstant.ACTION_INSERT, ApplicationGenerator.TypeResult.FAIL));
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    TempData["Alert"] = ApplicationGenerator.RenderResult(ApplicationGenerator.TypeResult.FAIL, "Vui lòng chọn thư mục cần tải hình lên");
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                TempData["Alert"] = ApplicationGenerator.RenderResult(ApplicationGenerator.TypeResult.ERROR, ApplicationGenerator.GeneralActionMessage(APIConstant.ACTION_INSERT, ApplicationGenerator.TypeResult.ERROR));
                return View();
            }
        }

        [HttpPost]
        public JsonResult GetTreeData()
        {
            JsTreeModel rootNode = new JsTreeModel();
            rootNode.text = "Videos";
            rootNode.state = new StateNode();
            rootNode.state.opened = true;

            string rootPath = Request.MapPath(ValueConstant.VIDEO_PATH);
            rootNode.id = rootPath;
            rootNode.state.selected = true;
            PopulateTree(rootPath, rootNode);
            AlreadyPopulated = true;
            return Json(rootNode, JsonRequestBehavior.AllowGet);
        }
    }
}