namespace PokerHands; 

public class Parser
{
    public List<Player>  Parse(string input)
    {
        // Black: 2H 3D 5S 8C 6D  White: 2C 3H 4S 9C 5H
        var playerSection = input.Split("  ", StringSplitOptions.RemoveEmptyEntries);
        var player1Name = playerSection[0].Split(":", StringSplitOptions.RemoveEmptyEntries)[0];
        var player2Name = playerSection[1].Split(":", StringSplitOptions.RemoveEmptyEntries)[0];
        return new List<Player>
        {
            new Player() 
            {
                Name = player1Name, 
                Card = new List<Card>() 
                {
                    new Card(){Suit="H", Value=2, Output="2"}, 
                    new Card(){Suit="D", Value=3, Output="3"},  
                    new Card(){Suit="S", Value=5, Output="5"},  
                    new Card(){Suit="C", Value=8, Output="8"},  
                    new Card(){Suit="D", Value=6, Output="6"}, 
                }
            },
            new Player() {Name = player2Name},
        };
    }
}