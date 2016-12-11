namespace Photography.XMLImport
{
    using System;
    using System.Linq;
    using System.Xml.XPath;
    using Data;
    using Models;
    using System.Xml.Linq;
    using AutoMapper;
    using Models.DTOs;
    using System.Collections.Generic;

    public class XMLImport
    {
        private const string xmlPath = "..//..//..//datasets//{0}.xml";

        static void Main()
        {
            UnitOfWork unit = new UnitOfWork();
            ConfigureMapper();

            ImportAccessories(unit);
            ImportWorkshops(unit);
        }

        private static void ImportAccessories(UnitOfWork unit)
        {
            var xml = XDocument.Load(String.Format(xmlPath, "accessories"));
            var accessories = xml.XPathSelectElements("accessories/accessory");
            Random rnd = new Random();
            int photographersCount = unit.Photographers.GetAll().Count();

            foreach (var accessoryXml in accessories)
            {
                var accessoryNameAttr = accessoryXml.Attribute("name");
                if (accessoryNameAttr == null)
                {
                    continue;
                }
                AccessoryDTO accessoryDto = new AccessoryDTO
                {
                    Name = accessoryNameAttr.Value
                };

                Accessory accessory = Mapper.Map<Accessory>(accessoryDto);

                int randomOwnerId = rnd.Next(1, photographersCount);

                accessory.Owner = unit.Photographers.FirstOrDefaultWhere(phot => phot.Id == randomOwnerId);
                unit.Accessories.Add(accessory);
                unit.Commit();
                Console.WriteLine($"Successfully imported {accessory.Name}");
            }
        }

        private static void ImportWorkshops(UnitOfWork unit)
        {
            var xml = XDocument.Load(String.Format(xmlPath, "workshops"));
            var workshopsXml = xml.XPathSelectElements("workshops/workshop");

            foreach (var workshopXml in workshopsXml)
            {
                var workshopNameAttr = workshopXml.Attribute("name");
                var workshopStartDateAttr = workshopXml.Attribute("start-date");
                var workshopEndDateAttr = workshopXml.Attribute("end-date");
                var workshopLocationAttr = workshopXml.Attribute("location");
                var workshopPriceAttr = workshopXml.Attribute("price");

                var trainerNameEl = workshopXml.XPathSelectElement("trainer");

                if (workshopNameAttr == null || workshopLocationAttr == null || workshopPriceAttr == null ||
                    trainerNameEl == null)
                {
                    Console.WriteLine("Error. Invalid data provided");
                    continue;
                }

                var participantsXml = workshopXml.XPathSelectElements("participants/participant");

                ICollection<Photographer> participants = new List<Photographer>();
                foreach (var participantXml in participantsXml)
                {
                    var firstNameAttr = participantXml.Attribute("first-name");
                    var lastNameAttr = participantXml.Attribute("last-name");

                    if (firstNameAttr == null || lastNameAttr == null)
                    {
                        Console.WriteLine("Error. Invalid data provided");
                        continue;
                    }

                    Photographer participant = unit.Photographers
                        .FirstOrDefaultWhere(ph => ph.FirstName == firstNameAttr.Value
                                                   && ph.LastName == lastNameAttr.Value);
                    participants.Add(participant);
                }
                DateTime? starDate = DateTime.Now;
                DateTime? endDate = DateTime.Now;
                try
                {
                    starDate = DateTime.Parse(workshopStartDateAttr.Value);
                }
                catch (Exception)
                {
                    starDate = null;
                }
                try
                {
                    endDate = DateTime.Parse(workshopEndDateAttr.Value);
                }
                catch (Exception)
                {
                    endDate = null;
                }

                Workshop workshop = new Workshop
                {
                    Name = workshopNameAttr.Value,
                    EndDate = endDate,
                    StartDate = starDate,
                    Location = workshopLocationAttr.Value,
                    Trainer = unit.Photographers.FirstOrDefaultWhere(tr => tr.FirstName + " "+ tr.LastName == trainerNameEl.Value),
                    Participants = participants,
                    PricePerParticipant = decimal.Parse(workshopPriceAttr.Value)
                };

                unit.Workshops.Add(workshop);
                unit.Commit();
                Console.WriteLine($"Successfully imported {workshop.Name}");
            }
        }

        private static void ConfigureMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<AccessoryDTO, Accessory>();
            });
        }
    }
}