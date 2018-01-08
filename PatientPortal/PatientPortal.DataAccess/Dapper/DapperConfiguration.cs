using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

// <copyright file="DapperConfiguration.cs" company="FIS" department="R&D">
// Copyright (c) 2017 All Rights Reserved
// </copyright>
// <author>LinhNT76</author>
// <date></date>
// <summary>Dapper Configuration</summary>
namespace PatientPortal.DataAccess.Dapper
{
    public static class DapperConfiguration
    {
        public static IDbConnection db;

        /// <summary>
        /// Open connection Dapper
        /// </summary>
        /// <param name="areaConnectionString">
        /// Hospital.CMS/Hospital.Core
        /// </param>
        public static void OpenConnection(short idxInstance)
        {
            string areaConnectionString = PatientPortal.Domain.Utilities.GlobalVariables.DapperInstance(idxInstance);
            string connStr = ConfigurationManager.ConnectionStrings[areaConnectionString].ConnectionString;
            db = new SqlConnection(connStr);
        }

        public static IDbConnection Open(short idxInstance)
        {
            string areaConnectionString = PatientPortal.Domain.Utilities.GlobalVariables.DapperInstance(idxInstance);
            string connStr = ConfigurationManager.ConnectionStrings[areaConnectionString].ConnectionString;
            return new SqlConnection(connStr);
        }

        /// <summary>
        /// Close connection Dapper
        /// </summary>
        public static void CloseConnection()
        {
            if (db != null && db.State == ConnectionState.Open)
                db.Close();
        }
    }
}
