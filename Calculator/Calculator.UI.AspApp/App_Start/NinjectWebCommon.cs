using Calculator.DataAccess.Xml;
using Calculator.Domain.AbstractRepositories;
using Calculator.Domain.Services;
using Calculator.Infrastructure.BootStrapper;
using Calculator.Presentation.AbstractPresenters;
using Calculator.Presentation.Presenter;
using Calculator.Presentation.Presenter.AbstractServices;
using Calculator.Utils;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Calculator.UI.AspApp.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(Calculator.UI.AspApp.App_Start.NinjectWebCommon), "Stop")]

namespace Calculator.UI.AspApp.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = NinjectBootstrapper.CreateKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            return kernel;
        }
            
    }
}
