﻿using System;
using System.Collections.Generic;
using NUnit.Framework;

public class ForeachTest
{
    [Test]
    public void ExpectedBehaviourTest0()
    {
        var ints = new[] { 0, 1, 2 };
        var list = new List<Func<int>>();
        foreach (var num in ints)
        {
            list.Add(() => num);
        }

        Assert.AreEqual(0, list[0]());
        Assert.AreEqual(1, list[1]());
        Assert.AreEqual(2, list[2]());
    }

    [Test]
    public void ExpectedBehaviourTest1()
    {
        var ints = new[] { 0, 1, 2 };
        var list = new List<Func<int>>();
        foreach (var num in ints)
        {
            var n = num;
            list.Add(() => n);
        }

        Assert.AreEqual(0, list[0]());
        Assert.AreEqual(1, list[1]());
        Assert.AreEqual(2, list[2]());
    }
}
