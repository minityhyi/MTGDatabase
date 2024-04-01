using magicDatabase.DependencyConventions;

namespace magicDatabase.Commands
{
    public class Help : ISyncCommand
    {
        public int Execute(string[] args)
        {
            Console.WriteLine("Welcome to MTG (Magic database)");
            Console.WriteLine(" - A Magic The Gathering deck builder.");
            Console.WriteLine("Here is a list of all commands avaliable:");
            
            var allCommands = CommandConvensions.GetCommands();
            allCommands.ForEach(c => Console.WriteLine($" - {c.Name}"));

            return 0;
        }
    }
}
