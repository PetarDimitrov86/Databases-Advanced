namespace MassDefect.XMLExport
{
    using System.Linq;
    using System.Xml.Linq;
    using Data;

    public class ConsoleClientXML
    {
        static void Main(string[] args)
        {
            var context = new MassDefectContext();
            var exportedAnomalies = context.Anomalies.Select(anomaly => new
            {
                id = anomaly.Id,
                originPlanetName = anomaly.OriginPlanet.Name,
                teleportPlanetName = anomaly.TeleportPlanet.Name,
                victims = anomaly.Victims
            }).OrderBy(anom => anom.id);
            
            var xmlDocument = new XElement("anomalies");

            foreach (var exportedAnomaly in exportedAnomalies)
            {
                var anomalyNode = new XElement("anomaly");
                anomalyNode.Add(new XAttribute("id", exportedAnomaly.id));
                anomalyNode.Add(new XAttribute("origin-planet", exportedAnomaly.originPlanetName));
                anomalyNode.Add(new XAttribute("teleport-planet", exportedAnomaly.teleportPlanetName));

                var victimsNode = new XElement("victims");
                foreach (var victim in exportedAnomaly.victims)
                {
                    var victimNode = new XElement("victim");
                    victimNode.Add(new XAttribute("name", victim.Name));
                    victimsNode.Add(victimNode);
                }
                
                anomalyNode.Add(victimsNode);

                xmlDocument.Add(anomalyNode);
            }
            xmlDocument.Save("../../anomalies.xml");
        }
    }
}