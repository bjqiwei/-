using System;

namespace ScreenPen
{
    /// <summary>
    /// 图形工厂（静态工厂模式）
    /// </summary>
    public static class ShapeFactory
    {

        /// <summary>
        /// 创建图形对象
        /// </summary>
        /// <param name="type">图形的类型</param>
        /// <returns>图形对象</returns>
        public static Shape Create(string type)
        {
            Shape sh = null;
            switch (type)
            {
                case "线条": sh = new Line(); break;
                case "矩形": sh = new Rectangle(); break;
                case "椭圆": sh = new Oval(); break;
            }
            return sh;
        }
    }
}