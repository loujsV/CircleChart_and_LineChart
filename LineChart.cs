using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using System.Threading;

namespace Circle_Chart
{
    public partial class LineChart : Form
    {
        public LineChart()
        {
            InitializeComponent();
        }

        static string cs = ConfigurationManager.ConnectionStrings["SCPM"].ConnectionString.ToString();

        DateTime from_ = DateTime.Parse("9/1/2022");
        DateTime to_ = DateTime.Parse("2/28/2023");
        

        private static DataTable GetData_ChartNEW_4dept(DateTime _from, DateTime _to, int select)
        {
            DataTable dt = new DataTable();
            string cs = ConfigurationManager.ConnectionStrings["SCPM"].ConnectionString.ToString();
            using (SqlConnection con = new SqlConnection(cs))
            {
               
                con.Open();

                SqlCommand cmd = new SqlCommand("dbo.proc_2023_03_02_ChartLine_1", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@select", select);
                cmd.Parameters.AddWithValue("@from", _from);
                cmd.Parameters.AddWithValue("@to", _to);
            
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                adapt.Fill(dt);
                con.Close();
            }
            return dt;
        }
        private void chart1_method(int _selected)
        {
            DataTable dt = GetData_ChartNEW_4dept(from_, to_, _selected);

            string[] x = (from p in dt.AsEnumerable()
                          select p.Field<string>("mon_year")).ToArray();

            int[] y = (from p in dt.AsEnumerable()
                       select p.Field<int>("Customer")).ToArray();
         
            int[] z = (from p in dt.AsEnumerable()
                       select p.Field<int>("Stock")).ToArray();
            
            chart1_SCPM.Series[0].ChartType = SeriesChartType.Line;
            chart1_SCPM.Series[0].Name = "Customer";
            chart1_SCPM.Series[0].Points.DataBindXY(x, y);
            chart1_SCPM.Series[0].BorderWidth = 5;
            //add them 1 series bang cach vao design-> properties -> series ->collection
            chart1_SCPM.Series[1].ChartType = SeriesChartType.Line;
            chart1_SCPM.Series[1].Name = "Stock";
            chart1_SCPM.Series[1].Points.DataBindXY(x, z);
            chart1_SCPM.Series[1].BorderWidth = 5;
            chart1_SCPM.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chart1_SCPM.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = true;
            chart1_SCPM.ChartAreas["ChartArea1"].AxisX.Title = "Ship Month";
            chart1_SCPM.ChartAreas["ChartArea1"].AxisY.Title = "Cycle Time (Days)";
            chart1_SCPM.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Arial", 12F, FontStyle.Italic, GraphicsUnit.Point, ((byte)(0)));
            chart1_SCPM.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Arial", 12F, FontStyle.Italic, GraphicsUnit.Point, ((byte)(0)));
            chart1_SCPM.ChartAreas["ChartArea1"].BackColor = Color.Honeydew;
            chart1_SCPM.Legends[0].Font = new Font("Times new roman", 12.0f, FontStyle.Bold);
            Title title0 = new Title();
            title0.Font = new Font("Arial", 12, FontStyle.Bold);
            title0.Text = "SCPM Avarage Job Card Cycle Time by Job Category";
            chart1_SCPM.Titles.Add(title0);
            Title title1 = new Title();
            title1.Font = new Font("Arial", 12, FontStyle.Italic);
            title1.Text = "Number of days between job card received and shipped";
            chart1_SCPM.Titles.Add(title1);
            
            
        }

        private void chart2_method(int _selected)
        {
            DataTable dt = GetData_ChartNEW_4dept(from_, to_, _selected);

            string[] x = (from p in dt.AsEnumerable()
                          select p.Field<string>("mon_year")).ToArray();

            int[] a = (from p in dt.AsEnumerable()
                       select p.Field<int>("MILL")).ToArray();

            int[] b = (from p in dt.AsEnumerable()
                       select p.Field<int>("LATHE")).ToArray();

            int[] c = (from p in dt.AsEnumerable()
                       select p.Field<int>("HQR")).ToArray();

            int[] d = (from p in dt.AsEnumerable()
                       select p.Field<int>("EUROTECH")).ToArray();

            chart2_SCPM.Series[0].ChartType = SeriesChartType.Line;
            chart2_SCPM.Series[0].Name = "Mill";
            chart2_SCPM.Series[0].Points.DataBindXY(x, a);
            chart2_SCPM.Series[0].BorderWidth = 5;
            chart2_SCPM.Series[1].ChartType = SeriesChartType.Line;
            chart2_SCPM.Series[1].Name = "Lathe";
            chart2_SCPM.Series[1].Points.DataBindXY(x, b);
            chart2_SCPM.Series[1].BorderWidth = 5;
            chart2_SCPM.Series[2].ChartType = SeriesChartType.Line;
            chart2_SCPM.Series[2].Name = "Hqr";
            chart2_SCPM.Series[2].Points.DataBindXY(x, c);
            chart2_SCPM.Series[2].BorderWidth = 5;
            chart2_SCPM.Series[3].ChartType = SeriesChartType.Line;
            chart2_SCPM.Series[3].Name = "Euro";
            chart2_SCPM.Series[3].Points.DataBindXY(x, d);
            chart2_SCPM.Series[3].BorderWidth = 5;
            chart2_SCPM.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chart2_SCPM.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = true;
            chart2_SCPM.ChartAreas["ChartArea1"].AxisX.Title = "Ship Month";
            chart2_SCPM.ChartAreas["ChartArea1"].AxisY.Title = "Cycle Time (Days)";
            chart2_SCPM.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Arial", 12F, FontStyle.Italic, GraphicsUnit.Point, ((byte)(0)));
            chart2_SCPM.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Arial", 12F, FontStyle.Italic, GraphicsUnit.Point, ((byte)(0)));
            chart2_SCPM.ChartAreas["ChartArea1"].BackColor = Color.Honeydew;
            chart2_SCPM.Legends[0].Font = new Font("Times new roman", 12.0f, FontStyle.Bold);

            Title title0 = new Title();
            title0.Font = new Font("Arial", 12, FontStyle.Bold);
            title0.Text = "SCPM Avarage Job Card Cycle Time by Production Department";
            chart2_SCPM.Titles.Add(title0);
            Title title1 = new Title();
            title1.Font = new Font("Arial", 12, FontStyle.Italic);
            title1.Text = "Number of days between CUSTOMER job card received and shipped";
            chart2_SCPM.Titles.Add(title1);
        }

        private void chart3_method(int _selected)
        {
            DataTable dt = GetData_ChartNEW_4dept(from_, to_, _selected);

            string[] x = (from p in dt.AsEnumerable()
                          select p.Field<string>("mon_year")).ToArray();

            int[] a = (from p in dt.AsEnumerable()
                       select p.Field<int>("MILL")).ToArray();

            int[] b = (from p in dt.AsEnumerable()
                       select p.Field<int>("LATHE")).ToArray();

            int[] c = (from p in dt.AsEnumerable()
                       select p.Field<int>("HQR")).ToArray();

            int[] d = (from p in dt.AsEnumerable()
                       select p.Field<int>("EUROTECH")).ToArray();

            chart3_SCPM.Series[0].ChartType = SeriesChartType.Line;
            chart3_SCPM.Series[0].Name = "Mill";
            chart3_SCPM.Series[0].Points.DataBindXY(x, a);
            chart3_SCPM.Series[0].BorderWidth = 5;
            chart3_SCPM.Series[1].ChartType = SeriesChartType.Line;
            chart3_SCPM.Series[1].Name = "Lathe";
            chart3_SCPM.Series[1].Points.DataBindXY(x, b);
            chart3_SCPM.Series[1].BorderWidth = 5;
            chart3_SCPM.Series[2].ChartType = SeriesChartType.Line;
            chart3_SCPM.Series[2].Name = "Hqr";
            chart3_SCPM.Series[2].Points.DataBindXY(x, c);
            chart3_SCPM.Series[2].BorderWidth = 5;
            chart3_SCPM.Series[3].ChartType = SeriesChartType.Line;
            chart3_SCPM.Series[3].Name = "Euro";
            chart3_SCPM.Series[3].Points.DataBindXY(x, d);
            chart3_SCPM.Series[3].BorderWidth = 5;
            chart3_SCPM.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chart3_SCPM.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = true;
            chart3_SCPM.ChartAreas["ChartArea1"].AxisX.Title = "Ship Month";
            chart3_SCPM.ChartAreas["ChartArea1"].AxisY.Title = "Cycle Time (Days)";
            chart3_SCPM.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Arial", 12F, FontStyle.Italic, GraphicsUnit.Point, ((byte)(0)));
            chart3_SCPM.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Arial", 12F, FontStyle.Italic, GraphicsUnit.Point, ((byte)(0)));
            chart3_SCPM.ChartAreas["ChartArea1"].BackColor = Color.Honeydew;
            chart3_SCPM.Legends[0].Font = new Font("Times new roman", 12.0f, FontStyle.Bold);

            Title title0 = new Title();
            title0.Font = new Font("Arial", 12, FontStyle.Bold);
            title0.Text = "SCPM Successful 7 day Turnaround";
            chart3_SCPM.Titles.Add(title0);
            Title title1 = new Title();
            title1.Font = new Font("Arial", 12, FontStyle.Italic);
            title1.Text = "Percentage of customer jobs completed within 7 days of receiving";
            chart3_SCPM.Titles.Add(title1);
        }

        private void LineChart_Load(object sender, EventArgs e)
        {
            int _day = (to_.Date - from_.Date).Days;
            if (_day <= 370)
            {
                chart1_method(1);
                chart2_method(2);
                chart3_method(3);
            }
            else
                MessageBox.Show("The Date range is too long");
        }
    }
}
