using System;
using System.Drawing;

namespace ScreenPen
{
    /// <summary>
    /// 矩形类
    /// </summary>
    public class Rectangle : Shape
    {

        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(Color, Thickness);
            int x = StartX < EndX ? StartX : EndX;
            int y = StartY < EndY ? StartY : EndY;
            int width = Math.Abs(StartX - EndX);
            int height = Math.Abs(StartY - EndY);
            g.DrawRectangle(pen, x, y, width, height);
        }
    }
}