﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;

namespace PatientPortal.Utility.Application
{
    public static class ApplicationGenerator
    {
        public static T GetObject<T>() where T : new()
        {
            return new T();
        }

        public static string GeneralActionMessage(string actionType, TypeResult typeResult)
        {
            var strReturn = string.Empty;
            //Action Type
            if(actionType != null)
            { 
                switch(actionType)
                {
                    case "I": //Insert
                        strReturn = "Thêm";
                        break;
                    case "U": //Update
                        strReturn = "Cập nhật";
                        break;
                    case "D": //Delete
                        strReturn = "Xóa";
                        break;
                    case "R": //Read
                        strReturn = "Thống kê";
                        break;
                    case "S": //Send
                        strReturn = "Gửi";
                        break;
                    case "C": //Confirm
                        strReturn = "Xác nhận";
                        break;
                    case "CP": //Change pass
                        strReturn = "Đổi mật khẩu";
                        break;
                    case "B": //Change pass
                        strReturn = "Đặt lịch hẹn";
                        break;
                }
            }
            switch (typeResult)
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
                case TypeResult.LOGINERROR:
                    strReturn = "Sai tên đăng nhập hoặc mật khẩu, xin thử lại!";
                    break;
                case TypeResult.USER_NOT_EXIST:
                    strReturn = "Không tìm thấy thông tin tài khoản.";
                    break;
                case TypeResult.USER_EXIST:
                    strReturn = "Email bạn đăng ký đã tồn tại, vui lòng nhập địa chỉ email khác.";
                    break;
                case TypeResult.INCORRECT_PASS:
                    strReturn = "Mật khẩu cũ không đúng, vui lòng nhập lại mật khẩu.";
                    break;
                case TypeResult.SUCCESS_APPROVE:
                    strReturn = "Bài viết đã được duyệt.";
                    break;
                case TypeResult.FAIL_APPROVE:
                    strReturn = "Vui lòng nhập ghi chú để duyệt bài viết.";
                    break;
                case TypeResult.SUCCESS_PUBLISH:
                    strReturn = "Bài viết đã được xuất bản.";
                    break;
                case TypeResult.FAIL_PUBLISH:
                    strReturn = "Vui lòng nhập ghi chú để xuất bản bài viết.";
                    break;
                case TypeResult.reCAPTCHA:
                    strReturn = "Captcha không hợp lệ. Xin thử lại.";
                    break;
                case TypeResult.SUCCESS_APPOINTMENT:
                    strReturn = "Đặt lịch hẹn thành công.";
                    break;
            }

            return strReturn;
        }

        

        public static HtmlString RenderResult(TypeResult typeResult, string strMessage)
        {
            var messages = string.Empty;
            var icon = string.Empty;
            var cssClass = string.Empty;

            switch (typeResult)
            {
                case TypeResult.SUCCESS:
                    cssClass = @"alert-success";
                    icon = "check";
                    messages = "Success";
                    break;
                case TypeResult.ISUSED:
                    cssClass = @"alert-warning";
                    icon = "warning";
                    messages = "Warning";
                    break;
                case TypeResult.FAIL:
                    cssClass = @"alert-warning";
                    icon = "warning";
                    messages = "Warning";
                    break;
                case TypeResult.ERROR:
                    cssClass = @"alert-danger";
                    icon = "close";
                    messages = "Error";
                    break;
                case TypeResult.INFO:
                    cssClass = @"alert-info";
                    icon = "info";
                    messages = "Info";
                    break;
                case TypeResult.USER_NOT_EXIST:
                    cssClass = @"alert-warning";
                    icon = "warning";
                    messages = "Warning";
                    break;
                case TypeResult.USER_EXIST:
                    cssClass = @"alert-warning";
                    icon = "warning";
                    messages = "Warning";
                    break;
                case TypeResult.INCORRECT_PASS:
                    cssClass = @"alert-warning";
                    icon = "warning";
                    messages = "Warning";
                    break;
                case TypeResult.LOGINERROR:
                    cssClass = @"alert-warning";
                    icon = "warning";
                    messages = "Warning";
                    break;
                case TypeResult.SUCCESS_APPROVE:
                    cssClass = @"alert-success";
                    icon = "check";
                    messages = "Success";
                    break;
                case TypeResult.FAIL_APPROVE:
                    cssClass = @"alert-warning";
                    icon = "warning";
                    messages = "warning";
                    break;
                case TypeResult.SUCCESS_PUBLISH:
                    cssClass = @"alert-success";
                    icon = "check";
                    messages = "Success";
                    break;
                case TypeResult.FAIL_PUBLISH:
                    cssClass = @"alert-warning";
                    icon = "warning";
                    messages = "warning";
                    break;
                case TypeResult.SUCCESS_APPOINTMENT:
                    cssClass = @"alert-success";
                    icon = "check";
                    messages = "Success";
                    break;
            }

            messages = @"<div class='alert "+ cssClass + @" alert-dismissable alert-view fade in'>
                                <a href = '#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                                <strong><i class='fa fa-"+ icon +"'></i> "+ messages  + ":</strong> " + strMessage + @"
                                </div>";

            return new HtmlString(messages);
        }

        
        public static HtmlString RenderResult(FuntionType type, string actionType = "A")
        {
            var messages = "Bạn không có quyền ";
            var icon = "lock";
            var cssClass = "alert-danger";

            if (actionType != null)
            {
                switch (actionType)
                {
                    case "I": //Insert
                        messages = "thêm";
                        break;
                    case "U": //Update
                        messages = "cập nhật";
                        break;
                    case "D": //Delete
                        messages = "xóa";
                        break;
                    case "G": //Get
                        messages = "thống kê";
                        break;
                    case "S": //Send
                        messages = "gửi";
                        break;
                    case "C": //Confirm
                        messages = "xác nhận";
                        break;
                    case "A": //Access
                        messages = "truy cập chức năng";
                        break;
                }
            }

            switch (type)
            {
                case FuntionType.Department:
                    messages += " Chuyên Khoa";
                    break;
                case FuntionType.Account:
                    messages += " Tài khoản";
                    break;
                case FuntionType.Article:
                    messages += " Hỏi đáp y tế";
                    break;
                case FuntionType.OfferAdvise:
                    messages += " Góp ý xây dựng";
                    break;
                case FuntionType.Permission:
                    messages += " Chi tiết quyền";
                    break;
                case FuntionType.Survey:
                    messages += " Khảo sát";
                    break;
                case FuntionType.UserProfile:
                    messages += " Thông tin người dùng";
                    break;
                case FuntionType.Module:
                    messages += " Chức năng";
                    break;
                case FuntionType.Role:
                    messages += " Nhóm quyền";
                    break;
                case FuntionType.Redis:
                    messages += " Redis Cache";
                    break;
            }
            messages += ". Xin liên hệ Quản trị hệ thống để được hỗ trợ. Xin cảm ơn.";
            messages = @"<div class='alert " + cssClass + @" alert-dismissable alert-view fade in'>
                                <a href = '#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                                <strong><i class='fa fa-" + icon + "'></i> Authorization:</strong> " + messages + @"
                                </div>";

            return new HtmlString(messages);
        }

