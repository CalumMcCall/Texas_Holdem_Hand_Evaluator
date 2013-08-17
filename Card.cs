using System;

namespace TexasHoldemHandEvaluator
{
	public class Card : IComparable
	{
		public Value value { get; private set; }
		public Suit suit { get; private set; }

		public Card ( Suit s, Value v)
		{
			value = v;
			suit = s;
		}

		public int CompareTo(Object obj)
		{
			if (obj == null)
				return 1;

			Card c = obj as Card;
			if (c != null) {
				return this.value - c.value;
			} else {
				throw new ArgumentException ("Object is not a Card");
			}
		}

		public Card DeepCopy()
		{
			return new Card (this.suit, this.value);
		}

		public override string ToString()
		{
			String s = "";
			if(this.value == Value.Ace)
				s += "A";
			else if(this.value == Value.King)
				s += "K";
			else if(this.value == Value.Queen)
				s += "Q";
			else if(this.value == Value.Jack)
				s += "J";
			else if(this.value == Value.Ten)
				s += "T";
			else if(this.value == Value.Nine)
				s += "9";
			else if(this.value == Value.Eight)
				s += "8";
			else if(this.value == Value.Seven)
				s += "7";
			else if(this.value == Value.Six)
				s += "6";
			else if(this.value == Value.Five)
				s += "5";
			else if(this.value == Value.Four)
				s += "4";
			else if(this.value == Value.Three)
				s += "3";
			else if(this.value == Value.Two)
				s += "2";

			if(this.suit == Suit.Spades)
				s += "s";
			else if(this.suit == Suit.Clubs)
				s += "c";
			else if(this.suit == Suit.Diamonds)
				s += "d";
			else if(suit == Suit.Hearts)
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

			return (c.value == this.value);
		}

		public override int GetHashCode() {
			return Tuple.Create(value, suit).GetHashCode();
		}
	}

	public enum Suit { Hearts, Spades, Diamonds, Clubs }; //Suit Order is irrelevant in Holdem
	//Start this enum from one as it seems more intuitive
	public enum Value { One=1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace };
}

