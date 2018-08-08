using System;
using System.Drawing;

namespace ScreenPen
{
    /// <summary>
    /// 线条类
    /// </summary>
    public class Line : Shape
    {

        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(Color, Thickness);
            g.DrawLine(pen, StartX, StartY, EndX, EndY);
        }
    }
}