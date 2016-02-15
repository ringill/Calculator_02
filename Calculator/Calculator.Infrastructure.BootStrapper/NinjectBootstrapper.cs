using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.DataAccess.Xml;
using Calculator.Domain.AbstractRepositories;
using Calculator.Domain.Services;
using Calculator.Presentation.AbstractPresenters;
using Calculator.Presentation.Presenter;
using Calculator.Presentation.Presenter.AbstractServices;
using Calculator.Utils;
using Ninject;

namespace Calculator.Infrastructure.BootStrapper
{
    public static class NinjectBootstrapper
    {
        public static NinjectDependencyResolver GetDependencyResolver()
        {
            return new NinjectDependencyResolver(CreateKernel());
        }

        /// <summary>
        /// Возвращает новый экземпляр формы
        /// </summary>
        /// <typeparam name="T">тип формы</typeparam>
        /// <returns>экземпляр формы</returns>
        public static T GetForm<T>()
        {
            return CreateKernel().Get<T>();
        }

        /// <summary>
        /// Создает контейнер
        /// </summary>
        /// <returns>контейнер</returns>
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Регистрируем модули
        /// </summary>
        /// <param name="kernel">контейнер</param>
        private static void RegisterServices(IKernel kernel)
        {
            //Регистрируем презентер
            kernel.Bind<IPresenter>().To<Presenter>().InSingletonScope();

            //Регистрируем CalculationService
            kernel.Bind<ICalculationService>().To<CalculationService>().InSingletonScope();

            //Регистрируем утилитарную службу даты-времени
            kernel.Bind<IDateTimeService>().To<DateTimeService>().InSingletonScope();

            //Регистрируем службу работы с хранилищем
            kernel.Bind<IStorageService>().To<StorageService>().InSingletonScope();

            //Привязываемся к конкретному хранилищу
            //SQL Server через ADO.NET
            //container.RegisterType<IRepository,SqlRepository>(new ContainerControlledLifetimeManager());

            //SQL Server через Entity Framework
            //container.RegisterType<IRepository, EFRepository>(new ContainerControlledLifetimeManager());

            //XML файл
            kernel.Bind<IRepository>().To<XmlRepository>().InSingletonScope();
        }    
    }
}
