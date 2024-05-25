
using _2_Methods;
using System.Collections.Generic;

namespace _2_Methods_2._0
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
            this.textBox_variables = new System.Windows.Forms.TextBox();
            this.textBox_limitations = new System.Windows.Forms.TextBox();
            this.Variables_label = new System.Windows.Forms.Label();
            this.Limitations_label = new System.Windows.Forms.Label();
            this.action_combo_Box = new System.Windows.Forms.ComboBox();
            this.error_label = new System.Windows.Forms.Label();
            this.action_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_variables
            // 
            this.textBox_variables.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_variables.Location = new System.Drawing.Point(363, 39);
            this.textBox_variables.Name = "textBox_variables";
            this.textBox_variables.Size = new System.Drawing.Size(70, 26);
            this.textBox_variables.TabIndex = 0;
            this.textBox_variables.TextChanged += new System.EventHandler(this.textBox_variables_TextChanged);
            this.textBox_variables.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_variables_KeyPress);
            // 
            // textBox_limitations
            // 
            this.textBox_limitations.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_limitations.Location = new System.Drawing.Point(363, 80);
            this.textBox_limitations.Name = "textBox_limitations";
            this.textBox_limitations.Size = new System.Drawing.Size(70, 26);
            this.textBox_limitations.TabIndex = 1;
            this.textBox_limitations.TextChanged += new System.EventHandler(this.textBox_limitations_TextChanged);
            // 
            // Variables_label
            // 
            this.Variables_label.AutoSize = true;
            this.Variables_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Variables_label.Location = new System.Drawing.Point(213, 42);
            this.Variables_label.Name = "Variables_label";
            this.Variables_label.Size = new System.Drawing.Size(144, 20);
            this.Variables_label.TabIndex = 2;
            this.Variables_label.Text = "Кількість зміних";
            // 
            // Limitations_label
            // 
            this.Limitations_label.AutoSize = true;
            this.Limitations_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Limitations_label.Location = new System.Drawing.Point(182, 83);
            this.Limitations_label.Name = "Limitations_label";
            this.Limitations_label.Size = new System.Drawing.Size(175, 20);
            this.Limitations_label.TabIndex = 3;
            this.Limitations_label.Text = "Кількість обмежень";
            // 
            // action_combo_Box
            // 
            this.action_combo_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.action_combo_Box.FormattingEnabled = true;
            this.action_combo_Box.Items.AddRange(new object[] {
            "Симплекс метод",
            "Графічний метод"});
            this.action_combo_Box.Location = new System.Drawing.Point(560, 42);
            this.action_combo_Box.Name = "action_combo_Box";
            this.action_combo_Box.Size = new System.Drawing.Size(194, 28);
            this.action_combo_Box.TabIndex = 4;
            // 
            // error_label
            // 
            this.error_label.AutoSize = true;
            this.error_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.error_label.ForeColor = System.Drawing.Color.Red;
            this.error_label.Location = new System.Drawing.Point(552, 128);
            this.error_label.Name = "error_label";
            this.error_label.Size = new System.Drawing.Size(236, 20);
            this.error_label.TabIndex = 5;
            this.error_label.Text = "Не усі значення введені";
            this.error_label.Visible = false;
            // 
            // action_button
            // 
            this.action_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.action_button.Location = new System.Drawing.Point(576, 80);
            this.action_button.Name = "action_button";
            this.action_button.Size = new System.Drawing.Size(168, 31);
            this.action_button.TabIndex = 6;
            this.action_button.Text = "Розрахувати";
            this.action_button.UseVisualStyleBackColor = true;
            this.action_button.Click += new System.EventHandler(this.action_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.action_button);
            this.Controls.Add(this.error_label);
            this.Controls.Add(this.action_combo_Box);
            this.Controls.Add(this.Limitations_label);
            this.Controls.Add(this.Variables_label);
            this.Controls.Add(this.textBox_limitations);
            this.Controls.Add(this.textBox_variables);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_variables;
        private System.Windows.Forms.TextBox textBox_limitations;
        private System.Windows.Forms.Label Variables_label;
        private System.Windows.Forms.Label Limitations_label;
        private System.Windows.Forms.ComboBox action_combo_Box;
        private System.Windows.Forms.Label error_label;
        private System.Windows.Forms.Button action_button;

        public System.Windows.Forms.ComboBox combo_Box_f;
        public List<System.Windows.Forms.Label> variables_labels = new List<System.Windows.Forms.Label>();
        public List<System.Windows.Forms.TextBox> variables_TextBox = new List<System.Windows.Forms.TextBox>();
        public List<List<System.Windows.Forms.Label>> limitations_Labels = new List<List<System.Windows.Forms.Label>>();
        public List<List<System.Windows.Forms.TextBox>> limitations_TextBox = new List<List<System.Windows.Forms.TextBox>>();
        public List<System.Windows.Forms.ComboBox> combo_Box_limitations = new List<System.Windows.Forms.ComboBox>();
        public List<System.Windows.Forms.TextBox> text_Box_free_numbers = new List<System.Windows.Forms.TextBox>();
        public List<System.Windows.Forms.Label> plus_f_max = new List<System.Windows.Forms.Label>();
        public List<List<System.Windows.Forms.Label>> plus_limitations = new List<List<System.Windows.Forms.Label>>();
        private Algorithm algorithm_simplex_method;
    }
}

