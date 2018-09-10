﻿namespace AvodatKaitz
{
    public class Point
    {
        public double x { get; set; }
        public double y { get; set; }

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return "(" + x + "," + y + ")";
        }
    }
}