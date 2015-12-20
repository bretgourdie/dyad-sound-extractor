using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractionLibrary
{
    public class FileExtractionSettings
    {
        public IEnumerable<string> FileList { get; set; }

        public string DyadSoundBinFolder { get; set; }

        public string TargetFileFormat { get; set; }

        public string OutputLocation { get; set; }

        public string SubdirectoryPattern { get; set; }

        public bool PadRawFileNumberWithZeroes { get; set; }

        public bool DeleteExtractedFilesAfterConverting { get; set; }

        public FileExtractionSettings()
        {

        }
    }
}
