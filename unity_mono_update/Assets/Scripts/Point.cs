using UnityEngine;

public class Point
{
    public int X { get; }
    public int Y { get; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public static int CalculationDistance(Point a, Point b) => Mathf.Abs(a.X - b.X) + Mathf.Abs(a.Y - b.Y);

    public override string ToString() => $"[x = {X}, y = {Y}]";
}
