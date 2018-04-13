using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using iw5_2018_team20.BL.Models;
using iw5_2018_team20.DAL;
using iw5_2018_team20.DAL.Entities;

namespace iw5_2018_team20.BL.Repositories
{
    class PhotoRepository
    {
        Mapper mapper = new Mapper();

        public PhotoDetailModel FindByName(string name)
        {
            using (var galleryDbContext = new GalleryDbContext())
            {
                var photo = galleryDbContext.Photos
                    .Include(x => x.ObjectsOnPhoto)
                    .FirstOrDefault(x => x.Name == name);

                if (photo == null)
                    return null;

                return mapper.MapPhotoEntityToPhotoDetailModel(photo);
            }
        }

        public PhotoDetailModel FindById(Guid id)
        {
            using (var galleryDbContext = new GalleryDbContext())
            {
                var photo = galleryDbContext.Photos
                    .Include(x => x.ObjectsOnPhoto)
                    .FirstOrDefault(x => x.Id == id);

                if (photo == null)
                    return null;

                return mapper.MapPhotoEntityToPhotoDetailModel(photo);
            }
        }

        public List<PhotosListModel> GetAll()
        {
            using (var galleryDbContext = new GalleryDbContext())
            {
                return galleryDbContext.Photos
                    .Select(x => mapper.MapPhotoEntityToPhotoListModel(x))
                    .ToList();
            }
        }

        public PhotoDetailModel Insert(PhotoDetailModel detail)
        {
            using (var galleryDbContext = new GalleryDbContext())
            {
                var entity = mapper.MapPhotoDetailModelToPhotoEntity(detail);
                entity.Id = Guid.NewGuid();

                galleryDbContext.Photos.Add(entity);
                galleryDbContext.SaveChanges();

                return mapper.MapPhotoEntityToPhotoDetailModel(entity);
            }
        }

        public void Remove(Guid id)
        {
            using (var galleryDbContext = new GalleryDbContext())
            {
                var entity = new PhotoEntity() {Id = id};
                galleryDbContext.Photos.Attach(entity);
                galleryDbContext.Photos.Remove(entity);
                galleryDbContext.SaveChanges();
            }
        }
    }
}
