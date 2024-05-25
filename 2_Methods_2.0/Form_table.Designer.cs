
using _2_Methods;

namespace _2_Methods_2._0
{
    partial class Form_table
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
            this.table_simplex = new System.Windows.Forms.DataGridView();
            this.close_button = new System.Windows.Forms.Button();
            this.label_error_plan = new System.Windows.Forms.Label();
            this.next_step_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.table_simplex)).BeginInit();
            this.SuspendLayout();
            // 
            // table_simplex
            // 
            this.table_simplex.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.table_simplex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table_simplex.Location = new System.Drawing.Point(12, 12);
            this.table_simplex.Name = "table_simplex";
            this.table_simplex.RowHeadersWidth = 51;
            this.table_simplex.RowTemplate.Height = 24;
            this.table_simplex.Size = new System.Drawing.Size(776, 356);
            this.table_simplex.TabIndex = 0;
            // 
            // close_button
            // 
            this.close_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.close_button.Location = new System.Drawing.Point(12, 390);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(167, 39);
            this.close_button.TabIndex = 1;
            this.close_button.Text = "Закрити";
            this.close_button.UseVisualStyleBackColor = true;
            this.close_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_error_plan
            // 
            this.label_error_plan.AutoSize = true;
            this.label_error_plan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_error_plan.ForeColor = System.Drawing.Color.Red;
            this.label_error_plan.Location = new System.Drawing.Point(364, 399);
            this.label_error_plan.Name = "label_error_plan";
            this.label_error_plan.Size = new System.Drawing.Size(53, 20);
            this.label_error_plan.TabIndex = 2;
            this.label_error_plan.Text = "label1";
            this.label_error_plan.Visible = false;
            // 
            // next_step_button
            // 
            this.next_step_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.next_step_button.Location = new System.Drawing.Point(589, 390);
            this.next_step_button.Name = "next_step_button";
            this.next_step_button.Size = new System.Drawing.Size(199, 39);
            this.next_step_button.TabIndex = 3;
            this.next_step_button.Text = "Наступна ітерація";
            this.next_step_button.UseVisualStyleBackColor = true;
            this.next_step_button.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form_table
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.next_step_button);
            this.Controls.Add(this.label_error_plan);
            this.Controls.Add(this.close_button);
            this.Controls.Add(this.table_simplex);
            this.Name = "Form_table";
            this.Text = "Form_table";
            this.Load += new System.EventHandler(this.Form_table_Load);
            ((System.ComponentModel.ISupportInitialize)(this.table_simplex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView table_simplex;
        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.Label label_error_plan;
        private System.Windows.Forms.Button next_step_button;
        private Algorithm algorithm_simplex_method;
    }
}