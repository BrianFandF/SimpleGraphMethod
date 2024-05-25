using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Methods_2._0
{
    class Define_points
    {
        private List<PointF> points = new List<PointF>();
        private List<location_point> search_points = new List<location_point>();
        private PointF prev_point = new PointF();

        struct location_point
        {
            public PointF point;
            public int previous_index;
            public int next_index;
        }

        public Define_points(int x_max, int y_max)
        {
            points.Add(new PointF(0, 0));
            points.Add(new PointF(0, y_max));
            points.Add(new PointF(x_max, y_max));
            points.Add(new PointF(x_max, 0));
        }

        public void get_new_points(List<double> limitation)
        {
            search_points.Clear();
            for (int i = 0; i < this.points.Count; i++)
            {
                List<double> koef = get_koef(points[i], points[(i + 1) % points.Count]);
                PointF cross_new_point;

                try
                {
                    cross_new_point = get_cross_graph(limitation, koef);
                }

                catch (Exception e)
                {
                    continue;
                }

                if (check_point(points[i], points[(i + 1) % points.Count], cross_new_point))
                {
                    location_point res_point = new location_point();
                    res_point.point = cross_new_point;
                    res_point.previous_index = i;
                    res_point.next_index = (i + 1) % points.Count;

                    int flag = 0;
                    for(int j = 0; j < search_points.Count; j++)
                    {
                        if(Math.Abs(search_points[j].point.X - res_point.point.X) < 0.001 &&
                            Math.Abs(search_points[j].point.Y - res_point.point.Y) < 0.001)
                        {
                            flag = 1;
                            break;
                        } 
                    }

                    if(flag == 0)
                    {
                        search_points.Add(res_point);

                    }
                }
            }

            if (search_points.Count != 2)
            {
                throw new ApplicationException("No points");
            }

            List<PointF> tmp_points = new List<PointF>();
            points.Insert(search_points[0].previous_index + 1, search_points[0].point);
            points.Insert(search_points[1].previous_index + 2, search_points[1].point);

            for (int i = 0; i < points.Count; i++)
            {
                if(this.points[i].X == search_points[0].point.X &&
                    this.points[i].Y == search_points[0].point.Y)
                {
                    tmp_points.Add(points[i]);
                    continue;
                }

                if (this.points[i].X == search_points[1].point.X &&
                    this.points[i].Y == search_points[1].point.Y)
                {
                    tmp_points.Add(points[i]);
                    continue;
                }

                if ((limitation[0] * this.points[i].X + limitation[1] * this.points[i].Y)
                <= limitation[2])
                {
                    tmp_points.Add(points[i]);
                }
            }

            this.points.Clear();

            foreach (PointF point in tmp_points)
            {
                this.points.Add(point);
            }
        }

        public void get_new_points_without_points(List<double> limitation)
        {
            search_points.Clear();
            for (int i = 0; i < this.points.Count; i++)
            {
                List<double> koef = get_koef(points[i], points[(i + 1) % points.Count]);
                PointF cross_new_point;

                try
                {
                    cross_new_point = get_cross_graph(limitation, koef);
                }

                catch (Exception e)
                {
                    continue;
                }

                if (check_point(points[i], points[(i + 1) % points.Count], cross_new_point))
                {
                    location_point res_point = new location_point();
                    res_point.point = cross_new_point;
                    res_point.previous_index = i;
                    res_point.next_index = (i + 1) % points.Count;

                    int flag = 0;
                    for (int j = 0; j < search_points.Count; j++)
                    {
                        if (Math.Abs(search_points[j].point.X - res_point.point.X) < 0.001 &&
                            Math.Abs(search_points[j].point.Y - res_point.point.Y) < 0.001)
                        {
                            flag = 1;
                            break;
                        }
                    }

                    if (flag == 0)
                    {
                        search_points.Add(res_point);

                    }
                }
            }

            if (search_points.Count != 2)
            {
                ApplicationException e = new ApplicationException("No points");
                e.Data.Add("Point", prev_point);
                throw e;
            }

            else
            {
                this.prev_point = search_points[0].point;
            }
        }

        public List<double> get_koef(PointF first, PointF second)
        {
            double a = 0;
            double b = 0;
            double c = 0;

            a = second.Y - first.Y;
            b = first.X - second.X;
            c = first.Y * (second.X - first.X) - first.X * (second.Y - first.Y);


            List<double> res = new List<double>();
            res.Add(a);
            res.Add(b);
            res.Add(c);

            return res;
        }

        public PointF get_cross_graph(List<double> first_lim, List<double> second_koef)
        {
            double D = first_lim[0] * second_koef[1] - second_koef[0] * first_lim[1];
            PointF res = new PointF();

            if (D == 0)
            {
                throw new Exception();
            }

            else
            {
                double Dx = first_lim[2] * second_koef[1] + second_koef[2] * first_lim[1];
                double Dy = first_lim[0] * (-second_koef[2]) - second_koef[0] * first_lim[2];

                res.X = (float)(Dx / D);
                res.Y = (float)(Dy / D);

                return res;
            }
        }

        private bool check_point(PointF first_figure, PointF second_figure, PointF grap_point)
        {
            double distance = Math.Sqrt(Math.Pow(second_figure.X - first_figure.X, 2) +
                Math.Pow(second_figure.Y - first_figure.Y, 2));
            
            double first_grap = Math.Sqrt(Math.Pow(grap_point.X - first_figure.X, 2) +
                Math.Pow(grap_point.Y - first_figure.Y, 2));

            double second_grap = Math.Sqrt(Math.Pow(second_figure.X - grap_point.X, 2) +
                Math.Pow(second_figure.Y - grap_point.Y, 2));

            if(Math.Abs(distance - (first_grap + second_grap)) < 0.0001)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public List<PointF> get_points()
        {
            return this.points;
        }

        public bool check_the_right_side(List<double> limitation)
        {
            for(int i = 0; i < this.points.Count; i++)
            {
                if(limitation[0] * this.points[i].X + limitation[1] * this.points[i].Y
                > limitation[2])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
