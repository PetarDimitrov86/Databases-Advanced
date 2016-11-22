using System;
using System.Collections.Generic;
using PhotoShare.Client.Repositories;

namespace PhotoShare.Client
{
    using Core;
    using Data;
    using Interfaces;
    using IO;
    using Models;
    using System.Data.Entity;

    class Application
    {
        static void Main()
        {
            var testContext = new PhotoShareContext();
            IRepository<Tag> tags = new Repository<Tag>(testContext);
            Tag firstTag = tags.GetById(1);
            Console.WriteLine(firstTag.Name);
            IEnumerable<Tag> tagsCollection = tags.Find(t => t.Name == "random");

            foreach (var tag in tagsCollection)
            {
                Console.WriteLine(tag.Name);
            }

            testContext.SaveChanges();
        }
    }
}
