using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestPromIT.Application.interfaces;
using TestPromIT.Application.Common.Exeptions;
using TestPromIT.Domain;

namespace TestPromIT.Application.CardDecks.Queries.GetDeckDetails
{
    public class GetDeckDetailsQuaryHandler : IRequestHandler<GetDeckDetailsQuary, DeckDetailsVm>
    {
        private readonly ITestDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDeckDetailsQuaryHandler(ITestDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<DeckDetailsVm> Handle(GetDeckDetailsQuary request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext
                .Decks
                .Include(deck => deck.Cards)
                .FirstOrDefaultAsync(deck => deck.Id == request.Id);

            if (entity == null) 
            {
                throw new NotFoundExeption(nameof(CardDeck), request.Id);
            }
            
            return _mapper.Map<DeckDetailsVm>(entity);
        }
    }
}
