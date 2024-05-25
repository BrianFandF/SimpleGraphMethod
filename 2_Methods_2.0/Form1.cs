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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.action_combo_Box.SelectedIndex = 0;
        }

        private void textBox_variables_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox_variables.Text.Equals("") || this.textBox_limitations.Text.Equals(""))
            {
                return;
            }

            int count_variables = Convert.ToInt32(this.textBox_variables.Text);
            int count_limitations = Convert.ToInt32(this.textBox_limitations.Text);

            create_limitations(count_variables, count_limitations);
            create_pluses(count_variables, count_limitations);
        }

        private void textBox_limitations_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox_variables.Text.Equals("") || this.textBox_limitations.Text.Equals(""))
            {
                return;
            }

            int count_variables = Convert.ToInt32(this.textBox_variables.Text);
            int count_limitations = Convert.ToInt32(this.textBox_limitations.Text);

            create_limitations(count_variables, count_limitations);
            create_pluses(count_variables, count_limitations);
        }

        private void textBox_variables_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != '-') // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void create_limitations(int count_variables, int count_limitations)
        {
            if (combo_Box_f == null)
            {
                combo_Box_f = new ComboBox();
                combo_Box_f.Items.Add("max");
                combo_Box_f.Items.Add("min");
                combo_Box_f.SelectedItem = "max";
                this.Controls.Add(combo_Box_f);
            }

            if (count_variables > variables_labels.Count)
            {
                int i = variables_labels.Count;
                for (; i < count_variables; i++)
                {
                    Label add_label = new Label();
                    add_label.Location = new Point(70 + i * 100, 160);
                    add_label.Size = new Size(30, 30);
                    add_label.Text = $"X{(i + 1).ToString()}";
                    variables_labels.Add(add_label);
                    this.Controls.Add(variables_labels[i]);

                    TextBox add_TextBox = new TextBox();
                    add_TextBox.Location = new Point(40 + i * 100, 160);
                    add_TextBox.Size = new Size(30, 30);
                    add_TextBox.KeyPress += this.textBox_variables_KeyPress;
                    variables_TextBox.Add(add_TextBox);
                    this.Controls.Add(variables_TextBox[i]);
                }

                combo_Box_f.Location = new Point(60 + i * 95, 160);
                combo_Box_f.Visible = true;
                combo_Box_f.Size = new Size(60, 30);
            }

            else if (count_variables == variables_labels.Count)
            {

            }

            else
            {
                int i = variables_labels.Count - 1;
                for (; i > count_variables - 1; i--)
                {
                    this.Controls.Remove(variables_labels[i]);
                    variables_labels.RemoveAt(i);

                    this.Controls.Remove(variables_TextBox[i]);
                    variables_TextBox.RemoveAt(i);
                }

                combo_Box_f.Location = new Point(60 + (i + 1) * 95, 160);
            }

            // створення обмежень

            if (count_limitations > limitations_Labels.Count)
            {
                for (int i = limitations_Labels.Count; i < count_limitations; i++)
                {
                    List<TextBox> add_TextBox_Row = new List<TextBox>();
                    List<Label> add_Label_Row = new List<Label>();
                    int j = 0;
                    for (; j < count_variables; j++)
                    {
                        Label add_label = new Label();
                        add_label.Location = new Point(70 + j * 100, 220 + i * 30);
                        add_label.Size = new Size(30, 30);
                        add_label.Text = $"X{(j + 1).ToString()}";
                        add_Label_Row.Add(add_label);
                        this.Controls.Add(add_Label_Row[j]);

                        TextBox add_TextBox = new TextBox();
                        add_TextBox.Location = new Point(40 + j * 100, 220 + i * 30);
                        add_TextBox.Size = new Size(30, 30);
                        add_TextBox.KeyPress += this.textBox_variables_KeyPress;
                        add_TextBox_Row.Add(add_TextBox);
                        this.Controls.Add(add_TextBox_Row[j]);
                    }

                    limitations_TextBox.Add(add_TextBox_Row);
                    limitations_Labels.Add(add_Label_Row);

                    ComboBox add_Combo_box = new ComboBox();
                    //add_Combo_box.Location = new Point(30 + j * 100, 220 + i * 30);
                    add_Combo_box.Location = new Point(limitations_TextBox[i][limitations_TextBox[i].Count - 1].Location.X + 70, 220 + i * 30);
                    add_Combo_box.Size = new Size(60, 30);
                    add_Combo_box.Items.Add("<=");
                    add_Combo_box.Items.Add(">=");
                    add_Combo_box.SelectedItem = "<=";
                    combo_Box_limitations.Add(add_Combo_box);
                    this.Controls.Add(combo_Box_limitations[i]);

                    TextBox add_free_Text_box = new TextBox();
                    add_free_Text_box.Location = new Point(120 + j * 100, 220 + i * 30);
                    add_free_Text_box.Size = new Size(30, 30);
                    add_free_Text_box.KeyPress += this.textBox_variables_KeyPress;
                    text_Box_free_numbers.Add(add_free_Text_box);
                    this.Controls.Add(text_Box_free_numbers[i]);
                }
            }

            else if (count_limitations == limitations_Labels.Count)
            {

            }

            else
            {
                for (int i = limitations_Labels.Count - 1; i > count_limitations - 1; i--)
                {
                    for (int j = limitations_Labels[i].Count - 1; j >= 0; j--)
                    {
                        this.Controls.Remove(limitations_TextBox[i][j]);
                        this.Controls.Remove(limitations_Labels[i][j]);

                        limitations_TextBox[i].RemoveAt(j);
                        limitations_Labels[i].RemoveAt(j);
                    }

                    limitations_TextBox.RemoveAt(i);
                    limitations_Labels.RemoveAt(i);

                    this.Controls.Remove(combo_Box_limitations[i]);
                    combo_Box_limitations.RemoveAt(i);

                    this.Controls.Remove(text_Box_free_numbers[i]);
                    text_Box_free_numbers.RemoveAt(i);
                }
            }

            if (count_variables > limitations_Labels[0].Count)
            {
                for (int i = 0; i < count_limitations; i++)
                {
                    int j = limitations_Labels[i].Count;
                    for (; j < count_variables; j++)
                    {
                        Label add_label = new Label();
                        add_label.Location = new Point(70 + j * 100, 220 + i * 30);
                        add_label.Size = new Size(30, 30);
                        add_label.Text = $"X{(j + 1).ToString()}";
                        limitations_Labels[i].Add(add_label);
                        this.Controls.Add(limitations_Labels[i][j]);

                        TextBox add_TextBox = new TextBox();
                        add_TextBox.Location = new Point(40 + j * 100, 220 + i * 30);
                        add_TextBox.Size = new Size(30, 30);
                        add_TextBox.KeyPress += this.textBox_variables_KeyPress;
                        limitations_TextBox[i].Add(add_TextBox);
                        this.Controls.Add(limitations_TextBox[i][j]);
                    }

                    combo_Box_limitations[i].Location = new Point(limitations_TextBox[i][limitations_TextBox[i].Count - 1].Location.X + 70, 220 + i * 30);
                    text_Box_free_numbers[i].Location = new Point(120 + j * 100, 220 + i * 30);
                }
            }

            else if (count_variables < limitations_Labels[0].Count)
            {
                for (int i = 0; i < count_limitations; i++)
                {
                    int j = limitations_Labels[i].Count - 1;
                    for (; j > count_variables - 1; j--)
                    {
                        this.Controls.Remove(limitations_TextBox[i][j]);
                        this.Controls.Remove(limitations_Labels[i][j]);

                        limitations_TextBox[i].RemoveAt(j);
                        limitations_Labels[i].RemoveAt(j);
                    }

                    combo_Box_limitations[i].Location = new Point(limitations_TextBox[i][limitations_TextBox[i].Count - 1].Location.X + 70, 220 + i * 30);
                    text_Box_free_numbers[i].Location = new Point(120 + (j + 1) * 100, 220 + i * 30);
                }
            }
        }

        private void create_pluses(int count_variables, int count_limitations)
        {
            if (count_variables > plus_f_max.Count)
            {
                if (plus_f_max.Count != 0)
                {
                    plus_f_max[plus_f_max.Count - 1].Text = " + ";
                }

                for (int i = plus_f_max.Count; i < count_variables; i++)
                {
                    Label add_plus_f_max = new Label();
                    add_plus_f_max.Location = new Point(105 + i * 100, 160);
                    add_plus_f_max.Size = new Size(30, 30);
                    add_plus_f_max.Text = " + ";
                    plus_f_max.Add(add_plus_f_max);
                    this.Controls.Add(plus_f_max[i]);
                }

                plus_f_max[plus_f_max.Count - 1].Text = " -> ";
            }

            else if (count_variables < plus_f_max.Count)
            {
                for (int i = plus_f_max.Count - 1; i > count_variables - 1; i--)
                {
                    this.Controls.Remove(plus_f_max[i]);
                    plus_f_max.RemoveAt(i);
                }

                plus_f_max[plus_f_max.Count - 1].Text = " -> ";
            }


            // для обмежень

            if (count_limitations > plus_limitations.Count)
            {
                for (int i = plus_limitations.Count; i < count_limitations; i++)
                {
                    List<Label> add_plus_Row = new List<Label>();
                    for (int j = 0; j < count_variables - 1; j++)
                    {
                        Label add_plus_limitation = new Label();
                        add_plus_limitation.Location = new Point(105 + j * 100, 220 + i * 30);
                        add_plus_limitation.Size = new Size(30, 30);
                        add_plus_limitation.Text = " + ";
                        add_plus_Row.Add(add_plus_limitation);
                        this.Controls.Add(add_plus_Row[j]);
                    }

                    //add_plus_Row[add_plus_Row.Count - 1].Text = " <= ";
                    plus_limitations.Add(add_plus_Row);
                }
            }

            else if (count_limitations < plus_limitations.Count)
            {
                for (int i = plus_limitations.Count - 1; i > count_limitations - 1; i--)
                {
                    for (int j = plus_limitations[i].Count - 1; j >= 0; j--)
                    {
                        this.Controls.Remove(plus_limitations[i][j]);
                        plus_limitations[i].RemoveAt(j);
                    }

                    plus_limitations.RemoveAt(i);
                }
            }

            if (count_variables > plus_limitations[0].Count)
            {
                for (int i = 0; i < count_limitations; i++)
                {
                    if(plus_limitations[i].Count != 0)
                    {
                        plus_limitations[i][plus_limitations[i].Count - 1].Text = " + ";
                    }

                    for (int j = plus_limitations[i].Count; j < count_variables - 1; j++)
                    {
                        Label add_plus_limitation = new Label();
                        add_plus_limitation.Location = new Point(105 + j * 100, 220 + i * 30);
                        add_plus_limitation.Size = new Size(30, 30);
                        add_plus_limitation.Text = " + ";
                        plus_limitations[i].Add(add_plus_limitation);
                        this.Controls.Add(plus_limitations[i][j]);
                    }

                    //plus_limitations[i][plus_limitations[i].Count - 1].Text = " <= ";
                }
            }

            else if (count_variables < plus_limitations[0].Count)
            {
                for (int i = 0; i < count_limitations; i++)
                {
                    for (int j = plus_limitations[i].Count - 1; j > count_variables - 2; j--)
                    {
                        this.Controls.Remove(plus_limitations[i][j]);
                        plus_limitations[i].RemoveAt(j);
                    }

                    //plus_limitations[i][plus_limitations[i].Count - 1].Text = " <= ";
                }
            }
        }

        private void check_free_numbers()
        {
            for (int i = 0; i < combo_Box_limitations.Count; i++)
            {
                if (combo_Box_limitations[i].SelectedItem.Equals("<="))
                {
                    if (Convert.ToDouble(text_Box_free_numbers[i].Text) < 0)
                    {
                        throw new ArgumentException("Де <=, вільні члени повині бути додатними");
                    }
                }

                else if (combo_Box_limitations[i].SelectedItem.Equals(">="))
                {
                    if (Convert.ToDouble(text_Box_free_numbers[i].Text) >= 0)
                    {
                        throw new ArgumentException("Де >=, вільний член повинен бути від'ємним");
                    }
                }
            }
        }

        private void action_button_Click(object sender, EventArgs e)
        {
            error_label.Visible = false;

            if (action_combo_Box.SelectedIndex == 0)
            {
                try
                {
                    error_label.Visible = false;
                    check_free_numbers();
                    algorithm_simplex_method = new Algorithm(Convert.ToInt32(textBox_variables.Text),
                    Convert.ToInt32(textBox_limitations.Text));
                    algorithm_simplex_method.input(this);

                    Form_table form2 = new Form_table(this, algorithm_simplex_method);
                    form2.Owner = this;
                    form2.Show();
                }

                catch (ArgumentException error)
                {
                    error_label.Text = error.Message;
                    error_label.Visible = true;
                }

                catch (Exception error)
                {
                    error_label.Text = "Не усі значення введені";
                    error_label.Visible = true;
                }
            }

            else if (action_combo_Box.SelectedIndex == 1)
            {
                try
                {
                    check_free_numbers();
                    if (Convert.ToInt32(textBox_variables.Text) != 2)
                    {
                        error_label.Text = "Кількість зміних повина бути = 2";
                        error_label.Visible = true;
                        return;
                    }

                    else
                    {
                        algorithm_simplex_method = new Algorithm(Convert.ToInt32(textBox_variables.Text),
                        Convert.ToInt32(textBox_limitations.Text));
                        algorithm_simplex_method.input(this);

                        Form_graphics form3 = new Form_graphics(this, algorithm_simplex_method);
                        form3.Owner = this;
                        form3.Show();
                    }
                }

                catch (ArgumentException error)
                {
                    error_label.Text = error.Message;
                    error_label.Visible = true;
                }

                catch (Exception error)
                {
                    error_label.Text = "Не усі значення введені";
                    error_label.Visible = true;
                }
            }
        }
    }
}