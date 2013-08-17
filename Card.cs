using System;

namespace TexasHoldemHandEvaluator
{
	public class Card : IComparable
	{
		public Value Value { get; private set; }
		public Suit Suit { get; private set; }

		public Card ( Suit s, Value v)
		{
			Value = v;
			Suit = s;
		}

		public int CompareTo(Object obj)
		{
			if (obj == null)
				return 1;

			Card c = obj as Card;
			if (c != null) {
				return this.Value - c.Value;
			} else {
				throw new ArgumentException ("Object is not a Card");
			}
		}

		public Card DeepCopy()
		{
			return new Card (this.Suit, this.Value);
		}

		public override string ToString()
		{
			String s = "";
			if(this.Value == Value.Ace)
				s += "A";
			else if(this.Value == Value.King)
				s += "K";
			else if(this.Value == Value.Queen)
				s += "Q";
			else if(this.Value == Value.Jack)
				s += "J";
			else if(this.Value == Value.Ten)
				s += "T";
			else if(this.Value == Value.Nine)
				s += "9";
			else if(this.Value == Value.Eight)
				s += "8";
			else if(this.Value == Value.Seven)
				s += "7";
			else if(this.Value == Value.Six)
				s += "6";
			else if(this.Value == Value.Five)
				s += "5";
			else if(this.Value == Value.Four)
				s += "4";
			else if(this.Value == Value.Three)
				s += "3";
			else if(this.Value == Value.Two)
				s += "2";

			if(this.Suit == Suit.Spades)
				s += "s";
			else if(this.Suit == Suit.Clubs)
				s += "c";
			else if(this.Suit == Suit.Diamonds)
				s += "d";
			else if(Suit == Suit.Hearts)
				s += "h";

			return s;
		}

		public override bool Equals(object obj) {

			// If parameter is null return false.
			if (obj == null)
			{
				return false;
			}

			// If parameter cannot be cast to Card return false.
			Card c = obj as Card;
			if (c == null)
			{
				return false;
			}

			return (c.Value == this.Value);
		}
	}

	public enum Suit { Hearts, Spades, Diamonds, Clubs }; //Suit Order is irrelevant in Holdem
	//Start this enum from one as it seems more intuitive
	public enum Value { One=1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace };
}

