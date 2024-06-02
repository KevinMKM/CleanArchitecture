﻿using System.Data;

namespace CleanArc_Kevin.Core.Abstractions.Serializers;

public interface IExcelSerializer
{
    byte[] ListToExcelByteArray<T>(List<T> list, string sheetName = "Result");
    DataTable ExcelToDataTable(byte[] bytes);
    List<T> ExcelToList<T>(byte[] bytes);
}