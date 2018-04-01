[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(collectLoad.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(collectLoad.App_Start.NinjectWebCommon), "Stop")]

namespace collectLoad.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Extensions.Conventions;
    using Ninject.Planning.Bindings.Resolvers;
    using Ninject.Components;
    using Ninject.Infrastructure;
    using Ninject.Planning.Bindings;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using common;
    using Adaptor;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {

            StandardKernel kernel = null;
            try
            {
                kernel = new StandardKernel();
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                kernel.Components.Add<IBindingResolver, ContravariantBindingResolver>();
              //  kernel.Bind(scan => scan.FromAssemblyContaining<IMediator>().SelectAllClasses().BindDefaultInterface());
              //  kernel.Bind(scan => scan.FromAssemblyContaining<IApplicantLookupService>().SelectAllClasses().BindAllInterfaces());
             //   kernel.Bind<SingleInstanceFactory>().ToMethod(ctx => t => ctx.Kernel.Get(t));
              //  kernel.Bind<MultiInstanceFactory>().ToMethod(ctx => t => ctx.Kernel.GetAll(t));
                //  DependencyResolver.SetResolver(new mvc4.Logic.NinjectDependencyResolver(kernel));
                return kernel;
            }
            catch(Exception ex)
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IBook>().To<BookRepo>();
        }        
    }
    public class ContravariantBindingResolver : NinjectComponent, IBindingResolver
    {
        /// <summary>
        /// Returns any bindings from the specified collection that match the specified service.
        /// </summary>
        public IEnumerable<IBinding> Resolve(Multimap<Type, IBinding> bindings, Type service)
        {
            if (service.IsGenericType)
            {
                var genericType = service.GetGenericTypeDefinition();
                var genericArguments = genericType.GetGenericArguments();
                if (genericArguments.Count() == 1
                 && genericArguments.Single().GenericParameterAttributes.HasFlag(GenericParameterAttributes.Contravariant))
                {
                    var argument = service.GetGenericArguments().Single();
                    var matches = bindings.Where(kvp => kvp.Key.IsGenericType
                                                           && kvp.Key.GetGenericTypeDefinition().Equals(genericType)
                                                           && kvp.Key.GetGenericArguments().Single() != argument
                                                           && kvp.Key.GetGenericArguments().Single().IsAssignableFrom(argument))
                        .SelectMany(kvp => kvp.Value);
                    return matches;
                }
            }

            return Enumerable.Empty<IBinding>();
        }
    }
}
