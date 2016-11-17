namespace FootballBettingModels
{
    public enum Prediction
    {
        HomeTeamWin, DrawGame, AwatTeamWin
    }

    public class ResultPrediction
    {
        public int Id { get; set; }

        public Prediction Prediction { get; set; }
    }
}
