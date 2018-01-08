using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientPortal.Application.Utility.Helpers
{
    public static class ApplicationHelper
    {
        public static T GetObject<T>() where T : new()
        {
            return new T();
        }

        public static string GeneralActionMessage(string actionType, TypeResult typeResult)
        {
            var strReturn = string.Empty;
            //Action Type
            switch(actionType)
            {
                case "I":
                    strReturn = "Thêm";
                    break;
                case "U":
                    strReturn = "Cập nhật";
                    break;
                case "D":
                    strReturn = "Xóa";
                    break;
            }

            switch(typeResult)
            {
                case TypeResult.SUCCESS:
                    strReturn += " dữ liệu thành công";
                    break;
                case TypeResult.FAIL:
                    strReturn += " chưa được thực hiện thành công. Xin kiểm tra lại";
                    break;
                case TypeResult.ERROR:
                    strReturn = "Có lỗi phát sinh khi " + strReturn.ToLower() + " dữ liệu. Xin thử lại hoặc liên hệ Quản trị hệ thống. Xin cảm ơn";
                    break;
                case TypeResult.ISUSED:
                    strReturn = "Có lỗi phát sinh khi " + strReturn.ToLower() + " dữ liệu. Dữ liệu này đã được sử dụng, không thể xóa";
                    break;
            }

            return strReturn;
        }

        public enum TypeResult
        {
            SUCCESS,
            FAIL,
            ERROR,
            ISUSED
        }

        public static HtmlString RenderResult(TypeResult typeResult, string strMessage)
        {
            var messages = "";
            switch (typeResult)
            {
                case TypeResult.SUCCESS:
                    messages = "<div class='alert alert-view alert-success text-center'><strong>"
                        + strMessage + "</strong></div>";
                    break;
                case TypeResult.FAIL:
                    messages = "<div class='alert alert-view alert-warning text-center'><strong>"
                        + strMessage + "</strong></div>";
                    break;
                case TypeResult.ERROR:
                    messages = "<div class='alert alert-view alert-danger text-center'><strong>"
                        + strMessage + "</strong></div>";
                    break;
                case TypeResult.ISUSED:
                    messages = "<strong>"
                        + strMessage + "</strong>";
                    break;
            }
            return new HtmlString(messages);
        }
    }
}