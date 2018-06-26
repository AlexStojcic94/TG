namespace TG
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Map = new System.Windows.Forms.PictureBox();
            this.Distance = new System.Windows.Forms.TrackBar();
            this.SearchByName = new System.Windows.Forms.TextBox();
            this.ZoomIn = new System.Windows.Forms.Button();
            this.ZoomOut = new System.Windows.Forms.Button();
            this.Service = new System.Windows.Forms.CheckBox();
            this.Utility = new System.Windows.Forms.CheckBox();
            this.Inn = new System.Windows.Forms.CheckBox();
            this.Transportation = new System.Windows.Forms.CheckBox();
            this.Cultural = new System.Windows.Forms.CheckBox();
            this.Tourist = new System.Windows.Forms.CheckBox();
            this.Buildings = new System.Windows.Forms.CheckBox();
            this.Railways = new System.Windows.Forms.CheckBox();
            this.coordinates = new System.Windows.Forms.Label();
            this.intersection = new System.Windows.Forms.Button();
            this.searchFrom = new System.Windows.Forms.TextBox();
            this.searchTo = new System.Windows.Forms.TextBox();
            this.SearchRoute = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.coordinatesReg = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Map)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Distance)).BeginInit();
            this.SuspendLayout();
            // 
            // Map
            // 
            this.Map.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Map.Location = new System.Drawing.Point(12, 38);
            this.Map.Name = "Map";
            this.Map.Size = new System.Drawing.Size(802, 355);
            this.Map.TabIndex = 0;
            this.Map.TabStop = false;
            this.Map.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Map_MouseClick);
            this.Map.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Map_MouseDown);
            this.Map.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Map_MouseMove);
            this.Map.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Map_MouseUp);
            // 
            // Distance
            // 
            this.Distance.Location = new System.Drawing.Point(12, 419);
            this.Distance.Maximum = 100;
            this.Distance.Minimum = 1;
            this.Distance.Name = "Distance";
            this.Distance.Size = new System.Drawing.Size(802, 45);
            this.Distance.TabIndex = 1;
            this.Distance.Value = 2;
            this.Distance.Scroll += new System.EventHandler(this.Distance_Scroll);
            // 
            // SearchByName
            // 
            this.SearchByName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.SearchByName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.SearchByName.Location = new System.Drawing.Point(623, 10);
            this.SearchByName.Name = "SearchByName";
            this.SearchByName.Size = new System.Drawing.Size(191, 20);
            this.SearchByName.TabIndex = 2;
            this.SearchByName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SearchByName_KeyUp);
            // 
            // ZoomIn
            // 
            this.ZoomIn.Location = new System.Drawing.Point(769, 308);
            this.ZoomIn.Name = "ZoomIn";
            this.ZoomIn.Size = new System.Drawing.Size(33, 33);
            this.ZoomIn.TabIndex = 3;
            this.ZoomIn.Text = "+";
            this.ZoomIn.UseVisualStyleBackColor = true;
            this.ZoomIn.Click += new System.EventHandler(this.ZoomIn_Click);
            // 
            // ZoomOut
            // 
            this.ZoomOut.Location = new System.Drawing.Point(769, 347);
            this.ZoomOut.Name = "ZoomOut";
            this.ZoomOut.Size = new System.Drawing.Size(33, 33);
            this.ZoomOut.TabIndex = 4;
            this.ZoomOut.Text = "-";
            this.ZoomOut.UseVisualStyleBackColor = true;
            this.ZoomOut.Click += new System.EventHandler(this.ZoomOut_Click);
            // 
            // Service
            // 
            this.Service.Appearance = System.Windows.Forms.Appearance.Button;
            this.Service.AutoSize = true;
            this.Service.Image = ((System.Drawing.Image)(resources.GetObject("Service.Image")));
            this.Service.Location = new System.Drawing.Point(20, 470);
            this.Service.Name = "Service";
            this.Service.Size = new System.Drawing.Size(54, 54);
            this.Service.TabIndex = 5;
            this.Service.UseVisualStyleBackColor = true;
            this.Service.CheckedChanged += new System.EventHandler(this.Service_CheckedChanged);
            // 
            // Utility
            // 
            this.Utility.Appearance = System.Windows.Forms.Appearance.Button;
            this.Utility.AutoSize = true;
            this.Utility.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Utility.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Utility.Image = ((System.Drawing.Image)(resources.GetObject("Utility.Image")));
            this.Utility.Location = new System.Drawing.Point(158, 470);
            this.Utility.Name = "Utility";
            this.Utility.Size = new System.Drawing.Size(54, 54);
            this.Utility.TabIndex = 6;
            this.Utility.UseVisualStyleBackColor = true;
            this.Utility.CheckedChanged += new System.EventHandler(this.Utility_CheckedChanged);
            // 
            // Inn
            // 
            this.Inn.Appearance = System.Windows.Forms.Appearance.Button;
            this.Inn.AutoSize = true;
            this.Inn.Image = ((System.Drawing.Image)(resources.GetObject("Inn.Image")));
            this.Inn.Location = new System.Drawing.Point(306, 470);
            this.Inn.Name = "Inn";
            this.Inn.Size = new System.Drawing.Size(54, 54);
            this.Inn.TabIndex = 7;
            this.Inn.UseVisualStyleBackColor = true;
            this.Inn.CheckedChanged += new System.EventHandler(this.Inn_CheckedChanged);
            // 
            // Transportation
            // 
            this.Transportation.Appearance = System.Windows.Forms.Appearance.Button;
            this.Transportation.AutoSize = true;
            this.Transportation.Image = ((System.Drawing.Image)(resources.GetObject("Transportation.Image")));
            this.Transportation.Location = new System.Drawing.Point(460, 470);
            this.Transportation.Name = "Transportation";
            this.Transportation.Size = new System.Drawing.Size(54, 54);
            this.Transportation.TabIndex = 8;
            this.Transportation.UseVisualStyleBackColor = true;
            this.Transportation.CheckedChanged += new System.EventHandler(this.Transportation_CheckedChanged);
            // 
            // Cultural
            // 
            this.Cultural.Appearance = System.Windows.Forms.Appearance.Button;
            this.Cultural.AutoSize = true;
            this.Cultural.Image = ((System.Drawing.Image)(resources.GetObject("Cultural.Image")));
            this.Cultural.Location = new System.Drawing.Point(606, 470);
            this.Cultural.Name = "Cultural";
            this.Cultural.Size = new System.Drawing.Size(54, 54);
            this.Cultural.TabIndex = 9;
            this.Cultural.UseVisualStyleBackColor = true;
            this.Cultural.CheckedChanged += new System.EventHandler(this.Cultural_CheckedChanged);
            // 
            // Tourist
            // 
            this.Tourist.Appearance = System.Windows.Forms.Appearance.Button;
            this.Tourist.AutoSize = true;
            this.Tourist.Image = ((System.Drawing.Image)(resources.GetObject("Tourist.Image")));
            this.Tourist.Location = new System.Drawing.Point(748, 470);
            this.Tourist.Name = "Tourist";
            this.Tourist.Size = new System.Drawing.Size(54, 54);
            this.Tourist.TabIndex = 10;
            this.Tourist.UseVisualStyleBackColor = true;
            this.Tourist.CheckedChanged += new System.EventHandler(this.Tourist_CheckedChanged);
            // 
            // Buildings
            // 
            this.Buildings.Appearance = System.Windows.Forms.Appearance.Button;
            this.Buildings.Location = new System.Drawing.Point(20, 47);
            this.Buildings.Name = "Buildings";
            this.Buildings.Size = new System.Drawing.Size(53, 23);
            this.Buildings.TabIndex = 12;
            this.Buildings.Text = "Buildings";
            this.Buildings.UseVisualStyleBackColor = true;
            this.Buildings.CheckedChanged += new System.EventHandler(this.Buildings_CheckedChanged);
            // 
            // Railways
            // 
            this.Railways.Appearance = System.Windows.Forms.Appearance.Button;
            this.Railways.Location = new System.Drawing.Point(20, 76);
            this.Railways.Name = "Railways";
            this.Railways.Size = new System.Drawing.Size(53, 23);
            this.Railways.TabIndex = 13;
            this.Railways.Text = "Railways";
            this.Railways.UseVisualStyleBackColor = true;
            this.Railways.CheckedChanged += new System.EventHandler(this.Railways_CheckedChanged);
            // 
            // coordinates
            // 
            this.coordinates.AutoSize = true;
            this.coordinates.Location = new System.Drawing.Point(702, 47);
            this.coordinates.MaximumSize = new System.Drawing.Size(220, 220);
            this.coordinates.MinimumSize = new System.Drawing.Size(100, 15);
            this.coordinates.Name = "coordinates";
            this.coordinates.Size = new System.Drawing.Size(100, 15);
            this.coordinates.TabIndex = 15;
            // 
            // intersection
            // 
            this.intersection.Location = new System.Drawing.Point(896, 10);
            this.intersection.Name = "intersection";
            this.intersection.Size = new System.Drawing.Size(105, 23);
            this.intersection.TabIndex = 16;
            this.intersection.Text = "Find Intersection";
            this.intersection.UseVisualStyleBackColor = true;
            this.intersection.Click += new System.EventHandler(this.Intersection_Click);
            // 
            // searchFrom
            // 
            this.searchFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.searchFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.searchFrom.Location = new System.Drawing.Point(56, 12);
            this.searchFrom.Name = "searchFrom";
            this.searchFrom.Size = new System.Drawing.Size(156, 20);
            this.searchFrom.TabIndex = 16;
            // 
            // searchTo
            // 
            this.searchTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.searchTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.searchTo.Location = new System.Drawing.Point(258, 12);
            this.searchTo.Name = "searchTo";
            this.searchTo.Size = new System.Drawing.Size(156, 20);
            this.searchTo.TabIndex = 17;
            // 
            // SearchRoute
            // 
            this.SearchRoute.Location = new System.Drawing.Point(430, 10);
            this.SearchRoute.Name = "SearchRoute";
            this.SearchRoute.Size = new System.Drawing.Size(75, 23);
            this.SearchRoute.TabIndex = 18;
            this.SearchRoute.Text = "Find route";
            this.SearchRoute.UseVisualStyleBackColor = true;
            this.SearchRoute.Click += new System.EventHandler(this.SearchRoute_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "From:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "To:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(560, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Search:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(832, 38);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(169, 355);
            this.listBox1.TabIndex = 23;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(838, 419);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(838, 451);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 25;
            // 
            // coordinatesReg
            // 
            this.coordinatesReg.AutoSize = true;
            this.coordinatesReg.Location = new System.Drawing.Point(722, 76);
            this.coordinatesReg.MaximumSize = new System.Drawing.Size(220, 220);
            this.coordinatesReg.MinimumSize = new System.Drawing.Size(75, 15);
            this.coordinatesReg.Name = "coordinatesReg";
            this.coordinatesReg.Size = new System.Drawing.Size(75, 15);
            this.coordinatesReg.TabIndex = 24;
            this.coordinatesReg.Click += new System.EventHandler(this.coordinatesReg_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 567);
            this.Controls.Add(this.coordinatesReg);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.intersection);
            this.Controls.Add(this.SearchRoute);
            this.Controls.Add(this.searchTo);
            this.Controls.Add(this.searchFrom);
            this.Controls.Add(this.coordinates);
            this.Controls.Add(this.Railways);
            this.Controls.Add(this.Buildings);
            this.Controls.Add(this.Tourist);
            this.Controls.Add(this.Cultural);
            this.Controls.Add(this.Transportation);
            this.Controls.Add(this.Inn);
            this.Controls.Add(this.Utility);
            this.Controls.Add(this.Service);
            this.Controls.Add(this.ZoomOut);
            this.Controls.Add(this.ZoomIn);
            this.Controls.Add(this.SearchByName);
            this.Controls.Add(this.Distance);
            this.Controls.Add(this.Map);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Map)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Distance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Map;
        private System.Windows.Forms.TrackBar Distance;
        private System.Windows.Forms.TextBox SearchByName;
        private System.Windows.Forms.Button ZoomIn;
        private System.Windows.Forms.Button ZoomOut;
        private System.Windows.Forms.CheckBox Service;
        private System.Windows.Forms.CheckBox Utility;
        private System.Windows.Forms.CheckBox Inn;
        private System.Windows.Forms.CheckBox Transportation;
        private System.Windows.Forms.CheckBox Cultural;
        private System.Windows.Forms.CheckBox Tourist;
        private System.Windows.Forms.CheckBox Buildings;
        private System.Windows.Forms.CheckBox Railways;
        private System.Windows.Forms.Label coordinates;
        private System.Windows.Forms.Button intersection;
        private System.Windows.Forms.TextBox searchFrom;
        private System.Windows.Forms.TextBox searchTo;
        private System.Windows.Forms.Button SearchRoute;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label coordinatesReg;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

