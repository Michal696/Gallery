﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iw5_2018_team20.BL.Models;
using iw5_2018_team20.DAL;
using iw5_2018_team20.DAL.Entities;

namespace iw5_2018_team20.BL.Repositories
{
    public class ThingRepository
    {
        Mapper mapper = new Mapper();

        public List<ThingsListModel> GetAll()
        {
            using (var galleryDbContext = new GalleryDbContext())
            {
                var thingEntites = galleryDbContext.Things.ToList();
                return thingEntites.Select(mapper.MapThingEntityToThingsListModel).ToList();
            }
        }

        public ThingsListModel GetById(Guid Id)
        {
            using (var galleryDbContext = new GalleryDbContext())
            {
                var thingEntites = galleryDbContext.Things.FirstOrDefault(x=> x.Id == Id);
                return mapper.MapThingEntityToThingsListModel(thingEntites);
            }
        }

        public ThingsListModel Insert(ThingsListModel thing)
        {
            using (var galleryDbContext = new GalleryDbContext())
            {
                var entity = mapper.MapThingListModelToThingEntity(thing);
                entity.Id = Guid.NewGuid();

                galleryDbContext.Things.Add(entity);
                galleryDbContext.SaveChanges();

                return mapper.MapThingEntityToThingsListModel(entity);
            }
        }

        public void Remove(Guid id)
        {
            using (var galleryDbContext = new GalleryDbContext())
            {
                var entity = new ThingEntity() { Id = id };
                galleryDbContext.Things.Attach(entity);
                galleryDbContext.Things.Remove(entity);
                galleryDbContext.SaveChanges();
            }
        }
    }
}
