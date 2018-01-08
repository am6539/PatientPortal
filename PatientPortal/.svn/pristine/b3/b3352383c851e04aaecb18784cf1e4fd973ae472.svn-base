using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using PatientPortal.API.Identity.Models;
using PatientPortal.API.Identity.Providers;
using PatientPortal.API.Identity.Results;
using System.Linq;
using PatientPortal.API.Identity.Common;
using System.Data.Entity.Core.Objects;

namespace PatientPortal.API.Identity.Controllers
{
    [Authorize]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private const string LocalLoginProvider = "Local";
        private ApplicationUserManager _userManager;
        private ApplicationDbContext db = new ApplicationDbContext();

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager,
            ISecureDataFormat<AuthenticationTicket> accessTokenFormat)
        {
            UserManager = userManager;
            AccessTokenFormat = accessTokenFormat;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        #region QueriesCompiled
        //static readonly Func<ApplicationDbContext, IQueryable<UserListViewModel>> compiledQueryUsers =
        //    CompiledQuery.Compile<ApplicationDbContext, IQueryable<UserListViewModel>>(
        //    ctx => ctx.Users.
        //             Where(r => !(r.Name.ToLower().Contains("crd")) && (r.PatientId == null || r.PatientId.Length < 1))
        //             .Select(a => new UserListViewModel
        //             {
        //                 Id = a.Id,
        //                 Name = a.Name,
        //                 UserName = a.UserName,
        //                 Email = a.Email,
        //                 Image = a.Image,
        //                 GroupMember = (a.IsAdmin ? "Quản trị" : (a.IsDoctor ? "Bác sĩ" : "Nhân viên"))
        //             })
        //);

        #endregion
        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }

        //GET api/Account/GetListUser
        [Route("GetListUser")]
        public List<UserListViewModel> GetListUser()
        {
            try
            {
                //Only local data
                var data = db.Users.Where(r => !(r.UserName.ToLower().Contains("crd")) && (r.PatientId == null || r.PatientId.Length < 1)).Select(a => new UserListViewModel {
                    Id = a.Id,
                    Name = a.Name,
                    UserName = a.UserName,
                    Email = a.Email,
                    Image = a.Image,
                    GroupMember = (a.IsAdmin ? "Quản trị": (a.IsDoctor ? "Bác sĩ" : "Nhân viên"))
                }).ToList();
                return data;
 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET api/Account/UserInfo
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("UserInfo")]
        public UserInfoViewModel GetUserInfo()
        {
            ExternalLoginData externalLogin = ExternalLoginData.FromIdentity(User.Identity as ClaimsIdentity);

            return new UserInfoViewModel
            {
                Email = User.Identity.GetUserName(),
                HasRegistered = externalLogin == null,
                LoginProvider = externalLogin != null ? externalLogin.LoginProvider : null
            };
        }

        // POST api/Account/Logout
        [Route("Logout")]
        public IHttpActionResult Logout()
        {
            Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            return Ok();
        }

        // GET api/Account/GetSecretInfo
        [Route("GetSecretInfo")]
        public async Task<UserSecretInfoViewModel> GetSecretInfo()
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

            if (user == null)
            {
                return null;
            }
            try {
                var data = new UserSecretInfoViewModel
                {
                    Email = user.Email,
                    Name = (user.Name == null ? user.UserName : user.Name),
                    NameIdentifier = user.Id,
                    Image = user.Image,
                    PatientId = user.PatientId
                };
                return data;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        // GET api/Account/EditUser
        [Route("GetInfoEdit")]
        public async Task<UserEditViewModel> GetInfoEdit(Guid userId)
        {
            var user = await UserManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return null;
            else
            {
                try
                {
                    var roles = await UserManager.GetRolesAsync(userId.ToString());
                    string[] roleNames = new string[roles.Count];
                    if (roles != null)
                    {
                        roles.CopyTo(roleNames, 0);
                    }

                    var data = new UserEditViewModel
                    {
                        Email = user.Email,
                        Name = user.Name,
                        PatientId = user.PatientId,
                        DoB = user.DoB,
                        Gender = user.Gender,
                        Image = user.Image,
                        OrganizationId = user.OrganizationId,
                        IsDoctor = user.IsDoctor,
                        Tag = user.Tags,
                        RoleName = roleNames,
                        PhoneNumber = user.PhoneNumber,
                        Address = user.Address,
                        PersonalId = user.PersonalId,
                        InsuranceId = user.InsuranceId
                    };
                    return data;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        // GET api/Account/ManageInfo?returnUrl=%2F&generateState=true
        [Route("ManageInfo")]
        public async Task<ManageInfoViewModel> GetManageInfo(string returnUrl, bool generateState = false)
        {
            IdentityUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

            if (user == null)
            {
                return null;
            }

            List<UserLoginInfoViewModel> logins = new List<UserLoginInfoViewModel>();

            foreach (IdentityUserLogin linkedAccount in user.Logins)
            {
                logins.Add(new UserLoginInfoViewModel
                {
                    LoginProvider = linkedAccount.LoginProvider,
                    ProviderKey = linkedAccount.ProviderKey
                });
            }

            if (user.PasswordHash != null)
            {
                logins.Add(new UserLoginInfoViewModel
                {
                    LoginProvider = LocalLoginProvider,
                    ProviderKey = user.UserName,
                });
            }

            return new ManageInfoViewModel
            {
                LocalLoginProvider = LocalLoginProvider,
                Email = user.UserName,
                Logins = logins,
                ExternalLoginProviders = GetExternalLogins(returnUrl, generateState)
            };
        }

        //POST api/Account/UpdateUserInfo
        [Route("UpdateUserInfo")]
        public async Task<IHttpActionResult> UpdateUserInfo(UpdateUserInfoBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(string.IsNullOrEmpty(model.Id))
                return BadRequest();

            try
            {
                var user = await UserManager.FindByIdAsync(model.Id);
                user.Name = model.Name;
                user.Gender = model.Gender;
                user.DoB = model.DoB;
                user.IsDoctor = model.IsDoctor;
                user.Image = model.Image;
                //user.UserName = model.Email;
                user.Email = model.Email;

                IdentityResult result = await UserManager.UpdateAsync(user);

                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }
                else
                {
                    AddUserRole(user.Id, model.RoleName);
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("UpdateBasicUserInfo")]
        public async Task<IHttpActionResult> UpdateBasicUserInfo(UpdateUserInfoBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (string.IsNullOrEmpty(model.Id))
                return BadRequest();

            try
            {
                var user = await UserManager.FindByIdAsync(model.Id);
                user.Name = model.Name;
                user.Gender = model.Gender;
                user.DoB = model.DoB;
                user.IsDoctor = model.IsDoctor;
                user.Image = model.Image;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                user.Address = model.Address;
                user.PersonalId = model.PersonalId;
                user.InsuranceId = model.InsuranceId;

                IdentityResult result = await UserManager.UpdateAsync(user);

                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }
                else
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //POST api/Account/UpdateUserInfo
        [Route("DeleteUser")]
        [HttpPost]
        public async Task<IHttpActionResult> DeleteUser(DeleteUserBindingModel model)
        {
            if (string.IsNullOrEmpty(model.Id))
                return BadRequest();

            try
            {
                var user = await UserManager.FindByIdAsync(model.Id);

                IdentityResult result = await UserManager.DeleteAsync(user);

                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }
                else
                {
                    UserManager.RemoveFromRoles(model.Id, UserManager.GetRoles(model.Id).ToArray());
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/Account/ChangePassword
        [Route("ChangePassword")]
        public async Task<IHttpActionResult> ChangePassword(ChangePasswordBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword,
                model.NewPassword);
            
            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        // POST api/Account/SetPassword
        [Route("SetPassword")]
        public async Task<IHttpActionResult> SetPassword(SetPasswordBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        // POST api/Account/AddExternalLogin
        [Route("AddExternalLogin")]
        public async Task<IHttpActionResult> AddExternalLogin(AddExternalLoginBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);

            AuthenticationTicket ticket = AccessTokenFormat.Unprotect(model.ExternalAccessToken);

            if (ticket == null || ticket.Identity == null || (ticket.Properties != null
                && ticket.Properties.ExpiresUtc.HasValue
                && ticket.Properties.ExpiresUtc.Value < DateTimeOffset.UtcNow))
            {
                return BadRequest("External login failure.");
            }

            ExternalLoginData externalData = ExternalLoginData.FromIdentity(ticket.Identity);

            if (externalData == null)
            {
                return BadRequest("The external login is already associated with an account.");
            }

            IdentityResult result = await UserManager.AddLoginAsync(User.Identity.GetUserId(),
                new UserLoginInfo(externalData.LoginProvider, externalData.ProviderKey));

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        // POST api/Account/RemoveLogin
        [Route("RemoveLogin")]
        public async Task<IHttpActionResult> RemoveLogin(RemoveLoginBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result;

            if (model.LoginProvider == LocalLoginProvider)
            {
                result = await UserManager.RemovePasswordAsync(User.Identity.GetUserId());
            }
            else
            {
                result = await UserManager.RemoveLoginAsync(User.Identity.GetUserId(),
                    new UserLoginInfo(model.LoginProvider, model.ProviderKey));
            }

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        // GET api/Account/ExternalLogin
        [OverrideAuthentication]
        [HostAuthentication(DefaultAuthenticationTypes.ExternalCookie)]
        [AllowAnonymous]
        [Route("ExternalLogin", Name = "ExternalLogin")]
        public async Task<IHttpActionResult> GetExternalLogin(string provider, string error = null)
        {
            if (error != null)
            {
                return Redirect(Url.Content("~/") + "#error=" + Uri.EscapeDataString(error));
            }

            if (!User.Identity.IsAuthenticated)
            {
                return new ChallengeResult(provider, this);
            }

            ExternalLoginData externalLogin = ExternalLoginData.FromIdentity(User.Identity as ClaimsIdentity);

            if (externalLogin == null)
            {
                return InternalServerError();
            }

            if (externalLogin.LoginProvider != provider)
            {
                Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                return new ChallengeResult(provider, this);
            }

            ApplicationUser user = await UserManager.FindAsync(new UserLoginInfo(externalLogin.LoginProvider,
                externalLogin.ProviderKey));

            bool hasRegistered = user != null;

            if (hasRegistered)
            {
                Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                
                 ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(UserManager,
                    OAuthDefaults.AuthenticationType);
                ClaimsIdentity cookieIdentity = await user.GenerateUserIdentityAsync(UserManager,
                    CookieAuthenticationDefaults.AuthenticationType);

                AuthenticationProperties properties = ApplicationOAuthProvider.CreateProperties(user.UserName);
                Authentication.SignIn(properties, oAuthIdentity, cookieIdentity);
            }
            else
            {
                IEnumerable<Claim> claims = externalLogin.GetClaims();
                ClaimsIdentity identity = new ClaimsIdentity(claims, OAuthDefaults.AuthenticationType);
                Authentication.SignIn(identity);
            }

            return Ok();
        }

        // GET api/Account/ExternalLogins?returnUrl=%2F&generateState=true
        [AllowAnonymous]
        [Route("ExternalLogins")]
        public IEnumerable<ExternalLoginViewModel> GetExternalLogins(string returnUrl, bool generateState = false)
        {
            IEnumerable<AuthenticationDescription> descriptions = Authentication.GetExternalAuthenticationTypes();
            List<ExternalLoginViewModel> logins = new List<ExternalLoginViewModel>();

            string state;

            if (generateState)
            {
                const int strengthInBits = 256;
                state = RandomOAuthStateGenerator.Generate(strengthInBits);
            }
            else
            {
                state = null;
            }

            foreach (AuthenticationDescription description in descriptions)
            {
                ExternalLoginViewModel login = new ExternalLoginViewModel
                {
                    Name = description.Caption,
                    Url = Url.Route("ExternalLogin", new
                    {
                        provider = description.AuthenticationType,
                        response_type = "token",
                        client_id = Startup.PublicClientId,
                        redirect_uri = new Uri(Request.RequestUri, returnUrl).AbsoluteUri,
                        state = state
                    }),
                    State = state
                };
                logins.Add(login);
            }

            return logins;
        }

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(RegisterBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!IsExistUser(model.Email))
            {
                var user = new ApplicationUser()
                {
                    Name = model.Name,
                    Gender = model.Gender,
                    DoB = model.DoB,
                    IsDoctor = model.IsDoctor,
                    Image = model.Image,
                    UserName = model.Email,
                    Email = model.Email
                };
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }
                else
                {
                    AddUserRole(user.Id, model.RoleName);
                    return Ok();
                }
            }
            else
            {
                return GetErrorResult(IdentityResult.Failed(UserStatus.IsUsed.ToString()));
            }
        }

        // POST api/Account/RegisterExternal
        [OverrideAuthentication]
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("RegisterExternal")]
        public async Task<IHttpActionResult> RegisterExternal(RegisterExternalBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var info = await Authentication.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return InternalServerError();
            }

            var user = new ApplicationUser() { UserName = model.Email, Email = model.Email };

            IdentityResult result = await UserManager.CreateAsync(user);
            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            result = await UserManager.AddLoginAsync(user.Id, info.Login);
            if (!result.Succeeded)
            {
                return GetErrorResult(result); 
            }
            return Ok();
        }

        private bool IsExistUser(string email)
        {
            try
            {
                var result = UserManager.FindByEmail(email);
                if (result != null)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AddUserRole(string userId, string[] roles)
        {
            try
            {
                UserManager.RemoveFromRoles(userId, UserManager.GetRoles(userId).ToArray());
                foreach(var item in roles)
                {
                    UserManager.AddToRole(userId, item);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }

            base.Dispose(disposing);
        }

        #region Helpers

        private IAuthenticationManager Authentication
        {
            get { return Request.GetOwinContext().Authentication; }
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }

                    var query = from state in ModelState.Values
                                from error in state.Errors
                                select error.ErrorMessage;

                    var errorList = query.ToList();
                    var responseMsg = Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError,errorList);
                    IHttpActionResult response = ResponseMessage(responseMsg);
                    return response;

                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                    
                }
                
            }

            return null;
        }

        private class ExternalLoginData
        {
            public string LoginProvider { get; set; }
            public string ProviderKey { get; set; }
            public string UserName { get; set; }

            public IList<Claim> GetClaims()
            {
                IList<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, ProviderKey, null, LoginProvider));

                if (UserName != null)
                {
                    claims.Add(new Claim(ClaimTypes.Name, UserName, null, LoginProvider));
                }

                return claims;
            }

            public static ExternalLoginData FromIdentity(ClaimsIdentity identity)
            {
                if (identity == null)
                {
                    return null;
                }

                Claim providerKeyClaim = identity.FindFirst(ClaimTypes.NameIdentifier);

                if (providerKeyClaim == null || String.IsNullOrEmpty(providerKeyClaim.Issuer)
                    || String.IsNullOrEmpty(providerKeyClaim.Value))
                {
                    return null;
                }

                if (providerKeyClaim.Issuer == ClaimsIdentity.DefaultIssuer)
                {
                    return null;
                }

                return new ExternalLoginData
                {
                    LoginProvider = providerKeyClaim.Issuer,
                    ProviderKey = providerKeyClaim.Value,
                    UserName = identity.FindFirstValue(ClaimTypes.Name)
                };
            }
        }

        private static class RandomOAuthStateGenerator
        {
            private static RandomNumberGenerator _random = new RNGCryptoServiceProvider();

            public static string Generate(int strengthInBits)
            {
                const int bitsPerByte = 8;

                if (strengthInBits % bitsPerByte != 0)
                {
                    throw new ArgumentException("strengthInBits must be evenly divisible by 8.", "strengthInBits");
                }

                int strengthInBytes = strengthInBits / bitsPerByte;

                byte[] data = new byte[strengthInBytes];
                _random.GetBytes(data);
                return HttpServerUtility.UrlTokenEncode(data);
            }
        }

        #endregion
    }
}
