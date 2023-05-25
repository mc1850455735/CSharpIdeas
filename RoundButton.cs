using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpIdeas
{
    public partial class RoundButton : Button
    {
        private int radius;
        private Image imageEnter;
        private Image imageNormal;

        [Category("布局"), Browsable(true), ReadOnly(false)]
        public int Radius
        {
            get { return radius; }
            set
            {
                radius = value;
                this.Height = this.Width = Radius;
            }
        }

        [Category("外观"), Browsable(true), ReadOnly(false)]
        public Image ImageEnter
        {
            get => imageEnter;
            set => imageEnter = value;
        }

        [Category("外观"), Browsable(true), ReadOnly(false)]
        public Image ImageNormal
        {
            get => imageNormal;
            set
            {
                imageNormal = value;
                this.BackgroundImage = imageNormal;
            }
        }

        [Browsable(false)]
        public new Image BackgroundImage
        {
            get { return (Image)base.BackgroundImage; }
            set { base.BackgroundImage = value; }
        }

        [Browsable(false)]
        public new Size Size
        {
            get { return base.Size; }
            set { base.Size = value; }
        }


        public RoundButton()
        {
            Radius = 64;
            this.Height = this.Width = Radius;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackgroundImage = imageEnter;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, Radius, Radius);
            this.Region = new Region(path);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if(Height != Radius)
            {
                Radius = Width = Height;
            }
            else
            {
                Radius = Height = Width;
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            BackgroundImage = imageEnter;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseEnter(e);
            BackgroundImage = imageNormal;
        }

    }
}

