using System.Collections.Generic;
using System;
using System.ComponentModel;
using System.IO;
using System.Text.Json;
using System.Threading;
using Microsoft.CSharp;
using Frends.Community.Apache.ParquetToJson.Definitions;
using Parquet;
using Parquet.Data;
using System.Threading.Tasks;
using System.Reflection;


namespace Frends.Community.Apache.ParquetToJson
{
    public static class ParquetToJsonTask
    {
        /// <summary>
        /// This is task
        /// Documentation: https://github.com/CommunityHiQ/Frends.Community.Apache.ParquetToJson
        /// </summary>
        /// <param name="input">What to repeat.</param>
        /// <param name="options">Define if repeated multiple times. </param>
        /// <param name="cancellationToken"></param>
        /// <returns>{string Replication} </returns>
        public static async Task<Result> ConvertParquetToJson([PropertyTab] Input input, [PropertyTab] Output output, CancellationToken cancellationToken)
        {
            try
            {
                var rows = GetParquetRows(Path.Combine(input.Directory, input.FileName));

                using (var fileStream = File.OpenWrite(Path.Combine(output.Directory, output.FileName)))
                {
                    await JsonSerializer.SerializeAsync(fileStream, rows, new JsonSerializerOptions { WriteIndented = true });
                }

                var fileInfo = new FileInfo(Path.Combine(output.Directory, output.FileName));

                return new Result()
                {
                    Success = true,
                    StatusMessage = String.Empty,
                    DirectoryName = fileInfo.DirectoryName,
                    IsReadOnly = fileInfo.IsReadOnly,
                    Length = fileInfo.Length,
                    FileName = fileInfo.Name,
                    FullPath = System.IO.Path.Combine(fileInfo.DirectoryName, fileInfo.Name)
                };
            }
            catch (Exception e)
            {
                return new Result()
                {
                    Success = false,
                    StatusMessage = e.Message,
                    DirectoryName = null,
                    IsReadOnly = null,
                    Length = 0,
                    FileName = null,
                    FullPath = null
                };
            }
        }

        internal static async IAsyncEnumerable<Dictionary<string, object?>> GetParquetRows(string parquetFilePath)
        {
            using (Stream fileStream = File.OpenRead(parquetFilePath))
            {
                using (ParquetReader parquetReader = await ParquetReader.CreateAsync(fileStream, new ParquetOptions { TreatByteArrayAsString = true }))
                {
                    var dataFields = parquetReader.Schema.GetDataFields();

                    for (var i = 0; i < parquetReader.RowGroupCount; i++)
                    {
                        using (ParquetRowGroupReader rowGroupReader = parquetReader.OpenRowGroupReader(i))
                        {
                            var dataColumns = new List<DataColumn>(dataFields.Length);

                            foreach (var dataField in dataFields)
                            {
                                var dataColumn = await rowGroupReader.ReadColumnAsync(dataField);
                                dataColumns.Add(dataColumn);
                            }

                            for (var j = 0; j < rowGroupReader.RowCount; j++)
                            {
                                var row = new Dictionary<string, object?>();

                                for (var k = 0; k < dataFields.Length; k++)
                                {
                                    var dataField = dataFields[k];
                                    var dataColumn = dataColumns[k];

                                    var columnData = dataColumn.Data.GetValue(j);

                                    row.Add(dataField.Name, columnData);
                                }

                                yield return row;
                            }
                        }
                    }
                }
            }
        }
    }
}
