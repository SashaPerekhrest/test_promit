using TestPromIT.Application.interfaces;
using TestPromIT.Domain;
using TestPromIT.Application.Common.Exeptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace TestPromIT.Application.CardDecks.Commands.UpdateDeck
{
    public class UpdateDeckCommandHandler : IRequestHandler<UpdateDeckCommand>
    {
        private readonly ITestDbContext _dbContext;

        public UpdateDeckCommandHandler(ITestDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateDeckCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext
                .Decks
                .Include(decks => decks.Cards)
                .FirstOrDefaultAsync(deck => deck.Id == request.Id, cancellationToken);

            if (entity == null) 
            {
                throw new NotFoundExeption(nameof(CardDeck), request.Id);
            }

            entity.Name = request.Name;
            entity.Shuffle = request.Shuffle;
            entity.Updated = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
