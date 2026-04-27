using QuickCode.DemoUzeyir.Common.Nswag.Clients.TransactionProcessingModuleApi.Contracts;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using QuickCode.DemoUzeyir.Portal.Helpers;

namespace QuickCode.DemoUzeyir.Portal.Models.TransactionProcessingModule
{
    public class TransactionFeeData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public TransactionFeeDto SelectedItem { get; set; }
        public List<TransactionFeeDto> List { get; set; }
    }

    public static partial class TransactionFeeExtensions
    {
        public static string GetKey(this TransactionFeeDto dto)
        {
            return $"{dto.Id}";
        }
    }
}