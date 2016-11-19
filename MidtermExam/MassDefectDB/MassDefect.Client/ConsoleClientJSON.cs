namespace MassDefect.Client
{
    using Data;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;

    public class ConsoleClientJSON
    {

        static void Main(string[] args)
        {
            MassDefectContext context = new MassDefectContext();

            ExportPlanetsWhichAreNotAnomalyOrigins(context);

            ExportPeopleWhichHaveNotBeenVictims(context);

            ExportTopAnomaly(context);

            context.SaveChanges();
        }

        private static void ExportTopAnomaly(MassDefectContext context)
        {
            var topAnomaly = context.Anomalies
                .OrderByDescending(anom => anom.Victims.Count)
                .Take(1)
                .Select(anomaly => new
                {
                    name = anomaly.Id,
                    originPlanet = new
                    {
                        name = anomaly.OriginPlanet.Name
                    },
                    teleportPlanet = new
                    {
                        name = anomaly.TeleportPlanet.Name
                    },
                    victimsCount = anomaly.Victims.Count
                });

            var anomalyAsJson = JsonConvert.SerializeObject(topAnomaly, Formatting.Indented);
            File.WriteAllText("../../topAnomaly.json", anomalyAsJson);
        }

        private static void ExportPeopleWhichHaveNotBeenVictims(MassDefectContext context)
        {
            var exportedPeople = context.Persons
                .Where(person => !person.Anomalies.Any())
                .Select(per => new
                {
                    name = per.Name,
                    homePlanet = new
                    {
                        name = per.HomePlanet.Name
                    }
                });

            var personsAsJson = JsonConvert.SerializeObject(exportedPeople, Formatting.Indented);
            File.WriteAllText("../../persons.json", personsAsJson);
        }

        private static void ExportPlanetsWhichAreNotAnomalyOrigins(MassDefectContext context)
        {
            var exportedPlanets = context.Planets
                .Where(planet => !planet.OriginAnomalies.Any())
                .Select(planet => new
                {
                    name = planet.Name
                });

            var planetsAsJson = JsonConvert.SerializeObject(exportedPlanets, Formatting.Indented);
            File.WriteAllText("../../planets.json", planetsAsJson);
        }
    }
}