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
    public partial class GraphHistory : Form
    {
        private WinChartViewer wChart;
        private MainWin win;
        private Thread updateWin;
        private bool runningTh;
        private LineLayer layer;
        private ManualResetEvent mResEvent = new ManualResetEvent(true); 

        public GraphHistory(double[] dat0, double[] dat1, double[] dat2, MainWin w)
        {
            this.win = w;
            this.updateWin = new Thread(new ThreadStart(run));
            this.updateWin.Name = "WinData";
            this.runningTh = true;
            InitializeComponent();

            this.wChart = new WinChartViewer();
            this.wChart.Location = new System.Drawing.Point(0, 0);
            this.wChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.wChart.MouseMovePlotArea += new MouseEventHandler(this.winChartViewer1_MouseMovePlotArea);
            //this.wChart.Size = new System.Drawing.Size(330, 300);
            this.Controls.Add(this.wChart);

            // Data for the chart as 3 random data series
            RanSeries r = new RanSeries(127);
            double[] data0 = dat0;
            double[] data1 = dat1;
            double[] data2 = dat2;
            //DateTime[] timeStamps = r.getDateSeries(100, new DateTime(2011, 1, 1), 86400);
            double[] timeStamps = new double[data0.Length];
            for (int i = 0; i < data0.Length; i++)
            {
                timeStamps[i] = i;
            }
            //double[] timeStamps = { 0, 1, 2, 3, 4, 5, 6, 7 };

            // Create a XYChart object of size 640 x 400 pixels
            XYChart c = new XYChart(640, 700);
           
            
            c.setPlotArea(50, 55, c.getWidth() - 70, c.getHeight() - 90, -1);
            c.addLegend(50, 25, false, "Arial Bold", 10).setBackground(Chart.Transparent);
            c.xAxis().setLabelStyle("Arial Bold", 8);
            c.yAxis().setLabelStyle("Arial Bold", 8);
            c.xAxis().setColors(Chart.Transparent);
            c.yAxis().setColors(Chart.Transparent);
            c.yAxis().setTitle("HUD data [°]", "Arial Bold Italic", 10);

            layer = c.addLineLayer2();
            layer.setLineWidth(2);

            // Add 3 data series to the line layer
            layer.setXData(timeStamps);
            layer.addDataSet(data0, 0xff3333, "Yaw");
            layer.addDataSet(data1, 0x008800, "Pitch");
            layer.addDataSet(data2, 0x3333cc, "Roll");

            // Assign the chart to the WinChartViewer
            wChart.Chart = c;

            this.updateWin.Start();
        }

        public void run()
        {
            while (this.runningTh)
            {
                this.mResEvent.WaitOne();
                XYChart c = new XYChart(1300, 700);
                c.setPlotArea(50, 55, c.getWidth() - 70, c.getHeight() - 90, -1);
                c.addLegend(50, 25, false, "Arial Bold", 10).setBackground(Chart.Transparent);
                c.xAxis().setLabelStyle("Arial Bold", 8);
                c.yAxis().setLabelStyle("Arial Bold", 8);
                c.xAxis().setColors(Chart.Transparent);
                c.yAxis().setColors(Chart.Transparent);
                c.yAxis().setTitle("HUD data [°]", "Arial Bold Italic", 10);

                layer = c.addLineLayer2();
                // Assign the chart to the WinChartViewer
           
                if (this.wChart.InvokeRequired)
                {
                    this.wChart.Invoke(new MethodInvoker(delegate
                    {
                       
                        // Add 3 data series to the line layer
                        layer.addDataSet(this.win.HeadDat, 0xff3333, "Yaw");
                        layer.addDataSet(this.win.PitchDat, 0x008800, "Pitch");
                        layer.addDataSet(this.win.RollDat, 0x3333cc, "Roll");
                        double[] timeStamps = new double[this.win.HeadDat.Length];
                        for (int i = 0; i < this.win.HeadDat.Length -1; i++)
                        {
                            timeStamps[i] = i;
                        }
                        layer.setXData(timeStamps);
                        wChart.Chart = c;
                    }));
                }
                Thread.Sleep(500);
            }
        }

        private void winChartViewer1_MouseMovePlotArea(object sender, MouseEventArgs e)
        {
            WinChartViewer viewer = (WinChartViewer)sender;
            trackLineLabel((XYChart)viewer.Chart, viewer.PlotAreaMouseX);
            viewer.updateDisplay();

            // Hide the track cursor when the mouse leaves the plot area
            viewer.removeDynamicLayer("MouseLeavePlotArea");
        }

        private void trackLineLabel(XYChart c, int mouseX)
        {
            // Clear the current dynamic layer and get the DrawArea object to draw on it.
            DrawArea d = c.initDynamicLayer();

            // The plot area object
            PlotArea plotArea = c.getPlotArea();

            // Get the data x-value that is nearest to the mouse, and find its pixel coordinate.
            double xValue = c.getNearestXValue(mouseX);
            int xCoor = c.getXCoor(xValue);

            // Draw a vertical track line at the x-position
            d.vline(plotArea.getTopY(), plotArea.getBottomY(), xCoor, d.dashLineColor(0x000000, 0x0101));

            // Draw a label on the x-axis to show the track line position.
            string xlabel = "<*font,bgColor=000000*> " + c.xAxis().getFormattedLabel(xValue) +
                " <*/font*>";
            TTFText t = d.text(xlabel, "Arial Bold", 8);

            // Restrict the x-pixel position of the label to make sure it stays inside the chart image.
            int xLabelPos = Math.Max(0, Math.Min(xCoor - t.getWidth() / 2, c.getWidth() - t.getWidth()));
            t.draw(xLabelPos, plotArea.getBottomY() + 6, 0xffffff);

            // Iterate through all layers to draw the data labels
            for (int i = 0; i < c.getLayerCount(); ++i)
            {
                Layer layer = c.getLayerByZ(i);

                // The data array index of the x-value
                int xIndex = layer.getXIndexOf(xValue);

                // Iterate through all the data sets in the layer
                for (int j = 0; j < layer.getDataSetCount(); ++j)
                {
                    ChartDirector.DataSet dataSet = layer.getDataSetByZ(j);

                    // Get the color and position of the data label
                    int color = dataSet.getDataColor();
                    int yCoor = c.getYCoor(dataSet.getPosition(xIndex), dataSet.getUseYAxis());

                    // Draw a track dot with a label next to it for visible data points in the plot area
                    if ((yCoor >= plotArea.getTopY()) && (yCoor <= plotArea.getBottomY()) && (color !=
                        Chart.Transparent))
                    {

                        d.circle(xCoor, yCoor, 4, 4, color, color);

                        string label = "<*font,bgColor=" + color.ToString("x") + "*> " + c.formatValue(
                            dataSet.getValue(xIndex), "{value|P4}") + " <*/font*>";
                        t = d.text(label, "Arial Bold", 8);

                        // Draw the label on the right side of the dot if the mouse is on the left side the
                        // chart, and vice versa. This ensures the label will not go outside the chart image.
                        if (xCoor <= (plotArea.getLeftX() + plotArea.getRightX()) / 2)
                        {
                            t.draw(xCoor + 5, yCoor, 0xffffff, Chart.Left);
                        }
                        else
                        {
                            t.draw(xCoor - 5, yCoor, 0xffffff, Chart.Right);
                        }
                    }
                }
            }
        }


        private void Win3DPlot_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.runningTh = false;
            this.updateWin.Abort();
            this.layer = null;
            this.wChart = null;
            this.Parent = null;
            this.Dispose();
            GC.Collect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.button1.Text == "Pause")
            {
                this.mResEvent.Reset();
                this.button1.Text = "Resume";
            }
            else
            {
                this.button1.Text = "Pause";
                this.mResEvent.Set();
            }
        }
    }
}
