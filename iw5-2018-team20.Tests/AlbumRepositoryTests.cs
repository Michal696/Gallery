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
    public class AlbumRepositoryTests
    {
        private AlbumRepository albumRepositorySUT = new AlbumRepository();

        [Fact]
        public void AlbumFindById_NotNull()
        {
            var album = albumRepositorySUT.FindById(new Guid("92f40210-f3f5-4605-83b5-cf7c93889c4b"));
            Assert.NotNull(album);
        }

        [Fact]
        public void AlbumInsert()
        {
            var detail = new AlbumDetailModel()
            {
                Name = "TestInsertAlbum",
                Photos = new List<PhotoEntity>()
            };
            var album = albumRepositorySUT.Insert(detail);
            Assert.NotNull(album);

            using (var context = new GalleryDbContext())
            {
                Assert.Contains(context.Albums, x => x.Id == album.Id);
            }
        }

        [Fact]
        public void AlbumRemove()
        {
            var detail = new AlbumDetailModel()
            {
                Id = Guid.NewGuid(),
                Name = "TestovaciAlbum",
                Photos = new List<PhotoEntity>()
            };
            var album = albumRepositorySUT.Insert(detail);
            Assert.NotNull(album);

            albumRepositorySUT.Remove(detail.Id);

            using (var context = new GalleryDbContext())
            {
                Assert.DoesNotContain(context.Albums, x => x.Id == detail.Id);
            }
        }

        [Fact]
        public void AlbumGetAll_NotNull()
        {
            Assert.NotNull(albumRepositorySUT.GetAll());
        }

        [Fact]
        public void AlbumFindById()
        {
            var selfiesId = new Guid("92f40210-f3f5-4605-83b5-cf7c93889c4b");
            var selfiesAlbum = albumRepositorySUT.FindById(selfiesId);
            Assert.Equal(selfiesId, selfiesAlbum.Id);
            Assert.Equal("Selfies", selfiesAlbum.Name);

        }
    }
}
