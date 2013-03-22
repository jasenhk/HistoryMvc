using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using HistoryMvc.Models;

namespace HistoryMvc.Common
{
    public class PlanetRepository : IPlanetRepository
    {
        public PlanetRepository()
        {
        }

        public Planet GetPlanetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Planet> GetAll()
        {
            return planets.AsEnumerable<Planet>();
        }

        public static List<Planet> planets = new List<Planet>()
        {
            new Planet { Id = 1, Name = "Mercury", MassAU = 0.4F, Moons = 0 },
            new Planet { Id = 2, Name = "Venus", MassAU = 0.7F, Moons = 0 },
            new Planet { Id = 3, Name = "Earth", MassAU = 1F, Moons = 1 },
            new Planet { Id = 4, Name = "Mars", MassAU = 1.5F, Moons = 2},
            new Planet { Id = 5, Name = "Jupiter", MassAU = 5.2F, Moons = 67 },
            new Planet { Id = 6, Name = "Saturn", MassAU = 9.5F, Moons = 62 },
            new Planet { Id = 7, Name = "Uranus", MassAU = 30F, Moons = 27 },
            new Planet { Id = 8, Name = "Neptune", MassAU = 19.6F, Moons = 13 }
        };
    }

    public interface IPlanetRepository
    {
        Planet GetPlanetByName(string name);
        IEnumerable<Planet> GetAll();
    }
}