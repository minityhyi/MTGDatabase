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
            builder.RegisterType<RemoveCard>().Named<ICommand>(nameof(RemoveCard));
            builder.RegisterType<AddCardToDeck>().Named<ICommand>(nameof(AddCardToDeck));
            builder.RegisterType<RenameDeck>().Named<ICommand>(nameof(RenameDeck));
            builder.RegisterType<GetDeck>().Named<ICommand>(nameof(GetDeck));
            builder.RegisterType<GetMain>().Named<ICommand>(nameof(GetMain));
            builder.RegisterType<GetSide>().Named<ICommand>(nameof(GetSide));
            builder.RegisterType<ExportDeck>().Named<ICommand>(nameof(ExportDeck));
            builder.RegisterType<ImportDeck>().Named<ICommand>(nameof(ImportDeck));

            
        }
    }
}
