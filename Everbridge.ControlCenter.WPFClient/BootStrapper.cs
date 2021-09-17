using Everbridge.ControlCenter.DoorControl;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Everbridge.ControlCenter.WPFClient
{
    public class BootStrapper : PrismBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void InitializeModules()
        {
            base.InitializeModules();
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            Type moduleDoorControlType = typeof(DoorControlModule);
            moduleCatalog.AddModule(
            new ModuleInfo()
            {
                ModuleName = moduleDoorControlType.Name,
                ModuleType = moduleDoorControlType.AssemblyQualifiedName
            });

            base.ConfigureModuleCatalog(moduleCatalog);
        }
    }
}
