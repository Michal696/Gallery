using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iw5_2018_team20.BL.Models;
using iw5_2018_team20.DAL;

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
                    .FirstOrDefault(x => x.Name == name);

                if (photo == null)
                    return null;

                var objectsOnPhoto = galleryDbContext.ObjectOnPhotos
                    .Where(x => x.Photo == photo)
                    .ToList();

                var photoDetailModel = mapper.MapPhotoEntityToDetailModel(photo);
                photoDetailModel.ObjectsOnPhoto = objectsOnPhoto;

                return photoDetailModel;
            }
        }
    }
}
