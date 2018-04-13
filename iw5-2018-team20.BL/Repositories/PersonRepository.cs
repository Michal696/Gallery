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
                return galleryDbContext.Persons
                    .Select(x => mapper.MapPersonEntityToPersonListModel(x))
                    .ToList();
            }
        }
        
        //TODO: jeste nevim jaky navratovy typ zde budeme potrebovat
        public void Insert(PersonListModel person)
        {
            using (var galleryDbContext = new GalleryDbContext())
            {
                var entity = mapper.MapPersonListModelToPersonEntity(person);
                entity.Id = Guid.NewGuid();

                galleryDbContext.Persons.Add(entity);
                galleryDbContext.SaveChanges();
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
