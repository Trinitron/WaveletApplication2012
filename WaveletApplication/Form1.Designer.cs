using WaveletApplication.ChartTools;

namespace WaveletApplication
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьСигналToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveResultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьРезультатToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.tbVar2 = new System.Windows.Forms.TextBox();
            this.tbMean2 = new System.Windows.Forms.TextBox();
            this.tbCount2 = new System.Windows.Forms.TextBox();
            this.tbVar1 = new System.Windows.Forms.TextBox();
            this.tbMean1 = new System.Windows.Forms.TextBox();
            this.tbCount1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ucChart1 = new WaveletApplication.ucChart();
            this.ucChart2 = new WaveletApplication.ucChart();
            this.scrollBarSync2 = new WaveletApplication.ScrollBarSync();
            this.scrollBarSync1 = new WaveletApplication.ScrollBarSync();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem1,
            this.помощьToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(952, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem1
            // 
            this.файлToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьСигналToolStripMenuItem,
            this.SaveResultToolStripMenuItem});
            this.файлToolStripMenuItem1.Name = "файлToolStripMenuItem1";
            this.файлToolStripMenuItem1.Size = new System.Drawing.Size(55, 20);
            this.файлToolStripMenuItem1.Text = "Сигнал";
            // 
            // загрузитьСигналToolStripMenuItem
            // 
            this.загрузитьСигналToolStripMenuItem.Name = "загрузитьСигналToolStripMenuItem";
            this.загрузитьСигналToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.загрузитьСигналToolStripMenuItem.Text = "Загрузить файл";
            this.загрузитьСигналToolStripMenuItem.Click += new System.EventHandler(this.button1_Click);
            // 
            // SaveResultToolStripMenuItem
            // 
            this.SaveResultToolStripMenuItem.Name = "SaveResultToolStripMenuItem";
            this.SaveResultToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.SaveResultToolStripMenuItem.Text = "Сохранить результат";
            this.SaveResultToolStripMenuItem.Click += new System.EventHandler(this.SaveResultToolStripMenuItem_Click);
            // 
            // помощьToolStripMenuItem1
            // 
            this.помощьToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpToolStripMenuItem,
            this.AboutToolStripMenuItem});
            this.помощьToolStripMenuItem1.Name = "помощьToolStripMenuItem1";
            this.помощьToolStripMenuItem1.Size = new System.Drawing.Size(59, 20);
            this.помощьToolStripMenuItem1.Text = "Помощь";
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.HelpToolStripMenuItem.Text = "Справка";
            this.HelpToolStripMenuItem.Click += new System.EventHandler(this.HelpToolStripMenuItem_Click);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.AboutToolStripMenuItem.Text = "О программе";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьCSVToolStripMenuItem,
            this.сохранитьCSVToolStripMenuItem,
            this.сохранитьРезультатToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // загрузитьCSVToolStripMenuItem
            // 
            this.загрузитьCSVToolStripMenuItem.Name = "загрузитьCSVToolStripMenuItem";
            this.загрузитьCSVToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.загрузитьCSVToolStripMenuItem.Text = "Загрузить сигнал";
            // 
            // сохранитьCSVToolStripMenuItem
            // 
            this.сохранитьCSVToolStripMenuItem.Name = "сохранитьCSVToolStripMenuItem";
            this.сохранитьCSVToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.сохранитьCSVToolStripMenuItem.Text = "Загрузить вейвлет";
            // 
            // сохранитьРезультатToolStripMenuItem
            // 
            this.сохранитьРезультатToolStripMenuItem.Name = "сохранитьРезультатToolStripMenuItem";
            this.сохранитьРезультатToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.сохранитьРезультатToolStripMenuItem.Text = "Экспорт";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Title = "Выберите сигнал:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(331, 442);
            this.panel1.TabIndex = 10;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton2);
            this.groupBox3.Controls.Add(this.textBox3);
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Location = new System.Drawing.Point(4, 327);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(324, 47);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Пороговая обработка";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(249, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(62, 17);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "мягкий";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(105, 16);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(52, 20);
            this.textBox3.TabIndex = 5;
            this.textBox3.Text = "0";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(175, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(68, 17);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "жесткий";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button4.Location = new System.Drawing.Point(11, 17);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(80, 20);
            this.button4.TabIndex = 5;
            this.button4.Text = "Cd / Ca";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button3.Location = new System.Drawing.Point(153, 419);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 20);
            this.button3.TabIndex = 6;
            this.button3.Text = "Восстановить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Location = new System.Drawing.Point(3, 274);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(325, 47);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Выбор вейвлета";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(285, 19);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(34, 20);
            this.numericUpDown1.TabIndex = 8;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(173, 19);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(116, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "уровень разложения";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(12, 19);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(146, 21);
            this.comboBox2.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button2.Location = new System.Drawing.Point(247, 419);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 20);
            this.button2.TabIndex = 5;
            this.button2.Text = "Разложить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox12);
            this.groupBox1.Controls.Add(this.textBox11);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.tbVar2);
            this.groupBox1.Controls.Add(this.tbMean2);
            this.groupBox1.Controls.Add(this.tbCount2);
            this.groupBox1.Controls.Add(this.tbVar1);
            this.groupBox1.Controls.Add(this.tbMean1);
            this.groupBox1.Controls.Add(this.tbCount1);
            this.groupBox1.Controls.Add(this.scrollBarSync2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.scrollBarSync1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 265);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выбор сигнала";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(12, 236);
            this.textBox12.Name = "textBox12";
            this.textBox12.ReadOnly = true;
            this.textBox12.Size = new System.Drawing.Size(108, 20);
            this.textBox12.TabIndex = 1;
            this.textBox12.Text = "Дисперсия:";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(12, 219);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(108, 20);
            this.textBox11.TabIndex = 1;
            this.textBox11.Text = "Мат. ожидание:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(12, 202);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(108, 20);
            this.textBox4.TabIndex = 1;
            this.textBox4.Text = "Элементов:";
            // 
            // tbVar2
            // 
            this.tbVar2.Location = new System.Drawing.Point(173, 236);
            this.tbVar2.Name = "tbVar2";
            this.tbVar2.ReadOnly = true;
            this.tbVar2.Size = new System.Drawing.Size(39, 20);
            this.tbVar2.TabIndex = 1;
            this.tbVar2.Text = "0";
            // 
            // tbMean2
            // 
            this.tbMean2.Location = new System.Drawing.Point(173, 219);
            this.tbMean2.Name = "tbMean2";
            this.tbMean2.ReadOnly = true;
            this.tbMean2.Size = new System.Drawing.Size(39, 20);
            this.tbMean2.TabIndex = 1;
            this.tbMean2.Text = "0";
            // 
            // tbCount2
            // 
            this.tbCount2.Location = new System.Drawing.Point(173, 202);
            this.tbCount2.Name = "tbCount2";
            this.tbCount2.ReadOnly = true;
            this.tbCount2.Size = new System.Drawing.Size(39, 20);
            this.tbCount2.TabIndex = 1;
            this.tbCount2.Text = "0";
            // 
            // tbVar1
            // 
            this.tbVar1.Location = new System.Drawing.Point(119, 236);
            this.tbVar1.Name = "tbVar1";
            this.tbVar1.ReadOnly = true;
            this.tbVar1.Size = new System.Drawing.Size(39, 20);
            this.tbVar1.TabIndex = 1;
            this.tbVar1.Text = "0";
            // 
            // tbMean1
            // 
            this.tbMean1.Location = new System.Drawing.Point(119, 219);
            this.tbMean1.Name = "tbMean1";
            this.tbMean1.ReadOnly = true;
            this.tbMean1.Size = new System.Drawing.Size(39, 20);
            this.tbMean1.TabIndex = 1;
            this.tbMean1.Text = "0";
            // 
            // tbCount1
            // 
            this.tbCount1.Location = new System.Drawing.Point(119, 202);
            this.tbCount1.Name = "tbCount1";
            this.tbCount1.ReadOnly = true;
            this.tbCount1.Size = new System.Drawing.Size(39, 20);
            this.tbCount1.TabIndex = 1;
            this.tbCount1.Text = "0";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button1.Location = new System.Drawing.Point(244, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 20);
            this.button1.TabIndex = 1;
            this.button1.Text = "открыть";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(226, 20);
            this.textBox1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(331, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ucChart1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ucChart2);
            this.splitContainer1.Size = new System.Drawing.Size(621, 442);
            this.splitContainer1.SplitterDistance = 218;
            this.splitContainer1.TabIndex = 11;
            // 
            // ucChart1
            // 
            this.ucChart1.ChartData = null;
            this.ucChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucChart1.Location = new System.Drawing.Point(0, 0);
            this.ucChart1.Name = "ucChart1";
            this.ucChart1.Size = new System.Drawing.Size(621, 218);
            this.ucChart1.TabIndex = 0;
            // 
            // ucChart2
            // 
            this.ucChart2.ChartData = null;
            this.ucChart2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucChart2.Location = new System.Drawing.Point(0, 0);
            this.ucChart2.Name = "ucChart2";
            this.ucChart2.Size = new System.Drawing.Size(621, 220);
            this.ucChart2.TabIndex = 0;
            // 
            // scrollBarSync2
            // 
            this.scrollBarSync2.FormattingEnabled = true;
            this.scrollBarSync2.Location = new System.Drawing.Point(173, 45);
            this.scrollBarSync2.Name = "scrollBarSync2";
            this.scrollBarSync2.Size = new System.Drawing.Size(146, 147);
            this.scrollBarSync2.TabIndex = 7;
            //TODO:fixint
            //this.scrollBarSync2.OnVerticalScroll += new System.Windows.Forms.ScrollEventHandler(this.scrollBarSync2_OnVerticalScroll);
            // 
            // scrollBarSync1
            // 
            this.scrollBarSync1.FormattingEnabled = true;
            this.scrollBarSync1.Location = new System.Drawing.Point(12, 45);
            this.scrollBarSync1.Name = "scrollBarSync1";
            this.scrollBarSync1.Size = new System.Drawing.Size(146, 147);
            this.scrollBarSync1.TabIndex = 6;
            this.scrollBarSync1.OnVerticalScroll += new System.Windows.Forms.ScrollEventHandler(this.scrollBarSync1_OnVerticalScroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 466);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Вейвлет Анализ 1.0";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьРезультатToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem загрузитьСигналToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveResultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private ScrollBarSync scrollBarSync2;
        private System.Windows.Forms.Button button1;
        private ScrollBarSync scrollBarSync1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ucChart ucChart1;
        private ucChart ucChart2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox tbCount2;
        private System.Windows.Forms.TextBox tbCount1;
        private System.Windows.Forms.TextBox tbVar2;
        private System.Windows.Forms.TextBox tbMean2;
        private System.Windows.Forms.TextBox tbVar1;
        private System.Windows.Forms.TextBox tbMean1;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button4;

    }
}

