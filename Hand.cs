using System;
using System.Collections.Generic;

namespace TexasHoldemHandEvaluator
{
	/* This class takes a board with 5 cards and two holecards
	 * and returns a string detailing the best 5-card hand */
	public class Hand
	{

		public static List<Card> HasStraightFlush(List<Card> cards)
		{
			var highest = HasFlush(cards);
			if(highest == null) {
				return null;
			}

			var flushCards = new List<Card>();
			foreach(Card c in cards) {
				if(c.suit == highest[0].suit) {
					flushCards.Add(c);
				}
			}
			return Hand.HasStraight(flushCards);
		}
		
		/* Returns the Card value of the quads on the board, or 
		 * an empty string if there are no quads */
		public static List<Card> HasQuads(List<Card> cards)
		{
			Value highestSeen = 0;
			var hand = new List<Card>();
			var cardsCopy = cards.GetRange(0, cards.Count);
			foreach(KeyValuePair<Value, int> kvp in Hand.GetValueCounts(cards)) {
				if(kvp.Value == 4) {
					highestSeen = kvp.Key;
				}
			}

			if (highestSeen == 0) {
				return null;
			}

			foreach(Card c in cards) {
				if(c.value == highestSeen) {
					hand.Add(c);
					cardsCopy.Remove(c);
				}
			}
			hand.AddRange(Hand.GetHighCards(cardsCopy, 1));
			return hand;
		}

		public static List<Card> HasFullHouse(List<Card> cards)
		{
			var hand = new List<Card>();
			var cardsCopy = cards.GetRange(0, cards.Count);
			var trips = Hand.HasTrips(cards);
			if(trips == null) {
				return null;
			}
			trips = trips.GetRange(0,3);

			cardsCopy.RemoveAll (trips.Contains);

			var pair = Hand.HasPair(cardsCopy);
			if(pair == null) {
				return null;
			}
			hand.AddRange(trips);
			hand.AddRange(pair.GetRange(0,2));
			return hand;
		}

		/* Checks for a flush and if found, returns the highest card
		 * in the flush, else null */
		public static List<Card> HasFlush(List<Card> cards)
		{
			var counts = new Dictionary<Suit, int> ();
			var hand = new List<Card>();
			foreach (Card c in cards) {
				if (counts.ContainsKey (c.suit)) {
					counts [c.suit] += 1;
				} else {
					counts.Add (c.suit, 1);
				}
			}
			foreach (KeyValuePair<Suit, int> kvp in counts) {
				if (kvp.Value >= 5) {
					foreach(Card c in cards) {
						if(c.suit.Equals(kvp.Key)) {
							hand.Add(c);
						}
					}
					hand.Sort();
					hand.Reverse();
					return hand.GetRange(0, 5);
				}
			}

			return null;
		}


		/* Returns the highest card in the straight,
		 * or an empty string if there is no straight */
		public static List<Card> HasStraight(List<Card> cards)
		{
			cards.Sort ();
			cards.Reverse ();
			var hand = new List<Card>();
			hand.Add(cards[0]);
			for (int i = 1; i < cards.Count; i++) {
				if (cards [i].value == hand[hand.Count-1].value-1) {
					hand.Add(cards[i]);
					if (hand.Count >= 5) {
						return hand;
					}
					if (hand[0].value == Value.Five && hand[hand.Count-1].value == Value.Three) {
						//Need to handle the ace playing low for straights
						//the card suit here is unimportant, it just has to be something
						if (cards.Contains (new Card (Suit.Clubs, Value.Ace)) &&
							cards.Contains (new Card (Suit.Clubs, Value.Two))) {
							hand.Add(cards.FindLast(x => x.value == Value.Two));
							hand.Add(cards.FindLast(x => x.value == Value.Ace));
							return hand;
						}
						return null;
					}
					continue;
				}
				if (i == 4) {
					return null;
				}
				//there might still be a straight
				hand.Clear();
				hand.Add(cards[i]);
			}

			return null;
		}

		/* Returns the Card value of the highest trips on 
		 * the board, or an empty string if there are no trips */
		public static List<Card> HasTrips(List<Card> cards)
		{
			Value highestSeen = 0;
			var hand = new List<Card>();
			var cardsCopy = cards.GetRange(0, cards.Count);
			foreach (KeyValuePair<Value, int> kvp in Hand.GetValueCounts(cards)) {
				if (kvp.Value == 3 && kvp.Key > highestSeen) {
					highestSeen = kvp.Key;
				}
			}

			if (highestSeen == 0) {
				return null;
			}

			foreach(Card c in cards) {
				if(c.value == highestSeen) {
					hand.Add(c);
					cardsCopy.Remove(c);
				}
			}
			hand.AddRange(Hand.GetHighCards(cardsCopy, 2));
			return hand;
		}

		public static List<Card> HasTwoPair(List<Card> cards)
		{
			var cardsCopy = cards.GetRange(0, cards.Count);
			var biggestPair = Hand.HasPair(cards);
			var hand = new List<Card>();
			if(biggestPair == null) {
				return null;
			}

			biggestPair = biggestPair.GetRange(0,2);

			cardsCopy.RemoveAll(biggestPair.Contains);
			var secondPair = Hand.HasPair(cardsCopy);
			if(secondPair == null) {
				return null;
			}

			hand.AddRange(biggestPair);
			hand.AddRange(secondPair.GetRange(0,3));
			return hand;
		}

		public static List<Card> HasPair(List<Card> cards)
		{
			Value highestSeen = 0;
			var hand = new List<Card>();
			var cardsCopy = cards.GetRange(0, cards.Count);
			foreach (KeyValuePair<Value, int> kvp in Hand.GetValueCounts(cards)) {
				if (kvp.Value == 2 && kvp.Key > highestSeen) {
					highestSeen = kvp.Key;
				}
			}

			if (highestSeen == 0) {
				return null;
			}

			foreach(Card c in cards) {
				if(c.value == highestSeen) {
					hand.Add(c);
					cardsCopy.Remove(c);
				}
			}
			/* HasPair is sometimes called with cards.Count < 7 (see HasFullHouse) 
			 * so we need to handle that by returning the best partial hand */
			hand.AddRange(Hand.GetHighCards(cardsCopy, cards.Count-hand.Count));
			if(hand.Count > 5) {
				return hand.GetRange(0, 5);
			}
			return hand;
		}

		public static List<Card> GetHighCards(List<Card> cards, int count)
		{
			cards.Sort();
			cards.Reverse();
			var newCards = new List<Card>();
			for(int i = 0; i < count; i++) {
				newCards.Add(cards[i].DeepCopy());
			}
			return newCards;
		}

		static Dictionary<Value,int> GetValueCounts (List<Card> cs)
		{
			var counts = new Dictionary<Value, int>();
			foreach (Card c in cs) {
				if (counts.ContainsKey (c.value)) {
					counts [c.value] += 1;
				}
				else {
					counts.Add (c.value, 1);
				}
			}
			return counts;
		}
	}
}

