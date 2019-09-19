namespace BinarySearchTree_WFA
{
    partial class FormBST
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonClick = new System.Windows.Forms.Button();
            this.textBoxIns = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonClick
            // 
            this.buttonClick.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonClick.Location = new System.Drawing.Point(265, 48);
            this.buttonClick.Name = "buttonClick";
            this.buttonClick.Size = new System.Drawing.Size(75, 30);
            this.buttonClick.TabIndex = 0;
            this.buttonClick.Text = "Click";
            this.buttonClick.UseVisualStyleBackColor = true;
            this.buttonClick.Click += new System.EventHandler(this.buttonClick_Click);
            // 
            // textBoxIns
            // 
            this.textBoxIns.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxIns.Location = new System.Drawing.Point(252, 12);
            this.textBoxIns.Name = "textBoxIns";
            this.textBoxIns.Size = new System.Drawing.Size(100, 26);
            this.textBoxIns.TabIndex = 1;
            this.textBoxIns.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxIns_KeyPress);
            // 
            // FormBST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(605, 304);
            this.Controls.Add(this.textBoxIns);
            this.Controls.Add(this.buttonClick);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormBST";
            this.Text = "Project BST";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonClick;
        private System.Windows.Forms.TextBox textBoxIns;
    }
}

