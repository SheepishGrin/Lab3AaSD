namespace Lab3
{
    partial class Form1
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
            userControl11 = new UserControl1();
            button1 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button2 = new Button();
            label1 = new Label();
            listBox1 = new ListBox();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // userControl11
            // 
            userControl11.Location = new Point(118, 89);
            userControl11.Name = "userControl11";
            userControl11.Size = new Size(503, 136);
            userControl11.TabIndex = 0;
            userControl11.Visible = false;
            // 
            // button1
            // 
            button1.Location = new Point(12, 118);
            button1.Name = "button1";
            button1.Size = new Size(100, 38);
            button1.TabIndex = 1;
            button1.Text = "Выбрать очередь";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 89);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 12);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(154, 23);
            textBox2.TabIndex = 4;
            // 
            // button2
            // 
            button2.Location = new Point(12, 41);
            button2.Name = "button2";
            button2.Size = new Size(154, 23);
            button2.TabIndex = 3;
            button2.Text = "Изменить количество";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(172, 12);
            label1.Name = "label1";
            label1.Size = new Size(102, 15);
            label1.TabIndex = 5;
            label1.Text = "Всего 0 очередей";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(29, 291);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(555, 199);
            listBox1.TabIndex = 6;
            // 
            // button3
            // 
            button3.Location = new Point(12, 245);
            button3.Name = "button3";
            button3.Size = new Size(100, 40);
            button3.TabIndex = 7;
            button3.Text = "Выполнить задание";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(121, 231);
            button4.Name = "button4";
            button4.Size = new Size(76, 23);
            button4.TabIndex = 8;
            button4.Text = "Завершить";
            button4.UseVisualStyleBackColor = true;
            button4.Visible = false;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(616, 504);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(listBox1);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(userControl11);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UserControl1 userControl11;
        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button2;
        private Label label1;
        private ListBox listBox1;
        private Button button3;
        private Button button4;
    }
}
