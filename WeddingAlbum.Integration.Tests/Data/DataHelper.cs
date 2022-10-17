using System.Collections.Generic;
using WeddingAlbum.Domain.Samples;
using WeddingAlbum.Infrastructure.DataModel.Context;

namespace WeddingAlbum.Integration.Tests.Data
{
    public static class DataHelper
    {
        public static void PopulateTestData(WeddingAlbumContext dbContext)
        {
            dbContext.Samples.Add(new Sample("Sample_1"));
            dbContext.Samples.Add(new Sample("Sample_2"));
            dbContext.Samples.Add(new Sample("Sample_3"));
            dbContext.SaveChanges();
        }

        public static List<string> GetTableNames()
        {
            return new List<string>
            {
                "Sample"
            };
        }
    }
}
