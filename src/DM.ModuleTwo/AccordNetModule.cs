using System;
using Microsoft.Practices.Unity;
using Prism.Modularity;

namespace Plugin.AccordNet
{
    public class AccordNetModule : IModule
    {
        private readonly IUnityContainer _container;

        public AccordNetModule(IUnityContainer container)
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