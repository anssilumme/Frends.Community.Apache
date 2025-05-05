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
        /// Output directory name.
        /// </summary>
        public string DirectoryName { get; set; }

        /// <summary>
        /// If the output file is read only or could not be found.
        /// </summary>
        public bool? IsReadOnly { get; set; }

        /// <summary>
        /// The size of the output file in bytes.
        /// </summary>
        public Int64 Length { get; set; }

        /// <summary>
        /// Name of the output file.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Full path to output file.
        /// </summary>
        public string FullPath { get; set; }

    }
}
