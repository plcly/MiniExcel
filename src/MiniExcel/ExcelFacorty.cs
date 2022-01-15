﻿namespace MiniExcelLibs
{
    using MiniExcelLibs.OpenXml;
    using System;
    using MiniExcelLibs.Csv;
    using System.IO;

    internal class ExcelWriterFactory
    {
        internal static IExcelWriter GetProvider(Stream stream,ExcelType excelType, IConfiguration configuration,bool printHeader)
        {
            switch (excelType)
            {
                case ExcelType.CSV:
                    return new CsvWriter(stream, configuration, printHeader);
                case ExcelType.XLSX:
                    return new ExcelOpenXmlSheetWriter(stream, configuration, printHeader);
                default:
                    throw new NotSupportedException($"Please Issue for me");
            }
        }
    }

    internal class ExcelReaderFactory
    { 
        internal static IExcelReader GetProvider(Stream stream, ExcelType excelType)
        {
            switch (excelType)
            {
                case ExcelType.CSV:
                    return new CsvReader(stream);
                case ExcelType.XLSX:
                    return new ExcelOpenXmlSheetReader(stream);
                default:
                    throw new NotSupportedException($"Please Issue for me");
            }
        }
    }

    internal class ExcelTemplateFactory
    {
        internal static IExcelTemplateAsync GetProvider(Stream stream, ExcelType excelType= ExcelType.XLSX)
        {
            switch (excelType)
            {
                case ExcelType.XLSX:
                    return new ExcelOpenXmlTemplate(stream);
                default:
                    throw new NotSupportedException($"Please Issue for me");
            }
        }
    }
}
