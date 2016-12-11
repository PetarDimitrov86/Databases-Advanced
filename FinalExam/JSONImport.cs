namespace Photography.JSONImport
{
    using System.Linq;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Data;
    using Models;
    using Models.DTOs;
    using Newtonsoft.Json;
    using AutoMapper;
    using System.Data.Entity.Validation;

    public class JSONImport
    {
        private const string datasetsPath = "..//..//..//datasets//{0}.json";

        static void Main()
        {
            UnitOfWork unit = new UnitOfWork();
            ConfigureMapper(unit);

            ImportLenses(unit);
            ImportCameras(unit);
            ImportPhotographers(unit);
        }

        private static void ImportLenses(UnitOfWork unit)
        {
            var json = File.ReadAllText(String.Format(datasetsPath, "lenses"));
            var lensesDtos = JsonConvert.DeserializeObject<IEnumerable<LensDTO>>(json);

            foreach (var lensDto in lensesDtos)
            {
                if (lensDto.Make == null || lensDto.CompatibleWith == null || lensDto.FocalLength == 0 ||
                    lensDto.MaxAperture == 0)
                {
                    continue;
                }
                Lens lens = Mapper.Map<Lens>(lensDto);
                unit.Lenses.Add(lens);
                unit.Commit();
                Console.WriteLine($"Successfully imported {lens.Make} {lens.FocalLength}mm f{lens.MaxAperture}");
            }
        }

        private static void ImportCameras(UnitOfWork unit)
        {
            var json = File.ReadAllText(String.Format(datasetsPath, "cameras"));
            var camerasDtos = JsonConvert.DeserializeObject<IEnumerable<CameraDTO>>(json);

            foreach (var cameraDto in camerasDtos)
            {
                if (cameraDto.Type == null || cameraDto.Make == null || cameraDto.Model == null ||
                    cameraDto.MinISO == null)
                {
                    Console.WriteLine("Error. Invalid data provided");
                    continue;
                }

                if (cameraDto.Type == "DSLR")
                {
                    Camera camera = new DSLRCamera
                    {
                        IsFullFrame = cameraDto.IsFullFrame,
                        Make = cameraDto.Make,
                        MaxISO = cameraDto.MaxISO,
                        MaxShutterSpeed = cameraDto.MaxShutterSpeed,
                        MinISO = cameraDto.MinISO,
                        Model = cameraDto.Model
                    };

                    unit.Cameras.Add(camera);
                    try
                    {
                        unit.Commit();
                        Console.WriteLine($"Successfully imported {cameraDto.Type} {cameraDto.Make} {cameraDto.Model}");
                    }
                    catch (DbEntityValidationException dbex)
                    {
                        unit.Cameras.Delete(camera);
                        Console.WriteLine("Error. Invalid data provided");
                    }
                }
                else if (cameraDto.Type == "Mirrorless")
                {
                    Camera camera = new MirrorlessCamera
                    {
                        IsFullFrame = cameraDto.IsFullFrame,
                        Make = cameraDto.Make,
                        MaxFrameRate = cameraDto.MaxFrameRate,
                        MaxVideoResolution = cameraDto.MaxVideoResolution,
                        MaxISO = cameraDto.MaxISO,
                        MinISO = cameraDto.MinISO,
                        Model = cameraDto.Model
                    };

                    unit.Cameras.Add(camera);
                    try
                    {
                        unit.Commit();
                        Console.WriteLine($"Successfully imported {cameraDto.Type} {cameraDto.Make} {cameraDto.Model}");
                    }
                    catch (Exception)
                    {
                        unit.Cameras.Delete(camera);
                        Console.WriteLine("Error. Invalid data provided");
                    }
                }
            }
        }

        private static void ImportPhotographers(UnitOfWork unit)
        {
            var json = File.ReadAllText(String.Format(datasetsPath, "photographers"));
            var photographerDtos = JsonConvert.DeserializeObject<IEnumerable<PhotographerDTO>>(json);

            foreach (var photographerDto in photographerDtos)
            {
                if (photographerDto.FirstName == null || photographerDto.LastName == null)
                {
                    Console.WriteLine("Error. Invalid data provided");
                    continue;
                }

                Random rnd = new Random();
                int camerasCount = unit.Cameras.GetAll().Count();
                int firstCameraId = rnd.Next(1, camerasCount);
                int secondCameraId = rnd.Next(1, camerasCount);
                Camera randomPrimaryCamera = unit.Cameras.FirstOrDefaultWhere(cam => cam.Id == firstCameraId);
                Camera randomSecondaryCamera =
                    unit.Cameras.FirstOrDefaultWhere(cam => cam.Id == secondCameraId);

                Photographer photographer = new Photographer
                {
                    FirstName = photographerDto.FirstName,
                    LastName = photographerDto.LastName,
                    PrimaryCamera = randomPrimaryCamera,
                    SecondaryCamera = randomSecondaryCamera,
                    Phone = photographerDto.Phone
                };

                foreach (int lensId in photographerDto.Lenses)
                {
                    Lens lensToAdd = unit.Lenses.FirstOrDefaultWhere(lens => lens.Id == lensId);
                    if (lensToAdd == null)
                    {
                        continue;
                    }
                    ICollection<Camera> bothCameras = new List<Camera>
                    {
                        photographer.PrimaryCamera,
                        photographer.SecondaryCamera
                    };

                    if (bothCameras.Count(camera => camera.Make == lensToAdd.CompatibleWith) < 1)
                    {
                        continue;
                    }
                    photographer.Lenses.Add(lensToAdd);
                }

                unit.Photographers.Add(photographer);

                try
                {
                    unit.Commit();
                    Console.WriteLine($"Successfully imported {photographer.FirstName} {photographer.LastName} | Lenses: {photographer.Lenses.Count}");
                }
                catch (DbEntityValidationException dbex)
                {
                    unit.Photographers.Delete(photographer);
                    Console.WriteLine("Error. Invalid data provided");
                }
            }
        }

        private static void ConfigureMapper(UnitOfWork unit)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<LensDTO, Lens>();
                cfg.CreateMap<CameraDTO, Camera>();
                cfg.CreateMap<PhotographerDTO, Photographer>();
            });
        }
    }
}