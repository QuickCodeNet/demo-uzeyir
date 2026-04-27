using QuickCode.DemoUzeyir.Common.Nswag.Clients.TransactionProcessingModuleApi.Contracts;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using QuickCode.DemoUzeyir.Portal.Helpers;

namespace QuickCode.DemoUzeyir.Portal.Models.TransactionProcessingModule
{
    public class TransactionChannelData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public TransactionChannelDto SelectedItem { get; set; }
        public List<TransactionChannelDto> List { get; set; }
    }

    public static partial class TransactionChannelExtensions
    {
        public static string GetKey(this TransactionChannelDto dto)
        {
            return $"{dto.Id}";
        }
    }
}