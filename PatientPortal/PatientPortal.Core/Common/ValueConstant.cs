﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientPortal.Domain.Common
{
    public class ValueConstant
    {
        public const string LOGS_PATH = "~\\Assets\\Logs";
        public const char INSERT = 'I';
        public const char UPDATE = 'U';
        public const char DELETE = 'D';

        // Authentication
        public const string TOKEN = "AccessToken";
        public const string AccountImage = "Image";
        public const string AccountPatient = "PatientId";
        public const string AccountName = "UserName";

        public const string SET_PERMISSION = "/SetPermission";
        public const string UPDATE_PERMISSION = "/UpdatePermission";
        public const string REMOVE_PERMISSION = "/RemovePermission";
        public const string REGISTER = "/Register";
        public const string UPDATE_USER = "/UpdateBasicUserInfo";
        public const string DELETE_USER = "/DeleteUser";
        public const string GET_ROLE = "/Role/GetAll";
        public const string SET_USER_ROLE = "/UserRole/SetUserRole";
        public const string GET_USER_LIST = "/GetListUser";
        public const string CHANGE_PASSWORD = "/ChangePassword";

        //Captcha
        public const string GooglereCAPTCHA_SiteKey = "6LeViRIUAAAAADz-mCpf53nk8z9ysp-T-YszTOS8";
        public const string GooglereCAPTCHA_SecretKey = "6LeViRIUAAAAACh5rtRc-TlHwY98aQze_Lp1CYiy";

        //Object
        public const string DefaultKeyObject = "Id";
    }
}