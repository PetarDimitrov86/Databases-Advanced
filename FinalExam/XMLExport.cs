namespace Photography.XMLExport
{
    using System.Linq;
    using System.Xml.Linq;
    using Data;
    using System;

    public class XMLExport
    {
        private const string xmlExportPath = "..//..//..//results//{0}.xml";

        static void Main()
        {
            UnitOfWork unit = new UnitOfWork();

            PhotoGraphersWithSameCameraMake(unit);
            WorkshopsByLocation(unit);
        }

        private static void PhotoGraphersWithSameCameraMake(UnitOfWork unit)
        {
            var photographersWithSameCameraMake = unit.Photographers
                .GetAll(ph => ph.PrimaryCamera.Make == ph.SecondaryCamera.Make)
                .Select(ph => new
                {
                    name = ph.FirstName + " " + ph.LastName,
                    primary_camera = ph.PrimaryCamera.Make + " " + ph.PrimaryCamera.Model,
                    lenses = ph.Lenses.Select(lens => new
                    {
                        lensInfo = $"{lens.Make} {lens.FocalLength}mm f{lens.MaxAperture}"
                    })
                });

            var xmlDocument = new XElement("photographers");

            foreach (var photographer in photographersWithSameCameraMake)
            {
                var photographerNode = new XElement("photographer");
                photographerNode.Add(new XAttribute("name", photographer.name));
                photographerNode.Add(new XAttribute("primary-camera", photographer.primary_camera));

                if (photographer.lenses.Any())
                {
                    var lensesNode = new XElement("lenses");
                    foreach (var lense in photographer.lenses)
                    {
                        var lensNode = new XElement("lens");
                        lensNode.Value = lense.lensInfo;
                        lensesNode.Add(lensNode);
                    }
                    photographerNode.Add(lensesNode);
                }
                xmlDocument.Add(photographerNode);
            }

            xmlDocument.Save(String.Format(xmlExportPath, "same-cameras-photographers"));
        }

        private static void WorkshopsByLocation(UnitOfWork unit)
        {
            var workshopsByLocation = unit.Workshops
                .GetAll(work => work.Participants.Count >= 5)
                .GroupBy(wo => wo.Location)
                .Select(work => new 
                {
                    locationName = work.Key,
                    workshopInfo = work.Select(wo1 => new
                    {
                        workshopName = wo1.Name,
                        totalProfit = 0.8m * (wo1.Participants.Count * wo1.PricePerParticipant),
                        participantsCount = wo1.Participants.Count,
                        participants = wo1.Participants.Select(part => new
                        {
                            participantName = part.FirstName + " " + part.LastName
                        })
                    })
                });
            var xmlDocument = new XElement("locations");

            foreach (var workshop in workshopsByLocation)
            {
                var locationNode = new XElement("location");
                locationNode.SetAttributeValue("name", workshop.locationName);

                foreach (var workshInfo in workshop.workshopInfo)
                {
                    var workshopNode = new XElement("workshop");
                    workshopNode.SetAttributeValue("name", workshInfo.workshopName);
                    workshopNode.SetAttributeValue("total-profit", workshInfo.totalProfit);

                    var participantsNode = new XElement("participants");
                    participantsNode.SetAttributeValue("count", workshInfo.participantsCount);
                    foreach (var participant in workshInfo.participants)
                    {
                        participantsNode.Add(new XElement("participant", participant.participantName));
                    }

                    workshopNode.Add(participantsNode);
                    locationNode.Add(workshopNode);
                }
                xmlDocument.Add(locationNode);
            }

            xmlDocument.Save(String.Format(xmlExportPath, "workshops-by-location"));
        }
    }
}