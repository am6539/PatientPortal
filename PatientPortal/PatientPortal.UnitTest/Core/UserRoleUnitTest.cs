﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientPortal.Domain.Models.CORE;
using PatientPortal.DataAccess.CORE;
using System.Collections.Generic;
using System.Linq;
using PatientPortal.DataAccess.Repo.CORE;

namespace PatientPortal.UnitTest.Core
{
    [TestClass]
    public class UserRoleUnitTest
    {
        public IUserRole _userRoleImpl;
        [TestInitialize]
        public void TestInitialize()
        {
            //_userRoleImpl = new UserRoleImpl();
        }

        //[TestMethod]
        //public void UserRoleGetAll()
        //{
        //    var count = _userRoleImpl.Query().Count;
        //    Assert.IsTrue(count > 0);
        //}

        //[TestMethod]
        //public void UserRoleInsert()
        //{
        //    var list = new List<UserRole>()
        //    {
        //        new UserRole
        //        {
        //            UserId = 1,
        //            RoleId = 1
        //        }
        //    };

        //    var flag = _userRoleImpl.Transaction(list, 'I');
        //    Assert.IsTrue(flag);
        //}

        //[TestMethod]
        //public void UserRoleUpdate()
        //{
        //    var list = _userRoleImpl.Query();
        //    var listUpate = new List<UserRole>();
        //    if(list.Count> 0)
        //    {
        //        listUpate.Add(list.LastOrDefault());
        //    }
        //    else
        //    {
        //        var listInsert = new List<UserRole>()
        //        {
        //            new UserRole
        //            {
        //                UserId = 1,
        //                RoleId = 1
        //            }
        //        };
        //        _userRoleImpl.Transaction(listInsert, 'I');
        //        list = _userRoleImpl.Query();
        //        listUpate.Add(list.LastOrDefault());
        //    }
        //    var flag = _userRoleImpl.Transaction(listUpate, 'U');
        //    Assert.IsTrue(flag);
        //}
    }
}