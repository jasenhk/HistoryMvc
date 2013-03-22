using System;

namespace HistoryMvc.Models
{
    public interface IAjaxifiedModel
    {
        bool IsAjax { get; set; }
    }
}