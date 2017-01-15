using System;
using System.Runtime.Remoting.Messaging;
using Microsoft.Practices.Unity;
using SocialWebsiteStudent.Controllers;
using SocialWebsiteStudent.Domain.DatabaseContext;
using SocialWebsiteStudent.Domain.Repository.Implementation;
using SocialWebsiteStudent.Domain.Repository.Interface;

namespace SocialWebsiteStudent
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());
            container.RegisterType<IApplicationDbContext, ApplicationDbContext>(new PerRequestLifetimeManager());

            container.RegisterType<IPostRepository, PostRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IMessageRepository, MessageRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IAdminRepository, AdminRepository>(new PerRequestLifetimeManager());
            container.RegisterType<INotificationRepository, NotificationRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IUserRepository, UserRepository>(new PerRequestLifetimeManager());
            container.RegisterType<ITagRepository, TagRepository>(new PerRequestLifetimeManager());
            container.RegisterType<ISearchRepository, SearchRepository>(new PerRequestLifetimeManager());


        }
    }
}
