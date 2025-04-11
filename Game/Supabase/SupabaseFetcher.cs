using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

[Table("Leaderboard")]
public class LeaderboardEntity : BaseModel
{
    [PrimaryKey("PID", false)]
    public int Pid { get; set; }

    [Column("SCORE")]
    public int Score { get; set; }

    [Column("NAME")]
    public string Name { get; set; }
}

public class SupabaseFetcher
{
    public static async Task<List<Player>> FetchLeaderboard()
    {  
        var url = "https://vvxiyupjwawsdqcbcmoa.supabase.co";
        var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InZ2eGl5dXBqd2F3c2RxY2JjbW9hIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NDQzNjAwNjEsImV4cCI6MjA1OTkzNjA2MX0.0ATnDRUbLkgugRPXMu1OF9WFwCr_xZYGHQV_QbJDSVQ";

        var options = new Supabase.SupabaseOptions
        {
            AutoConnectRealtime = true
        };

        var supabase = new Supabase.Client(url, key, options);

        await supabase.InitializeAsync();

        var result = await supabase
            .From<LeaderboardEntity>()
            .Select("SCORE, NAME")
            .Order("SCORE", Supabase.Postgrest.Constants.Ordering.Descending)
            .Get();
        var players = result.Models.Select(row => new Player(
            row.Name,
            row.Score
        )).ToList();
        return players;
    }

    public static List<Player> FetchLeaderboardSync()
    {
        try
        {
            return FetchLeaderboard().GetAwaiter().GetResult();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching leaderboard: {ex.Message}");
            throw new Exception("Error fetching leaderboard synchronously", ex);
        }
    }
}