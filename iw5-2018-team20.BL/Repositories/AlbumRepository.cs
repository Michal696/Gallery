using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
                var albumEntites =  galleryDbContext.Albums.ToList();
                return albumEntites.Select(mapper.MapAlbumEntityToAlbumListModel).ToList();
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
                var itemToRemove = galleryDbContext.Albums.SingleOrDefault(x => x.Id == id);
                if (itemToRemove != null)
                {
                    var photosWithThisAlbum = galleryDbContext.Photos.Where(x => x.Album.Id == itemToRemove.Id)
                        .ToList();
                    foreach (var p in photosWithThisAlbum)
                    {
                        p.Album = null;
                    }

                    galleryDbContext.SaveChanges();

                    galleryDbContext.Albums.Remove(itemToRemove);
                    galleryDbContext.SaveChanges();
                }
            }
        }

    }
}
