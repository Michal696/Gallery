using System;
using System.Collections.Generic;
using System.Linq;
using iw5_2018_team20.BL.Models;
using iw5_2018_team20.DAL;
using iw5_2018_team20.DAL.Entities;

namespace iw5_2018_team20.BL.Repositories
{
    public class PersonRepository
    {
        Mapper mapper = new Mapper();

        public List<PersonListModel> GetAll()
        {
            using (var galleryDbContext = new GalleryDbContext())
            {
                var personEntites = galleryDbContext.Persons.ToList();
                return personEntites.Select(mapper.MapPersonEntityToPersonListModel).ToList();
            }
        }

        public PersonListModel GetById(Guid Id)
        {
            using (var galleryDbContext = new GalleryDbContext())
            {
                var personEntity = galleryDbContext.Persons.FirstOrDefault(x => x.Id == Id);
                return mapper.MapPersonEntityToPersonListModel(personEntity);
            }
        }

        public PersonListModel Insert(PersonListModel person)
        {
            using (var galleryDbContext = new GalleryDbContext())
            {
                var entity = mapper.MapPersonListModelToPersonEntity(person);
                entity.Id = Guid.NewGuid();

                galleryDbContext.Persons.Add(entity);
                galleryDbContext.SaveChanges();

                return mapper.MapPersonEntityToPersonListModel(entity);
            }
        }

        public void Remove(Guid id)
        {
            using (var galleryDbContext = new GalleryDbContext())
            {
                var entity = new PersonEntity() { Id = id };
                galleryDbContext.Persons.Attach(entity);
                galleryDbContext.Persons.Remove(entity);
                galleryDbContext.SaveChanges();
            }
        }
    }
}
