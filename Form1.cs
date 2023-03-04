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


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        static string cs = ConfigurationManager.ConnectionStrings["SCPM"].ConnectionString.ToString();

        string _DeptChart = "lathe";

        private static DataTable GetData_ChartNEW_4dept(string _dept_)
        {
            DataTable dt = new DataTable();
            string cs = ConfigurationManager.ConnectionStrings["SCPM"].ConnectionString.ToString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                DateTime from_ = DateTime.Parse("12/1/2020");
                DateTime to_ = DateTime.Parse("1/15/2021");
                con.Open();
                SqlCommand cmd = new SqlCommand("dbo.proc_2021_01_18_ExceedorNot_1", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@needby_con", _dept_);
                cmd.Parameters.AddWithValue("@from", from_);
                cmd.Parameters.AddWithValue("@to", to_);
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                adapt.Fill(dt);
                con.Close();
            }
            return dt;
        }

        private void Chart_Mill()
        {
            //Fetch the Statistical data from database.
            //string query = @"[Report_Mill_NEWchart_byColumn]";
            DataTable dt = GetData_ChartNEW_4dept(_DeptChart);

            //Get the names of Column
            string[] x = (from p in dt.AsEnumerable()
                          orderby p.Field<string>("Column") ascending
                          select p.Field<string>("Column")).ToArray();

            //Get the Total of Orders for each 
            int[] y = (from p in dt.AsEnumerable()
                       orderby p.Field<string>("Column") ascending
                       select p.Field<int>("Total")).ToArray();


            chart_Mill.Series[0].ChartType = SeriesChartType.Doughnut;
            chart_Mill.Series[0].Points.DataBindXY(x, y);
            //chart_Mill.Legends[0].Enabled = true; //Phan label nho nho ben goc phai cua Do thi
            chart_Mill.ChartAreas[0].Area3DStyle.Enable3D = true;

            //chart_Mill.Series[0]["PieLabelStyle"] = "Disabled";
            //chart_Mill.Series[0]["PieLabelStyle"] = "outside";
            chart_Mill.Series[0]["PieLabelStyle"] = "Disabled";

            //chart_Mill.Series[0].Label = "#VALX #PERCENT{P0}"; //Khong lay phan` du
            chart_Mill.Series[0].Label = "#VALX #PERCENT{P2}"; //Lay 2 chu so thap phan

            FontFamily family = new FontFamily("Times New Roman");
            chart_Mill.Legends[0].Font = new Font(family, 12, FontStyle.Regular);

            chart_Mill.Series[0]["DoughnutRadius"] = "30";
            chart_Mill.Series[0]["PieStartAngle"] = "270";
            chart_Mill.Series[0].Font = new Font("Arial", 12.0f, FontStyle.Bold);
            chart_Mill.Series[0].LabelForeColor = Color.Black;
            chart_Mill.Legends[0].BackColor = Color.Honeydew;
            chart_Mill.ChartAreas["ChartArea1"].BackColor = Color.Honeydew;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //flowLayoutPanel1.Visible = true;
            //flowLayoutPanel1.BringToFront();
            Chart_Mill();

            label1.Text = panel1.Width.ToString();
            label2.Text = panel1.Height.ToString();

            //Design datagridview1
            dataGridView1.RowTemplate.Height = 45;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.ColumnHeadersVisible = true;
            // Set the column header style.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 15, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            
            
            PanelCreator_forChart();

            //createtest();
            //dataGridView1.RowTemplate.Resizable = DataGridViewTriState.True;
            //dataGridView1.RowTemplate.Height = 50;
        }

        /* Neu xai createtest() thi add cai nay
         * private Rectangle dragBoxFromMouseDown;
        private int rowIndexFromMouseDown;
        private int rowIndexOfItemUnderMouseToDrop;

        private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)

            {
                // If the mouse moves outside the rectangle, start the drag.

                if (dragBoxFromMouseDown != Rectangle.Empty &&

                    !dragBoxFromMouseDown.Contains(e.X, e.Y))

                {
                    // Proceed with the drag and drop, passing in the list item.                   

                    DragDropEffects dropEffect = dataGridView1.DoDragDrop(

                    dataGridView1.Rows[rowIndexFromMouseDown],

                    DragDropEffects.Move);

                }

            }
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.

            rowIndexFromMouseDown = dataGridView1.HitTest(e.X, e.Y).RowIndex;



            if (rowIndexFromMouseDown != -1)

            {

                // Remember the point where the mouse down occurred.

                // The DragSize indicates the size that the mouse can move

                // before a drag event should be started.               

                Size dragSize = SystemInformation.DragSize;



                // Create a rectangle using the DragSize, with the mouse position being

                // at the center of the rectangle.

                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),

                                                               e.Y - (dragSize.Height / 2)),

                                    dragSize);

            }

            else

                // Reset the rectangle if the mouse is not over an item in the ListBox.

                dragBoxFromMouseDown = Rectangle.Empty;
        }

        private void dataGridView1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            // The mouse locations are relative to the screen, so they must be

            // converted to client coordinates.

            Point clientPoint = dataGridView1.PointToClient(new Point(e.X, e.Y));

            // Get the row index of the item the mouse is below.

            rowIndexOfItemUnderMouseToDrop =

                dataGridView1.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            // If the drag operation was a move then remove and insert the row.

            if (e.Effect == DragDropEffects.Move)

            {
                DataGridViewRow rowToMove = e.Data.GetData(

                    typeof(DataGridViewRow)) as DataGridViewRow;

                dataGridView1.Rows.RemoveAt(rowIndexFromMouseDown);

                dataGridView1.Rows.Insert(rowIndexOfItemUnderMouseToDrop, rowToMove);


            }
            
        }
         */
        private void createtest()
        {
            dataGridView1.RowTemplate.Height = 45;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.ColumnCount = 5;
            dataGridView1.ColumnHeadersVisible = true;

            // Set the column header style.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 15, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Set the column header names.
            dataGridView1.Columns[0].Name = "Recipe";
            dataGridView1.Columns[1].Name = "Category";
            dataGridView1.Columns[2].Name = "Main Ingredients";
            dataGridView1.Columns[3].Name = "Rating";
            dataGridView1.Columns[4].Name = "RN";

            // Populate the rows.
            string[] row1 = new string[] { "Meatloaf", "Main Dish", "ground beef",
        "**", "1"};
            string[] row2 = new string[] { "Key Lime Pie", "Dessert",
        "lime juice, evaporated milk", "****", "2" };
            string[] row3 = new string[] { "Orange-Salsa Pork Chops", "Main Dish",
        "pork chops, salsa, orange juice", "****", "3" };
            string[] row4 = new string[] { "Black Bean and Rice Salad", "Salad",
        "black beans, brown rice", "****", "4" };
            string[] row5 = new string[] { "Chocolate Cheesecake", "Dessert",
        "cream cheese", "***", "5"};
            string[] row6 = new string[] { "Black Bean Dip", "Appetizer",
        "black beans, sour cream", "***", "6"};
            object[] rows = new object[] { row1, row2, row3, row4, row5, row6 };

            foreach (string[] rowArray in rows)
            {
                dataGridView1.Rows.Add(rowArray);
            }
        }

        private Tuple<int, int, int, int> getNumberPercent_info(string _dept_)
        {
            int standard_exc = 0;
            int standard_met = 0;
            int standard_nea = 0;
            int standard_not = 0;

            try
            {

                using (SqlConnection con = new SqlConnection(cs))
                {
                    DateTime from_ = DateTime.Parse("2/1/2021");
                    DateTime to_ = DateTime.Parse("2/22/2021");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("dbo.[proc_2021_01_18_ExceedorNotbyROW_2]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@needby_con", _dept_);
                    cmd.Parameters.AddWithValue("@from", from_);
                    cmd.Parameters.AddWithValue("@to", to_);
                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapt.Fill(dt);
                    if (dt != null)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            standard_exc = Convert.ToInt32(dr["Exceeded"]);
                            standard_met = Convert.ToInt32(dr["Met"]);
                            standard_nea = Convert.ToInt32(dr["NearlyMet"]);
                            standard_not = Convert.ToInt32(dr["NotMet"]);
                        }
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("The connection has been lost");
            }

            return Tuple.Create(standard_exc, standard_met, standard_nea, standard_not);
        }
        decimal summary_ = 0;
        decimal exceed, met, near, notmet, sum_exc_met;


        int test;
        private void button1_Click_1(object sender, EventArgs e)
        {
            test = 1;


            //double h = panel1.Height / 2.2;

            //int x = Convert.ToInt32(w);
            //int y = Convert.ToInt32(h);

            //label1.Text = x.ToString();
            //label2.Text = y.ToString();


            //foreach (var process in Process.GetProcessesByName("SCPMToolManagement"))
            //{
            //    process.Kill();
            //}
        }

        private void TinhTong()
        {
            var tuple = getNumberPercent_info(_DeptChart);

            exceed = tuple.Item1;
            met = tuple.Item2;
            near = tuple.Item3;
            notmet = tuple.Item4;

            //Percent
            sum_exc_met = exceed + met + near + notmet;
            var per_exceed = (exceed / sum_exc_met) * 100;
            var per_met = (met / sum_exc_met) * 100;
            summary_ = Math.Truncate((per_exceed + per_met) * 100) / 100;
            //summary_ = Math.Truncate(per_exceed + per_met);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TinhTong();
            //label1.Text = exceed.ToString();
            //label2.Text = met.ToString();
            //label3.Text = sum_exc_met.ToString();
            //label4.Text = summary_.ToString();

        }
        private void chart_Mill_PrePaint(object sender, ChartPaintEventArgs e)
        {
            if (e.ChartElement is ChartArea)
            {
                TinhTong();
                var ta = new TextAnnotation();
                ta.Text = summary_.ToString() + "%\r\nOntime Delivery";
                ta.Width = e.Position.Width;
                ta.Height = e.Position.Height;
                ta.X = e.Position.X;
                ta.Y = e.Position.Y;
                ta.Font = new Font("Ms Sans Serif", 12, FontStyle.Bold);
                ta.ForeColor = Color.Black;
                chart_Mill.Annotations.Add(ta);
            }
        }



        private void PanelCreator_forChart()
        {
            int lop1 = 1;
            int lop2 = 0;
            int lop3 = 1;
            int lop4 = 1;

            Panel p = addpanel_forChart();
            flowLayoutPanel1.Controls.Add(p);

            Chart _char = new Chart();
            _char.Location = new Point(10, 10);

            _char.Width = 600;
            _char.Height = 450;

            _char.BackColor = Color.Transparent;

            _char.ResetAutoValues();
            _char.Name = "chartArea1";
            _char.ChartAreas.Add("chartArea1");

            Series s1 = new Series("metric");
            s1.Points.AddXY("Exceeded", lop1);
            s1.Points.AddXY("Met", lop2);
            s1.Points.AddXY("NearlyMet", lop3);
            s1.Points.AddXY("NotMet", lop4);
            _char.Series.Add(s1);


            FontFamily family = new FontFamily("Times New Roman");
            _char.Series["metric"].ChartType = SeriesChartType.Doughnut;
            _char.ChartAreas["chartArea1"].Area3DStyle.Enable3D = false;
            _char.ChartAreas["chartArea1"].BackColor = Color.Honeydew;
            //_char.ChartAreas["chartArea1"].Area3DStyle.Inclination = 10;

            // _char.Series["metric"]["PieLabelStyle"] = "Disabled";
            _char.Series["metric"]["PieLabelStyle"] = "Outside";
            _char.Series["metric"].Font = new Font(family, 15, FontStyle.Regular);

            _char.Series["metric"].Label = "#VALX #PERCENT{P2}"; //Lay 2 chu so thap phan
            _char.Series["metric"]["DoughnutRadius"] = "40";
            _char.Series["metric"]["PieStartAngle"] = "300";
            _char.Series["metric"].LabelForeColor = Color.Black;


            _char.Titles.Add("My Chart").Font = new Font(family, 15, FontStyle.Regular);

            // Create a new legend called "Legend2".
            Legend leg = new Legend("Legend2");
            //_char.Legends.Add(new Legend("Legend2"));
            leg.Font = new Font(family, 15, FontStyle.Regular);
            leg.BackColor = Color.Transparent;
            leg.ForeColor = Color.Blue;
            _char.Legends.Add(leg);
            _char.Series["metric"].Legend = "Legend2";
            _char.Series["metric"].IsVisibleInLegend = true;



            decimal exceed_euro = Convert.ToDecimal(lop1);
            decimal met_euro = Convert.ToDecimal(lop2);
            decimal near_euro = Convert.ToDecimal(lop3);
            decimal notmet_euro = Convert.ToDecimal(lop4);

            decimal sum_exc_met_euro = exceed_euro + met_euro + near_euro + notmet_euro;
            var euro = (exceed_euro / sum_exc_met_euro) * 100;
            var euro_ = (met_euro / sum_exc_met_euro) * 100;
            //summary_euro = Math.Truncate((euro + euro_) * 100) / 100; //Truncate lam tron ve 0, Floor <, Ceiling >, Round ga`n nhat
            decimal summary_euro = Math.Round((euro + euro_) * 100) / 100;

            _char.Series["metric"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;

            p.Controls.Add(_char);
        }

        Panel addpanel_forChart()
        {
            Panel p = new Panel();
            p.Name = "panel";
            p.ForeColor = Color.Black;
            p.BackColor = Color.Honeydew;
            p.Width = 700;
            p.Height = 512;
            p.Margin = new Padding(10);
            p.Anchor = (AnchorStyles.Top);
            return p;
        }

        int chb_CopyTape_a = 0;

        private void chb_CopyTapeDetail_All_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_CopyTapeDetail_All.Checked == true)
            {
                chb_CopyTape_a = 1; label3.Text = chb_CopyTape_a.ToString();
                chb_CopyTapeDetail_1.Checked = true;
                chb_CopyTapeDetail_2.Checked = true;
                chb_CopyTapeDetail_3.Checked = true;

                chb_CopyTapeDetail_1.Enabled = false;
                chb_CopyTapeDetail_2.Enabled = false;
                chb_CopyTapeDetail_3.Enabled = false;

            }
            else
            {
                chb_CopyTape_a = 0; label3.Text = chb_CopyTape_a.ToString();
                chb_CopyTapeDetail_1.Checked = false;
                chb_CopyTapeDetail_2.Checked = false;
                chb_CopyTapeDetail_3.Checked = false;

                chb_CopyTapeDetail_1.Enabled = true;
                chb_CopyTapeDetail_2.Enabled = true;
                chb_CopyTapeDetail_3.Enabled = true;
            }

        }
        private void chb_CopyTapeDetail_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_CopyTapeDetail_All.Checked == false)
            {
                if (chb_CopyTapeDetail_1.Checked == true && chb_CopyTapeDetail_2.Checked == true && chb_CopyTapeDetail_3.Checked == false) //2
                { chb_CopyTape_a = 2; label3.Text = chb_CopyTape_a.ToString(); }

                else if (chb_CopyTapeDetail_1.Checked == true && chb_CopyTapeDetail_2.Checked == false && chb_CopyTapeDetail_3.Checked == true) //3
                { chb_CopyTape_a = 3; label3.Text = chb_CopyTape_a.ToString(); }

                else if (chb_CopyTapeDetail_1.Checked == false && chb_CopyTapeDetail_2.Checked == true && chb_CopyTapeDetail_3.Checked == true) //4
                { chb_CopyTape_a = 4; label3.Text = chb_CopyTape_a.ToString(); }

                else if (chb_CopyTapeDetail_1.Checked == true && chb_CopyTapeDetail_2.Checked == false && chb_CopyTapeDetail_3.Checked == false) //5
                { chb_CopyTape_a = 5; label3.Text = chb_CopyTape_a.ToString(); }

                else if (chb_CopyTapeDetail_1.Checked == false && chb_CopyTapeDetail_2.Checked == true && chb_CopyTapeDetail_3.Checked == false) //6
                { chb_CopyTape_a = 6; label3.Text = chb_CopyTape_a.ToString(); }

                else if (chb_CopyTapeDetail_1.Checked == false && chb_CopyTapeDetail_2.Checked == false && chb_CopyTapeDetail_3.Checked == true) //7
                { chb_CopyTape_a = 7; label3.Text = chb_CopyTape_a.ToString(); }

                else
                {
                    chb_CopyTape_a = 0; label3.Text = chb_CopyTape_a.ToString();
                }
            }


        }



        private void btnPart1_Click(object sender, EventArgs e)
        {
            strPath = @"\\SCPFS01\database\Paperworks\TapePictures\T17856.JPG";
            ShowImage(strPath);
            strPath = "";
        }



        int _stop = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            Label lbltest = new Label();
            lbltest.Location = new Point(300,150);
            lbltest.Size = new Size(200,200);
            lbltest.Name = "long1";

                        
            System.Drawing.Graphics graphics = this.CreateGraphics();
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(100, 100, 200, 200);
            graphics.DrawEllipse(System.Drawing.Pens.Black, rectangle);

            if (_stop == 1)
            {
                SoftBlink(lbltest, Color.DarkOrange, Color.Honeydew, 2000, false);
                SoftBlink(lbltest, Color.DarkOrange, Color.Honeydew, 2000, true);
                lbltest.Visible = true;
                lbltest.BringToFront();
            }
            
           
            panel1.Controls.Add(lbltest);

            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, 50, 50);

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            lbltest.Region = new Region(path);
            lbltest.BringToFront();



        }


        /*
         * private void btn_Click(object sender, EventArgs e)
           {
               panel1.Controls.Clear(); //to remove all controls
           
           
               //to remove all comboboxes
               foreach (Control item in panel1.Controls.OfType<ComboBox>())
               {
                   panel1.Controls.Remove(item); 
               }
           
           
              //to remove control by Name
               foreach (Control item in panel1.Controls.OfType<Control>())
               {
                   if (item.Name == "bloodyControl")
                       panel1.Controls.Remove(item); 
               }
           
           
               //to remove just one control, no Linq
               foreach (Control item in panel1.Controls)
               {
                   if (item.Name == "bloodyControl")
                   {
                        panel1.Controls.Remove(item);
                        break; //important step
                   }
               }
           }
         */
        private void button4_Click(object sender, EventArgs e)
        {
            sw.Reset();
            _stop = 0;
            //1. Tao 1 List control
            List<Control> listControls = new List<Control>();

            //2. Add tat ca cac items trong flowPanel vao List control moi tao o tren
            foreach (Control control in panel1.Controls)
            {
                listControls.Add(control);
            }

            //3. Sau do remove item long
            foreach (Control item in panel1.Controls.OfType<Control>())
            {
                if (item.Name == "long1")
                    panel1.Controls.Remove(item);
            }


            //4. Add lai
            button2_Click(this, new EventArgs());
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _stop = 1;
            //1. Tao 1 List control
            List<Control> listControls = new List<Control>();

            //2. Add tat ca cac items trong flowPanel vao List control moi tao o tren
            foreach (Control control in panel1.Controls)
            {
                listControls.Add(control);
            }

            //3. Sau do remove item long
            foreach (Control item in panel1.Controls.OfType<Control>())
            {
                if (item.Name == "long1")
                    panel1.Controls.Remove(item);
            }


            //4. Add lai
            button2_Click(this, new EventArgs());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm = new Form1();
            frm.Show();

            MessageBox.Show(test.ToString());
        }

        private void btnPart2_Click(object sender, EventArgs e)
        {
            strPath = @"\\SCPFS01\database\Paperworks\TapePictures\T17897.JPG";
            ShowImage(strPath);
            strPath = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("proc_2021_03_03_ShowTapeDetail_1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tapename", "T18225");
            cmd.Parameters.AddWithValue("@_s_", 1);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapt.Fill(dt);
            con.Open();
            //Hide_column_schedule();
            dataGridView1.DataSource = dt.DefaultView;
            con.Close();
            this.dataGridView1.AllowDrop = true;
        }

        
        

        string strPath;

        private void ShowImage(string path)
        {
            //// open file dialog   
            //OpenFileDialog open = new OpenFileDialog();
            //// image filters  
            //open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";

            //if (open.ShowDialog() == DialogResult.OK)
            //{
            //    // display image in picture box  
            //    pictureBox1.Image = new Bitmap(open.FileName);
            //    // image file path  
            //    textBox1.Text = open.FileName;
            //}

            //string strPath = @"\\SCPFS01\database\Paperworks\TapePictures\T17856.PNG";

            System.Drawing.Image img = System.Drawing.Image.FromFile(path);

            pictureBox1.Image = new Bitmap(img);

        }

       
     

       

        private static Stopwatch sw { get; set; }

        private async void SoftBlink(Control ctrl, Color c1, Color c2, short CycleTime_ms, bool BkClr)
        {

            sw = new Stopwatch();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            sw.Start();
            short halfCycle = (short)Math.Round(CycleTime_ms * 0.5); //Default: CycleTime_ms * 0.5

            while (true)
            {
                await Task.Delay(1);//Default: 1

                var n = sw.ElapsedMilliseconds % CycleTime_ms;
                var per = (double)Math.Abs(n - halfCycle) / halfCycle;
                var red = (short)Math.Round((c2.R - c1.R) * per) + c1.R;
                var grn = (short)Math.Round((c2.G - c1.G) * per) + c1.G;
                var blw = (short)Math.Round((c2.B - c1.B) * per) + c1.B;
                var clr = Color.FromArgb(red, grn, blw);

                if (BkClr) ctrl.BackColor = clr; else ctrl.ForeColor = clr;
            }
        }



        private void btnSortUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to submit this Request?", "SUBMIT BOX", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {//Add tung dong du lieu vao
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd1 = new SqlCommand("[proc_2021_03_29_TapeDetail_Sort_1]", con);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    if (row.IsNewRow) continue;
                    cmd1.Parameters.AddWithValue("@tapeName", "T18225");
                    cmd1.Parameters.AddWithValue("@option", 1);
                    cmd1.Parameters.AddWithValue("@order", row.Cells[0].Value ?? DBNull.Value);
                    cmd1.Parameters.AddWithValue("@user", "Long");
                    cmd1.Parameters.AddWithValue("@new_order", row.Index + 1);
                    con.Open();
                    cmd1.ExecuteNonQuery();
                    con.Close();
                }
                Convert_Replace_From_1();


            }
        }

        private Rectangle dragBoxFromMouseDown;

        private int rowIndexFrom;

        private int rowIndexTo;

        //Hien so thu tu
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void Convert_Replace_From_1()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd1 = new SqlCommand("[proc_2021_03_29_TapeDetail_Sort_Replace_1]", con);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@tapeName", "T18225");
            cmd1.Parameters.AddWithValue("@option", 1);
            cmd1.Parameters.AddWithValue("@user", "Long");
            con.Open();
            cmd1.ExecuteNonQuery();
            con.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!textBox2.Text.Contains("Bullpen") 
                && !textBox2.Text.Contains("bullpen"))
            {
                Console.WriteLine("Khong Chua");
            }
            else 
                Console.WriteLine("Co Chua");
        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)

        {

            Point clientPoint = this.dataGridView1.PointToClient(new Point(e.X, e.Y));

            rowIndexTo = this.dataGridView1.HitTest(clientPoint.X, clientPoint.Y).RowIndex;



            if (rowIndexTo > -1)

            {

                if (e.Effect == DragDropEffects.Move)

                {

                    DataView dv = this.dataGridView1.DataSource as DataView;



                    object[] objs = dv[rowIndexFrom].Row.ItemArray;



                    if (rowIndexFrom > rowIndexTo)

                    {

                        for (int j = rowIndexFrom; j > rowIndexTo; j--)

                        {

                            dv[j].Row.ItemArray = dv[j - 1].Row.ItemArray;

                        }

                        dv[rowIndexTo].Row.ItemArray = objs;

                    }

                    if (rowIndexFrom < rowIndexTo)

                    {

                        for (int j = rowIndexFrom; j < rowIndexTo; j++)

                        {

                            dv[j].Row.ItemArray = dv[j + 1].Row.ItemArray;

                        }

                        dv[rowIndexTo].Row.ItemArray = objs;

                    }

                }

            }

        }



        private void dataGridView1_DragOver(object sender, DragEventArgs e)

        {

            e.Effect = DragDropEffects.Move;

        }



        void dataGridView1_MouseMove(object sender, MouseEventArgs e)

        {

            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)

            {

                // If the mouse moves outside the rectangle, start the drag.

                if (dragBoxFromMouseDown != Rectangle.Empty &&

                    !dragBoxFromMouseDown.Contains(e.X, e.Y))

                {

                    DataView dv = this.dataGridView1.DataSource as DataView;

                    DataRow dr = dv[this.rowIndexFrom].Row;

                    // Proceed with the drag and drop, passing in the list item.

                    DragDropEffects dropEffect = this.dataGridView1.DoDragDrop(

                    dr,

                    DragDropEffects.Move);

                }

            }

        }



        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)

        {

            rowIndexFrom = this.dataGridView1.HitTest(e.X, e.Y).RowIndex;

            if (rowIndexFrom != -1)

            {

                Size dragSize = SystemInformation.DragSize;

                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),

                    e.Y - (dragSize.Height / 2)),

                    dragSize);

            }

            else

                dragBoxFromMouseDown = Rectangle.Empty;

        }

    }
}


