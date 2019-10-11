using Microsoft.Extensions.DependencyInjection;

namespace royalmail.trail.Configuration
{
    public static class ServiceLocator
    {
        private static ServiceProvider _container;
        private static readonly ServiceCollection BuilderServiceCollection = new ServiceCollection();

        public static void RegisterType<T>() where T : class
        {
            BuilderServiceCollection.AddTransient<T>();
        }

        public static void RegisterType<TInterface, T>() where TInterface : class where T : class, TInterface
        {
            BuilderServiceCollection.AddTransient<TInterface, T>();
        }

        public static void BuildContainer()
        {
            _container = BuilderServiceCollection.BuildServiceProvider();
        }

        public static T GetService<T>()
        {
            return _container.GetService<T>();
        }

        public static ServiceCollection ServiceCollection => BuilderServiceCollection;
    }
}