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
    public class PersonRepositoryTests
    {
        private PersonRepository personRepositorySUT = new PersonRepository();

        [Fact]
        public void PersonInsert()
        {
            var person = new PersonListModel()
            {
                Firstname = "Market",
                Surname = "Moravcova"
            };
            var inserted = personRepositorySUT.Insert(person);
            Assert.NotNull(inserted);
            using (var context = new GalleryDbContext())
            {
                Assert.Contains(context.Persons, x => x.Id == inserted.Id);
            }
        }

        [Fact]
        public void PersonGetAll_NotNull()
        {
            Assert.NotNull(personRepositorySUT.GetAll());
        }

        [Fact]
        public void PersonRemove()
        {
            var person = new PersonListModel()
            {
                Firstname = "Michaela",
                Surname = "Nova"
            };
            var inserted = personRepositorySUT.Insert(person);
            Assert.NotNull(inserted);
            using (var context = new GalleryDbContext())
            {
                Assert.Contains(context.Persons, x => x.Id == inserted.Id);
            }

            personRepositorySUT.Remove(inserted.Id);

            using (var context = new GalleryDbContext())
            {
                Assert.DoesNotContain(context.Persons, x => x.Id == inserted.Id);
            }
        }
    }
}
