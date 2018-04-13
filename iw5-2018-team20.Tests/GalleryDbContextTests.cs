using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        [Fact]
        public void PhotoFindById_NotNull()
        {
            var photo = photoRepositorySUT.FindById(new Guid("1f92e3d5-7a1c-4a3f-8420-ecd04dc8208b"));
            Assert.NotNull(photo);
        }

        [Fact]
        public void PhotoInsert_NotNull()
        {
            var detail = new PhotoDetailModel()
            {
                Id = new Guid("8e141f54-7cfb-44b8-851a-232c8c489479"),
                Name = "TestovaciFotka",
                CreationTime = new DateTime(2018, 11, 24),
                Format = FormatType.Jpg,
                Height = 500,
                Width = 352,
                Note = "Nejaka druha dlouha poznamka."
            };
            var photo = photoRepositorySUT.Insert(detail);
            Assert.NotNull(photo);
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
