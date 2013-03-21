using System;
using System.Collections.Generic;

namespace HistoryMvc.Models
{
    public class Planet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float MassAU { get; set; }
        public IEnumerable<Moon> Moons { get; set; }
    }
}