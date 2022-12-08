using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Infrastructure.QueryBuilder;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.Infrastructure.Queries
{
    public class EventQuery : IEventQuery
    {
        private readonly SqlQueryBuilder _sqlQueryBuilder;

        public EventQuery(SqlQueryBuilder sqlQueryBuilder)
        {
            _sqlQueryBuilder = sqlQueryBuilder;
        }

        public async Task<List<EventDTO>> GetEvents(GetEventsParameter query)
        {
            return await _sqlQueryBuilder
                .SelectAllProperties<EventDTO>()
                .From("Event")
                .BuildQuery<EventDTO>()
                .ExecuteToList();
        }
    }
}
