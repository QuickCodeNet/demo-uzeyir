using QuickCode.DemoUzeyir.Common.Nswag.Clients.AccountManagementModuleApi.Contracts;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using QuickCode.DemoUzeyir.Portal.Helpers;

namespace QuickCode.DemoUzeyir.Portal.Models.AccountManagementModule
{
    public class AccountTypeData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public AccountTypeDto SelectedItem { get; set; }
        public List<AccountTypeDto> List { get; set; }
    }

    public static partial class AccountTypeExtensions
    {
        public static string GetKey(this AccountTypeDto dto)
        {
            return $"{dto.Id}";
        }
    }
}