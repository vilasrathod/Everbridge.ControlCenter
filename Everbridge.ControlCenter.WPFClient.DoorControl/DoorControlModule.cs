using Everbridge.ControlCenter.DoorControl.Services;
using Everbridge.ControlCenter.DoorControl.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Everbridge.ControlCenter.DoorControl
{
    public class DoorControlModule : IModule
    {
        private readonly IRegionViewRegistry _regionViewRegistry = null;

        public DoorControlModule(IRegionViewRegistry regionViewRegistry)
        {
            _regionViewRegistry = regionViewRegistry;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionViewRegistry.RegisterViewWithRegion("DoorControlRegion", typeof(DoorControlView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IDoorControlService, DoorControlService>();
        }
    }
}
