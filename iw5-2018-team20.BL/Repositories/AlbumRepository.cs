using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using iw5_2018_team20.BL.Models;
using iw5_2018_team20.DAL;
using iw5_2018_team20.DAL.Entities;

namespace iw5_2018_team20.BL.Repositories
{
    public class AlbumRepository
    {
        Mapper mapper = new Mapper();

        public AlbumDetailModel FindById(Guid id)
        {
            using (var galleryDbContext = new GalleryDbContext())
            {
                var album = galleryDbContext.Albums
                    .Include(x => x.Photos)
                    .FirstOrDefault(x => x.Id == id);

                if (album == null)
                    return null;

                return mapper.MapAlbumEntityToAlbumDetailModel(album);
            }
        }

        public List<AlbumsListModel> GetAll()
        {
            using (var galleryDbContext = new GalleryDbContext())
            {
                return galleryDbContext.Albums
                    .Select(x => mapper.MapAlbumEntityToAlbumListModel(x))
                    .ToList();
            }
        }

        public AlbumDetailModel Insert(AlbumDetailModel detail)
        {
            using (var galleryDbContext = new GalleryDbContext())
            {
                var entity = mapper.MapAlbumDetailModelToAlbumEntity(detail);
                entity.Id = Guid.NewGuid();
                galleryDbContext.Albums.Add(entity);
                galleryDbContext.SaveChanges();

                return mapper.MapAlbumEntityToAlbumDetailModel(entity);
            }
        }

        public void Remove(Guid id)
        {
            using (var galleryDbContext = new GalleryDbContext())
            {
                var entity = new AlbumEntity() { Id = id };
                galleryDbContext.Albums.Attach(entity);
                galleryDbContext.Albums.Remove(entity);
                galleryDbContext.SaveChanges();
            }
        }

    }
}
