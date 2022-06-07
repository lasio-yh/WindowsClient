using System;
using Microsoft.Practices.Unity;
using Plugin.AccordNet.ViewModels;
using Plugin.AccordNet.Views;
using Prism.Modularity;
using Prism.Mvvm;

namespace Plugin.AccordNet
{
    public class ModuleAccordNet : IModule
    {
        private readonly IUnityContainer _container;

        public ModuleAccordNet(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException($"{nameof(container)}");
            }

            _container = container;
        }

        public void Initialize()
        {
            //_container.RegisterType<InterfaceName, ClassName>();


        }
    }
}