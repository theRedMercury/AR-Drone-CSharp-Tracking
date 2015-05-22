using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ChartDirector;
using System.Threading;

namespace A.R.Drone.Main.UIClass
{
    public partial class Win3DPlot : Form
    {
        private WinChartViewer wChart;
        private MainWin win;
        private Thread updateWin;
        private bool runningTh;

        public Win3DPlot(double[] xData, double[] yData, double[] zData, MainWin w)
        {
            this.win = w;
            this.updateWin = new Thread(new ThreadStart(run));
            this.updateWin.Name = "WinPlot";
            this.runningTh = true;
            InitializeComponent();
            this.wChart = new WinChartViewer();
            this.wChart.Location = new System.Drawing.Point(0, 0);
            this.wChart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            //this.wChart.Size = new System.Drawing.Size(330, 300);
            this.Controls.Add(this.wChart);

            // The XYZ data for the 3D scatter chart as 3 random data series
            RanSeries r = new RanSeries(0);

           /*double[] xData = x;
            double[] yData = y;
            double[] zData =z;*/
            /*
            double[] xData = {0,0,0,0,0,1,2,3,5};//r.getSeries2(100, 100, -10, 10);
            double[] yData = {0,1,2,2,2.3,3,5,6,5};//r.getSeries2(100, 0, 0, 20);
            double[] zData = { 0, 3, 3, 3, 4, 4, 3, 3, 5 };//r.getSeries2(100, 100, -10, 10);
            */
            // Create a ThreeDScatterChart object of size 720 x 600 pixels
            ThreeDScatterChart c = new ThreeDScatterChart(720, 600);

            ThreeDScatterGroup g = c.addScatterGroup(xData, yData, zData, "",
                                    Chart.GlassSphere2Shape, 10, Chart.SameAsMainColor);
            g.setDropLine(0x888888);

            
            c.addTitle("3D Scatter Chart (1)  ", "Times New Roman Italic", 20);
            c.setPlotRegion(350, 280, 360, 360, 270);
           
            c.setColorAxis(645, 270, Chart.Left, 200, Chart.Right);

            c.xAxis().setTitle("X-Axis Place Holder", "Arial Bold", 10);
            c.yAxis().setTitle("Y-Axis Place Holder", "Arial Bold", 10);
            c.zAxis().setTitle("Z-Axis Place Holder", "Arial Bold", 10);

            this.wChart.Chart = c;

   
            this.wChart.ImageMap = c.getHTMLImageMap("clickable", "",
                "title='(x={x|p}, y={y|p}, z={z|p}'");
            this.updateWin.Start();
        }

        public void run()
        {
            while (this.runningTh)
            {
                ThreeDScatterChart c = new ThreeDScatterChart(720, 600);
                ThreeDScatterGroup g = c.addScatterGroup(this.win.XPlot, this.win.YPlot, this.win.ZPlot, "",
                                       Chart.GlassSphere2Shape, 10, Chart.SameAsMainColor);
                g.setDropLine(0x888888);
                if (this.wChart.InvokeRequired)
                {
                    this.wChart.Invoke(new MethodInvoker(delegate
                    {
                        this.wChart.Chart = c;
                    }));
                }
                Thread.Sleep(500);
            }
        }

       
        private void Win3DPlot_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.runningTh = false;
            this.updateWin.Abort();
            this.wChart = null;
            this.Parent = null;
            this.Dispose();
            GC.Collect();
        }
    }
}
