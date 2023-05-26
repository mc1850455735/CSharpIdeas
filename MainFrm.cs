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

        int sizes = 40;
        public MainFrm()
        {
            buttons = new RoundButton[9];
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < buttons.Length; i++)
            {
                buttons[i] = new RoundButton();
                buttons[i].Size = new Size(sizes, sizes);
                buttons[i].Location = new Point((i % 3) * sizes, (i / 3) * sizes);
                buttons[i].Click += ButtonClick_Event;
                this.Controls.Add(buttons[i]);
            }
        }

        private void ButtonClick_Event(object sender, EventArgs e)
        {
            MessageBox.Show("hhel");
        }
    }
}
