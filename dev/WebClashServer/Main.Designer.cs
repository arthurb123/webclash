﻿namespace WebClashServer
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.output = new System.Windows.Forms.RichTextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.Label();
            this.settings = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.charactersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NPCsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.effectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.questsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managePluginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.restartAfterNewChangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.obfuscateClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.permissions = new System.Windows.Forms.Button();
            this.interactionPanel = new System.Windows.Forms.Panel();
            this.inputCommand = new System.Windows.Forms.TextBox();
            this.generateExpTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.interactionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // output
            // 
            this.output.BackColor = System.Drawing.SystemColors.Control;
            this.output.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.output.Location = new System.Drawing.Point(0, 24);
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.Size = new System.Drawing.Size(404, 196);
            this.output.TabIndex = 0;
            this.output.Text = "";
            // 
            // startButton
            // 
            this.startButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.startButton.Location = new System.Drawing.Point(0, 0);
            this.startButton.MaximumSize = new System.Drawing.Size(120, 21);
            this.startButton.MinimumSize = new System.Drawing.Size(120, 21);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(120, 21);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // status
            // 
            this.status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.status.BackColor = System.Drawing.SystemColors.Control;
            this.status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status.Location = new System.Drawing.Point(208, 2);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(193, 20);
            this.status.TabIndex = 2;
            this.status.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // settings
            // 
            this.settings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("settings.BackgroundImage")));
            this.settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.settings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settings.Dock = System.Windows.Forms.DockStyle.Right;
            this.settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settings.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.settings.Location = new System.Drawing.Point(362, 0);
            this.settings.MaximumSize = new System.Drawing.Size(21, 21);
            this.settings.MinimumSize = new System.Drawing.Size(21, 21);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(21, 21);
            this.settings.TabIndex = 3;
            this.settings.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.settings.UseVisualStyleBackColor = true;
            this.settings.Click += new System.EventHandler(this.settings_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(404, 24);
            this.menuStrip.TabIndex = 4;
            this.menuStrip.Text = "menuStrip1";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapsToolStripMenuItem,
            this.charactersToolStripMenuItem,
            this.NPCsToolStripMenuItem,
            this.actionsToolStripMenuItem,
            this.effectsToolStripMenuItem,
            this.itemsToolStripMenuItem,
            this.questsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // mapsToolStripMenuItem
            // 
            this.mapsToolStripMenuItem.Name = "mapsToolStripMenuItem";
            this.mapsToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.mapsToolStripMenuItem.Text = "Maps";
            this.mapsToolStripMenuItem.ToolTipText = "Edit the maps";
            this.mapsToolStripMenuItem.Click += new System.EventHandler(this.mapsToolStripMenuItem_Click);
            // 
            // charactersToolStripMenuItem
            // 
            this.charactersToolStripMenuItem.Name = "charactersToolStripMenuItem";
            this.charactersToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.charactersToolStripMenuItem.Text = "Characters";
            this.charactersToolStripMenuItem.ToolTipText = "Edit the characters";
            this.charactersToolStripMenuItem.Click += new System.EventHandler(this.charactersToolStripMenuItem_Click);
            // 
            // NPCsToolStripMenuItem
            // 
            this.NPCsToolStripMenuItem.Name = "NPCsToolStripMenuItem";
            this.NPCsToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.NPCsToolStripMenuItem.Text = "NPCs";
            this.NPCsToolStripMenuItem.ToolTipText = "Edit the NPCs";
            this.NPCsToolStripMenuItem.Click += new System.EventHandler(this.NPCsToolStripMenuItem_Click);
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.actionsToolStripMenuItem.Text = "Actions";
            this.actionsToolStripMenuItem.ToolTipText = "Edit the actions";
            this.actionsToolStripMenuItem.Click += new System.EventHandler(this.actionsToolStripMenuItem_Click);
            // 
            // effectsToolStripMenuItem
            // 
            this.effectsToolStripMenuItem.Name = "effectsToolStripMenuItem";
            this.effectsToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.effectsToolStripMenuItem.Text = "Status Effects";
            this.effectsToolStripMenuItem.Click += new System.EventHandler(this.effectsToolStripMenuItem_Click);
            // 
            // itemsToolStripMenuItem
            // 
            this.itemsToolStripMenuItem.Name = "itemsToolStripMenuItem";
            this.itemsToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.itemsToolStripMenuItem.Text = "Items";
            this.itemsToolStripMenuItem.ToolTipText = "Edit the items";
            this.itemsToolStripMenuItem.Click += new System.EventHandler(this.itemsToolStripMenuItem_Click);
            // 
            // questsToolStripMenuItem
            // 
            this.questsToolStripMenuItem.Name = "questsToolStripMenuItem";
            this.questsToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.questsToolStripMenuItem.Text = "Quests";
            this.questsToolStripMenuItem.ToolTipText = "Edit the quests";
            this.questsToolStripMenuItem.Click += new System.EventHandler(this.questsToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.managePluginsToolStripMenuItem,
            this.toolStripSeparator1,
            this.restartAfterNewChangesToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // managePluginsToolStripMenuItem
            // 
            this.managePluginsToolStripMenuItem.Name = "managePluginsToolStripMenuItem";
            this.managePluginsToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.managePluginsToolStripMenuItem.Text = "Manage Plugins";
            this.managePluginsToolStripMenuItem.Click += new System.EventHandler(this.managePluginsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // restartAfterNewChangesToolStripMenuItem
            // 
            this.restartAfterNewChangesToolStripMenuItem.Checked = true;
            this.restartAfterNewChangesToolStripMenuItem.CheckOnClick = true;
            this.restartAfterNewChangesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.restartAfterNewChangesToolStripMenuItem.Name = "restartAfterNewChangesToolStripMenuItem";
            this.restartAfterNewChangesToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.restartAfterNewChangesToolStripMenuItem.Text = "Restart after changes";
            this.restartAfterNewChangesToolStripMenuItem.ToolTipText = "Enable or disable server restarting after server data has changed";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateExpTableToolStripMenuItem,
            this.obfuscateClientToolStripMenuItem,
            this.resetDataToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // obfuscateClientToolStripMenuItem
            // 
            this.obfuscateClientToolStripMenuItem.Name = "obfuscateClientToolStripMenuItem";
            this.obfuscateClientToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.obfuscateClientToolStripMenuItem.Text = "Obfuscate Client";
            this.obfuscateClientToolStripMenuItem.Click += new System.EventHandler(this.obfuscateClientToolStripMenuItem_Click);
            // 
            // resetDataToolStripMenuItem
            // 
            this.resetDataToolStripMenuItem.Name = "resetDataToolStripMenuItem";
            this.resetDataToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.resetDataToolStripMenuItem.Text = "Reset Data";
            this.resetDataToolStripMenuItem.ToolTipText = "Allows for server data resetting";
            this.resetDataToolStripMenuItem.Click += new System.EventHandler(this.resetDataToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // permissions
            // 
            this.permissions.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("permissions.BackgroundImage")));
            this.permissions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.permissions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.permissions.Dock = System.Windows.Forms.DockStyle.Right;
            this.permissions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.permissions.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.permissions.Location = new System.Drawing.Point(383, 0);
            this.permissions.MaximumSize = new System.Drawing.Size(21, 21);
            this.permissions.MinimumSize = new System.Drawing.Size(21, 21);
            this.permissions.Name = "permissions";
            this.permissions.Size = new System.Drawing.Size(21, 21);
            this.permissions.TabIndex = 5;
            this.permissions.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.permissions.UseVisualStyleBackColor = true;
            this.permissions.Click += new System.EventHandler(this.permissions_Click);
            // 
            // interactionPanel
            // 
            this.interactionPanel.Controls.Add(this.inputCommand);
            this.interactionPanel.Controls.Add(this.startButton);
            this.interactionPanel.Controls.Add(this.settings);
            this.interactionPanel.Controls.Add(this.permissions);
            this.interactionPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.interactionPanel.Location = new System.Drawing.Point(0, 220);
            this.interactionPanel.Name = "interactionPanel";
            this.interactionPanel.Size = new System.Drawing.Size(404, 21);
            this.interactionPanel.TabIndex = 6;
            // 
            // inputCommand
            // 
            this.inputCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputCommand.Location = new System.Drawing.Point(120, 0);
            this.inputCommand.Name = "inputCommand";
            this.inputCommand.Size = new System.Drawing.Size(242, 20);
            this.inputCommand.TabIndex = 6;
            // 
            // generateExpTableToolStripMenuItem
            // 
            this.generateExpTableToolStripMenuItem.Name = "generateExpTableToolStripMenuItem";
            this.generateExpTableToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.generateExpTableToolStripMenuItem.Text = "Generate Exp. Table";
            this.generateExpTableToolStripMenuItem.Click += new System.EventHandler(this.generateExpTableToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(404, 241);
            this.Controls.Add(this.output);
            this.Controls.Add(this.interactionPanel);
            this.Controls.Add(this.status);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(420, 280);
            this.Name = "Main";
            this.Text = "WebClash";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.interactionPanel.ResumeLayout(false);
            this.interactionPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox output;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Button settings;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem charactersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NPCsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemsToolStripMenuItem;
        private System.Windows.Forms.Button permissions;
        private System.Windows.Forms.Panel interactionPanel;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem questsToolStripMenuItem;
        private System.Windows.Forms.TextBox inputCommand;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartAfterNewChangesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem obfuscateClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem managePluginsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem effectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateExpTableToolStripMenuItem;
    }
}

