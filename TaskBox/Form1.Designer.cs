namespace TaskBox
{
    partial class form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form1));
            button1 = new Button();
            button2 = new Button();
            listView1 = new ListView();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 10F);
            button1.Location = new Point(101, 348);
            button1.Name = "button1";
            button1.Size = new Size(109, 31);
            button1.TabIndex = 0;
            button1.Text = "Adicionar";
            button1.TextAlign = ContentAlignment.BottomCenter;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 10F);
            button2.Location = new Point(466, 348);
            button2.Name = "button2";
            button2.Size = new Size(94, 31);
            button2.TabIndex = 1;
            button2.Text = "Excluir";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // listView1
            // 
            listView1.Location = new Point(83, 65);
            listView1.Name = "listView1";
            listView1.Size = new Size(496, 248);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(675, 450);
            Controls.Add(listView1);
            Controls.Add(button2);
            Controls.Add(button1);
            Cursor = Cursors.Default;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lista de tarefas";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private ListView listView1;
    }
}
