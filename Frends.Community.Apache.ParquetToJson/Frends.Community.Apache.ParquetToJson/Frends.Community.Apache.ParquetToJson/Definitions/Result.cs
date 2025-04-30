using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Frends.Community.Apache.ParquetToJson.Definitions
{
    public class Result
    {
        /// <summary>
        /// Operation success.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Status message / error message.
        /// </summary>
        public string StatusMessage { get; set; }

        /// <summary>
        /// FileInfo -object of the output JSON -file.
        /// </summary>
        public FileInfo? FileInfo { get; set; }
    }
}
