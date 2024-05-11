namespace Lab3
{
    partial class Server_Bai4
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
            this.listViewChatRoom = new System.Windows.Forms.ListView();
            this.listenBtn = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewChatRoom
            // 
            this.listViewChatRoom.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewChatRoom.GridLines = true;
            this.listViewChatRoom.HideSelection = false;
            this.listViewChatRoom.Location = new System.Drawing.Point(30, 95);
            this.listViewChatRoom.Name = "listViewChatRoom";
            this.listViewChatRoom.Size = new System.Drawing.Size(739, 343);
            this.listViewChatRoom.TabIndex = 3;
            this.listViewChatRoom.UseCompatibleStateImageBehavior = false;
            this.listViewChatRoom.View = System.Windows.Forms.View.Details;
            // 
            // listenBtn
            // 
            this.listenBtn.Location = new System.Drawing.Point(632, 31);
            this.listenBtn.Name = "listenBtn";
            this.listenBtn.Size = new System.Drawing.Size(137, 44);
            this.listenBtn.TabIndex = 2;
            this.listenBtn.Text = "Listen";
            this.listenBtn.UseVisualStyleBackColor = true;
            this.listenBtn.Click += new System.EventHandler(this.listenBtn_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 739;
            // 
            // Server_Bai4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listViewChatRoom);
            this.Controls.Add(this.listenBtn);
            this.Name = "Server_Bai4";
            this.Text = "Server_Bai4";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewChatRoom;
        private System.Windows.Forms.Button listenBtn;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}