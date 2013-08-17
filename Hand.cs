using System;
using System.Collections.Generic;

namespace TexasHoldemHandEvaluator
{
	/* This class takes a board with 5 cards and two holecards
	 * and returns a string detailing the best 5-card hand */
	public class Hand
	{
		List<Card> cards;

		public Hand (List<Card> b, List<Card> hc)
		{
			cards = new List<Card> ();
			foreach(Card c in b)
			{
				cards.Add (c.DeepCopy());
			}
			foreach(Card c in hc)
			{
				cards.Add (c.DeepCopy());
			}
		}

		/* Returns the highest card in the straight,
		 * or an empty string if there is no straight */
		public String HasStraight()
		{
			cards.Sort ();
			cards.Reverse ();
			Value curVal = cards[0].value;
			Value highestCard = curVal;
			int count = 1;
			for (int i = 0; i < cards.Count; i++) {
				if (cards [i].value == curVal - 1) {
					count++;
					if (count >= 5) {
						//we are done
						return highestCard.ToString ();
					}
					if (highestCard == Value.Five && curVal == Value.Three) {
						//Need to handle the ace playing low for straights
						//the card suit here is unimportant, it just has to be something
						if (cards.Contains (new Card (Suit.Clubs, Value.Ace)) &&
							cards.Contains (new Card (Suit.Clubs, Value.Two))) {
							return highestCard.ToString ();
						}
						return "";
					}
					curVal -= 1;
					continue;
				}
				if (i == 4) {
					return "";
				}
				//there might still be a straight
				highestCard = cards [i].value;
				curVal = highestCard;
				count = 1;
			}

			return ""; //here to keep the compiler happy
		}

		/* Returns the Card value of the highest trips on 
		 * the board, or an empty string if there are no trips */
		public String HasTrips()
		{
			var counts = new Dictionary<Value, int> ();
			foreach (Card c in cards) {
				if (counts.ContainsKey (c.value)) {
					counts [c.value] += 1;
				} else {
					counts.Add (c.value, 1);
				}
			}
			Value highestSeen = 0;
			foreach (KeyValuePair<Value, int> kvp in counts) {
				if (kvp.Value == 3 && kvp.Key > highestSeen) {
					highestSeen = kvp.Key;
				}
			}

			if (highestSeen == 0) {
				return "";
			}
			return highestSeen.ToString ();
		}

		/* Returns the Card value of the quads on the board, or 
		 * an empty string if there are no quads */
		public String HasQuads()
		{
			var counts = new Dictionary<Value, int>();
			foreach(Card c in cards) {
				if(counts.ContainsKey(c.value)) {
					counts[c.value] += 1;
				} else {
					counts.Add(c.value, 1);
				}
			}
			foreach(KeyValuePair<Value, int> kvp in counts) {
				if(kvp.Value == 4) {
					return kvp.Key.ToString();
				}
			}

			return "";
		}

	}
}

