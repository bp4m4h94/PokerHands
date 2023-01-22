namespace PokerHands; 

public class Parser
{
    private static readonly Dictionary<char, int> ValueLookup = new Dictionary<char, int>()
    {
        { 'T', 10 },
        { 'J', 11 },
        { 'Q', 12 },
        { 'K', 13 },
        { 'A', 14 }
    };

    private static readonly Dictionary<char, string> OutputLookup = new Dictionary<char, string>()
    {
        { 'T', "10" },
        { 'J', "Jack" },
        { 'Q', "Queen" },
        { 'K', "King" },
        { 'A', "Ace" }
    };

    public List<Player> Parse(string input)
    {
        // Black: 2H 3D 5S 8C 6D  White: 2C 3H 4S 9C 5H
        var playerSection = input.Split("  ", StringSplitOptions.RemoveEmptyEntries);   

        var players = new List<Player>
        {
            GetPlayer(playerSection, 0),
            GetPlayer(playerSection, 1)
        };
        return players;
    }
 
    private Player GetPlayer(string[] playerSection, int playerIndex)
    {
        var name = playerSection[playerIndex].Split(":", StringSplitOptions.RemoveEmptyEntries)[0];
        var card = playerSection[playerIndex]
            .Split(":")[1]
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(x => new Card()
            {
                Suit = x[1].ToString(),
                Output = GetOutput(x[0]),
                Value = GetValue(x[0])
            }).ToList();
        return new Player()
        {
            Name = name, 
            Card = card
        };
    }

    private static int GetValue(char cardNumber)
    {
        return ValueLookup.ContainsKey(cardNumber) ? ValueLookup[cardNumber] : (int)char.GetNumericValue(cardNumber);
    }

    private static string GetOutput(char cardNumber)
    {
        return OutputLookup.ContainsKey(cardNumber) ? OutputLookup[cardNumber] : cardNumber.ToString();
    }
}