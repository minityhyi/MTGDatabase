using Autofac;
using magicDatabase.Commands;
using System.Reflection;

namespace magicDatabase.DependencyConventions
{
    public static class CommandConvensions
    {
        public static List<Type> GetCommands()
        {
            return Assembly.GetCallingAssembly()
                .GetTypes()
                .Where(type => typeof(ICommand).IsAssignableFrom(type))
                .Where(t => t != typeof(ISyncCommand) && t != typeof(ICommand))
                .ToList();
        }

        public static void RegisterCommands(this ContainerBuilder builder)
        {
            builder.RegisterType<SearchCard>().Named<ICommand>(nameof(SearchCard));
            builder.RegisterType<CreateDeck>().Named<ICommand>(nameof(CreateDeck));
            builder.RegisterType<DeckList>().Named<ICommand>(nameof(DeckList));
            builder.RegisterType<DeleteDeck>().Named<ICommand>(nameof(DeleteDeck));
            builder.RegisterType<Help>().Named<ICommand>(nameof(Help));
        }
    }
}
