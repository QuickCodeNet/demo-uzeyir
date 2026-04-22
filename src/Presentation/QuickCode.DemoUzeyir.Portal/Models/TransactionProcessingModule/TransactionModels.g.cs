using QuickCode.DemoUzeyir.Common.Nswag.Clients.TransactionProcessingModuleApi.Contracts;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using QuickCode.DemoUzeyir.Portal.Helpers;

namespace QuickCode.DemoUzeyir.Portal.Models.TransactionProcessingModule
{
    public class TransactionData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public TransactionDto SelectedItem { get; set; }
        public List<TransactionDto> List { get; set; }
    }

    public static partial class TransactionExtensions
    {
        public static string GetKey(this TransactionDto dto)
        {
            return $"{dto.Id}";
        }
    }
}