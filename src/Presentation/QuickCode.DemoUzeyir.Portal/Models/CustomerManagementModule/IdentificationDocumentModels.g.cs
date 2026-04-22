using QuickCode.DemoUzeyir.Common.Nswag.Clients.CustomerManagementModuleApi.Contracts;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using QuickCode.DemoUzeyir.Portal.Helpers;

namespace QuickCode.DemoUzeyir.Portal.Models.CustomerManagementModule
{
    public class IdentificationDocumentData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public IdentificationDocumentDto SelectedItem { get; set; }
        public List<IdentificationDocumentDto> List { get; set; }
    }

    public static partial class IdentificationDocumentExtensions
    {
        public static string GetKey(this IdentificationDocumentDto dto)
        {
            return $"{dto.Id}";
        }

        public static List<string> GetImageColumnNames(this IdentificationDocumentDto dto) => new()
        {
            "DocumentUrl"
        };
    }
}