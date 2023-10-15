using System;
using System.Configuration;
using System.Net.Http.Headers;
using System.Net.Http;
using Unity;
using System.Data;
using Unity.Injection;
using Unity.Lifetime;
using zk4500.Abstractions.Interfaces;
using zk4500.Abstractions.IRepositories;
using zk4500.Abstractions.IServices;
using zk4500.ApiClient;
using zk4500.Implementations.Interfaces;
using zk4500.Implementations.Repositories;
using zk4500.Implementations.Services;
using zk4500.DataContext;
using zk4500.Forms;

namespace zk4500.Extensions
{
    public static class UnityConfig
    {
        [Obsolete]
        public static IUnityContainer RegisterComponents()
        {
            IUnityContainer container = new UnityContainer();

            container.RegisterType<IConfigurationService, ConfigurationService>(new ContainerControlledLifetimeManager());
            container.RegisterType<IServiceManager, ServiceManager>(new ContainerControlledLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new ContainerControlledLifetimeManager());
            container.RegisterType(typeof(IBaseRepository<>), typeof(BaseRepository<>), new ContainerControlledLifetimeManager());
            container.RegisterType<IPatientRepository, PatientRepository>(new ContainerControlledLifetimeManager());
            container.RegisterType<IFingerPrintRepository, FingerPrintRepository>(new ContainerControlledLifetimeManager());
            container.RegisterType<IPatientService, PatientService>(new ContainerControlledLifetimeManager());
            container.RegisterType<IFingerPrintService, FingerPrintService>(new ContainerControlledLifetimeManager());
            container.RegisterType<IAuthApiClient, AuthApiClient>(new ContainerControlledLifetimeManager());

            container.RegisterType<IDbConnection>(new InjectionFactory(c => new DapperContext(c.Resolve<IConfigurationService>()).CreateConnection()));

            container.RegisterInstance(CreateHttpClient());

            container.Resolve<Main>();
            container.Resolve<Login>();

            return container;
        }

        private static HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiBaseUrl"]);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.Timeout = TimeSpan.FromMinutes(10);

            return httpClient;
        }
    }
}
