using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractionLibrary
{
    class ConvertedFileResults
    {
        public Dictionary<string, string> convertedFileLocations { get; internal set; }

        public ConvertedFileResults()
        {
            convertedFileLocations = new Dictionary<string, string>();
        }
    }
}
