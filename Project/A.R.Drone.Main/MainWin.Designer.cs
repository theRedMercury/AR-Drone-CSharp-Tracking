using System.Windows.Forms;
namespace A.R.Drone.Main
{
    partial class MainWin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        //private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWin));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectDroneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetTrimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetEmergencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.picColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.joystickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grapHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dPlotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oculusRiftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calibrateJoystickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.joystickControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.howToRunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statutBar = new System.Windows.Forms.StatusStrip();
            this.statutConnect = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripWifiName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripWifiLenght = new System.Windows.Forms.ToolStripProgressBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.picVideoImg = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.shapeContainer2 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.ovalShapAirMin = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.ovalShapAirActu = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.ovalShapAirMax = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.labAireMax = new System.Windows.Forms.Label();
            this.labAireMin = new System.Windows.Forms.Label();
            this.labAireActu = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.hScrollAirMax = new System.Windows.Forms.HScrollBar();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.hScrollAirMin = new System.Windows.Forms.HScrollBar();
            this.label6 = new System.Windows.Forms.Label();
            this.ScrollBarRectRange = new System.Windows.Forms.HScrollBar();
            this.checkHistoEqual = new System.Windows.Forms.CheckBox();
            this.labRad = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelColor = new System.Windows.Forms.Panel();
            this.tvInfo = new System.Windows.Forms.TreeView();
            this.trackBarRadius = new System.Windows.Forms.TrackBar();
            this.consolDataDrone = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.labJoyInfo = new System.Windows.Forms.Label();
            this.panelManualControl = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.butAltiUp = new System.Windows.Forms.Button();
            this.butLeft = new System.Windows.Forms.Button();
            this.butAltiDown = new System.Windows.Forms.Button();
            this.butForward = new System.Windows.Forms.Button();
            this.butRollRight = new System.Windows.Forms.Button();
            this.butRight = new System.Windows.Forms.Button();
            this.butRollLeft = new System.Windows.Forms.Button();
            this.butBack = new System.Windows.Forms.Button();
            this.butMid = new System.Windows.Forms.Button();
            this.panelMainDataControl = new System.Windows.Forms.Panel();
            this.labDataCorrect = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelDataControlDebug = new System.Windows.Forms.Panel();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.shapeGaz = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.shapeYawPitch = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.butTracking = new System.Windows.Forms.Button();
            this.butTrack = new System.Windows.Forms.Button();
            this.butLand = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.butMasterEmergency = new System.Windows.Forms.Button();
            this.butMasterTakeOff = new System.Windows.Forms.Button();
            this.panelEngine = new System.Windows.Forms.Panel();
            this.engineLevel1 = new UI.LedControl.EngineLevel();
            this.engineLevel4 = new UI.LedControl.EngineLevel();
            this.engineLevel2 = new UI.LedControl.EngineLevel();
            this.engineLevel3 = new UI.LedControl.EngineLevel();
            this.ledTracking = new UI.LedControl.LedControl();
            this.batLevel1 = new UI.LedControl.BatLevel();
            this.ledLand = new UI.LedControl.LedControl();
            this.ledFly = new UI.LedControl.LedControl();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            this.statutBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVideoImg)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRadius)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelManualControl.SuspendLayout();
            this.panelMainDataControl.SuspendLayout();
            this.panelDataControlDebug.SuspendLayout();
            this.panelEngine.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1276, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectDroneToolStripMenuItem,
            this.resetTrimToolStripMenuItem,
            this.resetEmergencyToolStripMenuItem,
            this.toolStripSeparator1,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.fileToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Red;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(40, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // connectDroneToolStripMenuItem
            // 
            this.connectDroneToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.connectDroneToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.connectDroneToolStripMenuItem.Image = global::A.R.Drone.Main.Properties.Resources.ok;
            this.connectDroneToolStripMenuItem.Name = "connectDroneToolStripMenuItem";
            this.connectDroneToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.connectDroneToolStripMenuItem.Text = "Connect Drone";
            this.connectDroneToolStripMenuItem.Click += new System.EventHandler(this.connectDroneToolStripMenuItem_Click);
            // 
            // resetTrimToolStripMenuItem
            // 
            this.resetTrimToolStripMenuItem.Image = global::A.R.Drone.Main.Properties.Resources.flat;
            this.resetTrimToolStripMenuItem.Name = "resetTrimToolStripMenuItem";
            this.resetTrimToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.resetTrimToolStripMenuItem.Text = "Flat Trim";
            this.resetTrimToolStripMenuItem.Click += new System.EventHandler(this.resetTrimToolStripMenuItem_Click);
            // 
            // resetEmergencyToolStripMenuItem
            // 
            this.resetEmergencyToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.resetEmergencyToolStripMenuItem.Image = global::A.R.Drone.Main.Properties.Resources.emergency;
            this.resetEmergencyToolStripMenuItem.Name = "resetEmergencyToolStripMenuItem";
            this.resetEmergencyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.resetEmergencyToolStripMenuItem.Text = "Reset Emergency";
            this.resetEmergencyToolStripMenuItem.Click += new System.EventHandler(this.resetEmergencyToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.quitToolStripMenuItem.Image = global::A.R.Drone.Main.Properties.Resources.shutdown;
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.quitToolStripMenuItem.Text = "Exit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.picColorToolStripMenuItem,
            this.joystickToolStripMenuItem,
            this.manualCommandToolStripMenuItem,
            this.grapHistoryToolStripMenuItem,
            this.dPlotToolStripMenuItem,
            this.fullScreenToolStripMenuItem,
            this.oculusRiftToolStripMenuItem});
            this.toolsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(52, 21);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // picColorToolStripMenuItem
            // 
            this.picColorToolStripMenuItem.Image = global::A.R.Drone.Main.Properties.Resources.picCol;
            this.picColorToolStripMenuItem.Name = "picColorToolStripMenuItem";
            this.picColorToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.picColorToolStripMenuItem.Text = "Pic Color";
            this.picColorToolStripMenuItem.Click += new System.EventHandler(this.picColorToolStripMenuItem_Click_1);
            // 
            // joystickToolStripMenuItem
            // 
            this.joystickToolStripMenuItem.Image = global::A.R.Drone.Main.Properties.Resources.joy2;
            this.joystickToolStripMenuItem.Name = "joystickToolStripMenuItem";
            this.joystickToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.joystickToolStripMenuItem.Text = "Joystick";
            this.joystickToolStripMenuItem.Click += new System.EventHandler(this.joystickToolStripMenuItem_Click);
            // 
            // manualCommandToolStripMenuItem
            // 
            this.manualCommandToolStripMenuItem.Image = global::A.R.Drone.Main.Properties.Resources.manualC;
            this.manualCommandToolStripMenuItem.Name = "manualCommandToolStripMenuItem";
            this.manualCommandToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.manualCommandToolStripMenuItem.Text = "Manual Control";
            this.manualCommandToolStripMenuItem.Click += new System.EventHandler(this.manualCommandToolStripMenuItem_Click);
            // 
            // grapHistoryToolStripMenuItem
            // 
            this.grapHistoryToolStripMenuItem.Image = global::A.R.Drone.Main.Properties.Resources.grah1;
            this.grapHistoryToolStripMenuItem.Name = "grapHistoryToolStripMenuItem";
            this.grapHistoryToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.grapHistoryToolStripMenuItem.Text = "Grap History";
            this.grapHistoryToolStripMenuItem.Click += new System.EventHandler(this.grapHistoryToolStripMenuItem_Click);
            // 
            // dPlotToolStripMenuItem
            // 
            this.dPlotToolStripMenuItem.Name = "dPlotToolStripMenuItem";
            this.dPlotToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.dPlotToolStripMenuItem.Text = "3D Plot";
            this.dPlotToolStripMenuItem.Click += new System.EventHandler(this.dPlotToolStripMenuItem_Click);
            // 
            // fullScreenToolStripMenuItem
            // 
            this.fullScreenToolStripMenuItem.Image = global::A.R.Drone.Main.Properties.Resources.fullSc;
            this.fullScreenToolStripMenuItem.Name = "fullScreenToolStripMenuItem";
            this.fullScreenToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.fullScreenToolStripMenuItem.Text = "FullScreen";
            this.fullScreenToolStripMenuItem.Click += new System.EventHandler(this.fullScreenToolStripMenuItem_Click);
            // 
            // oculusRiftToolStripMenuItem
            // 
            this.oculusRiftToolStripMenuItem.Image = global::A.R.Drone.Main.Properties.Resources.oculus;
            this.oculusRiftToolStripMenuItem.Name = "oculusRiftToolStripMenuItem";
            this.oculusRiftToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.oculusRiftToolStripMenuItem.Text = "Oculus Rift";
            this.oculusRiftToolStripMenuItem.Click += new System.EventHandler(this.oculusRiftToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Checked = true;
            this.helpToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pDFToolStripMenuItem,
            this.calibrateJoystickToolStripMenuItem,
            this.joystickControlToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.howToRunToolStripMenuItem});
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(48, 21);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // pDFToolStripMenuItem
            // 
            this.pDFToolStripMenuItem.Image = global::A.R.Drone.Main.Properties.Resources.pdf1;
            this.pDFToolStripMenuItem.Name = "pDFToolStripMenuItem";
            this.pDFToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pDFToolStripMenuItem.Text = "PDF";
            this.pDFToolStripMenuItem.Click += new System.EventHandler(this.pDFToolStripMenuItem_Click);
            // 
            // calibrateJoystickToolStripMenuItem
            // 
            this.calibrateJoystickToolStripMenuItem.Image = global::A.R.Drone.Main.Properties.Resources.joy;
            this.calibrateJoystickToolStripMenuItem.Name = "calibrateJoystickToolStripMenuItem";
            this.calibrateJoystickToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.calibrateJoystickToolStripMenuItem.Text = "Calibrate Joystick";
            this.calibrateJoystickToolStripMenuItem.Click += new System.EventHandler(this.calibrateJoystickToolStripMenuItem_Click);
            // 
            // joystickControlToolStripMenuItem
            // 
            this.joystickControlToolStripMenuItem.Name = "joystickControlToolStripMenuItem";
            this.joystickControlToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.joystickControlToolStripMenuItem.Text = "Joystick Control";
            this.joystickControlToolStripMenuItem.Click += new System.EventHandler(this.joystickControlToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::A.R.Drone.Main.Properties.Resources.about;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // howToRunToolStripMenuItem
            // 
            this.howToRunToolStripMenuItem.Image = global::A.R.Drone.Main.Properties.Resources.about;
            this.howToRunToolStripMenuItem.Name = "howToRunToolStripMenuItem";
            this.howToRunToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.howToRunToolStripMenuItem.Text = "How to run ?";
            this.howToRunToolStripMenuItem.Click += new System.EventHandler(this.howToRunToolStripMenuItem_Click);
            // 
            // statutBar
            // 
            this.statutBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.statutBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statutConnect,
            this.toolStripStatusLabel2,
            this.toolStripWifiName,
            this.toolStripWifiLenght});
            this.statutBar.Location = new System.Drawing.Point(0, 670);
            this.statutBar.Name = "statutBar";
            this.statutBar.Size = new System.Drawing.Size(1276, 22);
            this.statutBar.TabIndex = 1;
            this.statutBar.Text = "statusStrip1";
            // 
            // statutConnect
            // 
            this.statutConnect.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statutConnect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.statutConnect.Name = "statutConnect";
            this.statutConnect.Size = new System.Drawing.Size(52, 17);
            this.statutConnect.Text = "Statut : ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Enabled = false;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(1070, 17);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // toolStripWifiName
            // 
            this.toolStripWifiName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.toolStripWifiName.Name = "toolStripWifiName";
            this.toolStripWifiName.Size = new System.Drawing.Size(37, 17);
            this.toolStripWifiName.Text = "Wifi : ";
            // 
            // toolStripWifiLenght
            // 
            this.toolStripWifiLenght.Name = "toolStripWifiLenght";
            this.toolStripWifiLenght.Size = new System.Drawing.Size(100, 16);
            this.toolStripWifiLenght.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.panelManualControl);
            this.splitContainer1.Panel2.Controls.Add(this.panelMainDataControl);
            this.splitContainer1.Size = new System.Drawing.Size(1276, 645);
            this.splitContainer1.SplitterDistance = 599;
            this.splitContainer1.TabIndex = 14;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackgroundImage = global::A.R.Drone.Main.Properties.Resources.grille;
            this.splitContainer2.Panel1.Controls.Add(this.picVideoImg);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panel2);
            this.splitContainer2.Size = new System.Drawing.Size(599, 645);
            this.splitContainer2.SplitterDistance = 350;
            this.splitContainer2.TabIndex = 0;
            // 
            // picVideoImg
            // 
            this.picVideoImg.BackgroundImage = global::A.R.Drone.Main.Properties.Resources.droneInit;
            this.picVideoImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picVideoImg.InitialImage = ((System.Drawing.Image)(resources.GetObject("picVideoImg.InitialImage")));
            this.picVideoImg.Location = new System.Drawing.Point(0, 0);
            this.picVideoImg.Name = "picVideoImg";
            this.picVideoImg.Size = new System.Drawing.Size(640, 360);
            this.picVideoImg.TabIndex = 0;
            this.picVideoImg.TabStop = false;
            this.picVideoImg.Click += new System.EventHandler(this.picVideoImg_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.labAireMax);
            this.panel2.Controls.Add(this.labAireMin);
            this.panel2.Controls.Add(this.labAireActu);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.hScrollAirMax);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.hScrollAirMin);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.ScrollBarRectRange);
            this.panel2.Controls.Add(this.checkHistoEqual);
            this.panel2.Controls.Add(this.labRad);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.panelColor);
            this.panel2.Controls.Add(this.tvInfo);
            this.panel2.Controls.Add(this.trackBarRadius);
            this.panel2.Controls.Add(this.consolDataDrone);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(599, 291);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Controls.Add(this.shapeContainer2);
            this.panel3.Location = new System.Drawing.Point(281, 138);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(140, 140);
            this.panel3.TabIndex = 36;
            // 
            // shapeContainer2
            // 
            this.shapeContainer2.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer2.Name = "shapeContainer2";
            this.shapeContainer2.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.ovalShapAirMin,
            this.ovalShapAirActu,
            this.ovalShapAirMax});
            this.shapeContainer2.Size = new System.Drawing.Size(140, 140);
            this.shapeContainer2.TabIndex = 0;
            this.shapeContainer2.TabStop = false;
            // 
            // ovalShapAirMin
            // 
            this.ovalShapAirMin.BackColor = System.Drawing.Color.Blue;
            this.ovalShapAirMin.FillColor = System.Drawing.Color.Blue;
            this.ovalShapAirMin.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Percent40;
            this.ovalShapAirMin.Location = new System.Drawing.Point(36, 36);
            this.ovalShapAirMin.Name = "ovalShapAirMin";
            this.ovalShapAirMin.Size = new System.Drawing.Size(68, 68);
            // 
            // ovalShapAirActu
            // 
            this.ovalShapAirActu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.ovalShapAirActu.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.ovalShapAirActu.Location = new System.Drawing.Point(20, 20);
            this.ovalShapAirActu.Name = "ovalShapAirActu";
            this.ovalShapAirActu.Size = new System.Drawing.Size(100, 100);
            // 
            // ovalShapAirMax
            // 
            this.ovalShapAirMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ovalShapAirMax.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.ovalShapAirMax.Location = new System.Drawing.Point(0, 0);
            this.ovalShapAirMax.Name = "ovalShapAirMax";
            this.ovalShapAirMax.Size = new System.Drawing.Size(140, 140);
            // 
            // labAireMax
            // 
            this.labAireMax.AutoSize = true;
            this.labAireMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labAireMax.ForeColor = System.Drawing.Color.Gold;
            this.labAireMax.Location = new System.Drawing.Point(236, 249);
            this.labAireMax.Name = "labAireMax";
            this.labAireMax.Size = new System.Drawing.Size(15, 16);
            this.labAireMax.TabIndex = 35;
            this.labAireMax.Text = "0";
            // 
            // labAireMin
            // 
            this.labAireMin.AutoSize = true;
            this.labAireMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labAireMin.ForeColor = System.Drawing.Color.Gold;
            this.labAireMin.Location = new System.Drawing.Point(236, 223);
            this.labAireMin.Name = "labAireMin";
            this.labAireMin.Size = new System.Drawing.Size(15, 16);
            this.labAireMin.TabIndex = 34;
            this.labAireMin.Text = "0";
            // 
            // labAireActu
            // 
            this.labAireActu.AutoSize = true;
            this.labAireActu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labAireActu.ForeColor = System.Drawing.Color.Gold;
            this.labAireActu.Location = new System.Drawing.Point(236, 202);
            this.labAireActu.Name = "labAireActu";
            this.labAireActu.Size = new System.Drawing.Size(15, 16);
            this.labAireActu.TabIndex = 33;
            this.labAireActu.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Gold;
            this.label10.Location = new System.Drawing.Point(124, 202);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 16);
            this.label10.TabIndex = 32;
            this.label10.Text = "Actual Detected :";
            // 
            // hScrollAirMax
            // 
            this.hScrollAirMax.Location = new System.Drawing.Point(51, 248);
            this.hScrollAirMax.Maximum = 27000;
            this.hScrollAirMax.Minimum = 7000;
            this.hScrollAirMax.Name = "hScrollAirMax";
            this.hScrollAirMax.Size = new System.Drawing.Size(182, 17);
            this.hScrollAirMax.TabIndex = 31;
            this.hScrollAirMax.Value = 8000;
            this.hScrollAirMax.ValueChanged += new System.EventHandler(this.hScrollAirMax_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Gold;
            this.label9.Location = new System.Drawing.Point(13, 248);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 16);
            this.label9.TabIndex = 30;
            this.label9.Text = "Max :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gold;
            this.label8.Location = new System.Drawing.Point(13, 222);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 16);
            this.label8.TabIndex = 29;
            this.label8.Text = "Min :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gold;
            this.label7.Location = new System.Drawing.Point(12, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 20);
            this.label7.TabIndex = 28;
            this.label7.Text = "Area :";
            // 
            // hScrollAirMin
            // 
            this.hScrollAirMin.Location = new System.Drawing.Point(51, 222);
            this.hScrollAirMin.Maximum = 26000;
            this.hScrollAirMin.Minimum = 6000;
            this.hScrollAirMin.Name = "hScrollAirMin";
            this.hScrollAirMin.Size = new System.Drawing.Size(182, 17);
            this.hScrollAirMin.TabIndex = 27;
            this.hScrollAirMin.Value = 7000;
            this.hScrollAirMin.ValueChanged += new System.EventHandler(this.hScrollAirMin_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gold;
            this.label6.Location = new System.Drawing.Point(12, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 20);
            this.label6.TabIndex = 26;
            this.label6.Text = "Rectangle detection :";
            // 
            // ScrollBarRectRange
            // 
            this.ScrollBarRectRange.Location = new System.Drawing.Point(16, 178);
            this.ScrollBarRectRange.Maximum = 40;
            this.ScrollBarRectRange.Minimum = 3;
            this.ScrollBarRectRange.Name = "ScrollBarRectRange";
            this.ScrollBarRectRange.Size = new System.Drawing.Size(217, 17);
            this.ScrollBarRectRange.TabIndex = 24;
            this.ScrollBarRectRange.Value = 10;
            this.ScrollBarRectRange.ValueChanged += new System.EventHandler(this.ScrollBarRectRange_ValueChanged);
            // 
            // checkHistoEqual
            // 
            this.checkHistoEqual.AutoSize = true;
            this.checkHistoEqual.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkHistoEqual.Checked = true;
            this.checkHistoEqual.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkHistoEqual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkHistoEqual.ForeColor = System.Drawing.Color.Gold;
            this.checkHistoEqual.Location = new System.Drawing.Point(12, 104);
            this.checkHistoEqual.Name = "checkHistoEqual";
            this.checkHistoEqual.Size = new System.Drawing.Size(165, 20);
            this.checkHistoEqual.TabIndex = 23;
            this.checkHistoEqual.Text = "Filtre Histogram Equal :";
            this.checkHistoEqual.UseVisualStyleBackColor = true;
            this.checkHistoEqual.Click += new System.EventHandler(this.checkHistoEqual_Click);
            // 
            // labRad
            // 
            this.labRad.AutoSize = true;
            this.labRad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labRad.ForeColor = System.Drawing.Color.Gold;
            this.labRad.Location = new System.Drawing.Point(8, 53);
            this.labRad.Name = "labRad";
            this.labRad.Size = new System.Drawing.Size(80, 20);
            this.labRad.TabIndex = 22;
            this.labRad.Text = "Radius : 0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(8, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Color :";
            // 
            // panelColor
            // 
            this.panelColor.BackColor = System.Drawing.Color.Red;
            this.panelColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelColor.Location = new System.Drawing.Point(68, 3);
            this.panelColor.Name = "panelColor";
            this.panelColor.Size = new System.Drawing.Size(34, 34);
            this.panelColor.TabIndex = 20;
            this.toolTip1.SetToolTip(this.panelColor, "Color to detect");
            this.panelColor.Click += new System.EventHandler(this.panel1_Click);
            // 
            // tvInfo
            // 
            this.tvInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.tvInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.tvInfo.Location = new System.Drawing.Point(427, 0);
            this.tvInfo.Name = "tvInfo";
            this.tvInfo.Size = new System.Drawing.Size(172, 291);
            this.tvInfo.TabIndex = 19;
            this.toolTip1.SetToolTip(this.tvInfo, "Data from drone");
            // 
            // trackBarRadius
            // 
            this.trackBarRadius.LargeChange = 1;
            this.trackBarRadius.Location = new System.Drawing.Point(12, 76);
            this.trackBarRadius.Maximum = 255;
            this.trackBarRadius.Name = "trackBarRadius";
            this.trackBarRadius.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBarRadius.Size = new System.Drawing.Size(167, 45);
            this.trackBarRadius.TabIndex = 11;
            this.trackBarRadius.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTip1.SetToolTip(this.trackBarRadius, "Range of detection");
            this.trackBarRadius.ValueChanged += new System.EventHandler(this.trackBarRadius_ValueChanged);
            // 
            // consolDataDrone
            // 
            this.consolDataDrone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.consolDataDrone.BackColor = System.Drawing.Color.Black;
            this.consolDataDrone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.consolDataDrone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consolDataDrone.ForeColor = System.Drawing.Color.Gold;
            this.consolDataDrone.Location = new System.Drawing.Point(185, 0);
            this.consolDataDrone.Name = "consolDataDrone";
            this.consolDataDrone.Size = new System.Drawing.Size(237, 121);
            this.consolDataDrone.TabIndex = 0;
            this.consolDataDrone.Text = ">...";
            this.toolTip1.SetToolTip(this.consolDataDrone, "Console");
            this.consolDataDrone.TextChanged += new System.EventHandler(this.consolDataDrone_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.labJoyInfo);
            this.panel1.Location = new System.Drawing.Point(372, 504);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(254, 115);
            this.panel1.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gold;
            this.label5.Location = new System.Drawing.Point(3, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "Joystick informations :";
            // 
            // labJoyInfo
            // 
            this.labJoyInfo.AutoSize = true;
            this.labJoyInfo.ForeColor = System.Drawing.Color.Gold;
            this.labJoyInfo.Location = new System.Drawing.Point(4, 32);
            this.labJoyInfo.Name = "labJoyInfo";
            this.labJoyInfo.Size = new System.Drawing.Size(79, 13);
            this.labJoyInfo.TabIndex = 6;
            this.labJoyInfo.Text = "Data to show...";
            this.toolTip1.SetToolTip(this.labJoyInfo, "Data");
            // 
            // panelManualControl
            // 
            this.panelManualControl.Controls.Add(this.label3);
            this.panelManualControl.Controls.Add(this.butAltiUp);
            this.panelManualControl.Controls.Add(this.butLeft);
            this.panelManualControl.Controls.Add(this.butAltiDown);
            this.panelManualControl.Controls.Add(this.butForward);
            this.panelManualControl.Controls.Add(this.butRollRight);
            this.panelManualControl.Controls.Add(this.butRight);
            this.panelManualControl.Controls.Add(this.butRollLeft);
            this.panelManualControl.Controls.Add(this.butBack);
            this.panelManualControl.Controls.Add(this.butMid);
            this.panelManualControl.Location = new System.Drawing.Point(3, 504);
            this.panelManualControl.Name = "panelManualControl";
            this.panelManualControl.Size = new System.Drawing.Size(363, 94);
            this.panelManualControl.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gold;
            this.label3.Location = new System.Drawing.Point(5, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "Manual Control :";
            // 
            // butAltiUp
            // 
            this.butAltiUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.butAltiUp.BackgroundImage = global::A.R.Drone.Main.Properties.Resources.altiUpCom;
            this.butAltiUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butAltiUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAltiUp.Location = new System.Drawing.Point(274, 3);
            this.butAltiUp.Name = "butAltiUp";
            this.butAltiUp.Size = new System.Drawing.Size(75, 23);
            this.butAltiUp.TabIndex = 32;
            this.toolTip1.SetToolTip(this.butAltiUp, "Alti Up");
            this.butAltiUp.UseVisualStyleBackColor = false;
            this.butAltiUp.Click += new System.EventHandler(this.butAltiUp_Click);
            // 
            // butLeft
            // 
            this.butLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.butLeft.BackgroundImage = global::A.R.Drone.Main.Properties.Resources.leftCom;
            this.butLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butLeft.Location = new System.Drawing.Point(71, 32);
            this.butLeft.Name = "butLeft";
            this.butLeft.Size = new System.Drawing.Size(75, 23);
            this.butLeft.TabIndex = 26;
            this.toolTip1.SetToolTip(this.butLeft, "Left");
            this.butLeft.UseVisualStyleBackColor = false;
            this.butLeft.Click += new System.EventHandler(this.butLeft_Click);
            // 
            // butAltiDown
            // 
            this.butAltiDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.butAltiDown.BackgroundImage = global::A.R.Drone.Main.Properties.Resources.altiDownCom;
            this.butAltiDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butAltiDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAltiDown.Location = new System.Drawing.Point(276, 61);
            this.butAltiDown.Name = "butAltiDown";
            this.butAltiDown.Size = new System.Drawing.Size(75, 23);
            this.butAltiDown.TabIndex = 31;
            this.toolTip1.SetToolTip(this.butAltiDown, "Alti Donw");
            this.butAltiDown.UseVisualStyleBackColor = false;
            this.butAltiDown.Click += new System.EventHandler(this.butAltiDown_Click);
            // 
            // butForward
            // 
            this.butForward.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.butForward.BackgroundImage = global::A.R.Drone.Main.Properties.Resources.forwCom;
            this.butForward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butForward.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.butForward.Location = new System.Drawing.Point(135, 3);
            this.butForward.Name = "butForward";
            this.butForward.Size = new System.Drawing.Size(75, 23);
            this.butForward.TabIndex = 24;
            this.toolTip1.SetToolTip(this.butForward, "Forward");
            this.butForward.UseVisualStyleBackColor = false;
            this.butForward.Click += new System.EventHandler(this.butForward_Click);
            // 
            // butRollRight
            // 
            this.butRollRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.butRollRight.BackgroundImage = global::A.R.Drone.Main.Properties.Resources.rigthRCom;
            this.butRollRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butRollRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butRollRight.Location = new System.Drawing.Point(216, 61);
            this.butRollRight.Name = "butRollRight";
            this.butRollRight.Size = new System.Drawing.Size(33, 23);
            this.butRollRight.TabIndex = 30;
            this.toolTip1.SetToolTip(this.butRollRight, "Roll Right");
            this.butRollRight.UseVisualStyleBackColor = false;
            this.butRollRight.Click += new System.EventHandler(this.butRollRight_Click);
            // 
            // butRight
            // 
            this.butRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.butRight.BackgroundImage = global::A.R.Drone.Main.Properties.Resources.rigthCom;
            this.butRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butRight.Location = new System.Drawing.Point(192, 32);
            this.butRight.Name = "butRight";
            this.butRight.Size = new System.Drawing.Size(75, 23);
            this.butRight.TabIndex = 25;
            this.toolTip1.SetToolTip(this.butRight, "Right");
            this.butRight.UseVisualStyleBackColor = false;
            this.butRight.Click += new System.EventHandler(this.butRight_Click);
            // 
            // butRollLeft
            // 
            this.butRollLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.butRollLeft.BackgroundImage = global::A.R.Drone.Main.Properties.Resources.leftRCom;
            this.butRollLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butRollLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butRollLeft.Location = new System.Drawing.Point(96, 61);
            this.butRollLeft.Name = "butRollLeft";
            this.butRollLeft.Size = new System.Drawing.Size(33, 23);
            this.butRollLeft.TabIndex = 29;
            this.toolTip1.SetToolTip(this.butRollLeft, "Roll Left");
            this.butRollLeft.UseVisualStyleBackColor = false;
            this.butRollLeft.Click += new System.EventHandler(this.butRollLeft_Click);
            // 
            // butBack
            // 
            this.butBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.butBack.BackgroundImage = global::A.R.Drone.Main.Properties.Resources.downCom;
            this.butBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butBack.Location = new System.Drawing.Point(135, 61);
            this.butBack.Name = "butBack";
            this.butBack.Size = new System.Drawing.Size(75, 23);
            this.butBack.TabIndex = 27;
            this.toolTip1.SetToolTip(this.butBack, "Back");
            this.butBack.UseVisualStyleBackColor = false;
            this.butBack.Click += new System.EventHandler(this.butBack_Click);
            // 
            // butMid
            // 
            this.butMid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.butMid.BackgroundImage = global::A.R.Drone.Main.Properties.Resources.neutreCom;
            this.butMid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butMid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butMid.Location = new System.Drawing.Point(152, 32);
            this.butMid.Name = "butMid";
            this.butMid.Size = new System.Drawing.Size(34, 23);
            this.butMid.TabIndex = 28;
            this.toolTip1.SetToolTip(this.butMid, "Hover (Stop Move)");
            this.butMid.UseVisualStyleBackColor = false;
            this.butMid.Click += new System.EventHandler(this.butMid_Click);
            // 
            // panelMainDataControl
            // 
            this.panelMainDataControl.BackColor = System.Drawing.Color.Black;
            this.panelMainDataControl.Controls.Add(this.labDataCorrect);
            this.panelMainDataControl.Controls.Add(this.label4);
            this.panelMainDataControl.Controls.Add(this.panelDataControlDebug);
            this.panelMainDataControl.Controls.Add(this.butTracking);
            this.panelMainDataControl.Controls.Add(this.butTrack);
            this.panelMainDataControl.Controls.Add(this.butLand);
            this.panelMainDataControl.Controls.Add(this.label1);
            this.panelMainDataControl.Controls.Add(this.butMasterEmergency);
            this.panelMainDataControl.Controls.Add(this.butMasterTakeOff);
            this.panelMainDataControl.Controls.Add(this.panelEngine);
            this.panelMainDataControl.Controls.Add(this.ledTracking);
            this.panelMainDataControl.Controls.Add(this.batLevel1);
            this.panelMainDataControl.Controls.Add(this.ledLand);
            this.panelMainDataControl.Controls.Add(this.ledFly);
            this.panelMainDataControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMainDataControl.Location = new System.Drawing.Point(0, 0);
            this.panelMainDataControl.Name = "panelMainDataControl";
            this.panelMainDataControl.Size = new System.Drawing.Size(673, 498);
            this.panelMainDataControl.TabIndex = 0;
            // 
            // labDataCorrect
            // 
            this.labDataCorrect.AutoSize = true;
            this.labDataCorrect.ForeColor = System.Drawing.Color.Gold;
            this.labDataCorrect.Location = new System.Drawing.Point(548, 347);
            this.labDataCorrect.Name = "labDataCorrect";
            this.labDataCorrect.Size = new System.Drawing.Size(79, 13);
            this.labDataCorrect.TabIndex = 26;
            this.labDataCorrect.Text = "Data to show...";
            this.toolTip1.SetToolTip(this.labDataCorrect, "Data");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gold;
            this.label4.Location = new System.Drawing.Point(399, 326);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 16);
            this.label4.TabIndex = 25;
            this.label4.Text = "Corrector :";
            // 
            // panelDataControlDebug
            // 
            this.panelDataControlDebug.BackgroundImage = global::A.R.Drone.Main.Properties.Resources.grille;
            this.panelDataControlDebug.Controls.Add(this.shapeContainer1);
            this.panelDataControlDebug.Location = new System.Drawing.Point(402, 345);
            this.panelDataControlDebug.Name = "panelDataControlDebug";
            this.panelDataControlDebug.Size = new System.Drawing.Size(140, 140);
            this.panelDataControlDebug.TabIndex = 6;
            this.toolTip1.SetToolTip(this.panelDataControlDebug, "Visual P corrector");
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.shapeGaz,
            this.shapeYawPitch});
            this.shapeContainer1.Size = new System.Drawing.Size(140, 140);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // shapeGaz
            // 
            this.shapeGaz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.shapeGaz.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.shapeGaz.Location = new System.Drawing.Point(-15, 58);
            this.shapeGaz.Name = "shapeGaz";
            this.shapeGaz.Size = new System.Drawing.Size(25, 25);
            // 
            // shapeYawPitch
            // 
            this.shapeYawPitch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.shapeYawPitch.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.shapeYawPitch.Location = new System.Drawing.Point(58, 58);
            this.shapeYawPitch.Name = "shapeYawPitch";
            this.shapeYawPitch.Size = new System.Drawing.Size(25, 25);
            // 
            // butTracking
            // 
            this.butTracking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.butTracking.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.butTracking.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.butTracking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butTracking.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butTracking.ForeColor = System.Drawing.Color.Gold;
            this.butTracking.Location = new System.Drawing.Point(533, 201);
            this.butTracking.Name = "butTracking";
            this.butTracking.Size = new System.Drawing.Size(125, 35);
            this.butTracking.TabIndex = 20;
            this.butTracking.Text = "Tracking ON";
            this.toolTip1.SetToolTip(this.butTracking, "Tracking ON/OFF");
            this.butTracking.UseVisualStyleBackColor = false;
            this.butTracking.Click += new System.EventHandler(this.butTracking_Click);
            // 
            // butTrack
            // 
            this.butTrack.BackColor = System.Drawing.Color.OliveDrab;
            this.butTrack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.butTrack.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.butTrack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butTrack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butTrack.ForeColor = System.Drawing.Color.Black;
            this.butTrack.Location = new System.Drawing.Point(533, 247);
            this.butTrack.Name = "butTrack";
            this.butTrack.Size = new System.Drawing.Size(125, 21);
            this.butTrack.TabIndex = 19;
            this.butTrack.Text = "Hover";
            this.butTrack.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTip1.SetToolTip(this.butTrack, "Hover (Stop Move)");
            this.butTrack.UseVisualStyleBackColor = false;
            this.butTrack.Click += new System.EventHandler(this.butTrack_Click);
            // 
            // butLand
            // 
            this.butLand.BackColor = System.Drawing.Color.OliveDrab;
            this.butLand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.butLand.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.butLand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butLand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLand.ForeColor = System.Drawing.Color.Black;
            this.butLand.Location = new System.Drawing.Point(402, 288);
            this.butLand.Name = "butLand";
            this.butLand.Size = new System.Drawing.Size(125, 35);
            this.butLand.TabIndex = 18;
            this.butLand.Text = "Landing";
            this.toolTip1.SetToolTip(this.butLand, "Landing");
            this.butLand.UseVisualStyleBackColor = false;
            this.butLand.Click += new System.EventHandler(this.butLand_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(499, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Data to show...";
            this.toolTip1.SetToolTip(this.label1, "Data");
            // 
            // butMasterEmergency
            // 
            this.butMasterEmergency.BackColor = System.Drawing.Color.IndianRed;
            this.butMasterEmergency.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.butMasterEmergency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butMasterEmergency.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butMasterEmergency.Location = new System.Drawing.Point(533, 274);
            this.butMasterEmergency.Name = "butMasterEmergency";
            this.butMasterEmergency.Size = new System.Drawing.Size(125, 49);
            this.butMasterEmergency.TabIndex = 17;
            this.butMasterEmergency.Text = "Emergency Stop";
            this.toolTip1.SetToolTip(this.butMasterEmergency, "Emergency Stop");
            this.butMasterEmergency.UseVisualStyleBackColor = false;
            this.butMasterEmergency.Click += new System.EventHandler(this.butMasterEmergency_Click);
            // 
            // butMasterTakeOff
            // 
            this.butMasterTakeOff.BackColor = System.Drawing.Color.OliveDrab;
            this.butMasterTakeOff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.butMasterTakeOff.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.butMasterTakeOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butMasterTakeOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butMasterTakeOff.ForeColor = System.Drawing.Color.Black;
            this.butMasterTakeOff.Location = new System.Drawing.Point(402, 247);
            this.butMasterTakeOff.Name = "butMasterTakeOff";
            this.butMasterTakeOff.Size = new System.Drawing.Size(125, 35);
            this.butMasterTakeOff.TabIndex = 16;
            this.butMasterTakeOff.Text = "WaitToConnect";
            this.toolTip1.SetToolTip(this.butMasterTakeOff, "Take Off");
            this.butMasterTakeOff.UseVisualStyleBackColor = false;
            this.butMasterTakeOff.Click += new System.EventHandler(this.butMasterTakeOff_Click);
            // 
            // panelEngine
            // 
            this.panelEngine.BackColor = System.Drawing.Color.Black;
            this.panelEngine.Controls.Add(this.engineLevel1);
            this.panelEngine.Controls.Add(this.engineLevel4);
            this.panelEngine.Controls.Add(this.engineLevel2);
            this.panelEngine.Controls.Add(this.engineLevel3);
            this.panelEngine.Location = new System.Drawing.Point(402, 3);
            this.panelEngine.Name = "panelEngine";
            this.panelEngine.Size = new System.Drawing.Size(94, 238);
            this.panelEngine.TabIndex = 15;
            // 
            // engineLevel1
            // 
            this.engineLevel1.BackColor = System.Drawing.Color.Black;
            this.engineLevel1.Location = new System.Drawing.Point(3, 3);
            this.engineLevel1.Name = "engineLevel1";
            this.engineLevel1.Size = new System.Drawing.Size(42, 112);
            this.engineLevel1.TabIndex = 20;
            this.toolTip1.SetToolTip(this.engineLevel1, "Engine 1");
            // 
            // engineLevel4
            // 
            this.engineLevel4.BackColor = System.Drawing.Color.Black;
            this.engineLevel4.Location = new System.Drawing.Point(48, 121);
            this.engineLevel4.Name = "engineLevel4";
            this.engineLevel4.Size = new System.Drawing.Size(42, 112);
            this.engineLevel4.TabIndex = 14;
            this.toolTip1.SetToolTip(this.engineLevel4, "Engine 4");
            // 
            // engineLevel2
            // 
            this.engineLevel2.BackColor = System.Drawing.Color.Black;
            this.engineLevel2.Location = new System.Drawing.Point(48, 3);
            this.engineLevel2.Name = "engineLevel2";
            this.engineLevel2.Size = new System.Drawing.Size(42, 112);
            this.engineLevel2.TabIndex = 12;
            this.toolTip1.SetToolTip(this.engineLevel2, "Engine 2");
            // 
            // engineLevel3
            // 
            this.engineLevel3.BackColor = System.Drawing.Color.Black;
            this.engineLevel3.Location = new System.Drawing.Point(3, 121);
            this.engineLevel3.Name = "engineLevel3";
            this.engineLevel3.Size = new System.Drawing.Size(42, 112);
            this.engineLevel3.TabIndex = 13;
            this.toolTip1.SetToolTip(this.engineLevel3, "Engine 3");
            // 
            // ledTracking
            // 
            this.ledTracking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(21)))), ((int)(((byte)(16)))));
            this.ledTracking.Location = new System.Drawing.Point(251, 3);
            this.ledTracking.Name = "ledTracking";
            this.ledTracking.Size = new System.Drawing.Size(90, 40);
            this.ledTracking.TabIndex = 10;
            this.toolTip1.SetToolTip(this.ledTracking, "Tracking");
            // 
            // batLevel1
            // 
            this.batLevel1.BackColor = System.Drawing.Color.Black;
            this.batLevel1.Location = new System.Drawing.Point(502, 32);
            this.batLevel1.Name = "batLevel1";
            this.batLevel1.Size = new System.Drawing.Size(30, 55);
            this.batLevel1.TabIndex = 9;
            this.toolTip1.SetToolTip(this.batLevel1, "Power supply");
            // 
            // ledLand
            // 
            this.ledLand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(21)))), ((int)(((byte)(16)))));
            this.ledLand.Location = new System.Drawing.Point(155, 3);
            this.ledLand.Name = "ledLand";
            this.ledLand.Size = new System.Drawing.Size(90, 40);
            this.ledLand.TabIndex = 8;
            this.toolTip1.SetToolTip(this.ledLand, "Land");
            // 
            // ledFly
            // 
            this.ledFly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(21)))), ((int)(((byte)(16)))));
            this.ledFly.Location = new System.Drawing.Point(59, 3);
            this.ledFly.Name = "ledFly";
            this.ledFly.Size = new System.Drawing.Size(90, 40);
            this.ledFly.TabIndex = 7;
            this.toolTip1.SetToolTip(this.ledFly, "Fly");
            // 
            // toolTip1
            // 
            this.toolTip1.UseAnimation = false;
            this.toolTip1.UseFading = false;
            // 
            // MainWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 692);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statutBar);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWin";
            this.Text = "A.R. Drone Control 1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWin_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statutBar.ResumeLayout(false);
            this.statutBar.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picVideoImg)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRadius)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelManualControl.ResumeLayout(false);
            this.panelManualControl.PerformLayout();
            this.panelMainDataControl.ResumeLayout(false);
            this.panelMainDataControl.PerformLayout();
            this.panelDataControlDebug.ResumeLayout(false);
            this.panelEngine.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statutBar;
        private System.Windows.Forms.ToolStripStatusLabel statutConnect;
        private System.Windows.Forms.ToolStripMenuItem connectDroneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetEmergencyToolStripMenuItem;
       
        private System.Windows.Forms.PictureBox picVideoImg;
       
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelMainDataControl;
        private System.Windows.Forms.Panel panelEngine;
        private UI.LedControl.EngineLevel engineLevel4;
        private UI.LedControl.EngineLevel engineLevel2;
        private UI.LedControl.EngineLevel engineLevel3;
        private System.Windows.Forms.Label label1;
        private UI.LedControl.LedControl ledTracking;
        private UI.LedControl.BatLevel batLevel1;
        private UI.LedControl.LedControl ledLand;
        private UI.LedControl.LedControl ledFly;
        private System.Windows.Forms.Button butMasterEmergency;
        private System.Windows.Forms.Button butMasterTakeOff;
        private System.Windows.Forms.RichTextBox consolDataDrone;
        private System.Windows.Forms.Button butLand;
        private System.Windows.Forms.TrackBar trackBarRadius;
        private System.Windows.Forms.Button butTrack;
        private System.Windows.Forms.ToolStripMenuItem joystickToolStripMenuItem;
        private System.Windows.Forms.TreeView tvInfo;
        private System.Windows.Forms.ToolStripMenuItem dPlotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualCommandToolStripMenuItem;
        private UI.LedControl.EngineLevel engineLevel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripWifiName;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripProgressBar toolStripWifiLenght;
        private Panel panelDataControlDebug;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.OvalShape shapeGaz;
        private Microsoft.VisualBasic.PowerPacks.OvalShape shapeYawPitch;
        private ToolStripMenuItem grapHistoryToolStripMenuItem;
        private ToolStripMenuItem resetTrimToolStripMenuItem;
        private ToolStripMenuItem pDFToolStripMenuItem;
        private Panel panelColor;
        private Label label2;
        private ToolStripMenuItem picColorToolStripMenuItem;
        private Button butTracking;
        private Label labRad;
        private Panel panelManualControl;
        private Button butAltiUp;
        private Button butLeft;
        private Button butAltiDown;
        private Button butForward;
        private Button butRollRight;
        private Button butRight;
        private Button butRollLeft;
        private Button butBack;
        private Button butMid;
        private Label label3;
        private ToolTip toolTip1;
        private CheckBox checkHistoEqual;
        private ToolStripMenuItem fullScreenToolStripMenuItem;
        private ToolStripMenuItem calibrateJoystickToolStripMenuItem;
        private Panel panel1;
        private Label label5;
        private Label labJoyInfo;
        private ToolStripMenuItem oculusRiftToolStripMenuItem;
        private ToolStripMenuItem joystickControlToolStripMenuItem;
        private ToolStripMenuItem howToRunToolStripMenuItem;
        private Label label4;
        private Label labDataCorrect;
        private HScrollBar ScrollBarRectRange;
        private Label label6;
        private HScrollBar hScrollAirMax;
        private Label label9;
        private Label label8;
        private Label label7;
        private HScrollBar hScrollAirMin;
        private Label labAireMax;
        private Label labAireMin;
        private Label labAireActu;
        private Label label10;
        private Panel panel3;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer2;
        private Microsoft.VisualBasic.PowerPacks.OvalShape ovalShapAirMin;
        private Microsoft.VisualBasic.PowerPacks.OvalShape ovalShapAirActu;
        private Microsoft.VisualBasic.PowerPacks.OvalShape ovalShapAirMax;
    }
}

