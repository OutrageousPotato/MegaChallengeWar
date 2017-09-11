using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar
{
    public class Card
    {
        public int cardValue { get; set; }
        public string cardName { get; set; }
        public Player cardOwner { get; set; }
    }
}