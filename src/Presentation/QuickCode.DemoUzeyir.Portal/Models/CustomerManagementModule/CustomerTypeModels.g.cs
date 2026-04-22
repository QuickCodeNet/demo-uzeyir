using QuickCode.DemoUzeyir.Common.Nswag.Clients.CustomerManagementModuleApi.Contracts;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using QuickCode.DemoUzeyir.Portal.Helpers;

namespace QuickCode.DemoUzeyir.Portal.Models.CustomerManagementModule
{
    public class CustomerTypeData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public CustomerTypeDto SelectedItem { get; set; }
        public List<CustomerTypeDto> List { get; set; }
    }

    public static partial class CustomerTypeExtensions
    {
        public static string GetKey(this CustomerTypeDto dto)
        {
            return $"{dto.Id}";
        }
    }
}