using System.Collections.Generic;
using iw5_2018_team20.BL.Models;
using iw5_2018_team20.BL.Repositories;
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
                ObjectsOnPhoto = MapObjectsOnPhotoEntityToModelList(entity.ObjectsOnPhoto)
            };
        }

        public ICollection<ObjectOnPhotoModel> MapObjectsOnPhotoEntityToModelList(
            ICollection<ObjectOnPhotoEntity> entities)
        {
            List<ObjectOnPhotoModel> toReturn = new List<ObjectOnPhotoModel>();
            foreach (var objectOnPhotoEntity in entities)
            {
                toReturn.Add(MapObjectOnPhotoEntityToModel(objectOnPhotoEntity));
            }

            return toReturn;
        }

        public ObjectOnPhotoModel MapObjectOnPhotoEntityToModel(ObjectOnPhotoEntity entity)
        {
            return new ObjectOnPhotoModel()
            {
                Id = entity.Id,
                Object = entity.Object,
                Photo = entity.Photo,
                PositionY = entity.PositionY,
                PositionX = entity.PositionX
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
                Album = entity.Album,
                Height = entity.Height,
                Width = entity.Width
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
                ObjectsOnPhoto = MapObjectsOnPhotoModelToEnityList(model.ObjectsOnPhoto)
            };
        }

        public ICollection<ObjectOnPhotoEntity> MapObjectsOnPhotoModelToEnityList(
            ICollection<ObjectOnPhotoModel> models)
        {
            List<ObjectOnPhotoEntity> toReturn = new List<ObjectOnPhotoEntity>();
            foreach (var objectOnPhotoModel in models)
            {
                toReturn.Add(MapObjectOnPhotoModelToEntity(objectOnPhotoModel));
            }

            return toReturn;
        }

        public ObjectOnPhotoEntity MapObjectOnPhotoModelToEntity(ObjectOnPhotoModel entity)
        {
            return new ObjectOnPhotoEntity()
            {
                Object = entity.Object,
                Photo = entity.Photo,
                PositionY = entity.PositionY,
                PositionX = entity.PositionX
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

        public PersonEntity MapPersonListModelToPersonEntity(PersonListModel model)
        {
            return new PersonEntity()
            {
                Id = model.Id,
                Firstname = model.Firstname,
                Surname = model.Surname
            };
        }

        public ThingEntity MapThingListModelToThingEntity(ThingsListModel model)
        {
            return new ThingEntity()
            {
                Id = model.Id,
                Name = model.Name,
            };
        }
    }
}
