using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace MrStarBase
{
	public class PointTest
	{
		[Test]
		public void CtorTest ()
		{
			Assert.AreEqual (new Point (2, 1), new Point (2, 1));
			Assert.AreNotEqual (new Point (2, 1), new Point (3, 1));
			Assert.AreNotEqual (new Point (2, 1), new Point (2, 0));
			Assert.AreNotEqual (new Point (2, 1), new Point (1, 2));
			Assert.True (new Point (2, 1).X == 2);
			Assert.True (new Point (2, 1).Y == 1);
		}

		[Test]
		public void EqualsTest ()
		{
			Assert.True (new Point (2, 1).Equals (new Point (2, 1)));
			Assert.False (new Point (2, 1).Equals (new Point (3, 1)));
			Assert.False (new Point (2, 1).Equals (new Point (2, 0)));
			Assert.False (new Point (2, 1).Equals (new Point (1, 2)));
			Assert.False (new Point (2, 1).Equals (null));
			Assert.False (new Point (2, 1).Equals (string.Empty));
		}

		[Test]
		public void DistanceTest ()
		{
			Assert.AreEqual (0, new Point (2, 1).Distance (new Point (2, 1)));
			Assert.AreEqual (1, new Point (2, 1).Distance (new Point (3, 1)));
			Assert.AreEqual (1, new Point (2, 1).Distance (new Point (1, 1)));
			Assert.AreEqual (1, new Point (2, 1).Distance (new Point (2, 0)));
			Assert.AreEqual (1, new Point (2, 1).Distance (new Point (2, 2)));
			Assert.AreEqual (2, new Point (2, 1).Distance (new Point (1, 2)));
			Assert.AreEqual (2, new Point (2, 1).Distance (new Point (2, 3)));
			Assert.AreEqual (2, new Point (2, 1).Distance (new Point (0, 1)));
			Assert.AreEqual (10, new Point (2, 1).Distance (new Point (12, 1)));
		}

		[Test]
		public void IsNextTest ()
		{
			Assert.True (new Point (2, 1).IsNext (new Point (3, 1)));
			Assert.True (new Point (2, 1).IsNext (new Point (1, 1)));
			Assert.True (new Point (2, 1).IsNext (new Point (2, 0)));
			Assert.True (new Point (2, 1).IsNext (new Point (2, 2)));

			Assert.False (new Point (2, 1).IsNext (new Point (2, 1)));
			Assert.False (new Point (2, 1).IsNext (new Point (1, 2)));
			Assert.False (new Point (2, 1).IsNext (new Point (2, 3)));
			Assert.False (new Point (2, 1).IsNext (new Point (0, 1)));
			Assert.False (new Point (2, 1).IsNext (new Point (12, 1)));
		}

		[Test]
		public void OperatorTest ()
		{
			Assert.True (new Point (2, 1) == new Point (2, 1));
			Assert.False (new Point (2, 1) == new Point (3, 1));
			Assert.False (new Point (2, 1) == new Point (2, 0));
			Assert.False (new Point (2, 1) == new Point (1, 2));

			Assert.False (new Point (2, 1) != new Point (2, 1));
			Assert.True (new Point (2, 1) != new Point (3, 1));
			Assert.True (new Point (2, 1) != new Point (2, 0));
			Assert.True (new Point (2, 1) != new Point (1, 2));
		}
	}
}