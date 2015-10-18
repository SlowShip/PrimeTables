using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PrimeTables.Web.UnitTests.Setup.Autofixture.Customizations
{
    // Fix for autofixture bug. See:
    // http://stackoverflow.com/questions/14985930/autofixture-fails-to-createanonymous-mvc-controller
    public class MvcControllerCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<ControllerContext>(c => c.Without(x => x.DisplayMode));
        }
    }
}
