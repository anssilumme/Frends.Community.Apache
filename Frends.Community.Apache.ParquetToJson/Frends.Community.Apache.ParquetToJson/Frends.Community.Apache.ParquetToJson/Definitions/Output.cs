using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text;

namespace Frends.Community.Apache.ParquetToJson.Definitions
{
    public class Output
    {
        /// <summary>
        /// JSON output directory.
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        [DefaultValue(@"C:\Temp\Output")]
        public string Directory { get; set; }


        /// <summary>
        /// JSON file name.
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        [DefaultValue(@"Output.json")]
        public string FileName { get; set; }
    }
}
