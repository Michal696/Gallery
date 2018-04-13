using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iw5_2018_team20.BL.Models;
using iw5_2018_team20.DAL.Entities;

namespace iw5_2018_team20.BL
{
    public class Mapper
    {
        public PhotoDetailModel MapPhotoEntityToDetailModel(PhotoEntity entity)
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
                Width = entity.Width
            };
        }
    }
}
