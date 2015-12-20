using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace ExtractionLibrary
{
    internal struct SoundRead
    {
        internal uint length;
        internal uint offset;
    }

    public class FileExtractor
    {
        private FileExtractionSettings Settings { get; set; }

        public FileExtractor(FileExtractionSettings settings)
        {
            Settings = settings;
        }

        public bool ExtractAndConvertFiles()
        {
            foreach (var file in Settings.FileList)
            {
                var scrubbedFileName = getScrubbedFileName(file);

                var curOutputDirectory = getOutputDirectory(scrubbedFileName);

                var curSourceFilePath = getSourceFilePath(file);

                // Create output folder if needed
                if (!Directory.Exists(curOutputDirectory))
                {
                    Directory.CreateDirectory(curOutputDirectory);
                }

                using (var fileStream = File.OpenRead(curSourceFilePath))
                {
                    using (var reader = new BinaryReader(fileStream))
                    {
                        var fileSize = reader.BaseStream.Length;

                        // Parse Header
                        var numSounds = reader.ReadUInt32();

                        var soundInfo = new SoundRead[numSounds];

                        for (int curSound = 0; curSound < numSounds; curSound++)
                        {
                            soundInfo[curSound].length = reader.ReadUInt32();
                            soundInfo[curSound].offset = reader.ReadUInt32();
                        }

                        // Collect Data portion
                        var dataStart = reader.BaseStream.Position;
                        var dataSize = fileSize - dataStart;

                        var dataPart = reader.ReadBytes((int)dataSize);

                        // Write individual files to folder
                        for (uint curSound = 0; curSound < numSounds; curSound++)
                        {
                            string newFileName = getBaseFileName(scrubbedFileName, curSound + 1) + getFileExtension();

                            var newFile = File.Create(curOutputDirectory + "\\" + newFileName);

                            var writer = new BinaryWriter(newFile);

                            if (Settings.TargetFileFormat == ".wav")
                            {
                                writeWavHeader(writer, soundInfo[curSound].length);
                            }

                            writer.Write(dataPart, (int)soundInfo[curSound].offset, (int)soundInfo[curSound].length);

                            writer.Close();
                            newFile.Close();
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Arranges the full path to the current source sound file.
        /// </summary>
        /// <param name="file">Current sound file.</param>
        /// <returns>Full path to sound file.</returns>
        private string getSourceFilePath(string file)
        {
            var sourceDirectory = Settings.DyadSoundBinFolder;

            if (!sourceDirectory.EndsWith("\\"))
            {
                sourceDirectory += "\\";
            }

            var sourceDirectoryFilePath = sourceDirectory + file;

            return sourceDirectoryFilePath;
        }

        /// <summary>
        /// Sanitizes a filename to be used for a folder or file name.
        /// </summary>
        /// <param name="file">The original file name.</param>
        /// <returns>A sanitized filename to be used for a folder or file.</returns>
        private string getScrubbedFileName(string file)
        {
            var lastIndexOfBackslash = file.LastIndexOf("\\");
            var lastIndexOfPeriod = file.LastIndexOf(".");

            var scrubbedFile = file.Substring(lastIndexOfBackslash + 1, lastIndexOfPeriod);

            return scrubbedFile;
        }

        /// <summary>
        /// Arranges the full output directory.
        /// </summary>
        /// <param name="scrubbedFileName">File name from getScrubbedFileName(string).</param>
        /// <returns>The current output directory to write files to.</returns>
        private string getOutputDirectory(string scrubbedFileName)
        {
            var outputDirectory = Settings.OutputLocation;

            if (!outputDirectory.EndsWith("\\"))
            {
                outputDirectory += "\\";
            }

            if (Settings.SubdirectoryPattern != "")
            {
                outputDirectory += Settings.SubdirectoryPattern;
                outputDirectory = outputDirectory.Replace("%FileName%", scrubbedFileName);
            }

            else // Default
            {
                outputDirectory += "Extracted_" + scrubbedFileName;
            }

            return outputDirectory;
        }

        /// <summary>
        /// Returns a file name with the packaged file name separated by an underscore and the sound number.
        /// </summary>
        /// <param name="packagedFileName">Name of file being parsed.</param>
        /// <param name="soundNum">Current sound being written to file.</param>
        /// <returns>The base filename dictated by ExtractorSettings.</returns>
        private string getBaseFileName(
            string packagedFileName, 
            uint soundNum)
        {
            var baseFileName = packagedFileName + "_";

            if (Settings.PadRawFileNumberWithZeroes)
            {
                baseFileName += soundNum.ToString("D3"); 
            }
            
            else
            {
                baseFileName += soundNum.ToString();
            }

            return baseFileName;
        }

        /// <summary>
        /// Returns target file extension.
        /// </summary>
        /// <returns>The target file extension.</returns>
        private string getFileExtension()
        {
            return Settings.TargetFileFormat;
        }

        /// <summary>
        /// Appends the .wav header to the Stream that "writer" is writing to.
        /// Needs to be done before writing data! It is a header, not a footer!
        /// </summary>
        /// <param name="writer">Initialized writer pointing to a Stream to write to.</param>
        /// <param name="length">Length of the data portion.</param>
        private void writeWavHeader(BinaryWriter writer, uint length)
        {
            const int PCM_FORMAT = 1;
            const int SUB_CHUNK_SIZE = 16;
            const int STEREO_CHANNELS = 2;
            const int SAMPLE_RATE = 44100;
            const int BIT_SIZE = 8;
            const int NUM_SAMPLES = 2;

            int BITS_PER_SAMPLE = BIT_SIZE * NUM_SAMPLES;

            writer.BaseStream.Position = 0;

            // RIFF header
            writer.Write(Encoding.ASCII.GetBytes("RIFF"), 0, 4);

            // File size
            writer.Write(BitConverter.GetBytes(length + 44));

            // Format
            writer.Write(Encoding.ASCII.GetBytes("WAVE"), 0, 4);

            // "fmt "
            writer.Write(Encoding.ASCII.GetBytes("fmt "), 0, 4);

            // Sub-chunk size
            writer.Write(BitConverter.GetBytes(SUB_CHUNK_SIZE), 0, 4);

            // Floating point
            writer.Write(BitConverter.GetBytes(PCM_FORMAT), 0, 2);

            // Number of channels
            writer.Write(BitConverter.GetBytes(STEREO_CHANNELS), 0, 2);

            // Sample Rate
            writer.Write(BitConverter.GetBytes(SAMPLE_RATE), 0, 4);

            // Idk
            writer.Write(BitConverter.GetBytes(SAMPLE_RATE * BITS_PER_SAMPLE * STEREO_CHANNELS / 8), 0, 4);

            // BITS_PER_SAMPLE * Channels
            writer.Write(BitConverter.GetBytes(BITS_PER_SAMPLE * STEREO_CHANNELS), 0, 2);

            // BITS_PER_SAMPLE
            writer.Write(BitConverter.GetBytes(BITS_PER_SAMPLE), 0, 2);

            // "data"
            writer.Write(Encoding.ASCII.GetBytes("data"), 0, 4);

            // File size
            writer.Write(BitConverter.GetBytes(length), 0, 4);
        }
    }
}
