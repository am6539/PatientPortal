using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.Utility.Files
{
    public class LayoutGuide
    {
        #region SPA
        public  static string SPA_ResourcePath(Provider.Common.APIEnums.Application appType, string path)
        {
            var hostAddress = string.Empty;
            switch(appType)
            {
                case Provider.Common.APIEnums.Application.CMS:
                    hostAddress = Provider.Common.AppConfig.HostAddress_CMS;
                    break;
                case Provider.Common.APIEnums.Application.Internal:
                    hostAddress = Provider.Common.AppConfig.HostAddress_Internal;
                    break;
            }

            return hostAddress + path.Replace("~", "").Replace(@"\", @"/").Replace(@" ", "%20");


        }

        #endregion


        //Image Size
        public static int[] GetDefaultSize(Image_ModuleName name)
        {
            
            var data = string.Empty;
            switch(name)
            {
                case Image_ModuleName.Post:
                    data = ConfigurationManager.AppSettings["image:Post"];
                    break;
                case Image_ModuleName.Feature:
                    data = ConfigurationManager.AppSettings["image:Feature"];
                    break;
                case Image_ModuleName.Slider:
                    data = ConfigurationManager.AppSettings["image:Slider"];
                    break;
                case Image_ModuleName.Account:
                    data = ConfigurationManager.AppSettings["image:Account"];
                    break;
            }
            if (data == null|| data.Length < 1 || !data.Contains("x") || data == "0" || data == "0x0") return null;
            var ar = data.Split('x');

            int[] demi = new int[2];
            demi[0] = Convert.ToInt32(ar[0]);
            demi[1] = Convert.ToInt32(ar[1]);

            return demi;
        }
    }
    public enum Image_ModuleName
    {
        Post = 1,
        Feature = 2,
        Slider = 3,
        Account = 4
    }
}
