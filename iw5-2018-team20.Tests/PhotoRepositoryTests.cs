﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using iw5_2018_team20.BL;
using iw5_2018_team20.BL.Models;
using iw5_2018_team20.BL.Repositories;
using iw5_2018_team20.DAL;
using iw5_2018_team20.DAL.Entities;
using Xunit;

namespace iw5_2018_team20.Tests
{
    public class PhotoRepositoryTests
    {

        private PhotoRepository photoRepositorySUT = new PhotoRepository();
        private Mapper mapper = new Mapper();

        [Fact]
        public void PhotoFindById_NotNull()
        {
            var photo = photoRepositorySUT.FindById(new Guid("1f92e3d5-7a1c-4a3f-8420-ecd04dc8208b"));
            Assert.NotNull(photo);
        }

        [Fact]
        public void PhotoGetAll_NotNull()
        {
            Assert.NotNull(photoRepositorySUT.GetAll());
        }


        [Fact]
        public void PhotoInsert_Simple()
        {
            var detail = new PhotoDetailModel()
            {
                Name = "SimpleTestPhoto"
            };

            var photo = photoRepositorySUT.Insert(detail);
            Assert.NotNull(photo);

            using (var context = new GalleryDbContext())
            {
                Assert.Contains(context.Photos, x => x.Id == photo.Id);
            }
        }

        [Fact]
        public void PhotoInsert_WithAlbum()
        {
            AlbumEntity album;
            using (var context = new GalleryDbContext())
            {
                album = context.Albums.First();
            }

            var detail = new PhotoDetailModel()
            {
                Name = "AlbumTestPhoto",
                Album = album
            };

            var photo = photoRepositorySUT.Insert(detail);
            Assert.NotNull(photo);

            using (var context = new GalleryDbContext())
            {
                Assert.Contains(context.Photos, x => x.Id == photo.Id);
            }
        }

        [Fact]
        public void PhotoInsert_WithObjects()
        {
            ThingEntity someThing;
            using (var context = new GalleryDbContext())
            {
                someThing = context.Things.First();
            }

            ObjectOnPhotoEntity thingOnPhoto = new ObjectOnPhotoEntity()
            {
                PositionX = 1,
                PositionY = 2,
                Id = Guid.NewGuid(),
                Object = someThing
            };

            var detail = new PhotoDetailModel()
            {
                Name = "ThingsTestPhoto",
                ObjectsOnPhoto = {mapper.MapObjectOnPhotoEntityToModel(thingOnPhoto)}
            };

            var photo = photoRepositorySUT.Insert(detail);
            Assert.NotNull(photo);

            using (var context = new GalleryDbContext())
            {
                Assert.Contains(context.Photos, x => x.Id == photo.Id);
            }
        }

        [Fact]
        public void PhotoRemove()
        {
            var detail = new PhotoDetailModel()
            {
                Name = "RemoveTestPhoto"
            };

            var photo = photoRepositorySUT.Insert(detail);
            Assert.NotNull(photo);

            photoRepositorySUT.Remove(photo.Id);

            using (var context = new GalleryDbContext())
            {
                Assert.DoesNotContain(context.Photos, x => x.Id == photo.Id);
            }

        }

        [Fact]
        public void PhotoUpdate()
        {
            ThingEntity someThing;
            using (var context = new GalleryDbContext())
            {
                someThing = context.Things.First();
            }

            ObjectOnPhotoModel thingOnPhoto = new ObjectOnPhotoModel()
            {
                PositionX = 111,
                PositionY = 2,
                Id = Guid.NewGuid(),
                Object = someThing
            };

            ObjectOnPhotoModel thingOnPhoto2 = new ObjectOnPhotoModel()
            {
                PositionX = 1,
                PositionY = 2,
                Id = Guid.NewGuid(),
                Object = someThing
            };

            var detail = new PhotoDetailModel()
            {
                Name = "UpdateTestPhotoStateBefore",
                ObjectsOnPhoto = {thingOnPhoto, thingOnPhoto2}
            };

            var photo = photoRepositorySUT.Insert(detail);
            Assert.NotNull(photo);

            photo.Name = "UpdateTestPhotoStateAfter";
            photo.ObjectsOnPhoto = new List<ObjectOnPhotoModel>();
            photo.ObjectsOnPhoto.Add(thingOnPhoto);

            var photoAfter = photoRepositorySUT.Update(photo);
            Assert.Equal("UpdateTestPhotoStateAfter", photoAfter.Name);
            Assert.Equal(1, photoAfter.ObjectsOnPhoto.Count);
            List<ObjectOnPhotoModel> list = (List<ObjectOnPhotoModel>) photoAfter.ObjectsOnPhoto;
            Assert.Equal(111, list[0].PositionX);


            using (var context = new GalleryDbContext())
            {
                var updatedPhoto = context.Photos.SingleOrDefault(x => x.Id == photoAfter.Id);
                Assert.NotNull(updatedPhoto);
                Assert.Equal("UpdateTestPhotoStateAfter", updatedPhoto.Name);
            }

        }


    }
}
