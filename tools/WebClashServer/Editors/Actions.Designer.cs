﻿namespace WebClashServer.Editors
{
    partial class Actions
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Actions));
            this.label1 = new System.Windows.Forms.Label();
            this.actionSelect = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.charSelect = new System.Windows.Forms.ComboBox();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.properties = new System.Windows.Forms.GroupBox();
            this.height = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.width = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.animation = new System.Windows.Forms.GroupBox();
            this.direction = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.speed = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.animates = new System.Windows.Forms.CheckBox();
            this.source = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.LinkLabel();
            this.animationTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.vitality = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.wisdom = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.intelligence = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.toughness = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.agility = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.power = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.properties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.width)).BeginInit();
            this.animation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speed)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vitality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wisdom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intelligence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toughness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.agility)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.power)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Action";
            // 
            // actionSelect
            // 
            this.actionSelect.FormattingEnabled = true;
            this.actionSelect.Location = new System.Drawing.Point(131, 12);
            this.actionSelect.Name = "actionSelect";
            this.actionSelect.Size = new System.Drawing.Size(135, 21);
            this.actionSelect.TabIndex = 1;
            this.actionSelect.SelectedIndexChanged += new System.EventHandler(this.actionSelect_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(284, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Test Character";
            // 
            // charSelect
            // 
            this.charSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.charSelect.FormattingEnabled = true;
            this.charSelect.Location = new System.Drawing.Point(472, 12);
            this.charSelect.Name = "charSelect";
            this.charSelect.Size = new System.Drawing.Size(135, 21);
            this.charSelect.TabIndex = 3;
            this.charSelect.SelectedIndexChanged += new System.EventHandler(this.charSelect_SelectedIndexChanged);
            // 
            // canvas
            // 
            this.canvas.Location = new System.Drawing.Point(287, 48);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(320, 320);
            this.canvas.TabIndex = 4;
            this.canvas.TabStop = false;
            // 
            // properties
            // 
            this.properties.Controls.Add(this.height);
            this.properties.Controls.Add(this.label7);
            this.properties.Controls.Add(this.width);
            this.properties.Controls.Add(this.label6);
            this.properties.Controls.Add(this.animation);
            this.properties.Controls.Add(this.animates);
            this.properties.Controls.Add(this.source);
            this.properties.Controls.Add(this.label3);
            this.properties.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.properties.Location = new System.Drawing.Point(12, 152);
            this.properties.Name = "properties";
            this.properties.Size = new System.Drawing.Size(254, 216);
            this.properties.TabIndex = 5;
            this.properties.TabStop = false;
            this.properties.Text = "Properties";
            this.properties.Visible = false;
            // 
            // height
            // 
            this.height.Location = new System.Drawing.Point(172, 58);
            this.height.Maximum = new decimal(new int[] {
            320,
            0,
            0,
            0});
            this.height.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.height.Name = "height";
            this.height.Size = new System.Drawing.Size(66, 21);
            this.height.TabIndex = 8;
            this.height.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.height.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.height.ValueChanged += new System.EventHandler(this.height_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(128, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "Height";
            // 
            // width
            // 
            this.width.Location = new System.Drawing.Point(50, 58);
            this.width.Maximum = new decimal(new int[] {
            320,
            0,
            0,
            0});
            this.width.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.width.Name = "width";
            this.width.Size = new System.Drawing.Size(66, 21);
            this.width.TabIndex = 6;
            this.width.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.width.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.width.ValueChanged += new System.EventHandler(this.width_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Width";
            // 
            // animation
            // 
            this.animation.Controls.Add(this.direction);
            this.animation.Controls.Add(this.label5);
            this.animation.Controls.Add(this.speed);
            this.animation.Controls.Add(this.label4);
            this.animation.Enabled = false;
            this.animation.Location = new System.Drawing.Point(9, 119);
            this.animation.Name = "animation";
            this.animation.Size = new System.Drawing.Size(236, 89);
            this.animation.TabIndex = 4;
            this.animation.TabStop = false;
            this.animation.Text = "Animation";
            // 
            // direction
            // 
            this.direction.DisplayMember = "0";
            this.direction.FormattingEnabled = true;
            this.direction.Items.AddRange(new object[] {
            "Horizontal",
            "Vertical"});
            this.direction.Location = new System.Drawing.Point(109, 55);
            this.direction.Name = "direction";
            this.direction.Size = new System.Drawing.Size(119, 23);
            this.direction.TabIndex = 6;
            this.direction.SelectedIndexChanged += new System.EventHandler(this.direction_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Direction";
            // 
            // speed
            // 
            this.speed.Location = new System.Drawing.Point(136, 20);
            this.speed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(63, 21);
            this.speed.TabIndex = 4;
            this.speed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.speed.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.speed.ValueChanged += new System.EventHandler(this.speed_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Speed";
            // 
            // animates
            // 
            this.animates.AutoSize = true;
            this.animates.Location = new System.Drawing.Point(9, 94);
            this.animates.Name = "animates";
            this.animates.Size = new System.Drawing.Size(77, 19);
            this.animates.TabIndex = 2;
            this.animates.Text = "Animates";
            this.animates.UseVisualStyleBackColor = true;
            this.animates.CheckedChanged += new System.EventHandler(this.animates_CheckedChanged);
            // 
            // source
            // 
            this.source.Location = new System.Drawing.Point(73, 24);
            this.source.Name = "source";
            this.source.Size = new System.Drawing.Size(165, 21);
            this.source.TabIndex = 1;
            this.source.TextChanged += new System.EventHandler(this.source_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Source";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(166, 371);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Remove Element";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 371);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Add Element";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(166, 39);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Remove Action";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 37);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "Add Action";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // save
            // 
            this.save.ActiveLinkColor = System.Drawing.Color.Blue;
            this.save.AutoSize = true;
            this.save.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.save.LinkColor = System.Drawing.Color.Blue;
            this.save.Location = new System.Drawing.Point(575, 381);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(32, 13);
            this.save.TabIndex = 11;
            this.save.TabStop = true;
            this.save.Text = "Save";
            this.save.VisitedLinkColor = System.Drawing.Color.Blue;
            this.save.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.save_LinkClicked);
            // 
            // animationTimer
            // 
            this.animationTimer.Interval = 16;
            this.animationTimer.Tick += new System.EventHandler(this.animationTimer_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.vitality);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.wisdom);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.intelligence);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.toughness);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.agility);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.power);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 92);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scaling";
            // 
            // vitality
            // 
            this.vitality.DecimalPlaces = 3;
            this.vitality.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.vitality.Location = new System.Drawing.Point(177, 64);
            this.vitality.Name = "vitality";
            this.vitality.Size = new System.Drawing.Size(61, 21);
            this.vitality.TabIndex = 11;
            this.vitality.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.vitality.ValueChanged += new System.EventHandler(this.vitality_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(123, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 15);
            this.label11.TabIndex = 10;
            this.label11.Text = "Vitality";
            // 
            // wisdom
            // 
            this.wisdom.DecimalPlaces = 3;
            this.wisdom.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.wisdom.Location = new System.Drawing.Point(177, 40);
            this.wisdom.Name = "wisdom";
            this.wisdom.Size = new System.Drawing.Size(61, 21);
            this.wisdom.TabIndex = 9;
            this.wisdom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.wisdom.ValueChanged += new System.EventHandler(this.wisdom_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(123, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 15);
            this.label12.TabIndex = 8;
            this.label12.Text = "Wisdom";
            // 
            // intelligence
            // 
            this.intelligence.DecimalPlaces = 3;
            this.intelligence.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.intelligence.Location = new System.Drawing.Point(177, 15);
            this.intelligence.Name = "intelligence";
            this.intelligence.Size = new System.Drawing.Size(61, 21);
            this.intelligence.TabIndex = 7;
            this.intelligence.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.intelligence.ValueChanged += new System.EventHandler(this.intelligence_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(123, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 15);
            this.label13.TabIndex = 6;
            this.label13.Text = "Intellig.";
            // 
            // toughness
            // 
            this.toughness.DecimalPlaces = 3;
            this.toughness.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.toughness.Location = new System.Drawing.Point(55, 64);
            this.toughness.Name = "toughness";
            this.toughness.Size = new System.Drawing.Size(61, 21);
            this.toughness.TabIndex = 5;
            this.toughness.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toughness.ValueChanged += new System.EventHandler(this.toughness_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 15);
            this.label10.TabIndex = 4;
            this.label10.Text = "Tough.";
            // 
            // agility
            // 
            this.agility.DecimalPlaces = 3;
            this.agility.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.agility.Location = new System.Drawing.Point(55, 40);
            this.agility.Name = "agility";
            this.agility.Size = new System.Drawing.Size(61, 21);
            this.agility.TabIndex = 3;
            this.agility.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.agility.ValueChanged += new System.EventHandler(this.agility_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 15);
            this.label9.TabIndex = 2;
            this.label9.Text = "Agility";
            // 
            // power
            // 
            this.power.DecimalPlaces = 3;
            this.power.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.power.Location = new System.Drawing.Point(55, 15);
            this.power.Name = "power";
            this.power.Size = new System.Drawing.Size(61, 21);
            this.power.TabIndex = 1;
            this.power.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.power.ValueChanged += new System.EventHandler(this.power_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Power";
            // 
            // Actions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 403);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.save);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.properties);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.charSelect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.actionSelect);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(635, 442);
            this.MinimumSize = new System.Drawing.Size(635, 442);
            this.Name = "Actions";
            this.Text = "WebClash Server - Actions";
            this.Load += new System.EventHandler(this.Actions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.properties.ResumeLayout(false);
            this.properties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.width)).EndInit();
            this.animation.ResumeLayout(false);
            this.animation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speed)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vitality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wisdom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intelligence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toughness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.agility)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.power)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox actionSelect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox charSelect;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.GroupBox properties;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.LinkLabel save;
        private System.Windows.Forms.TextBox source;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox animation;
        private System.Windows.Forms.NumericUpDown speed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox animates;
        private System.Windows.Forms.ComboBox direction;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown width;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown height;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer animationTimer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown power;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown vitality;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown wisdom;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown intelligence;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown toughness;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown agility;
        private System.Windows.Forms.Label label9;
    }
}