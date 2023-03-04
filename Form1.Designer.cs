using System.Drawing;

namespace Circle_Chart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.chart_Mill = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnPart1 = new System.Windows.Forms.Button();
            this.btnPart2 = new System.Windows.Forms.Button();
            this.chb_CopyTapeDetail_2 = new System.Windows.Forms.CheckBox();
            this.chb_CopyTapeDetail_3 = new System.Windows.Forms.CheckBox();
            this.chb_CopyTapeDetail_1 = new System.Windows.Forms.CheckBox();
            this.chb_CopyTapeDetail_All = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button6 = new System.Windows.Forms.Button();
            this.btnSortUpdate = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Mill)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_Mill
            // 
            this.chart_Mill.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart_Mill.BackColor = System.Drawing.Color.Honeydew;
            chartArea1.Name = "ChartArea1";
            this.chart_Mill.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_Mill.Legends.Add(legend1);
            this.chart_Mill.Location = new System.Drawing.Point(23, 16);
            this.chart_Mill.Name = "chart_Mill";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart_Mill.Series.Add(series1);
            this.chart_Mill.Size = new System.Drawing.Size(492, 305);
            this.chart_Mill.TabIndex = 0;
            this.chart_Mill.Text = "chart1";
            this.chart_Mill.PrePaint += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ChartPaintEventArgs>(this.chart_Mill_PrePaint);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(73, 492);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1236, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1236, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chart_Mill);
            this.panel1.Location = new System.Drawing.Point(56, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(591, 366);
            this.panel1.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(941, 579);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(641, 662);
            this.flowLayoutPanel1.TabIndex = 5;
            this.flowLayoutPanel1.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(154, 403);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 300);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(5, 566);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(143, 20);
            this.textBox1.TabIndex = 7;
            // 
            // btnPart1
            // 
            this.btnPart1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPart1.Location = new System.Drawing.Point(50, 609);
            this.btnPart1.Name = "btnPart1";
            this.btnPart1.Size = new System.Drawing.Size(75, 23);
            this.btnPart1.TabIndex = 8;
            this.btnPart1.Text = "Part 1";
            this.btnPart1.UseVisualStyleBackColor = true;
            this.btnPart1.Click += new System.EventHandler(this.btnPart1_Click);
            // 
            // btnPart2
            // 
            this.btnPart2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPart2.Location = new System.Drawing.Point(50, 657);
            this.btnPart2.Name = "btnPart2";
            this.btnPart2.Size = new System.Drawing.Size(75, 23);
            this.btnPart2.TabIndex = 9;
            this.btnPart2.Text = "Part 2";
            this.btnPart2.UseVisualStyleBackColor = true;
            this.btnPart2.Click += new System.EventHandler(this.btnPart2_Click);
            // 
            // chb_CopyTapeDetail_2
            // 
            this.chb_CopyTapeDetail_2.AutoSize = true;
            this.chb_CopyTapeDetail_2.Location = new System.Drawing.Point(490, 528);
            this.chb_CopyTapeDetail_2.Name = "chb_CopyTapeDetail_2";
            this.chb_CopyTapeDetail_2.Size = new System.Drawing.Size(81, 17);
            this.chb_CopyTapeDetail_2.TabIndex = 8042;
            this.chb_CopyTapeDetail_2.Text = "Opeartion 2";
            this.chb_CopyTapeDetail_2.UseVisualStyleBackColor = true;
            this.chb_CopyTapeDetail_2.CheckedChanged += new System.EventHandler(this.chb_CopyTapeDetail_CheckedChanged);
            // 
            // chb_CopyTapeDetail_3
            // 
            this.chb_CopyTapeDetail_3.AutoSize = true;
            this.chb_CopyTapeDetail_3.Location = new System.Drawing.Point(490, 560);
            this.chb_CopyTapeDetail_3.Name = "chb_CopyTapeDetail_3";
            this.chb_CopyTapeDetail_3.Size = new System.Drawing.Size(81, 17);
            this.chb_CopyTapeDetail_3.TabIndex = 8041;
            this.chb_CopyTapeDetail_3.Text = "Opeartion 3";
            this.chb_CopyTapeDetail_3.UseVisualStyleBackColor = true;
            this.chb_CopyTapeDetail_3.CheckedChanged += new System.EventHandler(this.chb_CopyTapeDetail_CheckedChanged);
            // 
            // chb_CopyTapeDetail_1
            // 
            this.chb_CopyTapeDetail_1.AutoSize = true;
            this.chb_CopyTapeDetail_1.Location = new System.Drawing.Point(490, 496);
            this.chb_CopyTapeDetail_1.Name = "chb_CopyTapeDetail_1";
            this.chb_CopyTapeDetail_1.Size = new System.Drawing.Size(81, 17);
            this.chb_CopyTapeDetail_1.TabIndex = 8040;
            this.chb_CopyTapeDetail_1.Text = "Opeartion 1";
            this.chb_CopyTapeDetail_1.UseVisualStyleBackColor = true;
            this.chb_CopyTapeDetail_1.CheckedChanged += new System.EventHandler(this.chb_CopyTapeDetail_CheckedChanged);
            // 
            // chb_CopyTapeDetail_All
            // 
            this.chb_CopyTapeDetail_All.AutoSize = true;
            this.chb_CopyTapeDetail_All.Location = new System.Drawing.Point(490, 464);
            this.chb_CopyTapeDetail_All.Name = "chb_CopyTapeDetail_All";
            this.chb_CopyTapeDetail_All.Size = new System.Drawing.Size(37, 17);
            this.chb_CopyTapeDetail_All.TabIndex = 8039;
            this.chb_CopyTapeDetail_All.Text = "All";
            this.chb_CopyTapeDetail_All.UseVisualStyleBackColor = true;
            this.chb_CopyTapeDetail_All.CheckedChanged += new System.EventHandler(this.chb_CopyTapeDetail_All_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(595, 464);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 8043;
            this.label3.Text = "label3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 431);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 8045;
            this.label5.Text = "      ";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(5, 447);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8046;
            this.button2.Text = "Blink";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(5, 528);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8047;
            this.button3.Text = "Blink ON";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(5, 492);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 8048;
            this.button4.Text = "Blink OFF";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 405);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(155, 23);
            this.button5.TabIndex = 8049;
            this.button5.Text = "Blink ON 100 times";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(510, 415);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 8050;
            this.label4.Text = "label4";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeight = 60;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 15F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(690, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(570, 484);
            this.dataGridView1.TabIndex = 8051;
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            this.dataGridView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragDrop);
            this.dataGridView1.DragOver += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragOver);
            this.dataGridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDown);
            this.dataGridView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseMove);
            // 
            // button6
            // 
            this.button6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button6.Location = new System.Drawing.Point(690, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(155, 23);
            this.button6.TabIndex = 8052;
            this.button6.Text = "T18225 info";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnSortUpdate
            // 
            this.btnSortUpdate.Location = new System.Drawing.Point(690, 528);
            this.btnSortUpdate.Name = "btnSortUpdate";
            this.btnSortUpdate.Size = new System.Drawing.Size(155, 36);
            this.btnSortUpdate.TabIndex = 8053;
            this.btnSortUpdate.Text = "Sort Update";
            this.btnSortUpdate.UseVisualStyleBackColor = true;
            this.btnSortUpdate.Click += new System.EventHandler(this.btnSortUpdate_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(690, 609);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(155, 36);
            this.button7.TabIndex = 8054;
            this.button7.Text = "Minus";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(490, 631);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(143, 20);
            this.textBox2.TabIndex = 8055;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(490, 657);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(155, 36);
            this.button8.TabIndex = 8056;
            this.button8.Text = "Check Bullpen";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 722);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.btnSortUpdate);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chb_CopyTapeDetail_2);
            this.Controls.Add(this.chb_CopyTapeDetail_3);
            this.Controls.Add(this.chb_CopyTapeDetail_1);
            this.Controls.Add(this.chb_CopyTapeDetail_All);
            this.Controls.Add(this.btnPart2);
            this.Controls.Add(this.btnPart1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart_Mill)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_Mill;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnPart1;
        private System.Windows.Forms.Button btnPart2;
        private System.Windows.Forms.CheckBox chb_CopyTapeDetail_2;
        private System.Windows.Forms.CheckBox chb_CopyTapeDetail_3;
        private System.Windows.Forms.CheckBox chb_CopyTapeDetail_1;
        private System.Windows.Forms.CheckBox chb_CopyTapeDetail_All;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btnSortUpdate;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button8;
    }
}

