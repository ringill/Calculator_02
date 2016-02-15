using Calculator.DataAccess.EF;
using Calculator.DataAccess.Sql;
using Calculator.DataAccess.Xml;
using Calculator.Domain.AbstractRepositories;
using Calculator.Domain.Services;
using Calculator.Presentation.AbstractPresenters;
using Calculator.Presentation.Presenter;
using Calculator.Presentation.Presenter.AbstractServices;
using Calculator.Utils;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Infrastructure.BootStrapper
{
    public static class Bootstrapper
    {
        /// <summary>
        /// Возвращает новый экземпляр формы
        /// </summary>
        /// <typeparam name="T">тип формы</typeparam>
        /// <returns>экземпляр формы</returns>
        public static T GetForm<T>()
        {
            return Initialise().Resolve<T>();
        }

        /// <summary>
        /// Возвращает проинициализированный контейнер
        /// </summary>
        /// <returns></returns>
        public static IUnityContainer Initialise()
        {
            IUnityContainer container = BuildUnityContainer();

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            //Регистрируем презентер
            container.RegisterType<IPresenter, Presenter>(new ContainerControlledLifetimeManager());
            
            //Регистрируем CalculationService
            container.RegisterType<ICalculationService, CalculationService>(new ContainerControlledLifetimeManager());
            
            //Регистрируем утилитарную службу даты-времени
            container.RegisterType<IDateTimeService, DateTimeService>(new ContainerControlledLifetimeManager());
            
            //Регистрируем службу работы с хранилищем
            container.RegisterType<IStorageService, StorageService>(new ContainerControlledLifetimeManager());
            
            //Привязываемся к конкретному хранилищу
            //SQL Server через ADO.NET
            //container.RegisterType<IRepository,SqlRepository>(new ContainerControlledLifetimeManager());

            //SQL Server через Entity Framework
            //container.RegisterType<IRepository, EFRepository>(new ContainerControlledLifetimeManager());

            //XML файл
            container.RegisterType<IRepository, XmlRepository>(new ContainerControlledLifetimeManager());
        }
    }
}
