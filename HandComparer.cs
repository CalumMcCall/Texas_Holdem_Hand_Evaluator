using System;
using System.Collections.Generic;

namespace TexasHoldemHandEvaluator
{
	public class HandComparer
	{

		public static void Main()
		{
			var c = new List<Card> ();
			var hc = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Five));
			c.Add (new Card(Suit.Diamonds, Value.King));
			c.Add (new Card(Suit.Spades, Value.Two));
			c.Add (new Card(Suit.Clubs, Value.Three));
			hc.Add (new Card(Suit.Clubs, Value.Eight));
			hc.Add (new Card(Suit.Clubs, Value.Four));
			var test = new Hand (c, hc);
			Console.WriteLine("lol"+ test.HasQuads());
		}
	}
}

