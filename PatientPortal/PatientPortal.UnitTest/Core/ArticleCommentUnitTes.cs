using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientPortal.Domain.Models.CORE;
using PatientPortal.DataAccess.CORE;
using System.Collections.Generic;
using PatientPortal.DataAccess.Repo.CORE;

namespace PatientPortal.UnitTest.Core
{
    [TestClass]
    public class ArticleCommentUnitTes
    {
        public IArticleComment _articleCommentImpl;
        [TestInitialize]
        public void TestInitialize()
        {
            //_articleCommentImpl = new ArticleCommentImpl();
        }

        //[TestMethod]
        //public void ArticleCommentGetAll()
        //{
        //    var count = _articleCommentImpl.Query().Count;
        //    Assert.IsTrue(count > 0);
        //}

        //[TestMethod]
        //public void ArticleCommentInsert()
        //{
        //    var list = new List<ArticleComment>()
        //    {
        //        new ArticleComment {
        //            ArticleId = 1,
        //            Detail = "",
        //            CreatedUser = 1,
        //            Status = 1
        //        }
        //    };

        //    var flag = _articleCommentImpl.Transaction(list, 'I');
        //    Assert.IsTrue(flag);
        //}
    }
}
