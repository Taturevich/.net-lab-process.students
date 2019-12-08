using Autofac;
using EF_Task.Repository;

namespace EF_Task.Scope
{
    public class DbScopeModule : Module
    {
        /// <summary>Override to add registrations to the container.</summary>
        /// <remarks>
        /// Note that the ContainerBuilder parameter is unique to this module.
        /// </remarks>
        /// <param name="builder">The builder through which components can be
        /// registered.</param>
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<NorthwindScopeCreator>().As<IScopeCreator>();
            builder.RegisterType<ProductCategoryService>().As<IProductCategoryService>();
            builder.RegisterGeneric(typeof(NorthwindEntityStorage<>)).As(typeof(IEntityStorage<>));
            builder.RegisterGeneric(typeof(DbScopeCollection<>)).AsImplementedInterfaces().SingleInstance();
        }
    }
}
