namespace magicDatabase.RepHelp
{
    public static class RepositoryHelpers
    {       
       
       /// <summary>
       /// changes list of cards to the right format
       /// </summary>
       /// <param name="cardList"></param>
       /// <returns></returns>
        public static List<string> DeckFormat(List<string> cardList)
        {
            Dictionary<string, int> itemCounts = new Dictionary<string, int>();

            foreach(string c in cardList)
        {
                if (itemCounts.ContainsKey(c))
                {
                    itemCounts[c]++;
                }
                else
                {
                    itemCounts[c] = 1;
                }
            }

            // Correct list
            List<string> formatedCards = itemCounts.Select(kvp => $"{kvp.Value} {kvp.Key}").ToList();

            return formatedCards;
        }
    }
}