namespace Photography.JSONExport
{
    using System;
    using System.IO;
    using Newtonsoft.Json;
    using System.Linq;
    using Data;
    using Models;

    public class JSONExport
    {
        private const string resultsPath = "..//..//..//results//{0}.json";
        
        static void Main()
        {
            UnitOfWork unit = new UnitOfWork();

            ExportOrderedPhotographers(unit);
            ExportLandscapePhotographers(unit);
        }

        private static void ExportOrderedPhotographers(UnitOfWork unit)
        {
            var photographers = unit.Photographers
                .GetAll().Select(ph => new
                {
                    FirstName = ph.FirstName,
                    LastName = ph.LastName,
                    Phone = ph.Phone
                })
                .OrderBy(ph => ph.FirstName)
                .ThenByDescending(ph => ph.LastName);

            var queryAsJson = JsonConvert.SerializeObject(photographers, Formatting.Indented);
            File.WriteAllText(String.Format(resultsPath, "photographers-ordered"), queryAsJson);
        }

        private static void ExportLandscapePhotographers(UnitOfWork unit)
        {
            var landscapePhotographers = unit.Photographers
                .GetAll(ph => ph.PrimaryCamera is DSLRCamera
                              && ph.Lenses.All(lens => lens.FocalLength <= 30)
                              && ph.Lenses.Count > 0)
                 .Select(ph => new
                {
                    FirstName = ph.FirstName,
                    LastName = ph.LastName,
                    CameraMake = ph.PrimaryCamera.Make,
                    LensesCount = ph.Lenses.Count
                })
                .OrderBy(ph => ph.FirstName);

            var queryAsJson = JsonConvert.SerializeObject(landscapePhotographers, Formatting.Indented);
            File.WriteAllText(String.Format(resultsPath, "landscape-photographers"), queryAsJson);
        }
    }
}