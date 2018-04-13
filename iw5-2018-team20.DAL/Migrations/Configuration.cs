using System.Collections.Generic;
using iw5_2018_team20.DAL.Entities;

namespace iw5_2018_team20.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<iw5_2018_team20.DAL.GalleryDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(iw5_2018_team20.DAL.GalleryDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var stul = new ThingEntity()
            {
                Id = new Guid("34b5d6d3-0e00-43f5-bbe6-62d0fd42149a"),
                Name = "Stul"
            };
            var postel = new ThingEntity()
            {
                Id = new Guid("37e9c315-a2d6-4d0d-997b-3b54a8f45ccf"),
                Name = "Postel"
            };

            context.Things.AddOrUpdate(x => x.Id, stul, postel);
          

            var tomas = new PersonEntity()
            {
                Id = new Guid("b8c585c3-9358-4cc1-b4bd-2478d2473df9"),
                Firstname = "Tomas",
                Surname = "Nezbeda"
            };
            var karolina = new PersonEntity()
            {
                Id = new Guid("742903e1-e131-455a-85e6-99665e14357b"),
                Firstname = "Karolina",
                Surname = "Pechancova"
            };

            context.Persons.AddOrUpdate(tomas, karolina);

            var stulNaTomasSelfie = new ObjectOnPhotoEntity()
            {
                Id = new Guid("f73da629-e4db-4913-b249-183a61f79933"),
                Object = stul,
                PositionX = 120,
                PositionY = 54
            };

            var tomasNaTomasSelfie = new ObjectOnPhotoEntity()
            {
                Id = new Guid("6f65632b-83ae-4867-9f18-35818f41bce7"),
                Object = tomas,
                PositionX = 125,
                PositionY = 59
            };

            var tomasPhoto = new PhotoEntity()
            {
                Id = new Guid("1f92e3d5-7a1c-4a3f-8420-ecd04dc8208b"),
                ObjectsOnPhoto = { stulNaTomasSelfie , tomasNaTomasSelfie },
                Name = "TomasSelfie",
                CreationTime = new DateTime(2018, 11, 24),
                Format = FormatType.Jpg,
                Height = 500,
                Width = 352,
                Note = "Nejaka dlouha poznamka."
            };

            tomasNaTomasSelfie.Photo = tomasPhoto;
            stulNaTomasSelfie.Photo = tomasPhoto;


            var selfiesAlbum = new AlbumEntity()
            {
                Id = new Guid("92f40210-f3f5-4605-83b5-cf7c93889c4b"),
                Name = "Selfies",
                Photos = { tomasPhoto }
            };

            tomasPhoto.Album = selfiesAlbum;

            context.Albums.AddOrUpdate( selfiesAlbum );
            context.Photos.AddOrUpdate( tomasPhoto );
        }
    }
}
