namespace WinFormsApp1
{
    partial class Form5
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label1 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            guna2Shapes5 = new Guna.UI2.WinForms.Guna2Shapes();
            pictureBox2 = new PictureBox();
            guna2Shapes6 = new Guna.UI2.WinForms.Guna2Shapes();
            guna2Shapes1 = new Guna.UI2.WinForms.Guna2Shapes();
            guna2Shapes2 = new Guna.UI2.WinForms.Guna2Shapes();
            label2 = new Label();
            panel1 = new Panel();
            timer2 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.BackColor = Color.FromArgb(226, 198, 106);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(52, 589);
            button1.Name = "button1";
            button1.Size = new Size(186, 29);
            button1.TabIndex = 1;
            button1.Text = "Таблица пользователей";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom;
            button2.BackColor = Color.FromArgb(226, 198, 106);
            button2.ForeColor = Color.Black;
            button2.Location = new Point(498, 589);
            button2.Name = "button2";
            button2.Size = new Size(166, 29);
            button2.TabIndex = 2;
            button2.Text = "Таблица услуг";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button3.BackColor = Color.FromArgb(226, 198, 106);
            button3.ForeColor = Color.Black;
            button3.Location = new Point(956, 589);
            button3.Name = "button3";
            button3.Size = new Size(159, 29);
            button3.TabIndex = 3;
            button3.Text = "Таблица заказов";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button4.BackColor = Color.FromArgb(226, 198, 106);
            button4.ForeColor = Color.Black;
            button4.Location = new Point(1002, 648);
            button4.Name = "button4";
            button4.Size = new Size(113, 29);
            button4.TabIndex = 4;
            button4.Text = "Назад";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(297, 381);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 6;
            label1.Visible = false;
            // 
            // timer1
            // 
            timer1.Interval = 10;
            timer1.Tick += timer1_Tick;
            // 
            // guna2Shapes5
            // 
            guna2Shapes5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            guna2Shapes5.BackColor = Color.FromArgb(55, 11, 35);
            guna2Shapes5.BorderColor = Color.FromArgb(55, 11, 35);
            guna2Shapes5.FillColor = Color.FromArgb(55, 11, 35);
            guna2Shapes5.Flip = Guna.UI2.WinForms.Enums.FlipOrientation.Horizontal;
            guna2Shapes5.Location = new Point(-5, -9);
            guna2Shapes5.Name = "guna2Shapes5";
            guna2Shapes5.PolygonSkip = 1;
            guna2Shapes5.Rotate = 0F;
            guna2Shapes5.RoundedEdges = customizableEdges1;
            guna2Shapes5.Shape = Guna.UI2.WinForms.Enums.ShapeType.Rounded;
            guna2Shapes5.Size = new Size(1174, 49);
            guna2Shapes5.TabIndex = 31;
            guna2Shapes5.Text = "guna2Shapes5";
            guna2Shapes5.Zoom = 80;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox2.BackColor = Color.FromArgb(55, 11, 35);
            pictureBox2.Cursor = Cursors.Hand;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(1129, 5);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(27, 28);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 32;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // guna2Shapes6
            // 
            guna2Shapes6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            guna2Shapes6.BackColor = Color.FromArgb(55, 11, 35);
            guna2Shapes6.BorderColor = Color.FromArgb(55, 11, 35);
            guna2Shapes6.FillColor = Color.FromArgb(55, 11, 35);
            guna2Shapes6.Flip = Guna.UI2.WinForms.Enums.FlipOrientation.Horizontal;
            guna2Shapes6.Location = new Point(1155, 32);
            guna2Shapes6.Name = "guna2Shapes6";
            guna2Shapes6.PolygonSkip = 1;
            guna2Shapes6.Rotate = 0F;
            guna2Shapes6.RoundedEdges = customizableEdges2;
            guna2Shapes6.Shape = Guna.UI2.WinForms.Enums.ShapeType.Rounded;
            guna2Shapes6.Size = new Size(14, 689);
            guna2Shapes6.TabIndex = 33;
            guna2Shapes6.Text = "guna2Shapes6";
            guna2Shapes6.Zoom = 80;
            // 
            // guna2Shapes1
            // 
            guna2Shapes1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            guna2Shapes1.BackColor = Color.FromArgb(55, 11, 35);
            guna2Shapes1.BorderColor = Color.FromArgb(55, 11, 35);
            guna2Shapes1.FillColor = Color.FromArgb(55, 11, 35);
            guna2Shapes1.Flip = Guna.UI2.WinForms.Enums.FlipOrientation.Horizontal;
            guna2Shapes1.Location = new Point(-5, 23);
            guna2Shapes1.Name = "guna2Shapes1";
            guna2Shapes1.PolygonSkip = 1;
            guna2Shapes1.Rotate = 0F;
            guna2Shapes1.RoundedEdges = customizableEdges3;
            guna2Shapes1.Shape = Guna.UI2.WinForms.Enums.ShapeType.Rounded;
            guna2Shapes1.Size = new Size(14, 689);
            guna2Shapes1.TabIndex = 34;
            guna2Shapes1.Text = "guna2Shapes1";
            guna2Shapes1.Zoom = 80;
            // 
            // guna2Shapes2
            // 
            guna2Shapes2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            guna2Shapes2.BackColor = Color.FromArgb(55, 11, 35);
            guna2Shapes2.BorderColor = Color.FromArgb(55, 11, 35);
            guna2Shapes2.FillColor = Color.FromArgb(55, 11, 35);
            guna2Shapes2.Flip = Guna.UI2.WinForms.Enums.FlipOrientation.Horizontal;
            guna2Shapes2.Location = new Point(-5, 689);
            guna2Shapes2.Name = "guna2Shapes2";
            guna2Shapes2.PolygonSkip = 1;
            guna2Shapes2.Rotate = 0F;
            guna2Shapes2.RoundedEdges = customizableEdges4;
            guna2Shapes2.Shape = Guna.UI2.WinForms.Enums.ShapeType.Rounded;
            guna2Shapes2.Size = new Size(1174, 43);
            guna2Shapes2.TabIndex = 35;
            guna2Shapes2.Text = "guna2Shapes2";
            guna2Shapes2.Zoom = 80;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 36;
            label2.Text = "label2";
            label2.Visible = false;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BackColor = Color.FromArgb(55, 11, 35);
            panel1.Location = new Point(52, 88);
            panel1.Name = "panel1";
            panel1.Size = new Size(1063, 459);
            panel1.TabIndex = 37;
            // 
            // timer2
            // 
            timer2.Tick += timer2_Tick;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(106, 65, 87);
            ClientSize = new Size(1170, 700);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(guna2Shapes2);
            Controls.Add(guna2Shapes1);
            Controls.Add(guna2Shapes6);
            Controls.Add(pictureBox2);
            Controls.Add(guna2Shapes5);
            Controls.Add(label1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form5";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form5";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        public Label label1;
        private System.Windows.Forms.Timer timer1;
        private Guna.UI2.WinForms.Guna2Shapes guna2Shapes5;
        private PictureBox pictureBox2;
        private Guna.UI2.WinForms.Guna2Shapes guna2Shapes6;
        private Guna.UI2.WinForms.Guna2Shapes guna2Shapes1;
        private Guna.UI2.WinForms.Guna2Shapes guna2Shapes2;
        public Label label2;
        private Panel panel1;
        public System.Windows.Forms.Timer timer2;
    }
}