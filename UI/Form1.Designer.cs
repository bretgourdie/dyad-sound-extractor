namespace UI
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
            this.label1 = new System.Windows.Forms.Label();
            this.soundBinLocationTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.browseSoundBinButton = new System.Windows.Forms.Button();
            this.reloadPackagedSoundsButton = new System.Windows.Forms.Button();
            this.packagedSoundFilesListView = new System.Windows.Forms.ListView();
            this.targetFileFormatComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.converterLocationLabel = new System.Windows.Forms.Label();
            this.converterLocationTextBox = new System.Windows.Forms.TextBox();
            this.browseConverterButton = new System.Windows.Forms.Button();
            this.organizeSubdirectoriesCheckBox = new System.Windows.Forms.CheckBox();
            this.subdirectoryPatternTextBox = new System.Windows.Forms.TextBox();
            this.padFileNumberCheckBox = new System.Windows.Forms.CheckBox();
            this.extractButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.saveParametersOnExitCheckBox = new System.Windows.Forms.CheckBox();
            this.saveSettingsButton = new System.Windows.Forms.Button();
            this.selectAllButton = new System.Windows.Forms.Button();
            this.deselectAllButton = new System.Windows.Forms.Button();
            this.outputLocationTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.browseOutputLocationButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(158, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dyad Sound Extractor";
            // 
            // soundBinLocationTextBox
            // 
            this.soundBinLocationTextBox.Location = new System.Drawing.Point(133, 64);
            this.soundBinLocationTextBox.Name = "soundBinLocationTextBox";
            this.soundBinLocationTextBox.Size = new System.Drawing.Size(304, 20);
            this.soundBinLocationTextBox.TabIndex = 3;
            this.soundBinLocationTextBox.Validated += new System.EventHandler(this.soundBinLocationTextBox_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Dyad Soundbin Folder:";
            // 
            // browseSoundBinButton
            // 
            this.browseSoundBinButton.Location = new System.Drawing.Point(443, 62);
            this.browseSoundBinButton.Name = "browseSoundBinButton";
            this.browseSoundBinButton.Size = new System.Drawing.Size(75, 23);
            this.browseSoundBinButton.TabIndex = 4;
            this.browseSoundBinButton.Text = "Browse...";
            this.browseSoundBinButton.UseVisualStyleBackColor = true;
            this.browseSoundBinButton.Click += new System.EventHandler(this.browseSoundBinButton_Click);
            // 
            // reloadPackagedSoundsButton
            // 
            this.reloadPackagedSoundsButton.Location = new System.Drawing.Point(524, 62);
            this.reloadPackagedSoundsButton.Name = "reloadPackagedSoundsButton";
            this.reloadPackagedSoundsButton.Size = new System.Drawing.Size(75, 23);
            this.reloadPackagedSoundsButton.TabIndex = 5;
            this.reloadPackagedSoundsButton.Text = "Reload";
            this.reloadPackagedSoundsButton.UseVisualStyleBackColor = true;
            this.reloadPackagedSoundsButton.Click += new System.EventHandler(this.reloadPackagedSoundsButton_Click);
            // 
            // packagedSoundFilesListView
            // 
            this.packagedSoundFilesListView.CheckBoxes = true;
            this.packagedSoundFilesListView.HideSelection = false;
            this.packagedSoundFilesListView.Location = new System.Drawing.Point(15, 90);
            this.packagedSoundFilesListView.Name = "packagedSoundFilesListView";
            this.packagedSoundFilesListView.Size = new System.Drawing.Size(584, 214);
            this.packagedSoundFilesListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.packagedSoundFilesListView.TabIndex = 0;
            this.packagedSoundFilesListView.UseCompatibleStateImageBehavior = false;
            this.packagedSoundFilesListView.View = System.Windows.Forms.View.SmallIcon;
            this.packagedSoundFilesListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.packagedSoundFilesListView_ItemChecked);
            // 
            // targetFileFormatComboBox
            // 
            this.targetFileFormatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.targetFileFormatComboBox.FormattingEnabled = true;
            this.targetFileFormatComboBox.Items.AddRange(new object[] {
            ".wav",
            ".pcm"});
            this.targetFileFormatComboBox.Location = new System.Drawing.Point(116, 339);
            this.targetFileFormatComboBox.Name = "targetFileFormatComboBox";
            this.targetFileFormatComboBox.Size = new System.Drawing.Size(72, 21);
            this.targetFileFormatComboBox.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 342);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Target File Format:";
            // 
            // converterLocationLabel
            // 
            this.converterLocationLabel.AutoSize = true;
            this.converterLocationLabel.Location = new System.Drawing.Point(203, 342);
            this.converterLocationLabel.Name = "converterLocationLabel";
            this.converterLocationLabel.Size = new System.Drawing.Size(100, 13);
            this.converterLocationLabel.TabIndex = 10;
            this.converterLocationLabel.Text = "Converter Location:";
            this.converterLocationLabel.Visible = false;
            // 
            // converterLocationTextBox
            // 
            this.converterLocationTextBox.Location = new System.Drawing.Point(309, 339);
            this.converterLocationTextBox.Name = "converterLocationTextBox";
            this.converterLocationTextBox.Size = new System.Drawing.Size(212, 20);
            this.converterLocationTextBox.TabIndex = 11;
            this.converterLocationTextBox.Visible = false;
            // 
            // browseConverterButton
            // 
            this.browseConverterButton.Location = new System.Drawing.Point(527, 337);
            this.browseConverterButton.Name = "browseConverterButton";
            this.browseConverterButton.Size = new System.Drawing.Size(75, 23);
            this.browseConverterButton.TabIndex = 12;
            this.browseConverterButton.Text = "Browse...";
            this.browseConverterButton.UseVisualStyleBackColor = true;
            this.browseConverterButton.Visible = false;
            this.browseConverterButton.Click += new System.EventHandler(this.browseConverterButton_Click);
            // 
            // organizeSubdirectoriesCheckBox
            // 
            this.organizeSubdirectoriesCheckBox.AutoSize = true;
            this.organizeSubdirectoriesCheckBox.Checked = true;
            this.organizeSubdirectoriesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.organizeSubdirectoriesCheckBox.Location = new System.Drawing.Point(15, 395);
            this.organizeSubdirectoriesCheckBox.Name = "organizeSubdirectoriesCheckBox";
            this.organizeSubdirectoriesCheckBox.Size = new System.Drawing.Size(206, 17);
            this.organizeSubdirectoriesCheckBox.TabIndex = 16;
            this.organizeSubdirectoriesCheckBox.Text = "Organize Files in Subdirectories Using:";
            this.organizeSubdirectoriesCheckBox.UseVisualStyleBackColor = true;
            this.organizeSubdirectoriesCheckBox.CheckedChanged += new System.EventHandler(this.organizeSubdirectoriesCheckBox_CheckedChanged);
            // 
            // subdirectoryPatternTextBox
            // 
            this.subdirectoryPatternTextBox.Location = new System.Drawing.Point(227, 393);
            this.subdirectoryPatternTextBox.Name = "subdirectoryPatternTextBox";
            this.subdirectoryPatternTextBox.Size = new System.Drawing.Size(174, 20);
            this.subdirectoryPatternTextBox.TabIndex = 17;
            this.subdirectoryPatternTextBox.Text = "Extracted_%FileName%";
            // 
            // padFileNumberCheckBox
            // 
            this.padFileNumberCheckBox.AutoSize = true;
            this.padFileNumberCheckBox.Checked = true;
            this.padFileNumberCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.padFileNumberCheckBox.Location = new System.Drawing.Point(15, 418);
            this.padFileNumberCheckBox.Name = "padFileNumberCheckBox";
            this.padFileNumberCheckBox.Size = new System.Drawing.Size(195, 17);
            this.padFileNumberCheckBox.TabIndex = 18;
            this.padFileNumberCheckBox.Text = "Pad %RawFileNumber% with zeroes";
            this.padFileNumberCheckBox.UseVisualStyleBackColor = true;
            // 
            // extractButton
            // 
            this.extractButton.Enabled = false;
            this.extractButton.Location = new System.Drawing.Point(12, 464);
            this.extractButton.Name = "extractButton";
            this.extractButton.Size = new System.Drawing.Size(98, 35);
            this.extractButton.TabIndex = 20;
            this.extractButton.Text = "Extract Files";
            this.extractButton.UseVisualStyleBackColor = true;
            this.extractButton.Click += new System.EventHandler(this.parseButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(504, 464);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(98, 35);
            this.exitButton.TabIndex = 23;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // saveParametersOnExitCheckBox
            // 
            this.saveParametersOnExitCheckBox.AutoSize = true;
            this.saveParametersOnExitCheckBox.Checked = true;
            this.saveParametersOnExitCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.saveParametersOnExitCheckBox.Location = new System.Drawing.Point(356, 474);
            this.saveParametersOnExitCheckBox.Name = "saveParametersOnExitCheckBox";
            this.saveParametersOnExitCheckBox.Size = new System.Drawing.Size(142, 17);
            this.saveParametersOnExitCheckBox.TabIndex = 22;
            this.saveParametersOnExitCheckBox.Text = "Save Parameters on Exit";
            this.saveParametersOnExitCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveSettingsButton
            // 
            this.saveSettingsButton.Location = new System.Drawing.Point(116, 464);
            this.saveSettingsButton.Name = "saveSettingsButton";
            this.saveSettingsButton.Size = new System.Drawing.Size(98, 35);
            this.saveSettingsButton.TabIndex = 21;
            this.saveSettingsButton.Text = "Save These Parameters";
            this.saveSettingsButton.UseVisualStyleBackColor = true;
            this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
            // 
            // selectAllButton
            // 
            this.selectAllButton.Location = new System.Drawing.Point(15, 310);
            this.selectAllButton.Name = "selectAllButton";
            this.selectAllButton.Size = new System.Drawing.Size(75, 23);
            this.selectAllButton.TabIndex = 6;
            this.selectAllButton.Text = "Select All";
            this.selectAllButton.UseVisualStyleBackColor = true;
            this.selectAllButton.Click += new System.EventHandler(this.selectAllButton_Click);
            // 
            // deselectAllButton
            // 
            this.deselectAllButton.Location = new System.Drawing.Point(96, 310);
            this.deselectAllButton.Name = "deselectAllButton";
            this.deselectAllButton.Size = new System.Drawing.Size(75, 23);
            this.deselectAllButton.TabIndex = 7;
            this.deselectAllButton.Text = "Deselect All";
            this.deselectAllButton.UseVisualStyleBackColor = true;
            this.deselectAllButton.Click += new System.EventHandler(this.deselectAllButton_Click);
            // 
            // outputLocationTextBox
            // 
            this.outputLocationTextBox.Location = new System.Drawing.Point(116, 367);
            this.outputLocationTextBox.Name = "outputLocationTextBox";
            this.outputLocationTextBox.Size = new System.Drawing.Size(405, 20);
            this.outputLocationTextBox.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 370);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Output Location:";
            // 
            // browseOutputLocationButton
            // 
            this.browseOutputLocationButton.Location = new System.Drawing.Point(527, 366);
            this.browseOutputLocationButton.Name = "browseOutputLocationButton";
            this.browseOutputLocationButton.Size = new System.Drawing.Size(75, 23);
            this.browseOutputLocationButton.TabIndex = 15;
            this.browseOutputLocationButton.Text = "Browse...";
            this.browseOutputLocationButton.UseVisualStyleBackColor = true;
            this.browseOutputLocationButton.Click += new System.EventHandler(this.browseOutputLocationButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 511);
            this.Controls.Add(this.browseOutputLocationButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.outputLocationTextBox);
            this.Controls.Add(this.deselectAllButton);
            this.Controls.Add(this.selectAllButton);
            this.Controls.Add(this.saveSettingsButton);
            this.Controls.Add(this.saveParametersOnExitCheckBox);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.extractButton);
            this.Controls.Add(this.padFileNumberCheckBox);
            this.Controls.Add(this.subdirectoryPatternTextBox);
            this.Controls.Add(this.organizeSubdirectoriesCheckBox);
            this.Controls.Add(this.browseConverterButton);
            this.Controls.Add(this.converterLocationTextBox);
            this.Controls.Add(this.converterLocationLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.targetFileFormatComboBox);
            this.Controls.Add(this.packagedSoundFilesListView);
            this.Controls.Add(this.reloadPackagedSoundsButton);
            this.Controls.Add(this.browseSoundBinButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.soundBinLocationTextBox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Dyad Sount Extractor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox soundBinLocationTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button browseSoundBinButton;
        private System.Windows.Forms.Button reloadPackagedSoundsButton;
        private System.Windows.Forms.ListView packagedSoundFilesListView;
        private System.Windows.Forms.ComboBox targetFileFormatComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label converterLocationLabel;
        private System.Windows.Forms.TextBox converterLocationTextBox;
        private System.Windows.Forms.Button browseConverterButton;
        private System.Windows.Forms.CheckBox organizeSubdirectoriesCheckBox;
        private System.Windows.Forms.TextBox subdirectoryPatternTextBox;
        private System.Windows.Forms.CheckBox padFileNumberCheckBox;
        private System.Windows.Forms.Button extractButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.CheckBox saveParametersOnExitCheckBox;
        private System.Windows.Forms.Button saveSettingsButton;
        private System.Windows.Forms.Button selectAllButton;
        private System.Windows.Forms.Button deselectAllButton;
        private System.Windows.Forms.TextBox outputLocationTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button browseOutputLocationButton;
    }
}

