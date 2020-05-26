using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dependencies;
using System.Web.Http.Validation;
using BLL.Interfaces;
using BLL.Services;
using Ninject;
using Ninject.Modules;
using Ninject.Syntax;
using Ninject.Web.WebApi.Filter;

namespace WebSchedule
{
    public class WebApiNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITeacherService>().To<TeacherService>();
            Bind<ILessonService>().To<LessonService>();
            Bind<IGroupService>().To<GroupService>();
            Bind<DefaultFilterProviders>().ToConstant(new DefaultFilterProviders(GlobalConfiguration.Configuration.Services.GetFilterProviders()));
            Bind<DefaultModelValidatorProviders>().ToConstant(new DefaultModelValidatorProviders(GlobalConfiguration.Configuration.Services.GetServices(typeof(ModelValidatorProvider)).Cast<ModelValidatorProvider>()));
        }
    }
    public class NinjectScope : IDependencyScope
    {
        IResolutionRoot resolver;

        public NinjectScope(IResolutionRoot resolver)
        {
            this.resolver = resolver;
        }

        public object GetService(Type serviceType)
        {
            if (resolver == null)
                throw new ObjectDisposedException("this", "This scope has been disposed");

            return resolver.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (resolver == null)
                throw new ObjectDisposedException("this", "This scope has been disposed");

            return resolver.GetAll(serviceType);
        }

        public void Dispose()
        {
            IDisposable disposable = resolver as IDisposable;
            if (disposable != null)
                disposable.Dispose();

            resolver = null;
        }
    }

    public class NinjectResolver : NinjectScope, IDependencyResolver
    {
        IKernel kernel;

        public NinjectResolver(IKernel kernel) : base(kernel)
        {
            this.kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectScope(kernel.BeginBlock());
        }
    }

}