using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnsureThat;
using WeddingAlbum.ApplicationServices.Boundaries;
using WeddingAlbum.Common.Auth;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.ApplicationServices.UseCases
{
    public class GetSampleUseCase : IQueryHandler<SampleParameter, List<SampleDTO>>
    {
        private readonly ISampleQuery _sampleQuery;
        private readonly ICurrentUserService _currentUserService;

        public GetSampleUseCase(ISampleQuery sampleQuery, ICurrentUserService currentUserService)
        {
            EnsureArg.IsNotNull(sampleQuery, nameof(sampleQuery));

            _sampleQuery = sampleQuery;
            _currentUserService = currentUserService;
        }

        public async Task<List<SampleDTO>> Handle(SampleParameter query)
        {
            Console.WriteLine(_currentUserService.UserId);
            return await _sampleQuery.GetSampleData(query);
        }
    }
}
