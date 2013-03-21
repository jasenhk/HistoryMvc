using System;
using System.Collections.Generic;

namespace HistoryMvc.Models
{
    public interface IPageViewModel
    {
        bool IsAjax { get; set; }
        string ActionName { get; set; }
        DateTime TimeStamp { get; set; }
    }

    public class PageViewModel : IPageViewModel
    {
        public PageViewModel()
        {
            this.TimeStamp = DateTime.Now;
        }

        public bool IsAjax { get; set; }
        public string ActionName { get; set; }
        public DateTime TimeStamp { get; set; }
    }

    public class PlanetPageViewModel : PageViewModel
    {
        public PlanetPageViewModel()
        {
            this.Planets = new List<Planet>();
        }
        public PlanetSearch SearchForm { get; set; }
        public IEnumerable<Planet> Planets { get; set; }
    }
}