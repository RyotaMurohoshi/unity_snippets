using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace MrStarBase
{
    public class ForeachTest
    {
        [Test]
        public void UnexpectedBehaviourTest()
        {
            var ints = new[] { 0, 1, 2 };
            var list = new List<Func<int>>();
            foreach (var num in ints)
            {
                list.Add(() => num);
            }

            Assert.AreEqual(2, list[0]());
            Assert.AreEqual(2, list[1]());
            Assert.AreEqual(2, list[2]());
        }
    }
}