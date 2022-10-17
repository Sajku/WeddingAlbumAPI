using System.Collections.Generic;
using System.Threading.Tasks;
using EnsureThat;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Infrastructure.QueryBuilder;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.Infrastructure.Queries
{
    public class SampleQuery : ISampleQuery
    {
        private readonly SqlQueryBuilder _sqlQueryBuilder;

        public SampleQuery(SqlQueryBuilder sqlQueryBuilder)
        {
            EnsureArg.IsNotNull(sqlQueryBuilder, nameof(sqlQueryBuilder));

            _sqlQueryBuilder = sqlQueryBuilder;
        }

        public async Task<List<SampleDTO>> GetSampleData(SampleParameter query)
        {
            return await _sqlQueryBuilder
                .Select("Name")
                .From("Sample")
                .BuildQuery<SampleDTO>()
                .ExecuteToList();
        }
    }
}
