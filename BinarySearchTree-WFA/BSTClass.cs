using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinarySearchTree_WFA
{
    class Node
    {
        public ButtonClass ButtonBST { get; set; }
        public Node lchild { get; set; }
        public Node rchild { get; set; }
        public int level { get; set; }
        public Graphics g = null;

        public Node(ButtonClass i, Node l, Node r, int lv)
        {
            ButtonBST = i;
            lchild = l;
            rchild = r;
            level = lv;
        }
    }
    class BSTClass
    {
        public Node ROOT;
        public BSTClass()
        {
            ROOT = null;
        }
        public void insert(int element, ref int maxlv, FormBST F)
        {
            Node newnode, currentNode = ROOT, parent = currentNode;
            Point LocationNode;
            int lvNode = 0;
            ButtonClass newBT = new ButtonClass();
            newBT.Click += new EventHandler(F.buttonClass_Click);
            newBT.Text = Convert.ToString(element);
            newBT.Location = new Point(F.Width - 70, 100);
            F.Controls.Add(newBT);
            F.Update();
            Thread.Sleep(500);
            find(element, ref parent, ref currentNode, ref lvNode);
            if (lvNode > maxlv)
            {
                maxlv = lvNode;
            }
            if (ROOT != null)
            {
                parent.ButtonBST.BackColor = Color.Blue;
                parent.ButtonBST.Update();
                Thread.Sleep(500);
                movingTree(ROOT, maxlv, newBT, F);
            }
            if (currentNode != null)
            {
                MessageBox.Show("Duplicates words not allowed");
                F.Controls.Remove(newBT);
                newBT.Dispose();

                currentNode.ButtonBST.BackColor = SystemColors.ButtonFace;
                currentNode.ButtonBST.UseVisualStyleBackColor = true;
                currentNode.ButtonBST.Update();

                parent.ButtonBST.BackColor = SystemColors.ButtonFace;
                parent.ButtonBST.UseVisualStyleBackColor = true;
                parent.ButtonBST.Update();
            }
            else
            {
                newnode = new Node(newBT, null, null, lvNode);
                newnode.g = F.CreateGraphics();
                if (parent == null)
                {
                    ROOT = newnode;
                    LocationNode = new Point(F.Width / 2 - 30, 100);
                    F.Controls.Add(ROOT.ButtonBST);
                    move(ROOT, LocationNode, maxlv);
                }
                else if (element < Convert.ToInt32(parent.ButtonBST.Text))
                {
                    parent.lchild = newnode;
                    if (parent.ButtonBST.Location.Y + 100 >= F.Height)
                    {
                        F.Height += 50;
                        F.Update();
                        Thread.Sleep(500);
                    }

                    LocationNode = new Point(parent.ButtonBST.Location.X - (int)(30 * Math.Pow(2, (maxlv - parent.lchild.level))), parent.ButtonBST.Location.Y + 50);
                    F.Controls.Add(parent.lchild.ButtonBST);
                    move(parent.lchild, LocationNode, maxlv);
                    parent.lchild.g = F.CreateGraphics();
                    parent.lchild.g.DrawLine(new Pen(Color.Black), parent.ButtonBST.Location.X + 25, parent.ButtonBST.Location.Y + 25, parent.lchild.ButtonBST.Location.X + 25, parent.lchild.ButtonBST.Location.Y + 25);
                }
                else
                {
                    parent.rchild = newnode;
                    if (parent.ButtonBST.Location.Y + 100 >= F.Height)
                    {
                        F.Height += 50;
                        F.Update();
                        Thread.Sleep(500);
                    }
                    LocationNode = new Point(parent.ButtonBST.Location.X + (int)(30 * Math.Pow(2, (maxlv - parent.rchild.level))), parent.ButtonBST.Location.Y + 50);
                    F.Controls.Add(parent.rchild.ButtonBST);
                    move(parent.rchild, LocationNode, maxlv);
                }
                Thread.Sleep(500);
                if (parent != null)
                {
                    parent.ButtonBST.BackColor = SystemColors.ButtonFace;
                    parent.ButtonBST.UseVisualStyleBackColor = true;
                    parent.ButtonBST.Update();
                }
            }

        }


        public void find(int element, ref Node parent, ref Node currentNode, ref int lv)
        {
            while ((currentNode != null) && (Convert.ToInt32(currentNode.ButtonBST.Text) != element))
            {
                currentNode.ButtonBST.BackColor = Color.Red;
                currentNode.ButtonBST.Update();
                Thread.Sleep(500);
                if (parent != null)
                {
                    parent.ButtonBST.BackColor = SystemColors.ButtonFace;
                    parent.ButtonBST.UseVisualStyleBackColor = true;
                    parent.ButtonBST.Update();
                }
                parent = currentNode;
                parent.ButtonBST.BackColor = Color.Blue;
                parent.ButtonBST.Update();
                if (element < Convert.ToInt32(currentNode.ButtonBST.Text))
                {
                    currentNode = currentNode.lchild;
                }
                else
                {
                    currentNode = currentNode.rchild;
                }
                lv++;
                if (currentNode != null)
                {
                    currentNode.ButtonBST.BackColor = Color.Red;
                    currentNode.ButtonBST.Update();
                }

            }
        }
        public void movingTree(Node root, int maxlv, Button newBT, Form F)
        {
            Point locationNode;

            if (root.lchild != null)
            {
                if (root.ButtonBST.Location.X - 50 <= 0)
                {
                    F.Width += (int)(30 * Math.Pow(2, root.lchild.level));
                    newBT.Location = new Point(F.Width - 70, 100);
                    newBT.Update();
                    F.Update();
                    Thread.Sleep(100);
                }
                locationNode = new Point(root.ButtonBST.Location.X - (int)(30 * Math.Pow(2, (maxlv - root.lchild.level))), root.ButtonBST.Location.Y + 50);
                move(root.lchild, locationNode, maxlv);
                movingTree(root.lchild, maxlv, newBT, F);
            }
            if (root.rchild != null)
            {

                if (root.ButtonBST.Location.X + 130 >= F.Width)
                {
                    F.Width += (int)(30 * Math.Pow(2, root.rchild.level));
                    newBT.Location = new Point(F.Width - 70, 100);
                    newBT.Update();
                    F.Update();
                    Thread.Sleep(100);
                }
                locationNode = new Point(root.ButtonBST.Location.X + (int)(30 * Math.Pow(2, (maxlv - root.rchild.level))), root.ButtonBST.Location.Y + 50);
                move(root.rchild, locationNode, maxlv);
                movingTree(root.rchild, maxlv, newBT, F);
            }
        }
        public void move(Node MovingBT, Point Location, int Maxlevel)
        {
            int Minx, Miny, Maxx, Maxy;
            Minx = Math.Min(MovingBT.ButtonBST.Location.X, Location.X);
            Maxx = Math.Max(MovingBT.ButtonBST.Location.X, Location.X);
            Miny = Math.Min(MovingBT.ButtonBST.Location.Y, Location.Y);
            Maxy = Math.Max(MovingBT.ButtonBST.Location.Y, Location.Y);
            int width = Maxx - Minx;
            int height = Maxy - Miny;
            double slope = 0;
            if (MovingBT.ButtonBST.Location.Y <= Location.Y)
            {
                if (width == 0 || height == 0)
                {
                    slope = 0;
                }
                else
                {
                    slope = (double)height / (double)width;
                }
                if (MovingBT.ButtonBST.Location.X <= Location.X)
                {
                    for (int i = 1; i <= width; i++)
                    {
                        MovingBT.ButtonBST.Location = new Point(Minx + i, Miny + (int)((slope * i) + 1));
                        Thread.Sleep(2);
                        MovingBT.ButtonBST.Update();

                    }
                    MovingBT.ButtonBST.Location = Location;
                    MovingBT.ButtonBST.Update();
                }
                else
                {
                    for (int i = 1; i <= width; i++)
                    {
                        MovingBT.ButtonBST.Location = new Point(Maxx - i, Miny + (int)((slope * i) + 1));
                        Thread.Sleep(2);
                        MovingBT.ButtonBST.Update();
                    }
                    MovingBT.ButtonBST.Location = Location;
                    MovingBT.ButtonBST.Update();
                }
            }
            else
            {
                if (width == 0 || height == 0)
                {
                    slope = 0;
                }
                else
                {
                    slope = (double)width / (double)height;
                }
                if (MovingBT.ButtonBST.Location.X <= Location.X)
                {
                    for (int i = 1; i <= height; i++)
                    {
                        MovingBT.ButtonBST.Location = new Point(Minx + (int)((slope * i) + 1), Maxy - i);
                        Thread.Sleep(2);
                        MovingBT.ButtonBST.Update();

                    }
                    MovingBT.ButtonBST.Location = Location;
                    MovingBT.ButtonBST.Update();

                }
                else
                {
                    for (int i = 1; i <= height; i++)
                    {
                        MovingBT.ButtonBST.Location = new Point(Maxx - (int)((slope * i) + 1), Maxy - i);
                        Thread.Sleep(2);
                        MovingBT.ButtonBST.Update();

                    }
                    MovingBT.ButtonBST.Location = Location;
                    MovingBT.ButtonBST.Update();
                }
            }

            if (MovingBT.lchild != null)
            {
                Point LocationNode = new Point(MovingBT.ButtonBST.Location.X - (int)(30 * Math.Pow(2, (Maxlevel - MovingBT.lchild.level))), MovingBT.ButtonBST.Location.Y + 50);
                move(MovingBT.lchild, LocationNode, Maxlevel);
            }
            if (MovingBT.rchild != null)
            {
                Point LocationNode = new Point(MovingBT.ButtonBST.Location.X + (int)(30 * Math.Pow(2, (Maxlevel - MovingBT.rchild.level))), MovingBT.ButtonBST.Location.Y + 50);
                move(MovingBT.rchild, LocationNode, Maxlevel);
            }
        }

        //public void inorder(Node ptr)
        //{
        //    if (ROOT == null)
        //    {
        //        Console.WriteLine("Tree is empty");
        //        return;
        //    }
        //    if (ptr != null)
        //    {
        //        inorder(ptr.lchild);
        //        Console.WriteLine(ptr.ButtonBST.Text + "   ");
        //        inorder(ptr.rchild);
        //    }
        //}

        //public void preorder(Node ptr, Node parentNode, int MaxlvNode, FormBST f)
        //{
        //    if (ROOT == null)
        //    {
        //        Console.WriteLine("Tree is empty");
        //        return;
        //    }
        //    if (ptr != null)
        //    {
        //        Console.WriteLine(ptr.ButtonBST.Text + "   ");
        //        inorder(ptr.lchild);
        //        inorder(ptr.rchild);
        //    }
        //}

        //public void postorder(Node ptr)
        //{
        //    if (ROOT == null)
        //    {
        //        Console.WriteLine("Tree is empty");
        //        return;
        //    }
        //    if (ptr != null)
        //    {
        //        postorder(ptr.lchild);
        //        postorder(ptr.rchild);
        //        Console.WriteLine(ptr.ButtonBST.Text + "   ");
        //    }
        //}

        public void remove(int element, Node Subtree, FormBST F, int levelmax, Node parent)
        {
            Node currentNode = Subtree;
            int lvNode = 0;
            find(element, ref parent, ref currentNode, ref lvNode);
            if (currentNode == null)
            {
                MessageBox.Show("Not Found");
            }
            else if (currentNode.lchild == null && currentNode.rchild == null) //0 Xac dinh Delete Node la Leaf Node
            {
                if (currentNode == Subtree)
                {
                    F.Controls.Remove(Subtree.ButtonBST);
                    Subtree.ButtonBST.Dispose();
                    if (Subtree == ROOT)
                    {
                        ROOT = null;
                    }
                    else if (parent != null)
                    {
                        parent.rchild = null;
                    }
                    else
                    {
                        Subtree = null;
                    }
                }
                else if (currentNode == parent.lchild)
                {
                    F.Controls.Remove(parent.lchild.ButtonBST);
                    parent.lchild.ButtonBST.Dispose();
                    parent.lchild = null;
                }
                else
                {
                    F.Controls.Remove(parent.rchild.ButtonBST);
                    parent.rchild.ButtonBST.Dispose();
                    parent.rchild = null;
                }
            }
            else if (currentNode.lchild == null ^ currentNode.rchild == null) //1 Xac dinh Delete Node co 1 child
            {
                Node Child = null;
                if (currentNode.lchild != null)
                {
                    Child = currentNode.lchild;
                    currentNode.lchild = null;
                }
                if (currentNode.rchild != null)
                {
                    Child = currentNode.rchild;
                    currentNode.rchild = null;
                }
                if (currentNode == Subtree)
                {
                    F.Controls.Remove(Subtree.ButtonBST);
                    Subtree.ButtonBST.Dispose();
                    if (parent != null)
                    {
                        parent.rchild = Child;
                    }
                    else if (Subtree == ROOT)
                    {
                        ROOT = Child;
                    }
                    else
                    {
                        Subtree = Child;
                    }
                }
                else if (currentNode == parent.lchild)
                {
                    F.Controls.Remove(parent.lchild.ButtonBST);
                    parent.lchild.ButtonBST.Dispose();
                    parent.lchild = Child;
                }
                else
                {
                    F.Controls.Remove(parent.rchild.ButtonBST);
                    parent.rchild.ButtonBST.Dispose();
                    parent.rchild = Child;
                }
                move(Child, currentNode.ButtonBST.Location, levelmax);
            }
            else//////////////////////////////////////////////////////////////////2 Xac dinh Delete Node co 2 child
            {
                Node Inorder_suc = currentNode.rchild;
                while (Inorder_suc.lchild != null)
                {
                    Inorder_suc = Inorder_suc.lchild;
                }
                if (currentNode == Subtree)
                {
                    string tmp = Inorder_suc.ButtonBST.Text;
                    Inorder_suc.ButtonBST.Text = Subtree.ButtonBST.Text;
                    Subtree.ButtonBST.Text = tmp;
                    Subtree.ButtonBST.Update();
                }
                else if (currentNode == parent.lchild)
                {
                    string tmp = Inorder_suc.ButtonBST.Text;
                    Inorder_suc.ButtonBST.Text = parent.lchild.ButtonBST.Text;
                    parent.lchild.ButtonBST.Text = tmp;
                    parent.lchild.ButtonBST.Update();
                }
                else
                {
                    string tmp = Inorder_suc.ButtonBST.Text;
                    Inorder_suc.ButtonBST.Text = parent.rchild.ButtonBST.Text;
                    parent.rchild.ButtonBST.Text = tmp;
                    parent.rchild.ButtonBST.Update();
                }
                Inorder_suc.ButtonBST.Update();
                if (parent == null)
                {
                    parent = ROOT;
                }
                else
                {
                    if (parent != null)
                    {
                        parent.ButtonBST.BackColor = SystemColors.ButtonFace;
                        parent.ButtonBST.UseVisualStyleBackColor = true;
                        parent.ButtonBST.Update();
                    }
                    parent = currentNode;
                }
                if (parent != null)
                {
                    parent.ButtonBST.BackColor = SystemColors.ButtonFace;
                    parent.ButtonBST.UseVisualStyleBackColor = true;
                    parent.ButtonBST.Update();
                }
                if (currentNode != null)
                {
                    currentNode.ButtonBST.BackColor = SystemColors.ButtonFace;
                    currentNode.ButtonBST.UseVisualStyleBackColor = true;
                    currentNode.ButtonBST.Update();
                }
                remove(Convert.ToInt32(Inorder_suc.ButtonBST.Text), currentNode.rchild, F, levelmax, parent);
            }
            if (parent != null)
            {
                parent.ButtonBST.BackColor = SystemColors.ButtonFace;
                parent.ButtonBST.UseVisualStyleBackColor = true;
                parent.ButtonBST.Update();
            }
            if (currentNode != null)
            {
                currentNode.ButtonBST.BackColor = SystemColors.ButtonFace;
                currentNode.ButtonBST.UseVisualStyleBackColor = true;
                currentNode.ButtonBST.Update();
            }
            currentNode = null;
            parent = null;
        }
    }
}
