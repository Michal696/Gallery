using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iw5_2018_team20.BL.Models;
using iw5_2018_team20.DAL;

namespace iw5_2018_team20.BL.Repositories
{
    public class ThingRepository
    {
        Mapper mapper = new Mapper();

        public List<ThingsListModel> GetAll()
        {
            using (var galleryDbContext = new GalleryDbContext())
            {
                return galleryDbContext.Things
                    .Select(x => mapper.MapThingEntityToThingsListModel(x))
                    .ToList();
            }
        }
    }
}
