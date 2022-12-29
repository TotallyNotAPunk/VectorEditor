namespace VectorEditor
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
            this.buttonGrouping = new System.Windows.Forms.Button();
            this.buttonUngrouping = new System.Windows.Forms.Button();
            this.FigureBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonFillColor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.widthBar = new System.Windows.Forms.TrackBar();
            this.FillColor = new System.Windows.Forms.Panel();
            this.ContourColor = new System.Windows.Forms.Panel();
            this.buttonContourColor = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.widthBar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.buttonGrouping);
            this.panel1.Controls.Add(this.buttonUngrouping);
            this.panel1.Controls.Add(this.FigureBox);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.buttonFillColor);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.widthBar);
            this.panel1.Controls.Add(this.FillColor);
            this.panel1.Controls.Add(this.ContourColor);
            this.panel1.Controls.Add(this.buttonContourColor);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(873, 113);
            this.panel1.TabIndex = 0;
            // 
            // buttonGrouping
            // 
            this.buttonGrouping.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonGrouping.Location = new System.Drawing.Point(535, 14);
            this.buttonGrouping.Name = "buttonGrouping";
            this.buttonGrouping.Size = new System.Drawing.Size(137, 34);
            this.buttonGrouping.TabIndex = 23;
            this.buttonGrouping.Text = "Группировать";
            this.buttonGrouping.UseVisualStyleBackColor = false;
            this.buttonGrouping.Click += new System.EventHandler(this.buttonGrouping_Click);
            // 
            // buttonUngrouping
            // 
            this.buttonUngrouping.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonUngrouping.Location = new System.Drawing.Point(535, 61);
            this.buttonUngrouping.Name = "buttonUngrouping";
            this.buttonUngrouping.Size = new System.Drawing.Size(137, 34);
            this.buttonUngrouping.TabIndex = 24;
            this.buttonUngrouping.Text = "Разгруппировать";
            this.buttonUngrouping.UseVisualStyleBackColor = false;
            this.buttonUngrouping.Click += new System.EventHandler(this.buttonUngrouping_Click);
            // 
            // FigureBox
            // 
            this.FigureBox.FormattingEnabled = true;
            this.FigureBox.Items.AddRange(new object[] {
            "Line",
            "Rect",
            "Ellipse"
            });
            this.FigureBox.Location = new System.Drawing.Point(12, 34);
            this.FigureBox.Name = "FigureBox";
            this.FigureBox.Size = new System.Drawing.Size(121, 24);
            this.FigureBox.TabIndex = 22;
            this.FigureBox.Text = "Line";
            this.FigureBox.SelectedIndexChanged += new System.EventHandler(this.FigureBox_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = "Фигура:";
            // 
            // buttonFillColor
            // 
            this.buttonFillColor.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonFillColor.Location = new System.Drawing.Point(233, 10);
            this.buttonFillColor.Name = "buttonFillColor";
            this.buttonFillColor.Size = new System.Drawing.Size(82, 42);
            this.buttonFillColor.TabIndex = 4;
            this.buttonFillColor.Text = "Цвет заливки";
            this.buttonFillColor.UseVisualStyleBackColor = false;
            this.buttonFillColor.Click += new System.EventHandler(this.buttonFillColor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(367, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Толшина кисти";
            // 
            // widthBar
            // 
            this.widthBar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.widthBar.Location = new System.Drawing.Point(328, 34);
            this.widthBar.Name = "widthBar";
            this.widthBar.Size = new System.Drawing.Size(192, 56);
            this.widthBar.TabIndex = 7;
            this.widthBar.Value = 2;
            this.widthBar.Scroll += new System.EventHandler(this.widthBar_Scroll);
            // 
            // FillColor
            // 
            this.FillColor.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FillColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FillColor.Location = new System.Drawing.Point(253, 56);
            this.FillColor.Name = "FillColor";
            this.FillColor.Size = new System.Drawing.Size(40, 39);
            this.FillColor.TabIndex = 6;
            // 
            // ContourColor
            // 
            this.ContourColor.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ContourColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContourColor.Location = new System.Drawing.Point(164, 56);
            this.ContourColor.Name = "ContourColor";
            this.ContourColor.Size = new System.Drawing.Size(40, 39);
            this.ContourColor.TabIndex = 5;
            // 
            // buttonContourColor
            // 
            this.buttonContourColor.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonContourColor.Location = new System.Drawing.Point(145, 8);
            this.buttonContourColor.Name = "buttonContourColor";
            this.buttonContourColor.Size = new System.Drawing.Size(82, 44);
            this.buttonContourColor.TabIndex = 3;
            this.buttonContourColor.Text = "Цвет границ";
            this.buttonContourColor.UseVisualStyleBackColor = false;
            this.buttonContourColor.Click += new System.EventHandler(this.buttonContourColor_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 113);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(873, 421);
            this.panel2.TabIndex = 1;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 534);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.widthBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar widthBar;
        private System.Windows.Forms.Panel FillColor;
        private System.Windows.Forms.Panel ContourColor;
        private System.Windows.Forms.Button buttonFillColor;
        private System.Windows.Forms.Button buttonContourColor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox FigureBox;
        private System.Windows.Forms.Button buttonUngrouping;
        private System.Windows.Forms.Button buttonGrouping;
    }
}

