using System;

namespace FootballBettingModels
{
    using System.Collections.Generic;

    public class Bet
    {
        public Bet()
        {
            this.BetGames = new HashSet<BetGame>();
        }

        public int Id { get; set; }

        public decimal BetMoney { get; set; }

        public DateTime DateTimeOfBet { get; set; }

        public User User { get; set; }

        public ICollection<BetGame> BetGames { get; set; }
    }
}
