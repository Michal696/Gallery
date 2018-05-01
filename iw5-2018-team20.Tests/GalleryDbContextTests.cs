using System;
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
    public class GalleryDbContextTests
    {
        [Fact]
        public void DbConnectionTest()
        {
            using (var galleryDbContext = new GalleryDbContext())
            {
                galleryDbContext.Photos.Any();
            }
        }
    }
}
