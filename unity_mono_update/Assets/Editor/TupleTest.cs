using NUnit.Framework;
using System;

public class TupleTest
{
    [Test]
    public void EditorTest()
    {
        var tuple = Tuple.Create(1, "3");
        Assert.AreEqual(1, tuple.Item1);
        Assert.AreEqual("3", tuple.Item2);
    }
}
