using QuickCode.DemoUzeyir.Common.Nswag.Clients.TransactionProcessingModuleApi.Contracts;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using QuickCode.DemoUzeyir.Portal.Helpers;

namespace QuickCode.DemoUzeyir.Portal.Models.TransactionProcessingModule
{
    public class FeeTypeData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public FeeTypeDto SelectedItem { get; set; }
        public List<FeeTypeDto> List { get; set; }
    }

    public static partial class FeeTypeExtensions
    {
        public static string GetKey(this FeeTypeDto dto)
        {
            return $"{dto.Id}";
        }
    }
}