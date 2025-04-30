using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text;

namespace Frends.Community.Apache.ParquetToJson.Definitions
{
    public class Input
    {
        /// <summary>
        /// Parquet input directory.
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        [DefaultValue(@"C:\Temp\Input")]
        public string Directory { get; set; }


        /// <summary>
        /// Parquet file name.
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        [DefaultValue(@"Input.parquet")]
        public string FileName { get; set; }
    }
}
