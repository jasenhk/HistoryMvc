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
            new Planet { Id = 1, Name = "Mercury", MassAU = 0.4F, Moons = new List<Moon>() },
            new Planet { Id = 2, Name = "Venus", MassAU = 0.7F, Moons = new List<Moon>() },
            new Planet { Id = 3, Name = "Earth", MassAU = 1F, Moons = new List<Moon>() {
                new Moon { Id = 1, Name = "Moon", PlanetId = 3 }
            }},
            new Planet { Id = 4, Name = "Mars", MassAU = 1.5F, Moons = new List<Moon>() {
                new Moon { Id = 2, Name = "Phobos", PlanetId = 4 },
                new Moon { Id = 3, Name = "Deimos", PlanetId = 4 }
            }},
            new Planet { Id = 5, Name = "Jupiter", MassAU = 5.2F, Moons = new List<Moon>() },
            new Planet { Id = 6, Name = "Saturn", MassAU = 9.5F, Moons = new List<Moon>() },
            new Planet { Id = 7, Name = "Uranus", MassAU = 30F, Moons = new List<Moon>() },
            new Planet { Id = 8, Name = "Neptune", MassAU = 19.6F, Moons = new List<Moon>() }
        };
    }

    public interface IPlanetRepository
    {
        Planet GetPlanetByName(string name);
        IEnumerable<Planet> GetAll();
    }
}