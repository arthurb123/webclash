﻿using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WebClashServer.Classes;

namespace WebClashServer.Editors
{
    public partial class DialogueProperties : Form
    {
        public DialogueItem current;

        public DialogueProperties(DialogueItem di)
        {
            InitializeComponent();

            current = di;

            portraitSource.Text = current.portrait;
            AttemptSetPortrait(portraitSource.Text);

            dialogue.Text = current.text;

            entryPoint.Checked = current.entry;

            LoadOptions();
        }

        private void DialogueItem_Load(object sender, EventArgs e)
        {
            //...
        }

        private void portraitSource_TextChanged(object sender, EventArgs e)
        {
            AttemptSetPortrait(portraitSource.Text);
        }

        private void AttemptSetPortrait(string src)
        {
            try
            {
                if (!File.Exists(Program.main.ClientLocation + src))
                {
                    current.portrait = null;

                    return;
                }

                portrait.BackgroundImage = Image.FromFile(Program.main.ClientLocation + src);

                current.portrait = src;
            }
            catch (Exception exc)
            {
                Logger.Error("Could not load portrait image: ", exc);
            }
        }

        private void dialogue_TextChanged(object sender, EventArgs e)
        {
            current.text = dialogue.Text;
        }

        private void entryPoint_CheckedChanged(object sender, EventArgs e)
        {
            current.entry = entryPoint.Checked;
        }

        private void LoadOptions()
        {
            optionList.Items.Clear();

            foreach (DialogueOption d in current.options)
                optionList.Items.Add(d);

            if (optionList.Items.Count > 0)
            {
                if (optionList.SelectedIndex == -1)
                    optionList.SelectedItem = optionList.Items[0];
                else
                    optionList.SelectedItem = optionList.Items[optionList.SelectedIndex];
            }
        }

        private void newLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            current.options.Add(new DialogueOption(-1));

            LoadOptions();
        }

        private void optionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            optionText.Text = current.options[optionList.SelectedIndex].text;

            optionNext.Value = current.options[optionList.SelectedIndex].next;
        }

        private void delete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            current.options.RemoveAt(optionList.SelectedIndex);

            LoadOptions();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            current.options[optionList.SelectedIndex].text = optionText.Text;
            current.options[optionList.SelectedIndex].next = (int)optionNext.Value;

            LoadOptions();
        }
    }
}
