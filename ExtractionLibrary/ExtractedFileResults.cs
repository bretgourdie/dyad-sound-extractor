using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractionLibrary
{
    public class ExtractedFileResults
    {
        public Dictionary<string, string> extractedFileLocations { get; internal set; }

        public ExtractedFileResults()
        {
            extractedFileLocations = new Dictionary<string, string>();
        }
    }
}
