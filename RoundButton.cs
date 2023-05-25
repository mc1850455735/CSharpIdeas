using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CSharpIdeas
{
    public partial class RoundButton : Button
    {
        #region --成员变量--
        // 控件
        Rectangle rect = new Rectangle();
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
            this.Height = this.Width = 80;
            DistanceToBorder = 4;
            ButtonColor = Color.Red;
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