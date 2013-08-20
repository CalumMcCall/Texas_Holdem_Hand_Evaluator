using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TexasHoldemHandEvaluator
{	
	[TestFixture()]
	public class NUnitTestHasStraightFlush
	{
		[Test()]
		public void TestHasStraightFlushHearts ()
		{
			List<Card> c = new List<Card> ();
			List<Card> hc = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Queen));
			c.Add (new Card(Suit.Hearts, Value.Ten));
			c.Add (new Card(Suit.Hearts, Value.Jack));
			c.Add (new Card(Suit.Clubs, Value.Two));
			hc.Add (new Card(Suit.Hearts, Value.King));
			hc.Add (new Card(Suit.Spades, Value.Ten));
			Hand test = new Hand (c, hc);
			Assert.AreEqual (new Card(Suit.Hearts, Value.Ace), test.HasStraightFlush());
		}

		[Test()]
		public void TestHasStraightFlushFail ()
		{
			List<Card> c = new List<Card> ();
			List<Card> hc = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Nine));
			c.Add (new Card(Suit.Diamonds, Value.Ten));
			c.Add (new Card(Suit.Spades, Value.Jack));
			c.Add (new Card(Suit.Clubs, Value.Two));
			hc.Add (new Card(Suit.Hearts, Value.Ten));
			hc.Add (new Card(Suit.Clubs, Value.Ten));
			Hand test = new Hand (c, hc);
			Assert.AreEqual (null, test.HasStraightFlush());
		}

		[Test()]
		public void TestHasStraightFlushSpades ()
		{
			List<Card> c = new List<Card> ();
			List<Card> hc = new List<Card> ();
			c.Add (new Card(Suit.Spades, Value.Ace));
			c.Add (new Card(Suit.Spades, Value.Queen));
			c.Add (new Card(Suit.Spades, Value.Ten));
			c.Add (new Card(Suit.Spades, Value.Jack));
			c.Add (new Card(Suit.Clubs, Value.Two));
			hc.Add (new Card(Suit.Spades, Value.King));
			hc.Add (new Card(Suit.Hearts, Value.Ten));
			Hand test = new Hand (c, hc);
			Assert.AreEqual (new Card(Suit.Spades, Value.Ace), test.HasStraightFlush());
		}

		[Test()]
		public void TestHasStraightFlushSpadesLow ()
		{
			List<Card> c = new List<Card> ();
			List<Card> hc = new List<Card> ();
			c.Add (new Card(Suit.Spades, Value.Nine));
			c.Add (new Card(Suit.Spades, Value.Queen));
			c.Add (new Card(Suit.Spades, Value.Ten));
			c.Add (new Card(Suit.Spades, Value.Jack));
			c.Add (new Card(Suit.Clubs, Value.Two));
			hc.Add (new Card(Suit.Spades, Value.King));
			hc.Add (new Card(Suit.Hearts, Value.Ten));
			Hand test = new Hand (c, hc);
			Assert.AreEqual (new Card(Suit.Spades, Value.King), test.HasStraightFlush());
		}

		[Test()]
		public void TestHasStraightFlushWheel ()
		{
			List<Card> c = new List<Card> ();
			List<Card> hc = new List<Card> ();
			c.Add (new Card(Suit.Spades, Value.Two));
			c.Add (new Card(Suit.Spades, Value.Three));
			c.Add (new Card(Suit.Spades, Value.Five));
			c.Add (new Card(Suit.Spades, Value.Four));
			c.Add (new Card(Suit.Clubs, Value.Two));
			hc.Add (new Card(Suit.Spades, Value.Ace));
			hc.Add (new Card(Suit.Hearts, Value.Ten));
			Hand test = new Hand (c, hc);
			Assert.AreEqual (new Card(Suit.Spades, Value.Five), test.HasStraightFlush());
		}
	}

	[TestFixture()]
	public class NUnitTestHasQuads
	{
		[Test()]
		public void TestHasQuadsNormal ()
		{
			List<Card> c = new List<Card> ();
			List<Card> hc = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Nine));
			c.Add (new Card(Suit.Diamonds, Value.Ten));
			c.Add (new Card(Suit.Spades, Value.Ten));
			c.Add (new Card(Suit.Clubs, Value.Two));
			hc.Add (new Card(Suit.Hearts, Value.Ten));
			hc.Add (new Card(Suit.Clubs, Value.Ten));
			Hand test = new Hand (c, hc);
			Assert.AreEqual ("Ten", test.HasQuads());
		}

		[Test()]
		public void TestHasQuadsTrips ()
		{
			List<Card> c = new List<Card> ();
			List<Card> hc = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Nine));
			c.Add (new Card(Suit.Diamonds, Value.Ten));
			c.Add (new Card(Suit.Spades, Value.Jack));
			c.Add (new Card(Suit.Clubs, Value.Two));
			hc.Add (new Card(Suit.Hearts, Value.Ten));
			hc.Add (new Card(Suit.Clubs, Value.Ten));
			Hand test = new Hand (c, hc);
			Assert.AreEqual ("", test.HasQuads());
		}

		[Test()]
		public void TestHasQuadsNoPairs ()
		{
			List<Card> c = new List<Card> ();
			List<Card> hc = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Nine));
			c.Add (new Card(Suit.Diamonds, Value.King));
			c.Add (new Card(Suit.Spades, Value.Jack));
			c.Add (new Card(Suit.Clubs, Value.Two));
			hc.Add (new Card(Suit.Hearts, Value.Ten));
			hc.Add (new Card(Suit.Clubs, Value.Three));
			Hand test = new Hand (c, hc);
			Assert.AreEqual ("", test.HasQuads());
		}
	}

	
	[TestFixture()]
	public class NUnitTestHasFullHouse
	{
	}

	[TestFixture()]
	public class NUnitTestHasFlush
	{
		[Test]
		public void TestHasFlush ()
		{
			var c = new List<Card> ();
			var hc = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Ten));
			c.Add (new Card(Suit.Diamonds, Value.King));
			c.Add (new Card(Suit.Hearts, Value.Jack));
			c.Add (new Card(Suit.Hearts, Value.Queen));
			hc.Add (new Card(Suit.Clubs, Value.Seven));
			hc.Add (new Card(Suit.Hearts, Value.Six));
			var test = new Hand (c, hc);
			Assert.AreEqual (new Card(Suit.Hearts, Value.Ace), test.HasFlush());
		}

		[Test]
		public void TestHasFlushSixCard ()
		{
			var c = new List<Card> ();
			var hc = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Three));
			c.Add (new Card(Suit.Hearts, Value.Ten));
			c.Add (new Card(Suit.Diamonds, Value.King));
			c.Add (new Card(Suit.Hearts, Value.Jack));
			c.Add (new Card(Suit.Hearts, Value.Queen));
			hc.Add (new Card(Suit.Hearts, Value.Seven));
			hc.Add (new Card(Suit.Hearts, Value.Six));
			var test = new Hand (c, hc);
			Assert.AreEqual(new Card(Suit.Hearts, Value.Queen), test.HasFlush());
		}

		[Test]
		public void TestHasFlushFourCard ()
		{
			var c = new List<Card> ();
			var hc = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Ten));
			c.Add (new Card(Suit.Diamonds, Value.King));
			c.Add (new Card(Suit.Hearts, Value.Jack));
			c.Add (new Card(Suit.Hearts, Value.Queen));
			hc.Add (new Card(Suit.Clubs, Value.Seven));
			hc.Add (new Card(Suit.Clubs, Value.Six));
			var test = new Hand (c, hc);
			Assert.AreEqual (null, test.HasFlush());
		}

	}

	[TestFixture]
	public class NUnitTestHasStraight
	{
		[Test]
		public void TestHasStraightNormal ()
		{
			var c = new List<Card> ();
			var hc = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Ten));
			c.Add (new Card(Suit.Diamonds, Value.King));
			c.Add (new Card(Suit.Spades, Value.Jack));
			c.Add (new Card(Suit.Clubs, Value.Queen));
			hc.Add (new Card(Suit.Clubs, Value.Seven));
			hc.Add (new Card(Suit.Clubs, Value.Six));
			var test = new Hand (c, hc);
			Assert.AreEqual ("Ace", test.HasStraight());
		}

		[Test]
		public void TestHasStraightLastCards ()
		{
			var c = new List<Card> ();
			var hc = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Nine));
			c.Add (new Card(Suit.Diamonds, Value.King));
			c.Add (new Card(Suit.Spades, Value.Ten));
			c.Add (new Card(Suit.Clubs, Value.Eight));
			hc.Add (new Card(Suit.Clubs, Value.Six));
			hc.Add (new Card(Suit.Clubs, Value.Seven));
			Hand test = new Hand (c, hc);
			Assert.AreEqual ("Ten", test.HasStraight());
		}

		[Test()]
		public void TestHasStraightWheel ()
		{
			List<Card> c = new List<Card> ();
			List<Card> hc = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Five));
			c.Add (new Card(Suit.Diamonds, Value.King));
			c.Add (new Card(Suit.Spades, Value.Two));
			c.Add (new Card(Suit.Clubs, Value.Three));
			hc.Add (new Card(Suit.Clubs, Value.Eight));
			hc.Add (new Card(Suit.Clubs, Value.Four));
			Hand test = new Hand (c, hc);
			Assert.AreEqual ("Five", test.HasStraight());
		}

		[Test()]
		public void TestHasStraightOffset ()
		{
			List<Card> c = new List<Card> ();
			List<Card> hc = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Nine));
			c.Add (new Card(Suit.Hearts, Value.Ten));
			c.Add (new Card(Suit.Diamonds, Value.Eight));
			c.Add (new Card(Suit.Spades, Value.Jack));
			c.Add (new Card(Suit.Clubs, Value.Queen));
			hc.Add (new Card(Suit.Clubs, Value.Two));
			hc.Add (new Card(Suit.Clubs, Value.Ace));
			Hand test = new Hand (c, hc);
			Assert.AreEqual ("Queen", test.HasStraight());
		}

		[Test()]
		public void TestHasStraightGap ()
		{
			List<Card> c = new List<Card> ();
			List<Card> hc = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Nine));
			c.Add (new Card(Suit.Diamonds, Value.King));
			c.Add (new Card(Suit.Spades, Value.Jack));
			c.Add (new Card(Suit.Clubs, Value.Eight));
			hc.Add (new Card(Suit.Clubs, Value.Seven));
			hc.Add (new Card(Suit.Clubs, Value.Ten));
			Hand test = new Hand (c, hc);
			Assert.AreEqual ("Jack", test.HasStraight());
		}

		[Test()]
		public void TestHasStraightFourCard ()
		{
			List<Card> c = new List<Card> ();
			List<Card> hc = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Nine));
			c.Add (new Card(Suit.Diamonds, Value.King));
			c.Add (new Card(Suit.Spades, Value.Jack));
			c.Add (new Card(Suit.Clubs, Value.Eight));
			hc.Add (new Card(Suit.Clubs, Value.Five));
			hc.Add (new Card(Suit.Clubs, Value.Ten));
			Hand test = new Hand (c, hc);
			Assert.AreEqual ("", test.HasStraight());
		}

		[Test()]
		public void TestHasStraightFourCardWheel ()
		{
			List<Card> c = new List<Card> ();
			List<Card> hc = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Jack));
			c.Add (new Card(Suit.Hearts, Value.Five));
			c.Add (new Card(Suit.Diamonds, Value.King));
			c.Add (new Card(Suit.Spades, Value.Two));
			c.Add (new Card(Suit.Clubs, Value.Three));
			hc.Add (new Card(Suit.Clubs, Value.Eight));
			hc.Add (new Card(Suit.Clubs, Value.Four));
			Hand test = new Hand (c, hc);
			Assert.AreEqual ("", test.HasStraight());
		}

		[Test()]
		public void TestHasStraightThreeCard ()
		{
			List<Card> c = new List<Card> ();
			List<Card> hc = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Nine));
			c.Add (new Card(Suit.Diamonds, Value.King));
			c.Add (new Card(Suit.Spades, Value.Jack));
			c.Add (new Card(Suit.Clubs, Value.Two));
			hc.Add (new Card(Suit.Clubs, Value.Five));
			hc.Add (new Card(Suit.Clubs, Value.Ten));
			Hand test = new Hand (c, hc);
			Assert.AreEqual ("", test.HasStraight());
		}
	}

	[TestFixture()]
	public class NUnitTestHasTrips
	{
		[Test()]
		public void TestHasTripsNormal ()
		{
			List<Card> c = new List<Card> ();
			List<Card> hc = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Nine));
			c.Add (new Card(Suit.Diamonds, Value.Ten));
			c.Add (new Card(Suit.Spades, Value.Jack));
			c.Add (new Card(Suit.Clubs, Value.Two));
			hc.Add (new Card(Suit.Hearts, Value.Ten));
			hc.Add (new Card(Suit.Clubs, Value.Ten));
			Hand test = new Hand (c, hc);
			Assert.AreEqual ("Ten", test.HasTrips());
		}

		[Test()]
		public void TestHasTripsTwo ()
		{
			List<Card> c = new List<Card> ();
			List<Card> hc = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Jack));
			c.Add (new Card(Suit.Clubs, Value.Jack));
			c.Add (new Card(Suit.Diamonds, Value.Ten));
			c.Add (new Card(Suit.Spades, Value.Jack));
			c.Add (new Card(Suit.Clubs, Value.Two));
			hc.Add (new Card(Suit.Hearts, Value.Ten));
			hc.Add (new Card(Suit.Clubs, Value.Ten));
			Hand test = new Hand (c, hc);
			Assert.AreEqual ("Jack", test.HasTrips());
		}

		[Test()]
		public void TestHasTripsPair ()
		{
			List<Card> c = new List<Card> ();
			List<Card> hc = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Nine));
			c.Add (new Card(Suit.Diamonds, Value.Ace));
			c.Add (new Card(Suit.Spades, Value.Jack));
			c.Add (new Card(Suit.Clubs, Value.Two));
			hc.Add (new Card(Suit.Hearts, Value.Ten));
			hc.Add (new Card(Suit.Clubs, Value.Ten));
			Hand test = new Hand (c, hc);
			Assert.AreEqual ("", test.HasTrips());
		}

		[Test()]
		public void TestHasTripsNoPairs ()
		{
			List<Card> c = new List<Card> ();
			List<Card> hc = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Nine));
			c.Add (new Card(Suit.Diamonds, Value.King));
			c.Add (new Card(Suit.Spades, Value.Jack));
			c.Add (new Card(Suit.Clubs, Value.Two));
			hc.Add (new Card(Suit.Hearts, Value.Ten));
			hc.Add (new Card(Suit.Clubs, Value.Three));
			Hand test = new Hand (c, hc);
			Assert.AreEqual ("", test.HasTrips());
		}
	}
	
	[TestFixture()]
	public class NUnitTestHasPair
	{
		[Test()]
		public void TestHasPairAces ()
		{
			List<Card> c = new List<Card> ();
			List<Card> hc = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Nine));
			c.Add (new Card(Suit.Diamonds, Value.Ten));
			c.Add (new Card(Suit.Spades, Value.King));
			c.Add (new Card(Suit.Clubs, Value.Two));
			hc.Add (new Card(Suit.Hearts, Value.Three));
			hc.Add (new Card(Suit.Clubs, Value.Ace));
			Hand test = new Hand (c, hc);
			Assert.AreEqual ("Ace", test.HasPair());
		}

		[Test()]
		public void TestHasPairThrees ()
		{
			List<Card> c = new List<Card> ();
			List<Card> hc = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Three));
			c.Add (new Card(Suit.Hearts, Value.Nine));
			c.Add (new Card(Suit.Diamonds, Value.Ten));
			c.Add (new Card(Suit.Spades, Value.Jack));
			c.Add (new Card(Suit.Clubs, Value.Two));
			hc.Add (new Card(Suit.Hearts, Value.Three));
			hc.Add (new Card(Suit.Clubs, Value.Five));
			Hand test = new Hand (c, hc);
			Assert.AreEqual ("Three", test.HasPair());
		}

		[Test()]
		public void TestHasPairFail ()
		{
			List<Card> c = new List<Card> ();
			List<Card> hc = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Three));
			c.Add (new Card(Suit.Diamonds, Value.Ten));
			c.Add (new Card(Suit.Spades, Value.Five));
			c.Add (new Card(Suit.Clubs, Value.Two));
			hc.Add (new Card(Suit.Hearts, Value.Eight));
			hc.Add (new Card(Suit.Clubs, Value.King));
			Hand test = new Hand (c, hc);
			Assert.AreEqual ("", test.HasPair());
		}
	}
	
	[TestFixture()]
	public class NUnitTestHasHighCard
	{
		[Test()]
		public void TestHasHighCardAce ()
		{
			List<Card> c = new List<Card> ();
			List<Card> hc = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Three));
			c.Add (new Card(Suit.Diamonds, Value.Ten));
			c.Add (new Card(Suit.Spades, Value.Five));
			c.Add (new Card(Suit.Clubs, Value.Two));
			hc.Add (new Card(Suit.Hearts, Value.Eight));
			hc.Add (new Card(Suit.Clubs, Value.King));
			Hand test = new Hand (c, hc);
			Assert.AreEqual ("Ace", test.HasHighCard());
		}

		[Test()]
		public void TestHasHighCardKing ()
		{
			List<Card> c = new List<Card> ();
			List<Card> hc = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Seven));
			c.Add (new Card(Suit.Hearts, Value.Three));
			c.Add (new Card(Suit.Diamonds, Value.Ten));
			c.Add (new Card(Suit.Spades, Value.Five));
			c.Add (new Card(Suit.Clubs, Value.Two));
			hc.Add (new Card(Suit.Hearts, Value.Eight));
			hc.Add (new Card(Suit.Clubs, Value.King));
			Hand test = new Hand (c, hc);
			Assert.AreEqual ("King", test.HasHighCard());
		}

		[Test()]
		public void TestHasHighCardLow ()
		{
			List<Card> c = new List<Card> ();
			List<Card> hc = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Nine));
			c.Add (new Card(Suit.Hearts, Value.Seven));
			c.Add (new Card(Suit.Diamonds, Value.Five));
			c.Add (new Card(Suit.Spades, Value.Eight));
			c.Add (new Card(Suit.Clubs, Value.Two));
			hc.Add (new Card(Suit.Hearts, Value.Four));
			hc.Add (new Card(Suit.Clubs, Value.Three));
			Hand test = new Hand (c, hc);
			Assert.AreEqual ("", test.HasHighCard());
		}
	}
}

