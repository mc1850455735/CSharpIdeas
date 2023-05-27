using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpIdeas
{
    public partial class MainFrm : Form
    {
        RoundButton[] buttons;
        readonly int N = 3;

        int sizes = 80;
        public MainFrm()
        {
            buttons = new RoundButton[N * N];
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int setPositionX, setPositionY;
            int distance = 10;

            setPositionY = 30;
            this.Height = setPositionY * 3 + N * (sizes + distance);
            setPositionX = this.Width / 2 - (int)((sizes + distance) * (double)N / 2);
            
            for(int i = 0; i < buttons.Length; i++)
            {
                buttons[i] = new RoundButton();
                buttons[i].Size = new Size(sizes, sizes);
                buttons[i].ButtonColor = Color.FromArgb(100, 255, 0, 0);
                buttons[i].Location = new Point(
                    (i % N) * sizes + setPositionX + (i % N * distance), 
                    (i / N) * sizes + setPositionY + (i / N * distance)
                    );
                buttons[i].Text = i.ToString();
                buttons[i].Click += ButtonClick_Event;
                this.Controls.Add(buttons[i]);
            }
        }

        private void ButtonClick_Event(object sender, EventArgs e)
        {
            RoundButton temp = (RoundButton)sender;
            int index = int.Parse(temp.Text);
            MessageBox.Show(index.ToString());
        }
    }
}
