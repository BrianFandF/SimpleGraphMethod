using _2_Methods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2_Methods_2._0
{
    public partial class Form_table : Form
    {
        public Form_table()
        {
            InitializeComponent();
        }

        public Form_table(Form1 form1, Algorithm simplex_method)
        {
            InitializeComponent();
            this.algorithm_simplex_method = simplex_method;
        }

        private void Form_table_Load(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            try
            {
                algorithm_simplex_method.first_step();
                algorithm_simplex_method.print_step(this);
                algorithm_simplex_method.color_table(this);
            }

            catch (Exception e_plan)
            {
                label_error_plan.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            algorithm_simplex_method.color_white_table(this);
            algorithm_simplex_method.print_basis(this);
            if (algorithm_simplex_method.check_delta())
            {
                algorithm_simplex_method.step_count();
                algorithm_simplex_method.print_next_step(this);
                algorithm_simplex_method.color_table(this);
            }

            else
            {
                this.table_simplex.Rows[table_simplex.Rows.Count - 1].Cells[2].Style.BackColor = Color.LimeGreen;
                label_error_plan.Text = "Кінець методу";
                label_error_plan.Visible = true;
            }
        }
    }
}
