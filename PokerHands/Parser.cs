 namespace PokerHands; 

public class Parser
{
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
        var cardLookup = new Dictionary<char, int>()
        {
            { 'T', 10 },
            { 'J', 11 }
        };
        if (cardLookup.ContainsKey(cardNumber))
        {
            return cardLookup[cardNumber];
        }
        return (int)char.GetNumericValue(cardNumber);
    }

    private static string GetOutput(char cardNumber)
    {
        if (cardNumber == 'T')
        {
            return "10";
        }
        if (cardNumber == 'J')
        {
            return "Jack";
        }
        return cardNumber.ToString();
    }
}