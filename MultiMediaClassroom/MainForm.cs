using ScreenPen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiMediaClassroom
{
    public partial class MainForm : Form
    {
        private Shape currentShape = null;          // 当前绘制的图形
        private string currentType = "线条";          // 当前选中的图形类型
        private Color currentColor = Color.Black;   // 当前选中的绘图颜色
        private float currentThick = 1f;            // 当前选中的图形粗细

        private bool isMouseLeftButtonDown = false; // 鼠标左键是否被按下

        private IList<Shape> list = new List<Shape>();

        public MainForm()
        {
            InitializeComponent();
            // 开启双缓冲
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            // 为单选按钮绑定事件
            foreach (Control c in panel1.Controls)
            {
                if (c is RadioButton)
                {
                    (c as RadioButton).CheckedChanged += new EventHandler(ChangeShapeType);
                }
            }

            this.FormBorderStyle = FormBorderStyle.None;    // 窗口无边框
            this.WindowState = FormWindowState.Maximized;   // 窗口最大化
            this.TopMost = true;    // 窗口置顶
            this.Opacity = 0.75;	// 窗口不透明度
        }

        // 点击单选按钮
        private void ChangeShapeType(object sender, EventArgs e)
        {
            currentType = (sender as RadioButton).Text; // 记录选中图形的类型
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseLeftButtonDown = true;
                currentShape = ShapeFactory.Create(currentType);
                if (currentShape != null)
                {
                    currentShape.Color = currentColor;
                    currentShape.Thickness = currentThick;
                    currentShape.StartX = currentShape.EndX = e.X;
                    currentShape.StartY = currentShape.EndY = e.Y;
                }
            }
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseLeftButtonDown && currentShape != null)
            {
                currentShape.EndX = e.X;
                currentShape.EndY = e.Y;
                this.Refresh();
            }
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (isMouseLeftButtonDown && currentShape != null)
            {
                isMouseLeftButtonDown = false;
                list.Add(currentShape);
                currentShape = null;
            }
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach (Shape shape in list)
            {
                shape.Draw(g);
            }
            if (currentShape != null)
            {
                currentShape.Draw(g);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                currentColor = colorDialog1.Color;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;
                using (Image image = new Bitmap(this.Width, this.Height))
                {
                    Graphics g = Graphics.FromImage(image);
                    foreach (Shape shape in list)
                    {
                        shape.Draw(g);
                    }
                    image.Save(filename, ImageFormat.Png);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            list.Clear();
            this.Refresh();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (list.Count > 0)
            {
                list.RemoveAt(list.Count - 1);
                this.Refresh();
            }
        }

        private void btnAddThick_Click(object sender, EventArgs e)
        {
            if (currentThick < 10)
            {
                currentThick += 0.5f;
            }
        }

        private void btnSubThick_Click(object sender, EventArgs e)
        {
            if (currentThick > 0.5)
            {
                currentThick -= 0.5f;
            }
        }
    }
}
