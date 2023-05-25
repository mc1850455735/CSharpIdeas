using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CSharpIdeas
{
    public partial class RoundButton : Button
    {
        #region --成员变量--

        RectangleF rect = new RectangleF();//控件矩形
        bool mouseEnter;//鼠标是否进入控件区域的标志
        bool buttonPressed;//按钮是否按下
        bool buttonClicked;//按钮是否被点击
        #endregion

        #region --属性--

        #endregion

        #endregion

        #region --构造函数--
        /// <summary>
        /// 构造函数
        /// </summary>
        public RoundButton()
        {
            // 控件风格
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);
            //初始值设定
            this.Height = this.Width = 80;

            DistanceToBorder = 4;
            ButtonCenterColorStart = Color.CornflowerBlue;
            ButtonCenterColorEnd = Color.DodgerBlue;
            BorderColor = Color.Black;
            FocusBorderColor = Color.Orange;
            IconColor = Color.Black;
            BorderWidth = 4;
            BorderTransparent = 200;
            GradientAngle = 90;

            mouseEnter = false;
            buttonPressed = false;
            buttonClicked = false;
            IsShowIcon = true;

            InitializeComponent();
        }
        #endregion

        #region --重写部分事件--

        #region OnPaint事件

        /// <summary>
        /// 控件绘制
        /// </summary>
        /// <param name="pevent"></param>
        protected override void OnPaint(PaintEventArgs pevent)
        {
            //base.OnPaint(pevent);
            base.OnPaintBackground(pevent);

            Graphics g = pevent.Graphics;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.AntiAlias;//抗锯齿         

            myResize();//调整圆形区域

            var brush = new LinearGradientBrush(rect, ButtonCenterColorStart, ButtonCenterColorEnd, GradientAngle);

            PaintShape(g, brush, rect);//绘制按钮中心区域

            DrawBorder(g);//绘制边框            

            DrawStateIcon(g);//绘制按钮功能标志

            if (mouseEnter)
            {
                DrawHighLight(g);//绘制高亮区域
                DrawStateIcon(g);//绘制按钮功能标志
            }
        }

        #endregion

        #region 鼠标

        /// <summary>
        /// 鼠标点击事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            buttonClicked = !buttonClicked;
        }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button != MouseButtons.Left) return;
            buttonPressed = false;
            base.Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button != MouseButtons.Left) return;
            buttonPressed = true;
        }

        /// <summary>
        /// 鼠标进入按钮
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            mouseEnter = true;
        }

        /// <summary>
        /// 鼠标离开控件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            mouseEnter = false;
        }

        #endregion
        #endregion

        #region --自定义函数--

        /// <summary>
        /// 绘制中心区域标志
        /// </summary>
        /// <param name="g"></param>
        private void DrawStateIcon(Graphics g)
        {
            if (IsShowIcon)
            {
                if (buttonClicked)
                {
                    GraphicsPath startIconPath = new GraphicsPath();
                    int W = base.Width / 3;
                    Point p1 = new Point(W, W);
                    Point p2 = new Point(2 * W, W);
                    Point p3 = new Point(2 * W, 2 * W);
                    Point p4 = new Point(W, 2 * W);
                    Point[] pts = { p1, p2, p3, p4 };
                    startIconPath.AddLines(pts);
                    Brush brush = new SolidBrush(IconColor);
                    g.FillPath(brush, startIconPath);
                }
                else
                {
                    GraphicsPath stopIconPath = new GraphicsPath();
                    int W = base.Width / 4;
                    Point p1 = new Point(3 * W / 2, W);
                    Point p2 = new Point(3 * W / 2, 3 * W);
                    Point p3 = new Point(3 * W, 2 * W);
                    Point[] pts = { p1, p2, p3, };
                    stopIconPath.AddLines(pts);
                    Brush brush = new SolidBrush(IconColor);
                    g.FillPath(brush, stopIconPath);
                }
            }
        }

        /// <summary>
        /// 重新确定控件大小
        /// </summary>
        protected void myResize()
        {
            int x = DistanceToBorder;
            int y = DistanceToBorder;
            int width = this.Width - 2 * DistanceToBorder;
            int height = this.Height - 2 * DistanceToBorder;
            rect = new RectangleF(x, y, width, height);
        }

        /// <summary>
        /// 绘制高亮效果
        /// </summary>
        /// <param name="g">Graphic对象</param>
        protected virtual void DrawHighLight(Graphics g)
        {
            RectangleF highlightRect = rect;
            highlightRect.Inflate(-BorderWidth / 2, -BorderWidth / 2);
            Brush brush = Brushes.DodgerBlue;
            if (buttonPressed)
            {
                brush = new LinearGradientBrush(rect, ButtonCenterColorStart, ButtonCenterColorEnd, GradientAngle);
            }

            else
            {
                brush = new LinearGradientBrush(rect, Color.FromArgb(60, Color.White),
              Color.FromArgb(60, Color.White), GradientAngle);
            }
            PaintShape(g, brush, highlightRect);
        }

        /// <summary>
        /// 绘制边框
        /// </summary>
        /// <param name="g">Graphics对象</param>
        protected virtual void DrawBorder(Graphics g)
        {
            Pen p = new Pen(BorderColor);
            if (Focused)
            {
                p.Color = FocusBorderColor;//外圈获取焦点后的颜色
                p.Width = BorderWidth;
                PaintShape(g, p, rect);
            }
            else
            {
                p.Width = BorderWidth;
                PaintShape(g, p, rect);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g">Graphic对象</param>
        protected virtual void DrawPressState(Graphics g)
        {
            RectangleF pressedRect = rect;
            pressedRect.Inflate(-2, -2);
            Brush brush = new LinearGradientBrush(rect, Color.FromArgb(60, Color.White),
                Color.FromArgb(60, Color.White), GradientAngle);
            PaintShape(g, brush, pressedRect);
        }

        /// <summary>
        /// 绘制图形
        /// </summary>
        /// <param name="g">Graphics对象</param>
        /// <param name="pen">Pen对象</param>
        /// <param name="rect">RectangleF对象</param>
        protected virtual void PaintShape(Graphics g, Pen pen, RectangleF rect)
        {
            g.DrawEllipse(pen, rect);
        }

        /// <summary>
        /// 绘制图形 
        /// </summary>
        /// <param name="g">Graphics对象</param>
        /// <param name="brush">Brush对象</param>
        /// <param name="rect">Rectangle对象</param>
        protected virtual void PaintShape(Graphics g, Brush brush, RectangleF rect)
        {
            g.FillEllipse(brush, rect);
        }

        #endregion
    }
}