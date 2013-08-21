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

			var c = obj as Card;
			if (c != null) {
				return value - c.value;
			}
			throw new ArgumentException ("Object is not a Card");
		}

		public Card DeepCopy()
		{
			return new Card (suit, value);
		}

		public override string ToString()
		{
			String s = "";
			if(value == Value.Ace)
				s += "A";
			else if(value == Value.King)
				s += "K";
			else if(value == Value.Queen)
				s += "Q";
			else if(value == Value.Jack)
				s += "J";
			else if(value == Value.Ten)
				s += "T";
			else if(value == Value.Nine)
				s += "9";
			else if(value == Value.Eight)
				s += "8";
			else if(value == Value.Seven)
				s += "7";
			else if(value == Value.Six)
				s += "6";
			else if(value == Value.Five)
				s += "5";
			else if(value == Value.Four)
				s += "4";
			else if(value == Value.Three)
				s += "3";
			else if(value == Value.Two)
				s += "2";

			if(suit == Suit.Spades)
				s += "s";
			else if(suit == Suit.Clubs)
				s += "c";
			else if(suit == Suit.Diamonds)
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
			var c = obj as Card;
			if (c == null)
			{
				return false;
			}

			return (c.value == value);
		}

		public override int GetHashCode() {
			return Tuple.Create(value, suit).GetHashCode();
		}
	}

	public enum Suit { Hearts, Spades, Diamonds, Clubs }; //Suit Order is irrelevant in Holdem
	//Start this enum from one as it seems more intuitive
	public enum Value { One=1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace };
}

