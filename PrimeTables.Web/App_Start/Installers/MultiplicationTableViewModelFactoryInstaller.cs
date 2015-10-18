using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using PrimeTables.Web.ModelProviders.Number;
using PrimeTables.Web.Services.Number;
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
            container.Register(
                Component.For<IMultiplicationTableCalculator>().ImplementedBy<MultiplicationTableCalculator>(),

                Component.For<IMultiplicationTableViewModelFactory>()
                .ImplementedBy<MultiplicationTableViewModelFactory>()
                .DependsOn(Dependency.OnValue(typeof(IDictionary<SequenceType, ISequenceGenerator>), new Dictionary<SequenceType, ISequenceGenerator>()
                {
                    /*Todo resolve from container*/
                    { SequenceType.Naturals, new NaturalsSequenceGenerator() },
                    { SequenceType.Primes, new PrimesSequenceGenerator() }
                })));
        }
    }
}