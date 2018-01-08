﻿using AutoMapper;
using PatientPortal.API.SPA.ViewModels;
using PatientPortal.Domain.Utilities;
using PatientPortal.IRepository.SPA;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PatientPortal.Domain.Models.CORE;
using PatientPortal.Utility.Email;
using PatientPortal.Domain.Caching.Redis.StackExchange;

namespace PatientPortal.API.SPA.Controllers
{
    public class ConfigurationController : ApiController
    {
        private readonly IConfigurationRepo _iConfigurationRepo;
        private RedisCacheService redisCache = new RedisCacheService();


        public ConfigurationController(IConfigurationRepo iConfigurationRepo)
        {
            this._iConfigurationRepo = iConfigurationRepo;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var result = redisCache.Get<ConfigurationViewModel>(1);
                if(result == null)
                {
                    var data = _iConfigurationRepo.Get(GlobalVariables.Id_Configuration);
                    result = Mapper.Map<ConfigurationViewModel>(data);

                    //MemoryCacheObject.CacheObject(ObjectCacheProfile.CACHE_SPA_CONFIG, result);
                    redisCache.Add<ConfigurationViewModel>(result);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // Configuration mail box
        private const string HostName = "smtp.gmail.com";
        //Gmail SMTP port (TLS): 587
        //Gmail SMTP port (SSL): 465
        private const int PortNumber = 587;
        private const string NetworkCredentialUserName = "patientportalfpt@gmail.com";
        private const string NetworkCredentialPassword = "P@sswordFPT";
        private const bool IsSSL = true;

        [HttpPost]
        public HttpResponseMessage SendMail(Mail mail)
        {
            try
            {
                var config = new MailSetting
                {
                    Port = PortNumber,
                    Host = HostName,
                    Email = NetworkCredentialUserName,
                    Pwd = NetworkCredentialPassword,
                    IsSSL = IsSSL
                };
                if (ModelState.IsValid)
                {
                    var result = Mailer.Send(config, mail);
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}