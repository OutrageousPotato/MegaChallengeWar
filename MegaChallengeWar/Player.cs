using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar
{
    public class Player
    {
        public string playerName { get; set; }
        public List<Card> playerCards { get; set; }
        public List<Card> playerDiscardPile { get; set; }
        
        public void shuffleCheck()
        {
            Random random = new Random();
            if (this.playerCards.Count == 0)
            {
                this.playerCards.Add(this.playerDiscardPile.ElementAt(random.Next(this.playerDiscardPile.Count)));
                playerDiscardPile.Clear();
            }
        }

    }
}