        public static HtmlString RenderResult()
        {
            var messages = "Bạn không có quyền truy cập chức năng này. ";
            var icon = "lock";
            var cssClass = "alert-danger";

            messages += "Xin liên hệ Quản trị hệ thống để được hỗ trợ. Xin cảm ơn.";
            messages = @"<div class='alert " + cssClass + @" alert-dismissable alert-view fade in'>
                                <a href = '#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
                                <strong><i class='fa fa-" + icon + "'></i> Authorization:</strong> " + messages + @"
                                </div>";

            return new HtmlString(messages);
        }

        #region Alert
        public static string Toast(ToastStyle style, string mess)
        {
            if (mess.Length < 1) mess = "Không có thông báo nào được hiển thị.";
            Dictionary<string, string> html = null;
            switch(style)
            {
                case ToastStyle.Info:
                    html.Add("class", "info");
                    html.Add("icon", "info-circle");
                    html.Add("title", "Info");
                    break;
                case ToastStyle.Error:
                    html.Add("class", "danger");
                    html.Add("icon", "close");
                    html.Add("title", "Error");
                    break;
                case ToastStyle.Success:
                    html.Add("class", "success");
                    html.Add("icon", "check");
                    html.Add("title", "Success");
                    break;
                case ToastStyle.Warning:
                    html.Add("class", "warning");
                    html.Add("icon", "warning");
                    html.Add("title", "Warning");
                    break;
            }
            return string.Format("<div class='alert alert-{0} alert-dismissable alert-view fade in' style='display: none;'>"
                        + "<a href='#' class='close' data-dismiss='alert' aria-label='close'>×</a>"
                        + "<strong><i class='fa fa-{1}'></i> {2}:</strong>{3}</div>", html["class"], html["icon"], html["title"], mess);
        }
        #endregion

        #region Enum
        public enum FuntionType
        {
            Department,
            Account,
            Article,
            OfferAdvise,
            Permission,
            Survey,
            UserProfile,
            Module,
            Role,
            Post,
            Redis
        }
        public enum TypeResult
        {
            SUCCESS,
            FAIL,
            ERROR,
            ISUSED,
            INFO,
            LOGINERROR,
            USER_NOT_EXIST,
            USER_EXIST,
            INCORRECT_PASS,
            SUCCESS_APPROVE,
            FAIL_APPROVE,
            SUCCESS_PUBLISH,
            FAIL_PUBLISH,
            reCAPTCHA,
            SUCCESS_APPOINTMENT
        }

        public enum ToastStyle
        {
            Warning,
            Error,
            Info,
            Success
        }
        #endregion
    }
}