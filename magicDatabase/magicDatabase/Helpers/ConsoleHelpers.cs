namespace magicDatabase.Helpers
{
    public static class ConsoleHelpers
    {
        public static bool? GetYesNo()
        {
            Console.Write("[Y/N]: ");
            var answer = Console.ReadLine()?.ToLower();

            if (answer == "y" || answer == "yes" || answer == "ja")
            {
                return true;
            }
            else if (answer == "n" || answer == "no" || answer == "nej")
            {
                return false;
            }
            return null;
        }

    }
}
