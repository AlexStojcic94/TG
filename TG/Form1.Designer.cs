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
            this.Search1 = new System.Windows.Forms.CheckBox();
            this.Search2 = new System.Windows.Forms.CheckBox();
            this.Search3 = new System.Windows.Forms.CheckBox();
            this.Search4 = new System.Windows.Forms.CheckBox();
            this.Search5 = new System.Windows.Forms.CheckBox();
            this.Search6 = new System.Windows.Forms.CheckBox();
            this.SearchByType = new System.Windows.Forms.TextBox();
            this.Buildings = new System.Windows.Forms.CheckBox();
            this.Railways = new System.Windows.Forms.CheckBox();
            this.Points = new System.Windows.Forms.CheckBox();
            this.coordinates = new System.Windows.Forms.Label();
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
            this.Map.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Map_MouseMove);
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
            // Search1
            // 
            this.Search1.Appearance = System.Windows.Forms.Appearance.Button;
            this.Search1.AutoSize = true;
            this.Search1.Location = new System.Drawing.Point(20, 511);
            this.Search1.Name = "Search1";
            this.Search1.Size = new System.Drawing.Size(71, 23);
            this.Search1.TabIndex = 5;
            this.Search1.Text = "checkBox1";
            this.Search1.UseVisualStyleBackColor = true;
            // 
            // Search2
            // 
            this.Search2.Appearance = System.Windows.Forms.Appearance.Button;
            this.Search2.AutoSize = true;
            this.Search2.Location = new System.Drawing.Point(156, 511);
            this.Search2.Name = "Search2";
            this.Search2.Size = new System.Drawing.Size(71, 23);
            this.Search2.TabIndex = 6;
            this.Search2.Text = "checkBox2";
            this.Search2.UseVisualStyleBackColor = true;
            // 
            // Search3
            // 
            this.Search3.Appearance = System.Windows.Forms.Appearance.Button;
            this.Search3.AutoSize = true;
            this.Search3.Location = new System.Drawing.Point(299, 511);
            this.Search3.Name = "Search3";
            this.Search3.Size = new System.Drawing.Size(71, 23);
            this.Search3.TabIndex = 7;
            this.Search3.Text = "checkBox3";
            this.Search3.UseVisualStyleBackColor = true;
            // 
            // Search4
            // 
            this.Search4.Appearance = System.Windows.Forms.Appearance.Button;
            this.Search4.AutoSize = true;
            this.Search4.Location = new System.Drawing.Point(420, 511);
            this.Search4.Name = "Search4";
            this.Search4.Size = new System.Drawing.Size(71, 23);
            this.Search4.TabIndex = 8;
            this.Search4.Text = "checkBox4";
            this.Search4.UseVisualStyleBackColor = true;
            // 
            // Search5
            // 
            this.Search5.Appearance = System.Windows.Forms.Appearance.Button;
            this.Search5.AutoSize = true;
            this.Search5.Location = new System.Drawing.Point(563, 511);
            this.Search5.Name = "Search5";
            this.Search5.Size = new System.Drawing.Size(71, 23);
            this.Search5.TabIndex = 9;
            this.Search5.Text = "checkBox5";
            this.Search5.UseVisualStyleBackColor = true;
            // 
            // Search6
            // 
            this.Search6.Appearance = System.Windows.Forms.Appearance.Button;
            this.Search6.AutoSize = true;
            this.Search6.Location = new System.Drawing.Point(691, 511);
            this.Search6.Name = "Search6";
            this.Search6.Size = new System.Drawing.Size(71, 23);
            this.Search6.TabIndex = 10;
            this.Search6.Text = "checkBox6";
            this.Search6.UseVisualStyleBackColor = true;
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
            // Points
            // 
            this.Points.Appearance = System.Windows.Forms.Appearance.Button;
            this.Points.Location = new System.Drawing.Point(20, 105);
            this.Points.Name = "Points";
            this.Points.Size = new System.Drawing.Size(53, 23);
            this.Points.TabIndex = 14;
            this.Points.Text = "Objekti";
            this.Points.UseVisualStyleBackColor = true;
            this.Points.CheckedChanged += new System.EventHandler(this.Points_CheckedChanged);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 567);
            this.Controls.Add(this.coordinates);
            this.Controls.Add(this.Points);
            this.Controls.Add(this.Railways);
            this.Controls.Add(this.Buildings);
            this.Controls.Add(this.SearchByType);
            this.Controls.Add(this.Search6);
            this.Controls.Add(this.Search5);
            this.Controls.Add(this.Search4);
            this.Controls.Add(this.Search3);
            this.Controls.Add(this.Search2);
            this.Controls.Add(this.Search1);
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
        private System.Windows.Forms.CheckBox Search1;
        private System.Windows.Forms.CheckBox Search2;
        private System.Windows.Forms.CheckBox Search3;
        private System.Windows.Forms.CheckBox Search4;
        private System.Windows.Forms.CheckBox Search5;
        private System.Windows.Forms.CheckBox Search6;
        private System.Windows.Forms.TextBox SearchByType;
        private System.Windows.Forms.CheckBox Buildings;
        private System.Windows.Forms.CheckBox Railways;
        private System.Windows.Forms.CheckBox Points;
        private System.Windows.Forms.Label coordinates;
    }
}

