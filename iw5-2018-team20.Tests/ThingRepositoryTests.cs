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
    public class ThingRepositoryTests
    {
        private ThingRepository thingRepositorySUT = new ThingRepository();

        [Fact]
        public void PersonInsert()
        {
            var thing = new ThingsListModel()
            {
                Name = "Obraz"
            };
            var inserted = thingRepositorySUT.Insert(thing);
            Assert.NotNull(inserted);
            using (var context = new GalleryDbContext())
            {
                Assert.Contains(context.Things, x => x.Id == inserted.Id);
            }
        }

        [Fact]
        public void PersonGetAll_NotNull()
        {
            Assert.NotNull(thingRepositorySUT.GetAll());
        }

        [Fact]
        public void PersonRemove()
        {
            var thing = new ThingsListModel()
            {
                Name = "Obraz"
            };
            var inserted = thingRepositorySUT.Insert(thing);
            Assert.NotNull(inserted);
            using (var context = new GalleryDbContext())
            {
                Assert.Contains(context.Things, x => x.Id == inserted.Id);
            }

            thingRepositorySUT.Remove(inserted.Id);

            using (var context = new GalleryDbContext())
            {
                Assert.DoesNotContain(context.Things, x => x.Id == inserted.Id);
            }
        }
    }
}
