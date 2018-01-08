using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using PatientPortal.API.Core.Models;
using PatientPortal.Domain.Models.CORE;
using PatientPortal.Domain.Models.CORE.Enum;
using PatientPortal.IRepository.CORE;
using PatientPortal.Provider.Models;
using PatientPortal.Utility.Email;

namespace PatientPortal.API.Core.Controllers
{
    [AuthorizeRoles]
    public class EmailMarketingController : ApiController
    {
        private readonly IEmailMarketingRepo _emailMarketingRepo;
        private readonly IUserRepo _userRepo;
        public EmailMarketingController(IEmailMarketingRepo emailMarketingRepo, IUserRepo userRepo)
        {
            this._emailMarketingRepo = emailMarketingRepo;
            this._userRepo = userRepo;
        }

        #region GET
        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<EmailMarketingViewModel>> Get()
        {
            var list = new List<string> { "id" };
            var para = APIProvider.APIDefaultParameter(list, 0);

            var source = await _emailMarketingRepo.Query(para);
            var dest = Mapper.Map<List<EmailMarketingViewModel>>(source ?? new List<EmailMarketing>());

            return dest;
        }

        /// <summary>
        /// Filter by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<EmailMarketingViewModel> Get(byte id)
        {
            var list = new List<string> { "id" };
            var para = APIProvider.APIDefaultParameter(list, id);

            var source = await _emailMarketingRepo.SingleQuery(para);
            var dest = Mapper.Map<EmailMarketingViewModel>(source);

            return dest;
        }
        #endregion

        #region POST

        /// <summary>
        /// Transaction data: Insert/Update/Delete
        /// </summary>
        /// <param name="model"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<int> Transaction(EmailMarketingViewModel model, char action)
        {
            if (action == 'S')
            {
                await SendMail(model);
                return 1;
            }
            else
            {
                var data = Mapper.Map<EmailMarketing>(model);
                return await _emailMarketingRepo.Transaction(data, action);
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> SendMail(EmailMarketingViewModel model)
        {
            try
            {
                var message = new MailMessage();
                //Get list email by EmailGroupType
                var listEmail = await GetEmailByGroupType(model.EmailGroupType);
                
                
                //Mail from
                var config = new MailSetting
                {
                    Port = 587,
                    Host = "smtp.gmail.com",
                    Email = "patientportalfpt@gmail.com",
                    Pwd = "P@sswordFPT",
                    IsSSL = true
                };

                foreach (var email in listEmail)
                {
                    //Mail to
                    var mail = new Mail
                    {
                        Email = email,
                        Subject = model.Name,
                        Body = model.Detail
                    };
                    Mailer.ServerSendMail(config, mail);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public async Task<List<string>> GetEmailByGroupType(string groupType)
        {
            var list = new List<string>();
            var fields = new List<string> { "GroupType" };
            var para = APIProvider.APIDefaultParameter(fields, groupType);
            var users = await _userRepo.GetUsersByGroupType(para);
            foreach (var user in users)
            {
                list.Add(user.Email);
            }
            return list;
        }
        #endregion
    }
}