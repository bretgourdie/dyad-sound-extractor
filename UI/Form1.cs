using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ExtractionLibrary;
using System.Diagnostics;

namespace UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadSettings();

            var path = soundBinLocationTextBox.Text;

            populateListViewIfDirectoryExists(path, packagedSoundFilesListView.Items);
            setParseButtonEnabled(packagedSoundFilesListView.CheckedItems);
        }

        /// <summary>
        /// Populates "items" with files found at folder "path" if "path" exists.
        /// </summary>
        /// <param name="path">A Windows folder.</param>
        /// <param name="items">A collection to add to.</param>
        private void populateListViewIfDirectoryExists(
            string path,
            ListView.ListViewItemCollection items)
        {
            if (Directory.Exists(path))
            {
                populateListView(path, items);
            }
        }

        /// <summary>
        /// Populates "items" with files found at folder "path".
        /// </summary>
        /// <param name="path">A Windows folder.</param>
        /// <param name="items">A collection to add to.</param>
        private void populateListView(
            string path,
            ListView.ListViewItemCollection items)
        {
            var filePaths = Directory.GetFiles(path);

            items.Clear();

            foreach (var filePath in filePaths)
            {
                var filePart = Path.GetFileName(filePath);
                items.Add(filePart);
            }
        }

        /// <summary>
        /// Loads settings from the User Settings mechanism in the
        /// Properties.Settings.Default object.
        /// </summary>
        private void loadSettings()
        {
            soundBinLocationTextBox.Text = Properties.Settings.Default.SoundBinLocation;
            targetFileFormatComboBox.Text = Properties.Settings.Default.TargetFileFormat;
            converterLocationTextBox.Text = Properties.Settings.Default.ConverterLocation;
            organizeSubdirectoriesCheckBox.Checked = Properties.Settings.Default.OrganizeInSubdirectories;
            subdirectoryPatternTextBox.Text = Properties.Settings.Default.SubdirectoryOrganization;
            padFileNumberCheckBox.Checked = Properties.Settings.Default.PadRawFileNumberWithZeroes;
            saveParametersOnExitCheckBox.Checked = Properties.Settings.Default.SaveParametersOnExit;
            outputLocationTextBox.Text = Properties.Settings.Default.OutputLocation;
        }

        /// <summary>
        /// Saves settings into the User Settings mechanism in the
        /// Properties.Settings.Default object.
        /// </summary>
        private void saveSettings() 
        {
            Properties.Settings.Default.SoundBinLocation = soundBinLocationTextBox.Text;
            Properties.Settings.Default.TargetFileFormat = targetFileFormatComboBox.Text;
            Properties.Settings.Default.ConverterLocation = converterLocationTextBox.Text;
            Properties.Settings.Default.OrganizeInSubdirectories = organizeSubdirectoriesCheckBox.Checked;
            Properties.Settings.Default.SubdirectoryOrganization = subdirectoryPatternTextBox.Text;
            Properties.Settings.Default.PadRawFileNumberWithZeroes = padFileNumberCheckBox.Checked;
            Properties.Settings.Default.SaveParametersOnExit = saveParametersOnExitCheckBox.Checked;
            Properties.Settings.Default.OutputLocation = outputLocationTextBox.Text;

            Properties.Settings.Default.Save();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (saveParametersOnExitCheckBox.Checked)
            {
                saveSettings();
            }
        }

        /// <summary>
        /// Shows or hides the Converter information if target file format
        ///  needs converted.
        /// </summary>
        /// <param name="targetFileFormat">Format requested.</param>
        private void requestConverterIfNeeded(string targetFileFormat)
        {
            var converterNeedsSpecified = 
                targetFileFormat != ".wav" &&
                targetFileFormat != ".pcm";

            converterLocationLabel.Visible = converterNeedsSpecified;
            converterLocationTextBox.Visible = converterNeedsSpecified;
            browseConverterButton.Visible = converterNeedsSpecified;
        }

        /// <summary>
        /// Centralized place to spawn Browser and return a path.
        /// </summary>
        /// <param name="originalPath">Path to start at.</param>
        /// <returns>The path picked or "originalPath" if cancelled.</returns>
        private string browseForPath(string originalPath)
        {
            var folderBrowser = new FolderBrowserDialog();
            folderBrowser.SelectedPath = originalPath;

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                return folderBrowser.SelectedPath;
            }
            else
            {
                return originalPath;
            }
        }

        private void browseConverterButton_Click(object sender, EventArgs e)
        {
            converterLocationTextBox.Text = 
                browseForPath(converterLocationTextBox.Text);
        }

        private void browseSoundBinButton_Click(object sender, EventArgs e)
        {
            soundBinLocationTextBox.Text =
                browseForPath(soundBinLocationTextBox.Text);

            populateListViewIfDirectoryExists(soundBinLocationTextBox.Text,
                packagedSoundFilesListView.Items);
        }

        private void saveSettingsButton_Click(object sender, EventArgs e)
        {
            saveSettings();
        }

        private void organizeSubdirectoriesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var checkBox = sender as CheckBox;
            var organizeSubDirectoriesCheckBoxChecked = checkBox.Checked;

            subdirectoryPatternTextBox.Enabled = organizeSubDirectoriesCheckBoxChecked;
        }

        private void reloadPackagedSoundsButton_Click(object sender, EventArgs e)
        {
            populateListViewIfDirectoryExists(
                soundBinLocationTextBox.Text,
                packagedSoundFilesListView.Items);
        }

        private void soundBinLocationTextBox_Validated(object sender, EventArgs e)
        {
            populateListViewIfDirectoryExists(soundBinLocationTextBox.Text,
                packagedSoundFilesListView.Items);
        }

        private void packagedSoundFilesListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            var listView = sender as ListView;
            setParseButtonEnabled(listView.CheckedItems);
        }

        /// <summary>
        /// Sets parseButton's Enabled property relative to the number of checked items.
        /// </summary>
        /// <param name="numCheckedItems">Collection of checked items to verify against.</param>
        private void setParseButtonEnabled(
            ListView.CheckedListViewItemCollection checkedItems)
        {
            extractButton.Enabled = checkedItems.Count > 0;
        }

        private void parseButton_Click(object sender, EventArgs e)
        {
            bool continueToParseFiles;

            bool validFileList = 
                validateFileList(packagedSoundFilesListView.CheckedItems);

            // other checks
            bool validSoundbinFolder =
                validateSoundBinFolder(soundBinLocationTextBox.Text);

            bool validConverterForTargetFile =
                validateConverterForTargetFile(
                    targetFileFormatComboBox.Text,
                    converterLocationTextBox.Text
                );

            bool validOutputLocation =
                validateOutputLocation(outputLocationTextBox.Text);

            bool validSubdirectoryPattern = validateSubdirectoryPattern(
                organizeSubdirectoriesCheckBox.Checked,
                subdirectoryPatternTextBox.Text);

            continueToParseFiles =
                validSoundbinFolder &&
                validConverterForTargetFile &&
                validOutputLocation &&
                validSubdirectoryPattern;

            if (continueToParseFiles)
            {
                parseFiles(getFileList());
            }
            else
            {
                MessageBox.Show("Parsing aborted",
                    "Parsing Aborted",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private bool validateSubdirectoryPattern(
            bool organizeSubdirectoriesChecked, 
            string subdirectoryPattern)
        {
            bool validSubdirectoryPattern = false;

            validSubdirectoryPattern = 
                !organizeSubdirectoriesChecked ||
                outputLocationTextBox.Text.Length > 0;

            return validSubdirectoryPattern;
        }

        /// <summary>
        /// Ensures "outputLocation" exists.
        /// </summary>
        /// <param name="outputLocation">The path to output sound files to.</param>
        /// <returns>If the output location is valid.</returns>
        private bool validateOutputLocation(string outputLocation)
        {
            bool validOutputLocation = false;

            if (!Directory.Exists(outputLocation))
            {
                if (MessageBox.Show("Output location folder \"" +
                    outputLocation
                    + "\" does not exist. Would you like to create it now?",
                    "Create Output Location Folder?",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    try
                    {
                        Directory.CreateDirectory(outputLocation);
                        validOutputLocation = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error has occurred:\n"
                            + ex.Message);
                    }
                }
            }
            else
            {
                validOutputLocation = true;
            }

            return validOutputLocation;
        }

        /// <summary>
        /// Ensures external converters for "targetFileFormat"s that 
        /// need them exist at "converterLocation".
        /// </summary>
        /// <param name="targetFileFormat">The format to convert to.</param>
        /// <param name="converterLocation">The location of the external converter.</param>
        /// <returns>If the external converter exists.</returns>
        private bool validateConverterForTargetFile(
            string targetFileFormat, 
            string converterLocation)
        {
            bool validConverterForTargetFile = false;

            bool converterNeeded =
                targetFileFormat != ".wav" &&
                targetFileFormat != ".pcm";

            validConverterForTargetFile = !converterNeeded;

            if (converterNeeded)
            {
                var converterExists =
                    File.Exists(converterLocation);

                if (!converterExists)
                {
                    MessageBox.Show("Converter at \"" +
                        converterLocation
                        + "\" does not exist.",
                        "Converter Does Not Exist",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1);
                }

                validConverterForTargetFile = converterExists;
            }

            return validConverterForTargetFile;
        }

        /// <summary>
        /// Checks that the SoundBin folder exists.
        /// </summary>
        /// <param name="soundBinFolderLocation">Dyad's SoundBin folder.</param>
        /// <returns>If the SoundBin folder exists.</returns>
        private bool validateSoundBinFolder(string soundBinFolderLocation)
        {
            bool validSoundBinFolder = Directory.Exists(soundBinFolderLocation);

            if (!validSoundBinFolder)
            {
                MessageBox.Show("SoundBin folder \""
                    + soundBinFolderLocation + "\" does not exist.",
                    "SoundBin Folder Does Not Exist",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }

            return validSoundBinFolder;
        }

        private void parseFiles(IEnumerable<string> fileList)
        {
            var fileExtractionSettings = assignSettings(fileList);

            var fileExtractor = new FileExtractor(fileExtractionSettings);

            try
            {

                var success = fileExtractor.ExtractAndConvertFiles();

                if (success)
                {
                    MessageBox.Show("Parsing complete! Opening \""
                        + fileExtractionSettings.OutputLocation
                        + "\" now.",
                        "Extraction Finished!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1);
                    Process.Start(fileExtractionSettings.OutputLocation);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Extraction interrupted:\n" + ex.Message,
                    "Extraction Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private FileExtractionSettings assignSettings(IEnumerable<string> fileList)
        {
            var fileExtractionSettings = new FileExtractionSettings();
            
            fileExtractionSettings.DyadSoundBinFolder = soundBinLocationTextBox.Text;
            fileExtractionSettings.TargetFileFormat = targetFileFormatComboBox.Text;
            fileExtractionSettings.OutputLocation = outputLocationTextBox.Text;
            fileExtractionSettings.SubdirectoryPattern = subdirectoryPatternTextBox.Text;
            fileExtractionSettings.PadRawFileNumberWithZeroes = padFileNumberCheckBox.Checked;
            fileExtractionSettings.FileList = fileList;

            return fileExtractionSettings;
        }

        /// <summary>
        /// Ensures that file list contains at least one file and
        /// each file is a ".bsd" file.
        /// </summary>
        /// <param name="checkedItems">Collection of checked items to validate.</param>
        /// <returns>If the file list passes the validation checks.</returns>
        private bool validateFileList(
            ListView.CheckedListViewItemCollection checkedItems)
        {
            bool isExpectedFileType = true;
            foreach (ListViewItem item in checkedItems)
            {
                var currentItemEndsWithBsd = item.Text.EndsWith(".bsd");

                isExpectedFileType &= currentItemEndsWithBsd;
            }

            return checkedItems.Count > 0
                && isExpectedFileType;
        }

        private IEnumerable<string> getFileList()
        {
            var checkedItems = packagedSoundFilesListView.CheckedItems;

            var checkedItemsList = checkedItems.Cast<ListViewItem>().ToList();

            var fileNameList = from f in checkedItemsList
                               select f.Text;

            return fileNameList;
        }

        private void selectAllButton_Click(object sender, EventArgs e)
        {
            setAllListViewItemsChecked(packagedSoundFilesListView.Items, true);
        }

        private void deselectAllButton_Click(object sender, EventArgs e)
        {
            setAllListViewItemsChecked(packagedSoundFilesListView.Items, false);
        }

        /// <summary>
        /// Sets all items in the listViewItemCollection to "checkState".
        /// </summary>
        /// <param name="listViewItemCollection">The items to set the checked status of.</param>
        /// <param name="checkState">Checked or not checked.</param>
        private void setAllListViewItemsChecked(
            ListView.ListViewItemCollection listViewItemCollection, 
            bool checkState)
        {
            foreach (ListViewItem item in listViewItemCollection)
            {
                item.Checked = checkState;
            }
        }

        private void browseOutputLocationButton_Click(object sender, EventArgs e)
        {
            outputLocationTextBox.Text = browseForPath(
                outputLocationTextBox.Text);
        }

    }
}
