using Autofac;
using Autofac.Extensions.DependencyInjection;
using magicDatabase.Commands;
using magicDatabase.DependencyConventions;
using Microsoft.Extensions.DependencyInjection;
using MTG.Common;
using MTG.Common.Repositories;
using MTG.Common.Repository.Interfaces;

internal class Program
{
    private static IContainer Container { get; set; }
    static void Main(string[] args)
    {
        var services = new ServiceCollection();
        InitializeContainer(services);

        var command = args.Any() ? args[0] : string.Empty;
        var arguments = args.Any() ? args.Skip(1).ToArray() : Array.Empty<string>();

        HandleCommand(command, arguments);
    }

    private static void InitializeContainer(IServiceCollection services)
    {
        var builder = new ContainerBuilder();
        builder.RegisterCommands();

        services.AddScoped<MagicContext>();
        services.AddScoped<IDeckRepository, DeckRepository>();

        builder.Populate(services);
        Container = builder.Build();
    }

    private static int HandleCommand(string commandName, string[] args)
    {
        var commands = CommandConvensions.GetCommands();

        try
        {
            var type = commands.Single(c => c.Name.ToLower() == commandName.ToLower());
            var command = Container.ResolveNamed<ICommand>(type.Name);

            try
            {
                if (command is ISyncCommand syncCommand)
                {
                    return syncCommand.Execute(args);
                }
                else
                {
                    Console.WriteLine("Command not created correctly.");
                    return -1;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred execution command {commandName}");
                Console.WriteLine(e);
                return -1;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Console.WriteLine($"The command '{commandName}' could not be found or activaed. Please use one of the following commands:");
            commands.ForEach(c => Console.WriteLine(c.Name));
            return -1;
        }
    }
}

