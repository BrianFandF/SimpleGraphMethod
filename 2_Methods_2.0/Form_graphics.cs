using _2_Methods;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace _2_Methods_2._0
{
    public partial class Form_graphics : Form
    {
        public Form_graphics()
        {
            InitializeComponent();
        }

        public Form_graphics(Form1 form1, Algorithm simplex_method)
        {
            InitializeComponent();
            this.algorithm_simplex_method = simplex_method;
        }

        private void Form_graphics_Load(object sender, EventArgs e)
        {
            this.counter = 0;
            this.points_paint = new Define_points(10000, 10000);

            this.chart1.ChartAreas[0].AxisX.Maximum = 10000;
            this.chart1.ChartAreas[0].AxisX.Minimum = 0;

            this.chart1.ChartAreas[0].AxisY.Maximum = 10000;
            this.chart1.ChartAreas[0].AxisY.Minimum = 0;

            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.Crossing = 0;
            chart1.ChartAreas[0].AxisY.Crossing = 0;
        }

        private void button_next_graphic_Click(object sender, EventArgs e)
        {
            if (this.label_end.Visible == true)
            {
                return;
            }

            List<List<double>> limitations = this.algorithm_simplex_method.get_limitations();
            // получение точек области для закрашивания

            if (counter < limitations.Count)
            {
                try
                {
                    this.points_paint.get_new_points(limitations[counter]);
                }

                catch(ApplicationException error)
                {
                    if(points_paint.check_the_right_side(limitations[counter]))
                    {
                        
                    }

                    else
                    {
                        this.label_end.Visible = true;
                        return;
                    }

                }
            }

            points = points_paint.get_points();

            // коррекция масштаба по осям

            if (points.Count != 0)
            {

                double maxX = this.points[0].X;
                double maxY = this.points[0].Y;

                foreach (var item in points)
                {
                    if (item.X > maxX)
                    {
                        maxX = item.X;
                    }
                    if (item.Y > maxY)
                    {
                        maxY = item.Y;
                    }
                }

                chart1.ChartAreas[0].AxisX.Maximum = (Math.Round(maxX * 1.1) / 10 + 1) * 10;
                chart1.ChartAreas[0].AxisY.Maximum = (Math.Round(maxY * 1.1) / 10 + 1) * 10;
            }

            // отрисовка прямых на графике
            if (counter < limitations.Count)
            {
                this.chart1.Series.Add($"Limitation {counter + 1}");
                chart1.Series[chart1.Series.Count - 1].ChartType = SeriesChartType.Line;

                if (limitations[counter][1] != 0)
                {
                    for (double x = 0; x < this.chart1.ChartAreas[0].AxisX.Maximum; x += 0.5)
                    {
                        chart1.Series[chart1.Series.Count - 1].Points.AddXY(x,
                            (limitations[counter][2] - x * limitations[counter][0]) / limitations[counter][1]);
                    }
                }

                else
                {
                    for (double y = 0; y < this.chart1.ChartAreas[0].AxisY.Maximum; y += 0.5)
                    {
                        chart1.Series[chart1.Series.Count - 1].Points.AddXY((limitations[counter][2] - 
                            limitations[counter][1] * y) / limitations[counter][0], y);
                    }
                }

                counter++;
            }

            else
            {
                this.label_end.Visible = true;
            }

            if (counter == limitations.Count)
            {
                this.chart1.Series.Add($"Function");
                chart1.Series[chart1.Series.Count - 1].ChartType = SeriesChartType.Line;
                chart1.Series[chart1.Series.Count - 1].Color = Color.Red;

                List<double> koeff = algorithm_simplex_method.get_f_max();

                for (double x = -30; x < 30; x += 0.5)
                {
                    chart1.Series[chart1.Series.Count - 1].Points.AddXY(x,
                        (0 - x * koeff[0]) / koeff[1]);
                }

                chart1.ChartAreas[0].AxisX.Minimum = -10;
                chart1.ChartAreas[0].AxisY.Minimum = -10;

                counter++;
            }

            if (counter == limitations.Count + 1)
            {
                this.chart1.Series.Add($"Function cross");
                chart1.Series[chart1.Series.Count - 1].ChartType = SeriesChartType.Line;
                chart1.Series[chart1.Series.Count - 1].Color = Color.Green;

                List<double> koeff = algorithm_simplex_method.get_f_max();

                List<double> coeff3 = koeff;
                coeff3.Add(2);

                try
                {
                    while (true)
                    {
                        points_paint.get_new_points_without_points(coeff3);
                        coeff3[coeff3.Count - 1] += 0.01;
                    }
                }
                catch (ApplicationException ex)
                {
                    PointF result = new PointF();
                    foreach (DictionaryEntry item in ex.Data)
                    {
                        result = (PointF)item.Value;
                    }

                    List<double> f_max_for_point = this.algorithm_simplex_method.get_f_max();
                    double res_f_max = f_max_for_point[0] * result.X + f_max_for_point[1] * result.Y;

                    this.label_end.Text = $"Результат: X = {result.X:f2}, Y = {result.Y:f2}, " +
                        $"F_max = {res_f_max:f2}";
                    this.label_end.Visible = true;
                }

                for (double x = -30; x < 30; x += 0.5)
                {
                    chart1.Series[chart1.Series.Count - 1].Points.AddXY(x,
                        (coeff3[2] - x * coeff3[0]) / coeff3[1]);
                }

                counter++;
            }
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chart1_PostPaint(object sender, ChartPaintEventArgs e)
        {
            List<PointF> points_tmp = new List<PointF>();
            List<PointF> points = this.points_paint.get_points();
            List<List<double>> limitations = this.algorithm_simplex_method.get_limitations();
            var area = chart1.ChartAreas[0];
            var xScale = area.AxisX;
            var yScale = area.AxisY;

            points_tmp.Clear();
            for (int j = 0; j < points.Count; j++)
            {
                PointF point = new PointF();
                point.X = (float)xScale.ValueToPixelPosition(points[j].X);
                point.Y = (float)yScale.ValueToPixelPosition(points[j].Y);

                points_tmp.Add(point);
            }

            var fillBrush = new SolidBrush(Color.FromArgb(5, Color.Blue));
            e.ChartGraphics.Graphics.FillPolygon(fillBrush, points_tmp.ToArray());
        }

        private void label_end_Click(object sender, EventArgs e)
        {

        }
    }
}
