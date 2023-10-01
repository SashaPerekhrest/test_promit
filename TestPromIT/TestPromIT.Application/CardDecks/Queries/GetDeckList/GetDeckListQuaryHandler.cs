using MediatR;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TestPromIT.Application.interfaces;

namespace TestPromIT.Application.CardDecks.Queries.GetDeckList
{
    public class GetDeckListQuaryHandler : IRequestHandler<GetDeckListQuary, DeckListVm>
    {
        private ITestDbContext _dbContext;
        private IMapper _mapper;

        public GetDeckListQuaryHandler(ITestDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<DeckListVm> Handle(GetDeckListQuary request, CancellationToken cancellationToken)
        {
            var decksQuery = await _dbContext
                .Decks
                .ProjectTo<DeckLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new DeckListVm { Decks = decksQuery };
        }
    }
}
