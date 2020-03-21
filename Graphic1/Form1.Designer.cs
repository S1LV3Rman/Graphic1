namespace Graphic1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Box1 = new System.Windows.Forms.TextBox();
            this.Box4 = new System.Windows.Forms.TextBox();
            this.Box5 = new System.Windows.Forms.TextBox();
            this.Box2 = new System.Windows.Forms.TextBox();
            this.Box6 = new System.Windows.Forms.TextBox();
            this.Box3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 450);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            this.panel1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseWheel);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(681, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "x";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(720, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "y";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(760, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "r";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(623, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Circle1";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(623, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Circle2";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Box1
            // 
            this.Box1.Location = new System.Drawing.Point(673, 31);
            this.Box1.Name = "Box1";
            this.Box1.Size = new System.Drawing.Size(28, 20);
            this.Box1.TabIndex = 7;
            this.Box1.TextChanged += new System.EventHandler(this.Box1_TextChanged);
            this.Box1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Box_KeyPress);
            // 
            // Box4
            // 
            this.Box4.Location = new System.Drawing.Point(673, 60);
            this.Box4.Name = "Box4";
            this.Box4.Size = new System.Drawing.Size(28, 20);
            this.Box4.TabIndex = 10;
            this.Box4.TextChanged += new System.EventHandler(this.Box4_TextChanged);
            this.Box4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Box_KeyPress);
            // 
            // Box5
            // 
            this.Box5.Location = new System.Drawing.Point(712, 60);
            this.Box5.Name = "Box5";
            this.Box5.Size = new System.Drawing.Size(28, 20);
            this.Box5.TabIndex = 11;
            this.Box5.TextChanged += new System.EventHandler(this.Box5_TextChanged);
            this.Box5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Box_KeyPress);
            // 
            // Box2
            // 
            this.Box2.Location = new System.Drawing.Point(712, 31);
            this.Box2.Name = "Box2";
            this.Box2.Size = new System.Drawing.Size(28, 20);
            this.Box2.TabIndex = 8;
            this.Box2.TextChanged += new System.EventHandler(this.Box2_TextChanged);
            this.Box2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Box_KeyPress);
            // 
            // Box6
            // 
            this.Box6.Location = new System.Drawing.Point(751, 60);
            this.Box6.Name = "Box6";
            this.Box6.Size = new System.Drawing.Size(28, 20);
            this.Box6.TabIndex = 12;
            this.Box6.TextChanged += new System.EventHandler(this.Box6_TextChanged);
            this.Box6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Box_KeyPress);
            // 
            // Box3
            // 
            this.Box3.Location = new System.Drawing.Point(751, 31);
            this.Box3.Name = "Box3";
            this.Box3.Size = new System.Drawing.Size(28, 20);
            this.Box3.TabIndex = 9;
            this.Box3.TextChanged += new System.EventHandler(this.Box3_TextChanged);
            this.Box3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Box_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(640, 395);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Calculate tangent";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Box6);
            this.Controls.Add(this.Box3);
            this.Controls.Add(this.Box5);
            this.Controls.Add(this.Box2);
            this.Controls.Add(this.Box4);
            this.Controls.Add(this.Box1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Graphic1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Box1;
        private System.Windows.Forms.TextBox Box4;
        private System.Windows.Forms.TextBox Box5;
        private System.Windows.Forms.TextBox Box2;
        private System.Windows.Forms.TextBox Box6;
        private System.Windows.Forms.TextBox Box3;
        private System.Windows.Forms.Button button1;
    }
}

