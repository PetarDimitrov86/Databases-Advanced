using System;

namespace UsersDatabase
{
    using System.Collections.Generic;
    using System.Data.Entity.Validation;
    using System.Linq;
    using Models;

    class Program
    {
        static void Main()
        {
            UsersContext context = new UsersContext();

            //NOTE: This solution does is not the most proper one, but in order for the task to be solved properly would require more layers and a concrete user frame (not to be able to do everything from the console
            context.AddOwnAlbumToUser(context.Users.First(), new Album()
            {
                IsPublic = true,
                Name = "SomeNames"
            });
            context.SaveChanges();

            context.AddPublicAlbumForUser(context.Users.First(), new Album()
            {
                IsPublic = true,
                Name = "Non public"
            });
            context.SaveChanges();

            var albums = context.GetPublicAlbumsForUser(context.Users.First());
            foreach (ReadOnlyAlbum readOnlyAlbum in albums)
            {
                Console.WriteLine(readOnlyAlbum.Name);
            }
        }
    }
}
