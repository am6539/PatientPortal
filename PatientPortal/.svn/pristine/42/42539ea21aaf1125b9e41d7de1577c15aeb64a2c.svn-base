using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientPortal.Core.Models.CMS;
using PatientPortal.DataAccess.CMS;
using PatientPortal.DataAccess.Repo.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPortal.UnitTest
{
    [TestClass]
    public class PostUnitTest
    {
        public IPost _post;

        [TestInitialize]
        public void TestInitialize()
        {
            _post = new PostImpl();
        }

        [TestMethod]
        public void GetAllPostTest()
        {
            var count = _post.GetAll().Count();
            Assert.IsTrue(count >= 0);
        }

        [TestMethod]
        public void PostInsertTest()
        {
            var editPost = new PostEdit
            {
                Image = "",
                Author = "",
                WorkflowStateId = 1,
                CategoryId = 1,
                Status = 1,
                CreatedBy = 1,
                ModifiedBy = 1,

                Title_SEO = "ABC",
                Canonical = "ABC",
                BreadcrumbsTitle = "",
                MetaRobotIndex = 1,
                MetaRobotFollow = 1,
                MetaRobotAdvanced = 1,

                LanguageId = 1,
                Title_Trans = "",
                Decription_Trans = "",
                Detail = "",
                Tag = "",

                IdPostStateHis = 1,
                UserId = 1,
                Note = ""
            };
            var list = new List<PostEdit>();
            list.Add(editPost);
            var flag = _post.PostTransaction(list, 'I');
            Assert.IsTrue(flag);
        }
    }
}
