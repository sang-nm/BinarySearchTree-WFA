using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinarySearchTree_WFA
{
    public partial class FormBST : Form
    {
        public FormBST()
        {
            InitializeComponent();
            Size = new Size(300, 200);
        }
        BSTClass bst = new BSTClass();
        public int MAX = 0;
        private void buttonClick_Click(object sender, EventArgs e)
        {
            
            if (textBoxIns.Text != "")
            {
                bst.insert(Convert.ToInt32(textBoxIns.Text), ref MAX, this);
            }
            else
            {
                for (int i = Controls.Count - 1; i >= 0; i--)
                {
                    if (Controls[i] is ButtonClass)
                    {
                        Controls[i].Dispose();
                    }
                    MAX = 0;
                }
                bst = new BSTClass();
                bst.insert(9, ref MAX, this);
                bst.insert(15, ref MAX, this);
                bst.insert(26, ref MAX, this);



                bst.insert(4, ref MAX, this);
                bst.insert(2, ref MAX, this);
                bst.insert(1, ref MAX, this);



                //bst.insert(6, ref MAX, this);
                //bst.insert(7, ref MAX, this);
                //bst.insert(11, ref MAX, this);
                //bst.insert(13, ref MAX, this);
                //bst.insert(22, ref MAX, this);
                //bst.insert(17, ref MAX, this);
                //bst.insert(5, ref MAX, this);
            }
        }

        private void textBoxIns_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        public void buttonClass_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            bst.remove(Convert.ToInt32(clickedButton.Text), bst.ROOT, this, MAX, null);
        }
    }
}
