namespace PokerHands; 

public class Parser
{
    public List<Player>  Parse(string input)
    {
        return new List<Player>
        {
            new Player() { Name = "white" }, new Player() { Name = "black" }
        };
    }
}

public class Player
{
    public string Name { get; set; }
}