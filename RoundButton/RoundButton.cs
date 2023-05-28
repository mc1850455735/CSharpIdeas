using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace CSharpIdeas
{
    public partial class RoundButton : Button
    {
        #region --成员变量--
        // 控件
        Rectangle rect = new Rectangle();
        bool mouseEnter = false;
        bool buttonPressed = false;
        #endregion

        #region --属性--
        #region 主体
        // 设置按钮边到边框的距离
        [Browsable(true), DefaultValue(2)]
        [Category("外貌")]
        public int DistanceToBorder { get; set; }

        [Browsable(true), DefaultValue(typeof(Color), "DodgerBlue"), Description("按钮颜色")]
        [Category("外貌")]
        public Color ButtonColor { get; set; }

        [Browsable(true), DefaultValue(typeof(Color), "White"), Description("按钮按下颜色")]
        [Category("外貌")]
        public Color ButtonPressColor
        {
            get {
                int r, g, b;
                r = ButtonColor.R - (int)(ButtonColor.R * 0.8);
                g = ButtonColor.G - (int)(ButtonColor.G * 0.8);
                b = ButtonColor.B - (int)(ButtonColor.B * 0.8);
                return Color.FromArgb(ButtonColor.A, r, g, b); 
            }
        }

        [Browsable(true), DefaultValue(typeof(Color), "White"), Description("按钮默认颜色")]
        [Category("外貌")]
        public Color ButtonOverColor 
        {
            get { 
                int r, g, b;
                r = ButtonColor.R + (int)((255 - ButtonColor.R) * 0.8);
                g = ButtonColor.G + (int)((255 - ButtonColor.G) * 0.8);
                b = ButtonColor.B + (int)((255 - ButtonColor.B) * 0.8);
                return Color.FromArgb(ButtonColor.A, r, g, b);
            }
        }
        #endregion
        #region 边框
        [Browsable(true), DefaultValue(typeof(Color), "Black"), Description("按钮边框颜色")]
        [Category("外貌")]
        public Color BorderColor { get; set; }

        [Browsable(true), DefaultValue(4), Description("按钮边框大小")]
        [Category("外貌")]
        public int BorderWidth { get; set; }
        #endregion
        #endregion

        #region --构造函数--
        public RoundButton()
        {
            // 设置初始值 
            this.Height = this.Width = 100;
            DistanceToBorder = 3;
            ButtonColor = Color.FromArgb(100, 200, 200, 200);
            BorderColor = Color.Black;
            BorderWidth = 4;

            InitializeComponent();
        }
        #endregion

        #region --重写事件--

        // 控件绘制
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
            Graphics g = pevent.Graphics;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.HighQuality;
            ReSize();

            var brush = new SolidBrush(ButtonColor);
            // 绘制按钮主体
            PaintShape(g, brush, rect);

            // 绘制按钮边框
            DrawBorder(g);

            if(mouseEnter && !buttonPressed)
            {
                PaintShape(g, new SolidBrush(ButtonOverColor), rect);
            }
            else if(buttonPressed)
            {
                PaintShape(g, new SolidBrush(ButtonPressColor), rect);
            }
        }

        // 鼠标划入
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            mouseEnter = true;
        }

        // 鼠标划出
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            mouseEnter = false;
        }

        // 鼠标按下
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            // 查看按下的是鼠标哪个键
            if (e.Button != MouseButtons.Left) return;
            buttonPressed = true;
        }

        // 鼠标抬起
        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            if(mevent.Button != MouseButtons.Left) return;
            buttonPressed = false;
            // 重新绘制
            base.Invalidate();
        }
        #endregion

        #region --自定义函数--
        // 重新确认控件大小
        // 通过调节rect的大小
        protected void ReSize()
        {
            int x = DistanceToBorder;
            int y = DistanceToBorder;
            int width = this.Width - 2 * DistanceToBorder;
            int height = this.Height - 2 * DistanceToBorder;
            rect = new Rectangle(x, y, width, height);
        }

        // 绘制图形
        protected virtual void PaintShape(Graphics g, Pen pen, Rectangle rect)
        {
            g.DrawEllipse(pen, rect);
        }
        protected virtual void PaintShape(Graphics g, Brush brush, Rectangle rect)
        {
            g.FillEllipse(brush, rect);
        }

        // 绘制按钮边框
        protected virtual void DrawBorder(Graphics g)
        {
            Pen p = new Pen(BorderColor);
            p.Width = BorderWidth;
            PaintShape(g, p, rect);
        }
        #endregion
    }
}