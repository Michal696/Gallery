using iw5_2018_team20.BL.Models;
using iw5_2018_team20.DAL.Entities;

namespace iw5_2018_team20.BL
{
    public class Mapper
    {
        public PhotoDetailModel MapPhotoEntityToPhotoDetailModel(PhotoEntity entity)
        {
            return new PhotoDetailModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Album = entity.Album,
                CreationTime = entity.CreationTime,
                Format = entity.Format,
                Height = entity.Height,
                Note = entity.Note,
                Width = entity.Width,
                ObjectsOnPhoto = entity.ObjectsOnPhoto
            };
        }

        public PhotosListModel MapPhotoEntityToPhotoListModel(PhotoEntity entity)
        {
            return new PhotosListModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                CreationTime = entity.CreationTime,
                Format = entity.Format,
                Album = entity.Album
            };
        }

        public PhotoEntity MapPhotoDetailModelToPhotoEntity(PhotoDetailModel model)
        {
            return new PhotoEntity()
            {
                Id = model.Id,
                Name = model.Name,
                Album = model.Album,
                CreationTime = model.CreationTime,
                Format = model.Format,
                Height = model.Height,
                Note = model.Note,
                Width = model.Width,
                ObjectsOnPhoto = model.ObjectsOnPhoto
            };
        }

        public AlbumDetailModel MapAlbumEntityToAlbumDetailModel(AlbumEntity entity)
        {
            return new AlbumDetailModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Photos = entity.Photos
            };
        }

        public AlbumsListModel MapAlbumEntityToAlbumListModel(AlbumEntity entity)
        {
            return new AlbumsListModel()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public AlbumEntity MapAlbumDetailModelToAlbumEntity(AlbumDetailModel model)
        {
            return new AlbumEntity()
            {
                Id = model.Id,
                Name = model.Name,
                Photos = model.Photos
            };
        }

        public ThingsListModel MapThingEntityToThingsListModel(ThingEntity entity)
        {
            return new ThingsListModel()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public PersonListModel MapPersonEntityToPersonListModel(PersonEntity entity)
        {
            return new PersonListModel()
            {
                Id = entity.Id,
                Firstname = entity.Firstname,
                Surname = entity.Surname
            };
        }
    }
}
