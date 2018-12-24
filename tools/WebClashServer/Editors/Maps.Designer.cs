﻿namespace WebClashServer.Editors
{
    partial class Maps
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Maps));
            this.mapList = new System.Windows.Forms.ListBox();
            this.import = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fixTilesets = new System.Windows.Forms.LinkLabel();
            this.mapTilesets = new System.Windows.Forms.Label();
            this.mapSize = new System.Windows.Forms.Label();
            this.mapID = new System.Windows.Forms.Label();
            this.mapTilesetStatus = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.help = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapList
            // 
            this.mapList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mapList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapList.FormattingEnabled = true;
            this.mapList.ItemHeight = 15;
            this.mapList.Location = new System.Drawing.Point(12, 12);
            this.mapList.Name = "mapList";
            this.mapList.Size = new System.Drawing.Size(150, 137);
            this.mapList.TabIndex = 0;
            this.mapList.SelectedIndexChanged += new System.EventHandler(this.mapList_SelectedIndexChanged);
            // 
            // import
            // 
            this.import.Location = new System.Drawing.Point(12, 155);
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(52, 23);
            this.import.TabIndex = 1;
            this.import.Text = "Import";
            this.import.UseVisualStyleBackColor = true;
            this.import.Click += new System.EventHandler(this.import_Click);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(110, 155);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(52, 23);
            this.delete.TabIndex = 2;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fixTilesets);
            this.groupBox1.Controls.Add(this.mapTilesets);
            this.groupBox1.Controls.Add(this.mapSize);
            this.groupBox1.Controls.Add(this.mapID);
            this.groupBox1.Controls.Add(this.mapTilesetStatus);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(169, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(237, 137);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Map Information";
            // 
            // fixTilesets
            // 
            this.fixTilesets.ActiveLinkColor = System.Drawing.Color.Blue;
            this.fixTilesets.AutoSize = true;
            this.fixTilesets.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.fixTilesets.Location = new System.Drawing.Point(208, 113);
            this.fixTilesets.Name = "fixTilesets";
            this.fixTilesets.Size = new System.Drawing.Size(23, 15);
            this.fixTilesets.TabIndex = 10;
            this.fixTilesets.TabStop = true;
            this.fixTilesets.Text = "Fix";
            this.fixTilesets.Visible = false;
            this.fixTilesets.VisitedLinkColor = System.Drawing.Color.Blue;
            this.fixTilesets.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.fixTilesets_LinkClicked);
            // 
            // mapTilesets
            // 
            this.mapTilesets.Location = new System.Drawing.Point(72, 90);
            this.mapTilesets.Name = "mapTilesets";
            this.mapTilesets.Size = new System.Drawing.Size(159, 15);
            this.mapTilesets.TabIndex = 9;
            this.mapTilesets.Text = "-";
            this.mapTilesets.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // mapSize
            // 
            this.mapSize.Location = new System.Drawing.Point(72, 54);
            this.mapSize.Name = "mapSize";
            this.mapSize.Size = new System.Drawing.Size(159, 15);
            this.mapSize.TabIndex = 7;
            this.mapSize.Text = "-";
            this.mapSize.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // mapID
            // 
            this.mapID.Location = new System.Drawing.Point(72, 24);
            this.mapID.Name = "mapID";
            this.mapID.Size = new System.Drawing.Size(159, 15);
            this.mapID.TabIndex = 6;
            this.mapID.Text = "-";
            this.mapID.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // mapTilesetStatus
            // 
            this.mapTilesetStatus.AutoSize = true;
            this.mapTilesetStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapTilesetStatus.Location = new System.Drawing.Point(11, 113);
            this.mapTilesetStatus.Name = "mapTilesetStatus";
            this.mapTilesetStatus.Size = new System.Drawing.Size(155, 15);
            this.mapTilesetStatus.TabIndex = 5;
            this.mapTilesetStatus.Text = "Not all Tilesets are present.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tilesets:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 0;
            // 
            // help
            // 
            this.help.Location = new System.Drawing.Point(349, 155);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(58, 23);
            this.help.TabIndex = 4;
            this.help.Text = "Help";
            this.help.UseVisualStyleBackColor = true;
            this.help.Click += new System.EventHandler(this.help_Click);
            // 
            // Maps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 186);
            this.Controls.Add(this.help);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.import);
            this.Controls.Add(this.mapList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(435, 225);
            this.MinimumSize = new System.Drawing.Size(435, 225);
            this.Name = "Maps";
            this.Text = "WebClash Server - Maps";
            this.Load += new System.EventHandler(this.Maps_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox mapList;
        private System.Windows.Forms.Button import;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label mapTilesetStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button help;
        private System.Windows.Forms.Label mapSize;
        private System.Windows.Forms.Label mapID;
        private System.Windows.Forms.Label mapTilesets;
        private System.Windows.Forms.LinkLabel fixTilesets;
    }
}