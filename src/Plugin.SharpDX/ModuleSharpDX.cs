using System;
using Microsoft.Practices.Unity;
using Prism.Modularity;

namespace Plugin.SharpDX
{
    public class ModuleSharpDX : IModule
    {
        private readonly IUnityContainer _container;
        
        public ModuleSharpDX(IUnityContainer container)
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