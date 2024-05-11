namespace Lab3
{
    partial class TCPServer_Bai3
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
            this.listenBtn = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Collumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listenBtn
            // 
            this.listenBtn.Location = new System.Drawing.Point(607, 31);
            this.listenBtn.Name = "listenBtn";
            this.listenBtn.Size = new System.Drawing.Size(121, 41);
            this.listenBtn.TabIndex = 0;
            this.listenBtn.Text = "Listen";
            this.listenBtn.UseVisualStyleBackColor = true;
            this.listenBtn.Click += new System.EventHandler(this.listenBtn_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Collumn});
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.LabelEdit = true;
            this.listView1.Location = new System.Drawing.Point(69, 95);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(659, 325);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Collumn
            // 
            this.Collumn.Text = "";
            this.Collumn.Width = 659;
            // 
            // TCPServer_Bai3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.listenBtn);
            this.Name = "TCPServer_Bai3";
            this.Text = "TCPServer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button listenBtn;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Collumn;
    }
}