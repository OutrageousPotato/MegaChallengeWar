using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar
{
    public class Battle
    {        
        public string battleResult { get; set; }
        public List<Card> battleKitty { get; set; }

        public string fightBattle(Player playerOne, Player playerTwo)
        {

            battleResult = "";
            Card playerOneCard;
            Card playerTwoCard;

            do {
                // Select 1st player card, remove it from their deck and add it to the kitty
                playerOne.shuffleCheck();
                playerOneCard = playerOne.playerCards.First();
                battleKitty.Add(playerOneCard);
                battleResult += String.Format("<p>Player One played: {0}</p>", playerOneCard.cardName);
                playerOne.playerCards.Remove(playerOneCard);

                // Select 2nd player card, remove it from their deck and add it to the kitty
                playerTwo.shuffleCheck();
                playerTwoCard = playerTwo.playerCards.First();
                battleKitty.Add(playerTwoCard);
                battleResult += String.Format("<p>Player Two played: {0}</p>", playerTwoCard.cardName);
                playerTwo.playerCards.Remove(playerTwoCard);

                /*//temporary kitty check
                battleResult += "<p>Battle Kitty Contents:</p>";
                foreach (var card in battleKitty)
                { battleResult += "<p>" + card.cardName + "</p>"; }
                */

                // add 3 more cards each to the kitty in case of a tie
                if (playerOneCard.cardValue == playerTwoCard.cardValue)
                {
                    battleResult += "<h3>THIS MEANS WAR!!!</h3> (players each add three cards to the kitty and play again...)";
                    for (int i = 0; i < 3; i++)
                    {
                        playerOne.shuffleCheck();
                        Card playerOneAnte = playerOne.playerCards.First();
                        //battleResult += "<p>Player one ante: " + playerOneAnte.cardName;
                        battleKitty.Add(playerOneAnte);
                        playerOne.playerCards.Remove(playerOneAnte);

                        playerOne.shuffleCheck();
                        Card playerTwoAnte = playerTwo.playerCards.First();
                        //battleResult += "<p>Player two ante: " + playerTwoAnte.cardName;
                        battleKitty.Add(playerTwoAnte);
                        playerTwo.playerCards.Remove(playerTwoAnte);
                    }
                }

                // Loop battle while values are equal
            } while (playerOneCard.cardValue == playerTwoCard.cardValue);

            // Set the winner
            Player winner = (playerOneCard.cardValue > playerTwoCard.cardValue) ? playerOneCard.cardOwner : playerTwoCard.cardOwner;
            
            if (battleKitty.Count > 2)
            {
                battleResult += "After a brutal struggle, " + winner.playerName + " wins a stunning " + battleKitty.Count + " cards!</br>";
            }
            else
            {
                battleResult += "<p>Victory to " + winner.playerName + "</p>";
            }
            // clear out the kitty and add to the winner's discard pile
            foreach (Card card in battleKitty)
            {
                winner.playerDiscardPile.Add(card);
                card.cardOwner = winner;
            }
            battleKitty.Clear();
            return battleResult;
        }    
    }
}