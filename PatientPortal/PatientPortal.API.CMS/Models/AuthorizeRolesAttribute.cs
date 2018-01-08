using Microsoft.AspNet.Identity;
using PatientPortal.IRepository.Authorize;
using PatientPortal.Provider.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace PatientPortal.API.CMS.Models
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public IUserAuthorizationRepo UserAuthorization { get; set; }

        //Custom named parameters for annotation
        public string ResourceKey { get; set; }

        public string OperationKey { get; set; }

        private HttpActionContext HttpUnauthorizedResponse(HttpActionContext actionContext)
        {
            actionContext.Response.StatusCode = HttpStatusCode.Unauthorized;
            actionContext.Response.Content = new StringContent("You have no enough permissions to request this resource", System.Text.Encoding.UTF8);
            return actionContext;
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var authorize = true;
            var principalIdentity = actionContext.RequestContext.Principal.Identity;
            if (!principalIdentity.IsAuthenticated) return !authorize;

            var userId = principalIdentity.GetUserId();

            if (userId.Length > 0)
            {
                try
                {
                    if (userId == null || userId.Length < 1)
                        return !authorize;
                    if (actionContext.Request.Headers.Contains(APIConstant.XAuthorizeHeaderARS)) OperationKey = actionContext.Request.Headers.GetValues(APIConstant.XAuthorizeHeaderARS).FirstOrDefault();

                    if (OperationKey == ARS.IgnoredARS) return authorize;

                    if (OperationKey == null || OperationKey.Length < 1) OperationKey = actionContext.ActionDescriptor.ActionName;
                    ResourceKey = actionContext.ControllerContext.ControllerDescriptor.ControllerName;

                    Dictionary<string, dynamic> para = new Dictionary<string, dynamic>();
                    para.Add("UserId", userId);
                    para.Add("OperationKey", OperationKey);
                    para.Add("ResourceKey", ResourceKey);
                    para.Add("DefaultRoleInitial", APIConstant.DefaultRoleInitial);

                    // Get the request lifetime scope so you can resolve services.
                    var requestScope = actionContext.Request.GetDependencyScope();

                    // Resolve the service you want to use.
                    var service = requestScope.GetService(typeof(IUserAuthorizationRepo)) as IUserAuthorizationRepo;
                    //var task = service.CheckPermission(para);
                    authorize = Task.Run(async () => await service.CheckPermission(para)).Result;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return authorize;
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }
            else
                base.OnAuthorization(actionContext);
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            if (actionContext == null)
            {
                throw new ArgumentNullException("actionContext", "Null actionContext");
            };

            if (!actionContext.RequestContext.Principal.Identity.IsAuthenticated)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound);
                string message = "Page not found!";
                response.Content = new StringContent(message);
                actionContext.Response = response;
            }
            else
            {
                var response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                string message = "You have no enough permissions to request this resource";
                response.Content = new StringContent(message);
                actionContext.Response = response;
            }
        }
    }
}