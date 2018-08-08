using System;
using System.Drawing;

namespace ScreenPen
{
    /// <summary>
    /// 椭圆类
    /// </summary>
    public class Oval : Shape
    {

        public override void Draw(System.Drawing.Graphics g)
        {
            Pen pen = new Pen(Color, Thickness);
            int x = StartX < EndX ? StartX : EndX;
            int y = StartY < EndY ? StartY : EndY;
            int width = Math.Abs(StartX - EndX);
            int height = Math.Abs(StartY - EndY);
            g.DrawEllipse(pen, x, y, width, height);
        }
    }
}