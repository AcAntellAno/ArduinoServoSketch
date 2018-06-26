using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace TrackPad
{

    public partial class Form1 : Form
    {
        public Stopwatch watch { get; set;}

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            watch = Stopwatch.StartNew();
            Port.Open();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            writeToPort(new Point(e.X, e.Y));
        }

        public void writeToPort(Point coordinates)
        {
            if (watch.ElapsedMilliseconds > 15)
            {
                watch = Stopwatch.StartNew();
                Port.Write(String.Format("X{0}Y{1}",
                (180 - coordinates.Y / (Size.Width / 180)),
                (coordinates.X / (Size.Height / 180))));
            }
            
        }
    }
}
