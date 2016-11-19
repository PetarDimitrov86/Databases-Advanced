using System;
using System.Linq;
using System.Xml.XPath;
using MassDefect.Data;
using MassDefect.Models;

namespace XMLSeed
{
    using System.Xml.Linq;
    public class XMLSeed
    {
        private const string NewAnomaliesPath = "../../../datasets/new-anomalies.xml";

        static void Main(string[] args)
        {
            var xml = XDocument.Load(NewAnomaliesPath);
            var anomalies = xml.XPathSelectElements("anomalies/anomaly");

            var context = new MassDefectContext();
            foreach (var anomaly in anomalies)
            {
                ImportAnomalyAndVictims(anomaly, context);
            }
            
            context.SaveChanges();
        }

        private static void ImportAnomalyAndVictims(XElement anomalyNode, MassDefectContext context)
        {
            var originPlanetName = anomalyNode.Attribute("origin-planet");
            var teleportPlanetName = anomalyNode.Attribute("teleport-planet");

            if (originPlanetName == null || teleportPlanetName == null)
            {
                Console.WriteLine("Error: Invalid data.");
                return;
            }

            var anomalyEntity = new Anomaly
            {
                OriginPlanet = GetPlanetByName(originPlanetName.Value, context),
                TeleportPlanet = GetPlanetByName(teleportPlanetName.Value, context)
            };

            if (anomalyEntity.OriginPlanet == null || anomalyEntity.TeleportPlanet == null)
            {
                Console.WriteLine("Error: Invalid data.");
                return;
            }
            else
            {
                context.Anomalies.Add(anomalyEntity);
                Console.WriteLine("Successfully imported anomaly.");
            }

            var victims = anomalyNode.XPathSelectElements("victims/victim");
            foreach (var victim in victims)
            {
                ImportVictim(victim, context, anomalyEntity);
            }

            context.SaveChanges();
        }

        private static void ImportVictim(XElement victimNode, MassDefectContext context, Anomaly anomaly)
        {
            var name = victimNode.Attribute("name");

            if (name == null)
            {
                Console.WriteLine("Error: Invalid data.");
                return;
            }

            var personEntity = GetPersonByName(name.Value, context);

            if (personEntity == null)
            {
                Console.WriteLine("Error: Invalid data.");
                return;
            }
            anomaly.Victims.Add(personEntity);
            Console.WriteLine($"Successfully imported Person {personEntity.Name}.");
        }

        private static Person GetPersonByName(string nameValue, MassDefectContext context)
        {
            Person desiredDerson = context.Persons.FirstOrDefault(person => person.Name == nameValue);
            return desiredDerson;
        }

        private static Planet GetPlanetByName(string planetName, MassDefectContext context)
        {
            Planet desiredPlanet = context.Planets.FirstOrDefault(planet => planet.Name == planetName);
            return desiredPlanet;
        }
    }
}