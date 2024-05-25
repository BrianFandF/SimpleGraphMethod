using _2_Methods_2._0;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2_Methods
{
	public class Algorithm
    {
		private int count_variables;
		private int count_limitations;
		private List<double> f_max;
		private List<List<double>> limitations;
		private List<List<double>> matrix_old;
		private List<List<double>> matrix_new;
		private int main_row = 0;
		private int main_column = 0;
		private void define_main_row()
        {
			int flag = 0;
			double min = 0;
			int index = 1;
			double tmp = 0;

			for (int i = 0; i < count_limitations; i++)
			{
				tmp = this.matrix_new[i + 1][1] / this.matrix_new[i + 1][this.main_column];
				if (tmp >= 0 && flag == 0)
				{
					min = tmp;
					index = i + 1;
					flag = 1;
				}

				else if (tmp >= 0)
				{
					if (min > tmp)
					{
						min = tmp;
						index = i + 1;
					}
				}
			}

			this.main_row = index;
		}
		private void define_main_column()
        {
			double min = this.matrix_new[matrix_new.Count - 1][1];
			int index = 1;
			for (int i = 2; i < matrix_new[0].Count; i++)
			{
				if (min > matrix_new[matrix_new.Count - 1][i])
				{
					min = matrix_new[matrix_new.Count - 1][i];
					index = i;
				}
			}

			this.main_column = index;
		}
		private void calculate_delta()
        {
			double sum = 0;
			for (int i = 0; i < count_limitations; i++)
			{
				sum += this.matrix_new[i + 1][1] * this.matrix_new[i + 1][0];
			}

			this.matrix_new[this.matrix_new.Count - 1][1] = sum;

			for (int i = 0; i < count_variables + count_limitations; i++)
			{
				sum = -this.matrix_new[0][i + 2];
				for (int j = 0; j < count_limitations; j++)
				{
					sum += this.matrix_new[j + 1][i + 2] * this.matrix_new[j + 1][0];
				}

				this.matrix_new[matrix_new.Count - 1][i + 2] = sum;
			}
		}
		private void copy_from_new_to_old_matrix()
        {
			for (int i = 0; i < this.matrix_new.Count; i++)
			{
				for (int j = 0; j < this.matrix_new[i].Count; j++)
				{
					this.matrix_old[i][j] = this.matrix_new[i][j];
				}
			}
		}
		public Algorithm(int count_variables, int count_limitations)
        {
			this.count_variables = count_variables;
			this.count_limitations = count_limitations;

			f_max = new List<double>();
			limitations = new List<List<double>>();
			
			for(int i = 0; i < limitations.Count; i++)
            {
				limitations[i] = new List<double>();
			}

			matrix_new = new List<List<double>>();
			for (int i = 0; i < count_limitations + 2; i++)
			{
				this.matrix_new.Add(new List<double>());
				for (int j = 0; j < count_variables + count_limitations + 2; j++)
				{
					matrix_new[i].Add(0.0);
				}
			}

			matrix_old = new List<List<double>>();
			for (int i = 0; i < count_limitations + 2; i++)
			{
				this.matrix_old.Add(new List<double>());
				for (int j = 0; j < count_variables + count_limitations + 2; j++)
				{
					matrix_old[i].Add(0.0);
				}
			}
		}
		public void count()
        {

        }
		public void first_step()
        {
			for (int i = 0; i < f_max.Count; i++)
			{
				this.matrix_new[0][i + 2] = f_max[i];
			}

			for (int i = 0; i < limitations.Count; i++)
			{
				this.matrix_new[i + 1][1] = limitations[i][limitations[i].Count - 1];
			}

			for (int i = 0; i < limitations.Count; i++)
			{
				for (int j = 0; j < limitations[i].Count - 1; j++)
				{
					this.matrix_new[i + 1][j + 2] = limitations[i][j];
				}
			}

			for (int i = 0; i < count_limitations; i++)
			{
				this.matrix_new[i + 1][2 + count_variables + i] = 1;
			}

			calculate_delta();
			define_main_column();
			define_main_row();
		}
		public void step_count()
        {
			copy_from_new_to_old_matrix();

			this.matrix_new[main_row][0] = this.matrix_old[0][main_column];

			for (int j = 1; j < this.matrix_old[0].Count; j++)
			{
				matrix_new[main_row][j] = matrix_old[main_row][j] / matrix_old[main_row][main_column];
			}

			for (int i = 1; i < count_limitations + 1; i++)
			{
				if (i == main_row)
				{
					continue;
				}

				for (int j = 1; j < matrix_old[0].Count; j++)
				{
					matrix_new[i][j] = matrix_old[i][j] - (matrix_old[i][main_column] * matrix_old[main_row][j] /
						matrix_old[main_row][main_column]);
				}
			}

			calculate_delta();
			define_main_column();
			define_main_row();
		}
		public void print_step(Form_table form_table)
        {
			var addColumn = new DataGridViewTextBoxColumn();
			addColumn.HeaderText = "Базис";
			form_table.table_simplex.Columns.Add(addColumn);

			addColumn = new DataGridViewTextBoxColumn();
			addColumn.HeaderText = "C(баз)";
			form_table.table_simplex.Columns.Add(addColumn);

			addColumn = new DataGridViewTextBoxColumn();
			addColumn.HeaderText = "План";
			form_table.table_simplex.Columns.Add(addColumn);

			for(int i = 0; i < count_variables; i++)
            {
				addColumn = new DataGridViewTextBoxColumn();
				addColumn.HeaderText = $"X{i + 1}";
				form_table.table_simplex.Columns.Add(addColumn);
			}

			for (int i = 0; i < count_limitations; i++)
			{
				addColumn = new DataGridViewTextBoxColumn();
				addColumn.HeaderText = $"Y{i + 1}";
				form_table.table_simplex.Columns.Add(addColumn);
			}

			for(int i = 0; i < this.matrix_new.Count - 1; i++)
            {
				form_table.table_simplex.Rows.Add();
			}

			for(int j = 2; j < matrix_new[0].Count; j++)
            {
				form_table.table_simplex.Rows[0].Cells[j + 1].Value = Math.Round(matrix_new[0][j], 2);
			}

			for (int i = 1; i < this.matrix_new.Count; i++)
			{
				for (int j = 0; j < matrix_new[i].Count; j++)
				{
					form_table.table_simplex.Rows[i].Cells[j + 1].Value = Math.Round(matrix_new[i][j], 2);
				}
			}

			for (int i = 0; i < count_limitations; i++)
            {
				form_table.table_simplex.Rows[i + 1].Cells[0].Value = $"Y{i + 1}";
			}

			form_table.table_simplex.Rows[matrix_new.Count - 1].Cells[0].Value = "delta";
		}
		public void print_coef()
        {

        }
		public void input(Form1 form1)
        {
			for(int i = 0; i < form1.variables_TextBox.Count; i++)
            {
				f_max.Add(Convert.ToDouble(form1.variables_TextBox[i].Text));
            }

			if(form1.combo_Box_f.SelectedItem.Equals("min"))
            {
				for(int i = 0; i < f_max.Count; i++)
                {
					f_max[i] *= -1;

				}
            }

			for(int i = 0; i < form1.limitations_TextBox.Count; i++)
            {
				List<double> tmp_row = new List<double>(); 
				for(int j = 0; j < form1.limitations_TextBox[i].Count; j++)
                {
					tmp_row.Add(Convert.ToDouble(form1.limitations_TextBox[i][j].Text));
				}

				tmp_row.Add(Convert.ToDouble(form1.text_Box_free_numbers[i].Text));
				if(form1.combo_Box_limitations[i].SelectedItem.ToString().Equals(">="))
                {
					for(int j = 0; j < tmp_row.Count; j++)
                    {
						tmp_row[j] *= -1;
                    }
                }

				limitations.Add(tmp_row);
            }
		}

		public bool check_delta()
        {
			for(int j = 1; j < matrix_new[matrix_new.Count - 1].Count; j++)
            {
				if(this.matrix_new[matrix_new.Count - 1][j] < 0)
                {
					return true;
                }
            }

			return false;
        }

		public void print_basis(Form_table form_table)
        {
			form_table.table_simplex.Rows[main_row].Cells[0].Value =
				form_table.table_simplex.Columns[main_column + 1].HeaderText;
		}

		public void color_table(Form_table form_table)
        {
			form_table.table_simplex.Columns[main_column + 1].DefaultCellStyle.BackColor = Color.FromArgb(0, 128, 255);
			form_table.table_simplex.Rows[main_row].DefaultCellStyle.BackColor = Color.FromArgb(0, 128, 255);
			form_table.table_simplex.Rows[main_row].Cells[main_column + 1].Style.BackColor = Color.Gold;
		}

		public void color_white_table(Form_table form_table)
        {
			form_table.table_simplex.Columns[main_column + 1].DefaultCellStyle.BackColor = Color.Empty;
			form_table.table_simplex.Rows[main_row].DefaultCellStyle.BackColor = Color.Empty;
			form_table.table_simplex.Rows[main_row].Cells[main_column + 1].Style.BackColor = Color.Empty;
		}

		public void print_next_step(Form_table form_table)
        {
			for (int j = 2; j < matrix_new[0].Count; j++)
			{
				form_table.table_simplex.Rows[0].Cells[j + 1].Value = Math.Round(matrix_new[0][j], 2);
			}

			for (int i = 1; i < this.matrix_new.Count; i++)
			{
				for (int j = 0; j < matrix_new[i].Count; j++)
				{
					form_table.table_simplex.Rows[i].Cells[j + 1].Value = Math.Round(matrix_new[i][j], 2);
				}
			}
		}

		public int get_count_variables()
        {
			return this.count_variables;
        }

		public List<double> get_f_max()
        {
			return this.f_max;
        }

		public List<List<double>> get_limitations()
        {
			return this.limitations;
        }
	}
}