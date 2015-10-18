using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using PrimeTables.Web.ModelProviders.Number;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeTables.Web.App_Start.Installers
{
    public class MultiplicationTableViewModelFactoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IMultiplicationTableViewModelFactory>().ImplementedBy<TestMultiplicationTableViewModelFactory>());
        }
    }
}