using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientPortal.API.SPA.ViewModels
{
    public class PostsViewModel
    {
        public PostViewModel PostViewModel { get; set; }
        public List<PostListViewModel> lstPostListViewModel { get; set; }
    }
}