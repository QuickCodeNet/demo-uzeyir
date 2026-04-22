using QuickCode.DemoUzeyir.Common.Nswag.Clients.LoanManagementModuleApi.Contracts;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using QuickCode.DemoUzeyir.Portal.Helpers;

namespace QuickCode.DemoUzeyir.Portal.Models.LoanManagementModule
{
    public class LoanData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public LoanDto SelectedItem { get; set; }
        public List<LoanDto> List { get; set; }
    }

    public static partial class LoanExtensions
    {
        public static string GetKey(this LoanDto dto)
        {
            return $"{dto.Id}";
        }
    }
}