using System;
using System.Drawing;

namespace ScreenPen
{
    /// <summary>
    /// 抽象图形类
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// 起点的横坐标
        /// </summary>
        public int StartX { set; get; }

        /// <summary>
        /// 起点的纵坐标
        /// </summary>
        public int StartY { set; get; }

        /// <summary>
        /// 终点的横坐标
        /// </summary>
        public int EndX { set; get; }

        /// <summary>
        /// 终点的纵坐标
        /// </summary>
        public int EndY { set; get; }

        /// <summary>
        /// 图形的颜色
        /// </summary>
        public Color Color { set; get; }

        /// <summary>
        /// 图形的粗细
        /// </summary>
        public float Thickness { set; get; }

        /// <summary>
        /// 绘制图形
        /// </summary>
        /// <param name="g">画笔</param>
        public abstract void Draw(Graphics g);
    }
}