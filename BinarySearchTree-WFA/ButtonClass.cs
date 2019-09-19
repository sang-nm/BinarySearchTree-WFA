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

namespace BinarySearchTree_WFA
{
    public partial class ButtonClass : Button
    {
        public ButtonClass()
        {
            InitializeComponent();
            Font = new Font("Times New Roman", 10F, FontStyle.Regular);
            Size = new Size(50, 50);
            AutoSize = false;
            //Margin = new Padding(30,30,30,30);
            Anchor = AnchorStyles.Top;
        }

        //public ButtonClass(int lv,out Point pos)
        //{
            
        //}

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(3, 3, ClientSize.Width - 7, ClientSize.Height - 7);
            pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pe.Graphics.DrawPath(new Pen(Color.Azure, 4), gp);
            Region = new Region(gp);
        }
    }
}
