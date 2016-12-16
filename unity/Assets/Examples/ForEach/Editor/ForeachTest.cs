using NUnit.Framework;
using System.Collections.Generic;
using System;
public class ForeachTest
{

    [Test]
    public void EditorTest0()
    {
        var names = new List<string> { "Taro", "Jiro", "Saburo" };

        var actions = new List<Action>();

        foreach (string name in names)
        {
            actions.Add(() =>
            {
                UnityEngine.Debug.Log(name);
                Console.WriteLine(name);
            });
        }

        foreach(var action in actions)
        {
            action();
        }
    }

    [Test]
    public void EditorTest1()
    {
        var names = new List<string> { "Taro", "Jiro", "Saburo" };

        var actions = new List<Action>();

        foreach (string name in names)
        {
            var n = name;
            actions.Add(() =>
            {
                UnityEngine.Debug.LogFormat("{0} : {1}", n, name);
                Console.WriteLine("{0} : {1}", n, name);
            });
        }

        foreach (var action in actions)
        {
            action();
        }
    }

}
