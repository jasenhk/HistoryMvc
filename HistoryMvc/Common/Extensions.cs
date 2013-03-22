using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HistoryMvc.Models;

namespace HistoryMvc.Common
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this System.String str)
        {
            return String.IsNullOrEmpty(str);
        }
    }
}