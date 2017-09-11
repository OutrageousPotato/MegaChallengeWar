using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MegaChallengeWar
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Random random = new Random();

            Deck gameDeck = new Deck()
            {
                cardList = new List<Card> {
                new Card { cardValue = 2, cardName = "Two of Clubs" },
                new Card { cardValue = 3, cardName = "Three of Clubs" },
                new Card { cardValue = 4, cardName = "Four of Clubs" },
                new Card { cardValue = 5, cardName = "Five of Clubs" },
                new Card { cardValue = 6, cardName = "Six of Clubs" },
                new Card { cardValue = 7, cardName = "Seven of Clubs" },
                new Card { cardValue = 8, cardName = "Eight of Clubs" },
                new Card { cardValue = 9, cardName = "Nine of Clubs" },
                new Card { cardValue = 10, cardName = "Ten of Clubs" },
                new Card { cardValue = 11, cardName = "Jack of Clubs" },
                new Card { cardValue = 12, cardName = "Queen of Clubs" },
                new Card { cardValue = 13, cardName = "King of Clubs" },
                new Card { cardValue = 14, cardName = "Ace of Clubs" },
                new Card { cardValue = 2, cardName = "Two of Spades" },
                new Card { cardValue = 3, cardName = "Three of Spades" },
                new Card { cardValue = 4, cardName = "Four of Spades" },
                new Card { cardValue = 5, cardName = "Five of Spades" },
                new Card { cardValue = 6, cardName = "Six of Spades" },
                new Card { cardValue = 7, cardName = "Seven of Spades" },
                new Card { cardValue = 8, cardName = "Eight of Spades" },
                new Card { cardValue = 9, cardName = "Nine of Spades" },
                new Card { cardValue = 10, cardName = "Ten of Spades" },
                new Card { cardValue = 11, cardName = "Jack of Spades" },
                new Card { cardValue = 12, cardName = "Queen of Spades" },
                new Card { cardValue = 13, cardName = "King of Spades" },
                new Card { cardValue = 14, cardName = "Ace of Spades" },
                new Card { cardValue = 2, cardName = "Two of Hearts" },
                new Card { cardValue = 3, cardName = "Three of Hearts" },
                new Card { cardValue = 4, cardName = "Four of Hearts" },
                new Card { cardValue = 5, cardName = "Five of Hearts" },
                new Card { cardValue = 6, cardName = "Six of Hearts" },
                new Card { cardValue = 7, cardName = "Seven of Hearts" },
                new Card { cardValue = 8, cardName = "Eight of Hearts" },
                new Card { cardValue = 9, cardName = "Nine of Hearts" },
                new Card { cardValue = 10, cardName = "Ten of Hearts" },
                new Card { cardValue = 11, cardName = "Jack of Hearts" },
                new Card { cardValue = 12, cardName = "Queen of Hearts" },
                new Card { cardValue = 13, cardName = "King of Hearts" },
                new Card { cardValue = 14, cardName = "Ace of Hearts" },
                new Card { cardValue = 2, cardName = "Two of Diamonds" },
                new Card { cardValue = 3, cardName = "Three of Diamonds" },
                new Card { cardValue = 4, cardName = "Four of Diamonds" },
                new Card { cardValue = 5, cardName = "Five of Diamonds" },
                new Card { cardValue = 6, cardName = "Six of Diamonds" },
                new Card { cardValue = 7, cardName = "Seven of Diamonds" },
                new Card { cardValue = 8, cardName = "Eight of Diamonds" },
                new Card { cardValue = 9, cardName = "Nine of Diamonds" },
                new Card { cardValue = 10, cardName = "Ten of Diamonds" },
                new Card { cardValue = 11, cardName = "Jack of Diamonds" },
                new Card { cardValue = 12, cardName = "Queen of Diamonds" },
                new Card { cardValue = 13, cardName = "King of Diamonds" },
                new Card { cardValue = 14, cardName = "Ace of Diamonds" } }
            };

            

            Player playerOne = new Player() { playerName = "Player One", playerCards = new List<Card>() { }, playerDiscardPile = new List<Card>() { } };
            Player playerTwo = new Player() { playerName = "Player Two", playerCards = new List<Card>() { }, playerDiscardPile = new List<Card>() { } };

            dealCards(gameDeck, playerOne, playerTwo, random);

            /* // check if deal worked
            resultLabel.Text += "<h3>Player One's Cards:</h3>";
            foreach (var card in playerOne.playerCards)
            {
                resultLabel.Text += card.cardName + "<br />";
            }

            resultLabel.Text += "<h3>Player Two's Cards:</h3>";
            foreach (var card in playerTwo.playerCards)
            {
                resultLabel.Text += card.cardName + "<br />";
            } */
            
            Battle battle = new Battle() { battleKitty = new List<Card> ()};

            // Run game as long as each player has cards in either deck or discard pile
            while ((playerOne.playerCards.Count > 0 || playerOne.playerDiscardPile.Count > 0) 
                && (playerTwo.playerCards.Count > 0 || playerTwo.playerDiscardPile.Count > 0))
            {
                resultLabel.Text += battle.fightBattle(playerOne, playerTwo);
            }

            Player winner;

            if(playerOne.playerCards.Count != 0 || playerOne.playerDiscardPile.Count != 0)
            {
                winner = playerOne;
            }
            else
            {
                winner = playerTwo;
            }

            resultLabel.Text += "<h2>Winner: " + winner.playerName + "</h2>";
            
            
        }

        
        public void dealCards(Deck deck, Player firstPlayer, Player secondPlayer, Random random)
        {
            int nextRandomCard = 0;

            while (deck.cardList.Count > 0)
            {
                nextRandomCard = random.Next(deck.cardList.Count);
                firstPlayer.playerCards.Add(deck.cardList.ElementAt(nextRandomCard));
                deck.cardList.ElementAt(nextRandomCard).cardOwner = firstPlayer;
                deck.cardList.Remove(deck.cardList.ElementAt(nextRandomCard));

                nextRandomCard = random.Next(deck.cardList.Count);
                secondPlayer.playerCards.Add(deck.cardList.ElementAt(nextRandomCard));
                deck.cardList.ElementAt(nextRandomCard).cardOwner = secondPlayer;
                deck.cardList.Remove(deck.cardList.ElementAt(nextRandomCard));
            }

            
        }

    }
}