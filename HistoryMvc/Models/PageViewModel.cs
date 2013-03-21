using System;
using System.Collections.Generic;

namespace HistoryMvc.Models
{
    public class PageViewModel
    {
        public PageViewModel()
        {
            this.TimeStamp = DateTime.Now;
            this.Planets = new List<Planet>();
        }

        public bool IsAjax { get; set; }
        public string ActionName { get; set; }
        public DateTime TimeStamp { get; set; }
        public IEnumerable<Planet> Planets { get; set; }
    }
}