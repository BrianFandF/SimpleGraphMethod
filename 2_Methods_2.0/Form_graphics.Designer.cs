
using _2_Methods;
using System.Collections.Generic;
using System.Drawing;

namespace _2_Methods_2._0
{
    partial class Form_graphics
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button_next_graphic = new System.Windows.Forms.Button();
            this.button_close = new System.Windows.Forms.Button();
            this.label_end = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(12, 12);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(929, 552);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.PostPaint += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ChartPaintEventArgs>(this.chart1_PostPaint);
            // 
            // button_next_graphic
            // 
            this.button_next_graphic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_next_graphic.Location = new System.Drawing.Point(709, 623);
            this.button_next_graphic.Name = "button_next_graphic";
            this.button_next_graphic.Size = new System.Drawing.Size(232, 41);
            this.button_next_graphic.TabIndex = 1;
            this.button_next_graphic.Text = "Наступний графік";
            this.button_next_graphic.UseVisualStyleBackColor = true;
            this.button_next_graphic.Click += new System.EventHandler(this.button_next_graphic_Click);
            // 
            // button_close
            // 
            this.button_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_close.Location = new System.Drawing.Point(12, 623);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(209, 41);
            this.button_close.TabIndex = 2;
            this.button_close.Text = "Закрити";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // label_end
            // 
            this.label_end.AutoSize = true;
            this.label_end.BackColor = System.Drawing.SystemColors.Control;
            this.label_end.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_end.ForeColor = System.Drawing.Color.Red;
            this.label_end.Location = new System.Drawing.Point(398, 588);
            this.label_end.Name = "label_end";
            this.label_end.Size = new System.Drawing.Size(131, 20);
            this.label_end.TabIndex = 3;
            this.label_end.Text = "Кінець методу";
            this.label_end.Visible = false;
            this.label_end.Click += new System.EventHandler(this.label_end_Click);
            // 
            // Form_graphics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 676);
            this.Controls.Add(this.label_end);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.button_next_graphic);
            this.Controls.Add(this.chart1);
            this.Name = "Form_graphics";
            this.Text = "Form_graphics";
            this.Load += new System.EventHandler(this.Form_graphics_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Algorithm algorithm_simplex_method;
        private System.Windows.Forms.Button button_next_graphic;
        private System.Windows.Forms.Button button_close;
        private int counter;
        private System.Windows.Forms.Label label_end;
        private List<PointF> points = new List<PointF>();
        private Define_points points_paint;
    }
}