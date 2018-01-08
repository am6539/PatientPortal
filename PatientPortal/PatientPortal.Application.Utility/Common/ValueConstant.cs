using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientPortal.Application.Utility.Common
{
    public class ValueConstant
    {

        //Value path image Upload
        public const string ROOT_FOLDER = "Assets";
        public const string ROOT_FOLDER_VIDEO = "Videos";
        public const string IMAGE_PATH = "~\\Assets\\Images";
        public const string VIDEO_PATH = "~\\Assets\\Videos";
        public const string FOLDER_SEPARATOR = "\\";

        // Value default language
        public const byte LANG_VIETNAM = 1;
        public const byte WORK_STATE_ID_DRAFF = 1;
        public const byte WORK_STATE_ID_APPROVE = 2;
        public const byte WORK_STATE_ID_PUBLISH = 3;

        // Temp UserId
        public const int TEMP_USERID = 1;

        public enum MEDIA_TYPE
        {
            IMAGE,
            VIDEO
        }

        public enum POST_STATUS
        {
            NEW = 1,
            DRAFT = 2,
            TRASH = 3
        }
    }
}