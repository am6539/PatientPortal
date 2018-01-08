using PatientPortal.Provider.Common;
using System;
using System.Configuration;
using System.Linq;
using System.Web;


// <copyright file="URLBuilder.cs" company="FIS" department="R&D">
// Copyright (c) 2017 All Rights Reserved
// </copyright>
// <author>LinhNT76</author>
// <date></date>
// <summary>URLBuilder</summary>
namespace PatientPortal.Provider.Models
{
    public static class URLBuilder
    {
        /// <summary>
        /// Get configuration URL Services
        /// </summary>
        /// <param name="apiSettingName"></param>
        /// <returns></returns>
        public static Uri APIBaseAddress(string apiSettingName)
        {
            try
            {
                var webapi = string.Empty;
                switch (apiSettingName)
                {
                    case "cms":
                        webapi = AppConfig.HostAddress_API_CMS;
                        break;
                    case "core":
                        webapi = AppConfig.HostAddress_API_Core;
                        break;
                    case "authorize":
                        webapi = AppConfig.HostAddress_API_Authorize;
                        break;
                }
                if(webapi.Length < 1) webapi = ConfigurationSettings.AppSettings[apiSettingName];
                return new Uri(webapi);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Bind multiple parameter
        /// </summary>
        /// <param name="obj">Model parameter</param>
        /// <returns>String Uri</returns>
        public static string GetQueryString(object obj)
        {
            var properties = from p in obj.GetType().GetProperties()
                             where p.GetValue(obj, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());

            return String.Join("&", properties.ToArray());
        }
    }
}