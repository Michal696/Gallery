using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using iw5_2018_team20.BL;
using iw5_2018_team20.BL.Models;
using iw5_2018_team20.BL.Repositories;
using iw5_2018_team20.DAL;
using iw5_2018_team20.DAL.Entities;
using Xunit;

namespace iw5_2018_team20.Tests
{
    public class GalleryDbContextTests
    {
        [Fact]
        public void DbConnectionTest()
        {
            using (var galleryDbContext = new GalleryDbContext())
            {
                galleryDbContext.Photos.Any();
            }
        }

        private PhotoRepository photoRepositorySUT = new PhotoRepository();
        private Mapper mapperSUT = new Mapper();

        [Fact]
        public void PhotoFindById_NotNull()
        {
            var photo = photoRepositorySUT.FindById(new Guid("1f92e3d5-7a1c-4a3f-8420-ecd04dc8208b"));
            Assert.NotNull(photo);
        }

        [Fact]
        public void PhotoInsert_Complex()
        {
            AlbumEntity selfieAlbum;
            ThingEntity someThing;
            using (var context = new GalleryDbContext())
            {
                selfieAlbum = context.Albums.First();
                someThing = context.Things.First();
            }

            ObjectOnPhotoEntity thingOnPhoto = new ObjectOnPhotoEntity()
            {
                PositionX = 1,
                PositionY = 2,
                Id = Guid.NewGuid(),
                Object = someThing
            };

            Assert.NotNull(selfieAlbum);

            var detail = new PhotoDetailModel()
            {
                Id = Guid.NewGuid(),
                Name = "TestovaciFotka",
                CreationTime = DateTime.Now,
                Format = FormatType.Jpg,
                Height = 500,
                Width = 352,
                Note = "Nejaka druha dlouha poznamka.",
                Album = selfieAlbum,
                ObjectsOnPhoto = { thingOnPhoto }

            };
            var photo = photoRepositorySUT.Insert(detail);
            Assert.NotNull(photo);

            using (var context = new GalleryDbContext())
            {
                Assert.DoesNotContain(context.Albums.First().Photos, x => x.Name == "TatoTamFaktNejni");
                Assert.Contains(context.Albums.First().Photos, x => x.Name == "TestovaciFotka");
                Assert.Contains(context.Photos, x => x.Name == "TestovaciFotka");
            }
        }

        private AlbumRepository albumRepositorySUT = new AlbumRepository();

        [Fact]
        public void AlbumFindById_NotNull()
        {
            var album = albumRepositorySUT.FindById(new Guid("92f40210-f3f5-4605-83b5-cf7c93889c4b"));
            Assert.NotNull(album);
        }

        [Fact]
        public void AlbumInsert_NotNull()
        {
            var detail = new AlbumDetailModel()
            {
                Id = new Guid("b95da128-0819-44b4-8b38-3640178588f0"),
                Name = "TestovaciAlbum",
                Photos = new List<PhotoEntity>()
            };
            var album = albumRepositorySUT.Insert(detail);
            Assert.NotNull(album);
        }
    }
}
