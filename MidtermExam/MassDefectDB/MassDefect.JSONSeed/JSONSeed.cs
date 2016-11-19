using System.Data.Entity.Validation;
using System.Linq;

namespace MassDefect.JSONSeed
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Data;
    using Models;
    using Models.DTOs;
    using Newtonsoft.Json;

    public class JSONSeed
    {
        private const string SolarSystemsPath = "../../../datasets/solar-systems.json";
        private const string StarsPath = "../../../datasets/stars.json";
        private const string PlanetsPath = "../../../datasets/planets.json";
        private const string PersonsPath = "../../../datasets/persons.json";
        private const string AnomaliesPath = "../../../datasets/anomalies.json";
        private const string AnomalyVictimsPath = "../../../datasets/anomaly-victims.json";

        static void Main()
        {
            ImportSolarSystems();
            ImportStar();
            ImportPlanets();
            ImportPersons();
            ImportAnomalies();
            ImportAnomalyVictims();
        }

        private static void ImportAnomalyVictims()
        {
            var context = new MassDefectContext();
            var json = File.ReadAllText(AnomalyVictimsPath);
            var anomalyVictims = JsonConvert.DeserializeObject<IEnumerable<AnomalyVictimDTO>>(json);

            foreach (var anomalyVictim in anomalyVictims)
            {
                if (anomalyVictim.Id == null || anomalyVictim.Person == null)
                {
                    Console.WriteLine("Error: Invalid data.");
                    continue;
                }

                var anomalyEntity = GetAnomalyById(anomalyVictim.Id, context);
                var personEntity = GetPersonByName(anomalyVictim.Person, context);

                if (anomalyEntity == null || personEntity == null)
                {
                    Console.WriteLine("Error: Invalid data.");
                    continue;
                }

                anomalyEntity.Victims.Add(personEntity);
                Console.WriteLine($"Successfully imported Person {personEntity.Name}.");
            }

            context.SaveChanges();
        }

        private static Person GetPersonByName(string anomalyVictimPerson, MassDefectContext context)
        {
            Person desiredPerson = context.Persons.FirstOrDefault(person => person.Name == anomalyVictimPerson);
            return desiredPerson;
        }

        private static Anomaly GetAnomalyById(int? anomalyVictimId, MassDefectContext context)
        {
            Anomaly desiredAnomaly = context.Anomalies.FirstOrDefault(anomaly => anomaly.Id == anomalyVictimId.Value);
            return desiredAnomaly;
        }

        private static void ImportAnomalies()
        {
            var context = new MassDefectContext();
            var json = File.ReadAllText(AnomaliesPath);
            var anomalies = JsonConvert.DeserializeObject<IEnumerable<AnomalyDTO>>(json);

            foreach (var anomaly in anomalies)
            {
                if (anomaly.OriginPlanet == null || anomaly.TeleportPlanet == null)
                {
                    Console.WriteLine("Error: Invalid data.");
                    continue;
                }

                var anomalyEntity = new Anomaly
                {
                    OriginPlanet = GetPlanetByName(anomaly.OriginPlanet, context),
                    TeleportPlanet = GetPlanetByName(anomaly.TeleportPlanet, context)
                };

                if (anomalyEntity.OriginPlanet == null || anomalyEntity.TeleportPlanet == null)
                {
                    Console.WriteLine("Error: Invalid data.");
                    continue;
                }

                context.Anomalies.Add(anomalyEntity);
                Console.WriteLine("Successfully imported anomaly.");
            }
            context.SaveChanges();
        }

        private static void ImportPersons()
        {
            var context = new MassDefectContext();
            var json = File.ReadAllText(PersonsPath);
            var persons = JsonConvert.DeserializeObject<IEnumerable<PersonDTO>>(json);

            foreach (var person in persons)
            {
                if (person.Name == null || person.HomePlanet == null)
                {
                    Console.WriteLine("Error: Invalid data.");
                    continue;
                }

                var personEntity = new Person
                {
                    Name = person.Name,
                    HomePlanet = GetPlanetByName(person.HomePlanet, context)
                };

                if (personEntity.HomePlanet == null)
                {
                    Console.WriteLine("Error: Invalid data.");
                    continue;
                }

                context.Persons.Add(personEntity);
                Console.WriteLine($"Successfully imported Solar System {personEntity.Name}.");
            }
            context.SaveChanges();
        }

        private static Planet GetPlanetByName(string personHomePlanet, MassDefectContext context)
        {
            var desiredPlanet = context.Planets.FirstOrDefault(planet => planet.Name == personHomePlanet);
            return desiredPlanet;
        }

        private static void ImportPlanets()
        {
            var context = new MassDefectContext();
            var json = File.ReadAllText(PlanetsPath);
            var planets = JsonConvert.DeserializeObject<IEnumerable<PlanetDTO>>(json);

            foreach (var planet in planets)
            {
                if (planet.Name == null || planet.Sun == null || planet.SolarSystem == null)
                {
                    Console.WriteLine("Error: Invalid data.");
                    continue;
                }

                var planetEntity = new Planet
                {
                    Name = planet.Name,
                    SolarSystem = GetSolarSystemByName(planet.SolarSystem, context),
                    Sun = GetSunByName(planet.Sun, context)
                };

                if (planetEntity.SolarSystem == null || planetEntity.Sun == null)
                {

                    Console.WriteLine("Error: Invalid data.");
                    continue;
                }

                context.Planets.Add(planetEntity);
                Console.WriteLine($"Successfully imported Planet {planetEntity.Name}.");
            }
            context.SaveChanges();
        }

        private static Star GetSunByName(string planetSunName, MassDefectContext context)
        {
            Star desiredSun = context.Stars.FirstOrDefault(star => star.Name == planetSunName);
            return desiredSun;
        }

        private static void ImportStar()
        {
            var context = new MassDefectContext();
            var json = File.ReadAllText(StarsPath);
            var stars = JsonConvert.DeserializeObject<IEnumerable<StarDTO>>(json);

            foreach (var star in stars)
            {
                if (star.Name == null || star.SolarSystem == null)
                {
                    Console.WriteLine("Error: Invalid data.");
                    continue;
                }

                var starEntity = new Star()
                {
                    Name = star.Name,
                    SolarSystem = GetSolarSystemByName(star.SolarSystem, context)
                };

                if (starEntity.SolarSystem == null)
                {
                    Console.WriteLine("Error: Invalid data.");
                    continue;
                }

                context.Stars.Add(starEntity);
                Console.WriteLine($"Successfully imported Star {starEntity.Name}.");
            }

            context.SaveChanges();
        }

        private static SolarSystem GetSolarSystemByName(string starSolarSystemName, MassDefectContext context)
        {
            var desiredSolarSystem = context.SolarSystems.FirstOrDefault(ss => ss.Name == starSolarSystemName);
            return desiredSolarSystem;
        }

        private static void ImportSolarSystems()
        {
            var context = new MassDefectContext();
            var json = File.ReadAllText(SolarSystemsPath);
            var solarSystems = JsonConvert.DeserializeObject<IEnumerable<SolarSystemDTO>>(json);

            foreach (var solarSystem in solarSystems)
            {
                if (solarSystem.Name == null)
                {
                    Console.WriteLine("Error: Invalid data.");
                    continue;
                }
                var solarSystemEntity = new SolarSystem
                {
                    Name = solarSystem.Name
                };

                context.SolarSystems.Add(solarSystemEntity);
                Console.WriteLine($"Successfully imported Solar System {solarSystem.Name}.");
            }
            context.SaveChanges();
        }
    }
}