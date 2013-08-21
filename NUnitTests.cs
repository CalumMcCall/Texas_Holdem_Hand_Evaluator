using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TexasHoldemHandEvaluator
{	
	[TestFixture]
	public class NUnitTestHasStraightFlush
	{
		[Test]
		public void TestHasStraightFlushHearts ()
		{
			var c = new List<Card> ();
			var expected = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Queen));
			c.Add (new Card(Suit.Hearts, Value.Ten));
			c.Add (new Card(Suit.Hearts, Value.Jack));
			c.Add (new Card(Suit.Clubs, Value.Two));
			c.Add (new Card(Suit.Hearts, Value.King));
			c.Add (new Card(Suit.Spades, Value.Ten));

			expected.Add (new Card(Suit.Hearts, Value.Ace));
			expected.Add (new Card(Suit.Hearts, Value.King));
			expected.Add (new Card(Suit.Hearts, Value.Queen));
			expected.Add (new Card(Suit.Hearts, Value.Jack));
			expected.Add (new Card(Suit.Hearts, Value.Ten));
			Assert.AreEqual (expected, Hand.HasStraightFlush(c));
		}

		[Test]
		public void TestHasStraightFlushFail ()
		{
			var c = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Nine));
			c.Add (new Card(Suit.Diamonds, Value.Ten));
			c.Add (new Card(Suit.Spades, Value.Jack));
			c.Add (new Card(Suit.Clubs, Value.Two));
			c.Add (new Card(Suit.Hearts, Value.Ten));
			c.Add (new Card(Suit.Clubs, Value.Ten));
			Assert.AreEqual (null, Hand.HasStraightFlush(c));
		}

		[Test]
		public void TestHasStraightFlushSixCard ()
		{
			var c = new List<Card> ();
			var expected = new List<Card> ();
			c.Add (new Card(Suit.Spades, Value.Nine));
			c.Add (new Card(Suit.Spades, Value.Queen));
			c.Add (new Card(Suit.Spades, Value.Ten));
			c.Add (new Card(Suit.Spades, Value.Jack));
			c.Add (new Card(Suit.Clubs, Value.Eight));
			c.Add (new Card(Suit.Spades, Value.King));
			c.Add (new Card(Suit.Hearts, Value.Ten));

			expected.Add (new Card(Suit.Spades, Value.King));
			expected.Add (new Card(Suit.Spades, Value.Queen));
			expected.Add (new Card(Suit.Spades, Value.Jack));
			expected.Add (new Card(Suit.Spades, Value.Ten));
			expected.Add (new Card(Suit.Spades, Value.Nine));
			Assert.AreEqual (expected, Hand.HasStraightFlush(c));
		}

		[Test]
		public void TestHasStraightFlushSpadesLow ()
		{
			var c = new List<Card> ();
			var expected = new List<Card> ();
			c.Add (new Card(Suit.Spades, Value.Nine));
			c.Add (new Card(Suit.Spades, Value.Queen));
			c.Add (new Card(Suit.Spades, Value.Ten));
			c.Add (new Card(Suit.Spades, Value.Jack));
			c.Add (new Card(Suit.Clubs, Value.Two));
			c.Add (new Card(Suit.Spades, Value.King));
			c.Add (new Card(Suit.Hearts, Value.Ten));

			expected.Add (new Card(Suit.Spades, Value.King));
			expected.Add (new Card(Suit.Spades, Value.Queen));
			expected.Add (new Card(Suit.Spades, Value.Jack));
			expected.Add (new Card(Suit.Spades, Value.Ten));
			expected.Add (new Card(Suit.Spades, Value.Nine));
			Assert.AreEqual (expected, Hand.HasStraightFlush(c));
		}

		[Test]
		public void TestHasStraightFlushWheel ()
		{
			var c = new List<Card> ();
			var expected = new List<Card> ();
			c.Add (new Card(Suit.Spades, Value.Two));
			c.Add (new Card(Suit.Spades, Value.Three));
			c.Add (new Card(Suit.Spades, Value.Five));
			c.Add (new Card(Suit.Spades, Value.Four));
			c.Add (new Card(Suit.Clubs, Value.Two));
			c.Add (new Card(Suit.Spades, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Ten));

			expected.Add (new Card(Suit.Spades, Value.Five));
			expected.Add (new Card(Suit.Spades, Value.Four));
			expected.Add (new Card(Suit.Spades, Value.Three));
			expected.Add (new Card(Suit.Spades, Value.Two));
			expected.Add (new Card(Suit.Spades, Value.Ace));
			Assert.AreEqual (expected, Hand.HasStraightFlush(c));
		}
	}

	[TestFixture]
	public class NUnitTestHasQuads
	{
		[Test]
		public void TestHasQuadsNormal ()
		{
			var c = new List<Card> ();
			var expected = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Nine));
			c.Add (new Card(Suit.Diamonds, Value.Ten));
			c.Add (new Card(Suit.Spades, Value.Ten));
			c.Add (new Card(Suit.Clubs, Value.Two));
			c.Add (new Card(Suit.Hearts, Value.Ten));
			c.Add (new Card(Suit.Clubs, Value.Ten));

			expected.Add (new Card(Suit.Hearts, Value.Ten));
			expected.Add (new Card(Suit.Clubs, Value.Ten));
			expected.Add (new Card(Suit.Diamonds, Value.Ten));
			expected.Add (new Card(Suit.Spades, Value.Ten));
			expected.Add (new Card(Suit.Hearts, Value.Ace));
			Assert.AreEqual (expected, Hand.HasQuads(c));
		}

		[Test]
		public void TestHasQuadsTrips ()
		{
			var c = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Nine));
			c.Add (new Card(Suit.Diamonds, Value.Ten));
			c.Add (new Card(Suit.Spades, Value.Jack));
			c.Add (new Card(Suit.Clubs, Value.Two));
			c.Add (new Card(Suit.Hearts, Value.Ten));
			c.Add (new Card(Suit.Clubs, Value.Ten));
			Assert.AreEqual (null, Hand.HasQuads(c));
		}

		[Test]
		public void TestHasQuadsNoPairs ()
		{
			var c = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Nine));
			c.Add (new Card(Suit.Diamonds, Value.King));
			c.Add (new Card(Suit.Spades, Value.Jack));
			c.Add (new Card(Suit.Clubs, Value.Two));
			c.Add (new Card(Suit.Hearts, Value.Ten));
			c.Add (new Card(Suit.Clubs, Value.Three));
			Assert.AreEqual (null, Hand.HasQuads(c));
		}
	}

	
	[TestFixture]
	public class NUnitTestHasFullHouse
	{
		[Test]
		public void TestHasFullHouse ()
		{
			var c = new List<Card> ();
			var expected = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Ten));
			c.Add (new Card(Suit.Clubs, Value.Seven));
			c.Add (new Card(Suit.Diamonds, Value.Ace));
			c.Add (new Card(Suit.Clubs, Value.Ten));
			c.Add (new Card(Suit.Spades, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Six));

			expected.Add (new Card(Suit.Hearts, Value.Ace));
			expected.Add (new Card(Suit.Diamonds, Value.Ace));
			expected.Add (new Card(Suit.Spades, Value.Ace));
			expected.Add (new Card(Suit.Hearts, Value.Ten));
			expected.Add (new Card(Suit.Clubs, Value.Ten));
			Assert.AreEqual (expected, Hand.HasFullHouse(c));
		}

		[Test]
		public void TestHasFullHouseTwoPair ()
		{
			var c = new List<Card> ();
			var expected = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Five));
			c.Add (new Card(Suit.Clubs, Value.Six));
			c.Add (new Card(Suit.Diamonds, Value.Ace));
			c.Add (new Card(Suit.Clubs, Value.Five));
			c.Add (new Card(Suit.Spades, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Six));

			expected.Add (new Card(Suit.Hearts, Value.Ace));
			expected.Add (new Card(Suit.Diamonds, Value.Ace));
			expected.Add (new Card(Suit.Spades, Value.Ace));
			expected.Add (new Card(Suit.Hearts, Value.Six));
			expected.Add (new Card(Suit.Clubs, Value.Six));
			Assert.AreEqual (expected, Hand.HasFullHouse(c));
		}
		
		[Test]
		public void TestHasFullHouseNoPair ()
		{
			var c = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Two));
			c.Add (new Card(Suit.Clubs, Value.Three));
			c.Add (new Card(Suit.Diamonds, Value.Ace));
			c.Add (new Card(Suit.Clubs, Value.Five));
			c.Add (new Card(Suit.Spades, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Six));
			Assert.AreEqual (null, Hand.HasFullHouse(c));
		}

		[Test]
		public void TestHasFullHouseNoPairNoTrips ()
		{
			var c = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Two));
			c.Add (new Card(Suit.Clubs, Value.Three));
			c.Add (new Card(Suit.Diamonds, Value.King));
			c.Add (new Card(Suit.Clubs, Value.Five));
			c.Add (new Card(Suit.Spades, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Six));
			Assert.AreEqual (null, Hand.HasFullHouse(c));
		}
		
		[Test]
		public void TestHasFullHouseNoTrips ()
		{
			var c = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Two));
			c.Add (new Card(Suit.Clubs, Value.Six));
			c.Add (new Card(Suit.Diamonds, Value.King));
			c.Add (new Card(Suit.Clubs, Value.Five));
			c.Add (new Card(Suit.Spades, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Six));
			Assert.AreEqual (null, Hand.HasFullHouse(c));
		}
	}

	[TestFixture]
	public class NUnitTestHasFlush
	{
		[Test]
		public void TestHasFlush ()
		{
			var c = new List<Card> ();
			var expected = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Ten));
			c.Add (new Card(Suit.Diamonds, Value.King));
			c.Add (new Card(Suit.Hearts, Value.Jack));
			c.Add (new Card(Suit.Hearts, Value.Queen));
			c.Add (new Card(Suit.Clubs, Value.Seven));
			c.Add (new Card(Suit.Hearts, Value.Six));

			expected.Add (new Card(Suit.Hearts, Value.Ace));
			expected.Add (new Card(Suit.Hearts, Value.Queen));
			expected.Add (new Card(Suit.Hearts, Value.Jack));
			expected.Add (new Card(Suit.Hearts, Value.Ten));
			expected.Add (new Card(Suit.Hearts, Value.Six));
			Assert.AreEqual (expected, Hand.HasFlush(c));
		}

		[Test]
		public void TestHasFlushSixCard ()
		{
			var c = new List<Card> ();
			var expected = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Three));
			c.Add (new Card(Suit.Hearts, Value.Ten));
			c.Add (new Card(Suit.Diamonds, Value.King));
			c.Add (new Card(Suit.Hearts, Value.Jack));
			c.Add (new Card(Suit.Hearts, Value.Queen));
			c.Add (new Card(Suit.Hearts, Value.Seven));
			c.Add (new Card(Suit.Hearts, Value.Six));

			expected.Add (new Card(Suit.Hearts, Value.Queen));
			expected.Add (new Card(Suit.Hearts, Value.Jack));
			expected.Add (new Card(Suit.Hearts, Value.Ten));
			expected.Add (new Card(Suit.Hearts, Value.Seven));
			expected.Add (new Card(Suit.Hearts, Value.Six));
			Assert.AreEqual(expected, Hand.HasFlush(c));
		}

		[Test]
		public void TestHasFlushFourCard ()
		{
			var c = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Ten));
			c.Add (new Card(Suit.Diamonds, Value.King));
			c.Add (new Card(Suit.Hearts, Value.Jack));
			c.Add (new Card(Suit.Hearts, Value.Queen));
			c.Add (new Card(Suit.Clubs, Value.Seven));
			c.Add (new Card(Suit.Clubs, Value.Six));
			Assert.AreEqual (null, Hand.HasFlush(c));
		}

	}

	[TestFixture]
	public class NUnitTestHasStraight
	{
		[Test]
		public void TestHasStraightNormal ()
		{
			var c = new List<Card> ();
			var expected = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Ten));
			c.Add (new Card(Suit.Diamonds, Value.King));
			c.Add (new Card(Suit.Spades, Value.Jack));
			c.Add (new Card(Suit.Clubs, Value.Queen));
			c.Add (new Card(Suit.Clubs, Value.Seven));
			c.Add (new Card(Suit.Clubs, Value.Six));

			expected.Add (new Card(Suit.Hearts, Value.Ace));
			expected.Add (new Card(Suit.Diamonds, Value.King));
			expected.Add (new Card(Suit.Clubs, Value.Queen));
			expected.Add (new Card(Suit.Spades, Value.Jack));
			expected.Add (new Card(Suit.Hearts, Value.Ten));
			Assert.AreEqual (expected, Hand.HasStraight(c));
		}

		[Test]
		public void TestHasStraightLastCards ()
		{
			var c = new List<Card> ();
			var expected = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Nine));
			c.Add (new Card(Suit.Diamonds, Value.King));
			c.Add (new Card(Suit.Spades, Value.Ten));
			c.Add (new Card(Suit.Clubs, Value.Eight));
			c.Add (new Card(Suit.Clubs, Value.Six));
			c.Add (new Card(Suit.Clubs, Value.Seven));

			expected.Add (new Card(Suit.Spades, Value.Ten));
			expected.Add (new Card(Suit.Hearts, Value.Nine));
			expected.Add (new Card(Suit.Clubs, Value.Eight));
			expected.Add (new Card(Suit.Clubs, Value.Seven));
			expected.Add (new Card(Suit.Clubs, Value.Six));
			Assert.AreEqual (expected, Hand.HasStraight(c));
		}

		[Test]
		public void TestHasStraightWheel ()
		{
			var c = new List<Card> ();
			var expected = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Five));
			c.Add (new Card(Suit.Diamonds, Value.King));
			c.Add (new Card(Suit.Spades, Value.Two));
			c.Add (new Card(Suit.Clubs, Value.Three));
			c.Add (new Card(Suit.Clubs, Value.Eight));
			c.Add (new Card(Suit.Clubs, Value.Four));

			expected.Add (new Card(Suit.Hearts, Value.Five));
			expected.Add (new Card(Suit.Clubs, Value.Four));
			expected.Add (new Card(Suit.Clubs, Value.Three));
			expected.Add (new Card(Suit.Spades, Value.Two));
			expected.Add (new Card(Suit.Hearts, Value.Ace));
			Assert.AreEqual (expected, Hand.HasStraight(c));
		}

		[Test]
		public void TestHasStraightOffset ()
		{
			var c = new List<Card> ();
			var expected = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Nine));
			c.Add (new Card(Suit.Hearts, Value.Ten));
			c.Add (new Card(Suit.Diamonds, Value.Eight));
			c.Add (new Card(Suit.Spades, Value.Jack));
			c.Add (new Card(Suit.Clubs, Value.Queen));
			c.Add (new Card(Suit.Clubs, Value.Two));
			c.Add (new Card(Suit.Clubs, Value.Ace));

			expected.Add (new Card(Suit.Clubs, Value.Queen));
			expected.Add (new Card(Suit.Spades, Value.Jack));
			expected.Add (new Card(Suit.Hearts, Value.Ten));
			expected.Add (new Card(Suit.Hearts, Value.Nine));
			expected.Add (new Card(Suit.Diamonds, Value.Eight));
			Assert.AreEqual (expected, Hand.HasStraight(c));
		}

		[Test]
		public void TestHasStraightGap ()
		{
			var c = new List<Card> ();
			var expected = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Nine));
			c.Add (new Card(Suit.Diamonds, Value.King));
			c.Add (new Card(Suit.Spades, Value.Jack));
			c.Add (new Card(Suit.Clubs, Value.Eight));
			c.Add (new Card(Suit.Clubs, Value.Seven));
			c.Add (new Card(Suit.Clubs, Value.Ten));

			expected.Add (new Card(Suit.Spades, Value.Jack));
			expected.Add (new Card(Suit.Clubs, Value.Ten));
			expected.Add (new Card(Suit.Hearts, Value.Nine));
			expected.Add (new Card(Suit.Clubs, Value.Eight));
			expected.Add (new Card(Suit.Clubs, Value.Seven));
			Assert.AreEqual (expected, Hand.HasStraight(c));
		}

		[Test]
		public void TestHasStraightFourCard ()
		{
			var c = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Nine));
			c.Add (new Card(Suit.Diamonds, Value.King));
			c.Add (new Card(Suit.Spades, Value.Jack));
			c.Add (new Card(Suit.Clubs, Value.Eight));
			c.Add (new Card(Suit.Clubs, Value.Five));
			c.Add (new Card(Suit.Clubs, Value.Ten));
			Assert.AreEqual (null, Hand.HasStraight(c));
		}

		[Test]
		public void TestHasStraightFourCardWheel ()
		{
			var c = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Jack));
			c.Add (new Card(Suit.Hearts, Value.Five));
			c.Add (new Card(Suit.Diamonds, Value.King));
			c.Add (new Card(Suit.Spades, Value.Two));
			c.Add (new Card(Suit.Clubs, Value.Three));
			c.Add (new Card(Suit.Clubs, Value.Eight));
			c.Add (new Card(Suit.Clubs, Value.Four));
			Assert.AreEqual (null, Hand.HasStraight(c));
		}

		[Test]
		public void TestHasStraightThreeCard ()
		{
			var c = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Nine));
			c.Add (new Card(Suit.Diamonds, Value.King));
			c.Add (new Card(Suit.Spades, Value.Jack));
			c.Add (new Card(Suit.Clubs, Value.Two));
			c.Add (new Card(Suit.Clubs, Value.Five));
			c.Add (new Card(Suit.Clubs, Value.Ten));
			Assert.AreEqual (null, Hand.HasStraight(c));
		}
	}

	[TestFixture]
	public class NUnitTestHasTrips
	{
		[Test]
		public void TestHasTripsNormal ()
		{
			var c = new List<Card> ();
			var expected = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Nine));
			c.Add (new Card(Suit.Diamonds, Value.Ten));
			c.Add (new Card(Suit.Spades, Value.Jack));
			c.Add (new Card(Suit.Clubs, Value.Two));
			c.Add (new Card(Suit.Hearts, Value.Ten));
			c.Add (new Card(Suit.Clubs, Value.Ten));

			expected.Add (new Card(Suit.Diamonds, Value.Ten));
			expected.Add (new Card(Suit.Hearts, Value.Ten));
			expected.Add (new Card(Suit.Clubs, Value.Ten));
			expected.Add (new Card(Suit.Hearts, Value.Ace));
			expected.Add (new Card(Suit.Spades, Value.Jack));
			Assert.AreEqual (expected, Hand.HasTrips(c));
		}

		/* This test checks for functionality required for
		 * HasFullHouse() */
		[Test]
		public void TestHasTripsTwo ()
		{
			var c = new List<Card> ();
			var expected = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Jack));
			c.Add (new Card(Suit.Clubs, Value.Jack));
			c.Add (new Card(Suit.Diamonds, Value.Ten));
			c.Add (new Card(Suit.Spades, Value.Jack));
			c.Add (new Card(Suit.Clubs, Value.Two));
			c.Add (new Card(Suit.Hearts, Value.Ten));
			c.Add (new Card(Suit.Clubs, Value.Ten));

			expected.Add (new Card(Suit.Hearts, Value.Jack));
			expected.Add (new Card(Suit.Clubs, Value.Jack));
			expected.Add (new Card(Suit.Spades, Value.Jack));
			expected.Add (new Card(Suit.Diamonds, Value.Ten));
			expected.Add (new Card(Suit.Hearts, Value.Ten));
			Assert.AreEqual (expected, Hand.HasTrips(c));
		}

		[Test]
		public void TestHasTripsPair ()
		{
			var c = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Nine));
			c.Add (new Card(Suit.Diamonds, Value.Ace));
			c.Add (new Card(Suit.Spades, Value.Jack));
			c.Add (new Card(Suit.Clubs, Value.Two));
			c.Add (new Card(Suit.Hearts, Value.Ten));
			c.Add (new Card(Suit.Clubs, Value.Ten));
			Assert.AreEqual (null, Hand.HasTrips(c));
		}

		[Test]
		public void TestHasTripsNoPairs ()
		{
			var c = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Nine));
			c.Add (new Card(Suit.Diamonds, Value.King));
			c.Add (new Card(Suit.Spades, Value.Jack));
			c.Add (new Card(Suit.Clubs, Value.Two));
			c.Add (new Card(Suit.Hearts, Value.Ten));
			c.Add (new Card(Suit.Clubs, Value.Three));
			Assert.AreEqual (null, Hand.HasTrips(c));
		}
	}
	
	[TestFixture]
	public class NUnitTestHasTwoPair
	{
		[Test]
		public void TestHasTwoPair ()
		{
			var c = new List<Card> ();
			var expected = new List<Card>();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Nine));
			c.Add (new Card(Suit.Diamonds, Value.Ten));
			c.Add (new Card(Suit.Spades, Value.King));
			c.Add (new Card(Suit.Clubs, Value.Two));
			c.Add (new Card(Suit.Hearts, Value.King));
			c.Add (new Card(Suit.Clubs, Value.Ace));

			expected.Add (new Card(Suit.Clubs, Value.Ace));
			expected.Add (new Card(Suit.Hearts, Value.Ace));
			expected.Add (new Card(Suit.Spades, Value.King));
			expected.Add (new Card(Suit.Hearts, Value.King));
			expected.Add (new Card(Suit.Hearts, Value.Ten));
			Assert.AreEqual (expected, Hand.HasTwoPair(c));
		}

		[Test]
		public void TestHasTwoPairThreePair ()
		{
			var c = new List<Card> ();
			var expected = new List<Card>();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Nine));
			c.Add (new Card(Suit.Diamonds, Value.Ten));
			c.Add (new Card(Suit.Spades, Value.King));
			c.Add (new Card(Suit.Clubs, Value.Nine));
			c.Add (new Card(Suit.Hearts, Value.King));
			c.Add (new Card(Suit.Clubs, Value.Ace));

			expected.Add (new Card(Suit.Clubs, Value.Ace));
			expected.Add (new Card(Suit.Hearts, Value.Ace));
			expected.Add (new Card(Suit.Spades, Value.King));
			expected.Add (new Card(Suit.Hearts, Value.King));
			expected.Add (new Card(Suit.Diamonds, Value.Ten));
			Assert.AreEqual (expected, Hand.HasTwoPair(c));
		}

		[Test]
		public void TestHasTwoPairFail ()
		{
			var c = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Nine));
			c.Add (new Card(Suit.Diamonds, Value.Ten));
			c.Add (new Card(Suit.Spades, Value.King));
			c.Add (new Card(Suit.Clubs, Value.Two));
			c.Add (new Card(Suit.Hearts, Value.Six));
			c.Add (new Card(Suit.Clubs, Value.Ace));
			Assert.AreEqual (null, Hand.HasTwoPair(c));
		}
	}

	[TestFixture]
	public class NUnitTestHasPair
	{
		[Test]
		public void TestHasPairAces ()
		{
			var c = new List<Card> ();
			var expected = new List<Card>();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Nine));
			c.Add (new Card(Suit.Diamonds, Value.Ten));
			c.Add (new Card(Suit.Spades, Value.King));
			c.Add (new Card(Suit.Clubs, Value.Two));
			c.Add (new Card(Suit.Hearts, Value.Three));
			c.Add (new Card(Suit.Clubs, Value.Ace));

			expected.Add (new Card(Suit.Clubs, Value.Ace));
			expected.Add (new Card(Suit.Hearts, Value.Ace));
			expected.Add (new Card(Suit.Spades, Value.King));
			expected.Add (new Card(Suit.Diamonds, Value.Ten));
			expected.Add (new Card(Suit.Hearts, Value.Nine));
			Assert.AreEqual (expected, Hand.HasPair(c));
		}

		[Test]
		public void TestHasPairThrees ()
		{
			var c = new List<Card> ();
			var expected = new List<Card>();
			c.Add (new Card(Suit.Hearts, Value.Three));
			c.Add (new Card(Suit.Hearts, Value.Nine));
			c.Add (new Card(Suit.Diamonds, Value.Ten));
			c.Add (new Card(Suit.Spades, Value.Jack));
			c.Add (new Card(Suit.Clubs, Value.Two));
			c.Add (new Card(Suit.Spades, Value.Three));
			c.Add (new Card(Suit.Clubs, Value.Five));

			expected.Add (new Card(Suit.Hearts, Value.Three));
			expected.Add (new Card(Suit.Hearts, Value.Three));
			expected.Add (new Card(Suit.Spades, Value.Jack));
			expected.Add (new Card(Suit.Diamonds, Value.Ten));
			expected.Add (new Card(Suit.Hearts, Value.Nine));
			Assert.AreEqual (expected, Hand.HasPair(c));
		}

		[Test]
		public void TestHasPairFail ()
		{
			var c = new List<Card> ();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Three));
			c.Add (new Card(Suit.Diamonds, Value.Ten));
			c.Add (new Card(Suit.Spades, Value.Five));
			c.Add (new Card(Suit.Clubs, Value.Two));
			c.Add (new Card(Suit.Hearts, Value.Eight));
			c.Add (new Card(Suit.Clubs, Value.King));
			Assert.AreEqual (null, Hand.HasPair(c));
		}
	}
	
	[TestFixture]
	public class NUnitTestHasHighCard
	{
		[Test]
		public void TestHasHighCardAce ()
		{
			var c = new List<Card> ();
			var expected = new List<Card>();
			c.Add (new Card(Suit.Hearts, Value.Ace));
			c.Add (new Card(Suit.Hearts, Value.Three));
			c.Add (new Card(Suit.Diamonds, Value.Ten));
			c.Add (new Card(Suit.Spades, Value.Five));
			c.Add (new Card(Suit.Clubs, Value.Two));
			c.Add (new Card(Suit.Hearts, Value.Eight));
			c.Add (new Card(Suit.Clubs, Value.King));

			expected.Add (new Card(Suit.Hearts, Value.Ace));
			expected.Add (new Card(Suit.Clubs, Value.King));
			expected.Add (new Card(Suit.Diamonds, Value.Ten));
			expected.Add (new Card(Suit.Hearts, Value.Eight));
			expected.Add (new Card(Suit.Spades, Value.Five));
			Assert.AreEqual (expected, Hand.GetHighCards(c, 5));
		}

		[Test]
		public void TestHasHighCardKing ()
		{
			var c = new List<Card> ();
			var expected = new List<Card>();
			c.Add (new Card(Suit.Hearts, Value.Seven));
			c.Add (new Card(Suit.Hearts, Value.Three));
			c.Add (new Card(Suit.Diamonds, Value.Ten));
			c.Add (new Card(Suit.Spades, Value.Five));
			c.Add (new Card(Suit.Clubs, Value.Two));
			c.Add (new Card(Suit.Hearts, Value.Eight));
			c.Add (new Card(Suit.Clubs, Value.King));

			expected.Add (new Card(Suit.Clubs, Value.King));
			expected.Add (new Card(Suit.Diamonds, Value.Ten));
			expected.Add (new Card(Suit.Hearts, Value.Eight));
			expected.Add (new Card(Suit.Hearts, Value.Seven));
			expected.Add (new Card(Suit.Spades, Value.Five));
			Assert.AreEqual (expected, Hand.GetHighCards(c, 5));
		}

		[Test]
		public void TestHasHighCardLow ()
		{
			var c = new List<Card> ();
			var expected = new List<Card>();
			c.Add (new Card(Suit.Hearts, Value.Nine));
			c.Add (new Card(Suit.Hearts, Value.Seven));
			c.Add (new Card(Suit.Diamonds, Value.Five));
			c.Add (new Card(Suit.Spades, Value.Eight));
			c.Add (new Card(Suit.Clubs, Value.Two));
			c.Add (new Card(Suit.Hearts, Value.Four));
			c.Add (new Card(Suit.Clubs, Value.Three));

			expected.Add (new Card(Suit.Hearts, Value.Nine));
			expected.Add (new Card(Suit.Spades, Value.Eight));
			expected.Add (new Card(Suit.Hearts, Value.Seven));
			expected.Add (new Card(Suit.Diamonds, Value.Five));
			expected.Add (new Card(Suit.Hearts, Value.Four));
			Assert.AreEqual (expected, Hand.GetHighCards(c, 5));
		}
	}
}

