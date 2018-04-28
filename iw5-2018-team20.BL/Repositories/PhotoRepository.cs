using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using iw5_2018_team20.BL.Models;
using iw5_2018_team20.DAL;
using iw5_2018_team20.DAL.Entities;

namespace iw5_2018_team20.BL.Repositories
{
    public class PhotoRepository
    {
        Mapper mapper = new Mapper();

        public PhotoDetailModel FindById(Guid id)
        {
            using (var galleryDbContext = new GalleryDbContext())
            {
                var photo = galleryDbContext.Photos
                    .Include(x => x.ObjectsOnPhoto.Select( y => y.Object))
                    .Include(x => x.Album)
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
                var photoEntities = galleryDbContext.Photos.ToList();
                return photoEntities.Select(mapper.MapPhotoEntityToPhotoListModel).ToList();
            }
        }

        public PhotoDetailModel Insert(PhotoDetailModel detail)
        {
            using (var galleryDbContext = new GalleryDbContext())
            {
                var entity = mapper.MapPhotoDetailModelToPhotoEntity(detail);
                entity.Id = Guid.NewGuid();

                if (entity.Album != null)
                {
                    var album = galleryDbContext.Albums.First(x => x.Id == entity.Album.Id);
                    entity.Album = album;
                }

                foreach (var objectOnPhotoEntity in entity.ObjectsOnPhoto)
                {
                    var thing = galleryDbContext.Things.FirstOrDefault(x => x.Id == objectOnPhotoEntity.Object.Id);
                    var person = galleryDbContext.Persons.FirstOrDefault(x => x.Id == objectOnPhotoEntity.Object.Id);
                    if (thing != null)
                        objectOnPhotoEntity.Object = thing;
                    else if (person != null)
                        objectOnPhotoEntity.Object = person;
                }

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

        public PhotoDetailModel Update(PhotoDetailModel detail)
        {
            using (var galleryDbContext = new GalleryDbContext())
            {
                var entity = galleryDbContext.Photos.First(r => r.Id == detail.Id);

                entity.Name = detail.Name;
                entity.CreationTime = detail.CreationTime;
                entity.Format = detail.Format;
                entity.Width = detail.Width;
                entity.Height = detail.Height;
                entity.Note = detail.Note;

                if (detail.Album != null)
                {
                    var album = galleryDbContext.Albums.First(x => x.Id == detail.Album.Id);
                    entity.Album = album;
                }

                foreach (var objectOnPhotoEntity in detail.ObjectsOnPhoto)
                {
                    var thing = galleryDbContext.Things.FirstOrDefault(x => x.Id == objectOnPhotoEntity.Object.Id);
                    var person = galleryDbContext.Persons.FirstOrDefault(x => x.Id == objectOnPhotoEntity.Object.Id);
                    if (thing != null)
                        objectOnPhotoEntity.Object = thing;
                    else if (person != null)
                        objectOnPhotoEntity.Object = person;
                }

                galleryDbContext.SaveChanges();

                return mapper.MapPhotoEntityToPhotoDetailModel(entity);
            }
        }
    }
}
