using System;

namespace AvodatKaitz
{
    public class Rectangle
    {
        //Points are in a Euclidean space
        private Point bottomLeft; //The bottom left point of the rectangle
        private Point topRight; //The top right point of the rectangle

        public Rectangle(Point bottomLeft, Point topRight)
        {
            this.bottomLeft = bottomLeft;
            this.topRight = topRight;
        }

        public Rectangle(Point bottomLeft, double width, double height)
        {
            this.bottomLeft = bottomLeft;
            this.topRight = new Point(bottomLeft.x + width, bottomLeft.y + height);
        }

        /// <summary>
        /// Returns the area of the rectangle 
        /// </summary>
        /// <returns></returns>
        public double GetArea()
        {
            return (this.topRight.y - this.bottomLeft.y) * (this.topRight.x - this.bottomLeft.x);
        }

        /// <summary>
        /// Returns the perimeter of the rectangle
        /// </summary>
        /// <returns></returns>
        public double GetPerimeter()
        {
            return 2 * ((this.topRight.y - this.bottomLeft.y) + (this.topRight.x - this.bottomLeft.x));
        }

        /// <summary>
        /// Moves the rectangle by such and such delta x and delta y (right left, up down)
        /// </summary>
        /// <param name="deltaX"></param>
        /// <param name="deltaY"></param>
        public string Move(double deltaX, double deltaY)
        {
            this.bottomLeft = new Point(this.bottomLeft.x + deltaX, this.bottomLeft.y + deltaY);
            this.topRight = new Point(this.topRight.x + deltaX, this.topRight.y + deltaY);
            return this.ToString();
        }

        public override string ToString()
        {
            return "Rectangle: \nBottom-Left-Point = " + this.bottomLeft.ToString() + "\nTop-Right-Point = " +
                   this.topRight.ToString();
        }
    }
}