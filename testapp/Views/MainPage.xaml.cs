namespace testapp;
using Camille.Enums;
using Camille.RiotGames;
using RiotSharp;
using testapp.Models;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
    }
    int count = 0;

    private async void OnButtonClicked(object sender, EventArgs e)
    {
        UserInputSingleton userInputSingleton = UserInputSingleton.Instance;

        string userInputName = summonerNameEntry.Text;


        var riotApi = RiotGamesApi.NewInstance("RGAPI-658cd94e-089e-405c-95c5-a4ace9707061");

        try
        {
            var summoner = await riotApi.SummonerV4().GetBySummonerNameAsync(PlatformRoute.EUW1, userInputName);

            if (summoner == null)
            {
                outputLabel.Text = "Summoner not found.";
                return;
            }

            string outputText = $"\n {userInputSingleton.RandomNumber} var skrivet med singleton \n {summoner.Name}'s Top 25 Champions: \n{summoner.Name}'s Current level is: {summoner.SummonerLevel}\n\n Champion name   \t Champion Points & rank\n";

            var masteries = await riotApi.ChampionMasteryV4().GetAllChampionMasteriesAsync(PlatformRoute.EUW1, summoner.Id);

            for (int i = 0; i < 25; i++)
            {
                var mastery = masteries[i];
                var champion = (Champion)mastery.ChampionId;
                outputText += $"{i + 1}) {champion,-10} \t\t {mastery.ChampionPoints,10} ({mastery.ChampionLevel})\n";
            }

            outputLabel.Text = outputText;
        }
        catch (RiotSharpException ex)
        {
            outputLabel.Text = $"Error: {ex.Message}";
        }
    }
}

