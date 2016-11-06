using NUnit.Framework;
using System.Collections.Generic;

public class IReadOnlyTest
{
    [Test]
    public void EditorTest()
    {
        IReadOnlyList<int> list = new List<int> { 3, 1, 4, 1 };
        Assert.AreEqual(4, list.Count);
        Assert.AreEqual(3, list[0]);
        Assert.AreEqual(1, list[1]);
        Assert.AreEqual(4, list[2]);
        Assert.AreEqual(1, list[3]);
        Assert.AreEqual(new List<int> { 3, 1, 4, 1 }, list);
    }
}
