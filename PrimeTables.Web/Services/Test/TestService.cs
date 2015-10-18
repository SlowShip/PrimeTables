using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeTables.Web.Services.Test
{
    // Todo kill this

    public interface ITestService
    {
    }

    public class TestService : ITestService
    {
    }

    public class TestServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<ITestService>().ImplementedBy<TestService>()
                );
        }
    }
}