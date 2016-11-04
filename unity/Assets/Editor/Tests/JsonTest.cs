using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework;

namespace MrStarBase
{
    public class JsonTest
    {
        [Test]
        public void ToJsonTest()
        {

            Assert.AreEqual(
                "{\"name\":\"Ryota\",\"age\":27}",
                JsonUtility.ToJson(new Person { name = "Ryota", age = 27 })
            );

            Assert.AreEqual(
                "{\"array\":[0,1,2]}",
                JsonUtility.ToJson(new IntArrayContainer { array = new int[] { 0, 1, 2 } })
            );

            Assert.AreEqual(
                "{\"list\":[0,1,2]}",
                JsonUtility.ToJson(new IntListContainer { list = new List<int> { 0, 1, 2 } })
            );
        }

        [Test]
        public void UnexpectedToJsonTest()
        {
            Assert.AreEqual(
                string.Empty, // "null"
                JsonUtility.ToJson(null)
            );

            Assert.AreEqual(
                "{\"name\":\"\",\"age\":27}", // "{\"name\":null,\"age\":27}",
                JsonUtility.ToJson(new Person { name = null, age = 27 })
            );

            Assert.AreEqual(
                "{}", // "{\"name\":\"Ryota\",\"age\":27}",
                JsonUtility.ToJson(new { name = "Ryota", age = 27 })
            );

            Assert.AreEqual(
                "{}", // "true"
                JsonUtility.ToJson(true)
            );

            Assert.AreEqual(
                "{}", // "[1,2,3]"
                JsonUtility.ToJson(new List<int> { 0, 1, 2 })
            );

            Assert.AreEqual(
                "{}", // "[1,2,3]"
                JsonUtility.ToJson(new int[] { 0, 1, 2 })
            );
        }
    }

    class Team
    {
        public string name;
        public int age;
    }

    class Person
    {
        public string name;
        public int age;
    }

    class IntArrayContainer
    {
        public int[] array;
    }

    class IntListContainer
    {
        public List<int> list;
    }
}