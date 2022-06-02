using System;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Core.Services;
using Core.Contracts;

namespace Core
{
    public class ModuleCore : IModule
    {
        private readonly IUnityContainer _container;

        public ModuleCore(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException($"{nameof(container)}");
            }

            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterType<ICustomerService, CustomerService>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IFileService, FileService>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IFTPService, FTPService>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IHTTPService, HTTPService>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ISerialService, SerialService>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ITCPService, TCPService>(new ContainerControlledLifetimeManager());
            //_container.RegisterType<IUDPService, UDPService>(new ContainerControlledLifetimeManager());
        }
    }
}