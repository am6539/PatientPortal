﻿using Autofac;
using System.Reflection;
using System.Web;
using PatientPortal.IRepository.SPA;
using PatientPortal.Repositoty.SPA;
using PatientPortal.DataAccess.SPA;
using PatientPortal.DataAccess.Repo.SPA;
using IReCore = PatientPortal.IRepository.CORE;
using ReCore = PatientPortal.Repositoty.CORE;
using DACore = PatientPortal.DataAccess.CORE;
using IDACore = PatientPortal.DataAccess.Repo.CORE;
using PatientPortal.IRepository.Wrapper;
using PatientPortal.Repositoty.Wraper;
using PatientPortal.DataAccess.Wrapper;
using PatientPortal.DataAccess.Repo.Wrapper;
using Autofac.Integration.WebApi;

namespace PatientPortal.API.SPA
{
    public class AutofacConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = System.Web.Http.GlobalConfiguration.Configuration;

            // Register your Web API controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            //builder.RegisterWebApiFilterProvider(config);
            builder.RegisterType<PostRepoImpl>().As<IPostRepo>().InstancePerRequest();
            builder.RegisterType<PostImpl>().As<IPost>().InstancePerRequest();

            builder.RegisterType<ConfigurationRepoImpl>().As<IConfigurationRepo>().InstancePerRequest();
            builder.RegisterType<ConfigurationImpl>().As<IConfiguration>().InstancePerRequest();

            builder.RegisterType<FeatureRepoImpl>().As<IFeatureRepo>().InstancePerRequest();
            builder.RegisterType<FeatureImpl>().As<IFeature>().InstancePerRequest();

            builder.RegisterType<SliderRepoImpl>().As<ISliderRepo>().InstancePerRequest();
            builder.RegisterType<SliderImpl>().As<ISlider>().InstancePerRequest();

            builder.RegisterType<DepartmentRepoImpl>().As<IDepartmentRepo>().InstancePerRequest();
            builder.RegisterType<DepartmentImpl>().As<IDepartment>().InstancePerRequest();

            builder.RegisterType<DepartmentServicesRepoImpl>().As<IDepartmentServicesRepo>().InstancePerRequest();
            builder.RegisterType<DepartmentServicesImpl>().As<IDepartmentServices>().InstancePerRequest();

            builder.RegisterType<AdvertiseRepoImpl>().As<IAdvertiseRepo>().InstancePerRequest();
            builder.RegisterType<AdvertiseImpl>().As<IAdvertise>().InstancePerRequest();

            builder.RegisterType<AdapterPattern>().As<IAdapterPattern>().InstancePerRequest();
            builder.RegisterType<AdapterPatternRepoImpl>().As<IAdapterPatternRepo>().InstancePerRequest();

            builder.RegisterType<UserRepoImpl>().As<IUserRepo>().InstancePerRequest();
            builder.RegisterType<UserImpl>().As<IUser>().InstancePerRequest();

            builder.RegisterType<ScheduleRepoImpl>().As<IScheduleRepo>().InstancePerRequest();
            builder.RegisterType<ScheduleImpl>().As<ISchedule>().InstancePerRequest();

            builder.RegisterType<AppointmentLogRepoImpl>().As<IAppointmentLogRepo>().InstancePerRequest();
            builder.RegisterType<AppointmentLogImpl>().As<IAppointmentLog>().InstancePerRequest();

            builder.RegisterType<CategoryRepoImpl>().As<ICategoryRepo>().InstancePerRequest();
            builder.RegisterType<CategoryImpl>().As<ICategory>().InstancePerRequest();

            builder.RegisterType<GalleryRepoImpl>().As<IGalleryRepo>().InstancePerRequest();
            builder.RegisterType<GalleryImpl>().As<IGallery>().InstancePerRequest();

            builder.RegisterType<ReCore.DoctorProfileRepoImpl>().As<IReCore.IDoctorProfileRepo>();
            builder.RegisterType<DACore.DoctorProfileImpl>().As<IDACore.IDoctorProfile>();

            builder.RegisterType<QARepoImpl>().As<IQARepo>();
            builder.RegisterType<QAImpl>().As<IQA>();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }

}