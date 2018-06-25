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
            this.SearchByType = new System.Windows.Forms.TextBox();
            this.Buildings = new System.Windows.Forms.CheckBox();
            this.Railways = new System.Windows.Forms.CheckBox();
            this.coordinates = new System.Windows.Forms.Label();
            this.intersection = new System.Windows.Forms.Button();
            this.searchFrom = new System.Windows.Forms.TextBox();
            this.searchTo = new System.Windows.Forms.TextBox();
            this.SearchRoute = new System.Windows.Forms.Button();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            ((System.ComponentModel.ISupportInitialize)(this.Map)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Distance)).BeginInit();
            this.SuspendLayout();
            // 
            // Map
            // 
            this.Map.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Map.Location = new System.Drawing.Point(12, 38);
            this.Map.Name = "Map";
            this.Map.Size = new System.Drawing.Size(802, 362);
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
            this.Distance.Name = "Distance";
            this.Distance.Size = new System.Drawing.Size(802, 45);
            this.Distance.TabIndex = 1;
            this.Distance.Value = 2;
            // 
            // SearchByName
            // 
            this.SearchByName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.SearchByName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.SearchByName.Location = new System.Drawing.Point(623, 12);
            this.SearchByName.Name = "SearchByName";
            this.SearchByName.Size = new System.Drawing.Size(191, 20);
            this.SearchByName.TabIndex = 2;
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
            this.Service.Location = new System.Drawing.Point(20, 511);
            this.Service.Name = "Service";
            this.Service.Size = new System.Drawing.Size(53, 23);
            this.Service.TabIndex = 5;
            this.Service.Text = "Service";
            this.Service.UseVisualStyleBackColor = true;
            this.Service.CheckedChanged += new System.EventHandler(this.Service_CheckedChanged);
            // 
            // Utility
            // 
            this.Utility.Appearance = System.Windows.Forms.Appearance.Button;
            this.Utility.AutoSize = true;
            this.Utility.Location = new System.Drawing.Point(156, 511);
            this.Utility.Name = "Utility";
            this.Utility.Size = new System.Drawing.Size(42, 23);
            this.Utility.TabIndex = 6;
            this.Utility.Text = "Utility";
            this.Utility.UseVisualStyleBackColor = true;
            this.Utility.CheckedChanged += new System.EventHandler(this.Utility_CheckedChanged);
            // 
            // Inn
            // 
            this.Inn.Appearance = System.Windows.Forms.Appearance.Button;
            this.Inn.AutoSize = true;
            this.Inn.Location = new System.Drawing.Point(299, 511);
            this.Inn.Name = "Inn";
            this.Inn.Size = new System.Drawing.Size(32, 23);
            this.Inn.TabIndex = 7;
            this.Inn.Text = "Inn";
            this.Inn.UseVisualStyleBackColor = true;
            this.Inn.CheckedChanged += new System.EventHandler(this.Inn_CheckedChanged);
            // 
            // Transportation
            // 
            this.Transportation.Appearance = System.Windows.Forms.Appearance.Button;
            this.Transportation.AutoSize = true;
            this.Transportation.Location = new System.Drawing.Point(420, 511);
            this.Transportation.Name = "Transportation";
            this.Transportation.Size = new System.Drawing.Size(85, 23);
            this.Transportation.TabIndex = 8;
            this.Transportation.Text = "Transportation";
            this.Transportation.UseVisualStyleBackColor = true;
            this.Transportation.CheckedChanged += new System.EventHandler(this.Transportation_CheckedChanged);
            // 
            // Cultural
            // 
            this.Cultural.Appearance = System.Windows.Forms.Appearance.Button;
            this.Cultural.AutoSize = true;
            this.Cultural.Location = new System.Drawing.Point(563, 511);
            this.Cultural.Name = "Cultural";
            this.Cultural.Size = new System.Drawing.Size(52, 23);
            this.Cultural.TabIndex = 9;
            this.Cultural.Text = "Cultural";
            this.Cultural.UseVisualStyleBackColor = true;
            this.Cultural.CheckedChanged += new System.EventHandler(this.Cultural_CheckedChanged);
            // 
            // Tourist
            // 
            this.Tourist.Appearance = System.Windows.Forms.Appearance.Button;
            this.Tourist.AutoSize = true;
            this.Tourist.Location = new System.Drawing.Point(691, 511);
            this.Tourist.Name = "Tourist";
            this.Tourist.Size = new System.Drawing.Size(49, 23);
            this.Tourist.TabIndex = 10;
            this.Tourist.Text = "Tourist";
            this.Tourist.UseVisualStyleBackColor = true;
            this.Tourist.CheckedChanged += new System.EventHandler(this.Tourist_CheckedChanged);
            // 
            // SearchByType
            // 
            this.SearchByType.Location = new System.Drawing.Point(20, 470);
            this.SearchByType.Name = "SearchByType";
            this.SearchByType.Size = new System.Drawing.Size(143, 20);
            this.SearchByType.TabIndex = 11;
            // 
            // Buildings
            // 
            this.Buildings.Appearance = System.Windows.Forms.Appearance.Button;
            this.Buildings.Location = new System.Drawing.Point(20, 47);
            this.Buildings.Name = "Buildings";
            this.Buildings.Size = new System.Drawing.Size(53, 23);
            this.Buildings.TabIndex = 12;
            this.Buildings.Text = "Zgrade";
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
            this.Railways.Text = "Pruge";
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
            this.intersection.Location = new System.Drawing.Point(492, 9);
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
            this.searchFrom.Location = new System.Drawing.Point(63, 12);
            this.searchFrom.Name = "searchFrom";
            this.searchFrom.Size = new System.Drawing.Size(100, 20);
            this.searchFrom.TabIndex = 16;
            // 
            // searchTo
            // 
            this.searchTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.searchTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.searchTo.Location = new System.Drawing.Point(196, 12);
            this.searchTo.Name = "searchTo";
            this.searchTo.Size = new System.Drawing.Size(100, 20);
            this.searchTo.TabIndex = 17;
            // 
            // SearchRoute
            // 
            this.SearchRoute.Location = new System.Drawing.Point(311, 10);
            this.SearchRoute.Name = "SearchRoute";
            this.SearchRoute.Size = new System.Drawing.Size(75, 23);
            this.SearchRoute.TabIndex = 18;
            this.SearchRoute.Text = "Search";
            this.SearchRoute.UseVisualStyleBackColor = true;
            this.SearchRoute.Click += new System.EventHandler(this.SearchRoute_Click);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(820, 38);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(190, 362);
            this.propertyGrid1.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 567);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.intersection);
            this.Controls.Add(this.SearchRoute);
            this.Controls.Add(this.searchTo);
            this.Controls.Add(this.searchFrom);
            this.Controls.Add(this.coordinates);
            this.Controls.Add(this.Railways);
            this.Controls.Add(this.Buildings);
            this.Controls.Add(this.SearchByType);
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
        private System.Windows.Forms.TextBox SearchByType;
        private System.Windows.Forms.CheckBox Buildings;
        private System.Windows.Forms.CheckBox Railways;
        private System.Windows.Forms.Label coordinates;
        private System.Windows.Forms.Button intersection;
        private System.Windows.Forms.TextBox searchFrom;
        private System.Windows.Forms.TextBox searchTo;
        private System.Windows.Forms.Button SearchRoute;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
    }
}

