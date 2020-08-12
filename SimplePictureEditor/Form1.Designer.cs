namespace SimplePictureEditor
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Open = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rateTrackBar = new System.Windows.Forms.TrackBar();
            this.effectList = new System.Windows.Forms.ComboBox();
            this.btn_Apply = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rateTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Save);
            this.groupBox1.Controls.Add(this.btn_Open);
            this.groupBox1.Location = new System.Drawing.Point(617, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 127);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controls";
            // 
            // btn_Save
            // 
            this.btn_Save.Enabled = false;
            this.btn_Save.Location = new System.Drawing.Point(7, 49);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(137, 23);
            this.btn_Save.TabIndex = 1;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Open
            // 
            this.btn_Open.Location = new System.Drawing.Point(6, 19);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(138, 23);
            this.btn_Open.TabIndex = 0;
            this.btn_Open.Text = "Open";
            this.btn_Open.UseVisualStyleBackColor = true;
            this.btn_Open.Click += new System.EventHandler(this.btn_Open_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rateTrackBar);
            this.groupBox2.Controls.Add(this.effectList);
            this.groupBox2.Controls.Add(this.btn_Apply);
            this.groupBox2.Location = new System.Drawing.Point(617, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(150, 394);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Efects";
            // 
            // rateTrackBar
            // 
            this.rateTrackBar.Location = new System.Drawing.Point(7, 49);
            this.rateTrackBar.Maximum = 50;
            this.rateTrackBar.Name = "rateTrackBar";
            this.rateTrackBar.Size = new System.Drawing.Size(137, 45);
            this.rateTrackBar.TabIndex = 2;
            this.rateTrackBar.TickFrequency = 10;
            this.rateTrackBar.Visible = false;
            // 
            // effectList
            // 
            this.effectList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.effectList.Enabled = false;
            this.effectList.FormattingEnabled = true;
            this.effectList.Items.AddRange(new object[] {
            "Invert Colors",
            "Blur",
            "Lighten",
            "Darken",
            "Flip Horizontally",
            "Flip Vertically"});
            this.effectList.Location = new System.Drawing.Point(6, 100);
            this.effectList.Name = "effectList";
            this.effectList.Size = new System.Drawing.Size(137, 21);
            this.effectList.TabIndex = 1;
            this.effectList.SelectedIndexChanged += new System.EventHandler(this.effectList_SelectedIndexChanged);
            // 
            // btn_Apply
            // 
            this.btn_Apply.Enabled = false;
            this.btn_Apply.Location = new System.Drawing.Point(7, 20);
            this.btn_Apply.Name = "btn_Apply";
            this.btn_Apply.Size = new System.Drawing.Size(137, 23);
            this.btn_Apply.TabIndex = 0;
            this.btn_Apply.Text = "Apply";
            this.btn_Apply.UseVisualStyleBackColor = true;
            this.btn_Apply.Click += new System.EventHandler(this.btn_Apply_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "SimplePictureEditor v1.0";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rateTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Open;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox effectList;
        private System.Windows.Forms.Button btn_Apply;
        private System.Windows.Forms.TrackBar rateTrackBar;
    }
}

