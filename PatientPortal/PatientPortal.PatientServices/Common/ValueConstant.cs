using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientPortal.PatientServices.Common
{
    public class ValueConstant
    {

        //Value path image Upload
        public const string IMAGE_PATH = "~\\Assets\\Images";
        public const string LOGS_PATH = "~\\Assets\\Logs";
        public const string PATH_IMAGE_DEFAULT = "/Assets/Avatar/user_default.jpg";
        public const string PATH_AVATAR = "/Assets/Avatar/";

        // Value action in tracsaction
        public const string ACTION_INSERT = "I";
        public const string ACTION_UPDATE = "U";
        public const string ACTION_DELETE = "D";
        public const string ACTION_APPOINMENT = "B";

        //Article status enum
        public enum ArticleStatus : byte
        {
            JustCreated = 1,
            Approved = 2,
            MoveToTrash = 3
        }

        //Appointment Status enum
        public enum AppointmentStatus: byte
        {
            Create = 1,
            Examed = 2,
            Cancel = 3
        }
        public enum UserStatus
        {
            Success = 1,
            IsUsed = 2,
        }
        // Change password
        public const string INCORRECT_PASSWORD = "Incorrect password.";
    }
}