using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace iw5_2018_team20.DAL
{
    class GalleryDbContext : DbContext
    {
        public IDbSet<Entities.PhotoEntity> Photos { get; set; }
        public IDbSet<Entities.AlbumEntity> Albums { get; set; }
        public IDbSet<Entities.PersonEntity> Persons { set; get; }
        public IDbSet<Entities.ThingEntity> Things { get; set; }
        public IDbSet<Entities.ObjectOnPhotoEntity> ObjectOnPhotos { get; set; }

        public GalleryDbContext() : base("GalleryContext")
        {
        }
    }
}
