using MediatR;
using Microsoft.EntityFrameworkCore;
using TestPromIT.Domain;
using TestPromIT.Application.interfaces;
using TestPromIT.Application.Common.Exeptions;
using System.Threading;
using System.Threading.Tasks;

namespace TestPromIT.Application.CardDecks.Commands.DeleteDeck
{
    public class DeleteDeckCommadHandler : IRequestHandler<DeleteDeckCommand>
    {
        private readonly ITestDbContext _dbContext;

        public DeleteDeckCommadHandler(ITestDbContext dbContext) => 
            _dbContext = dbContext;

        public async Task Handle(DeleteDeckCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Decks.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null) 
            {
                throw new NotFoundExeption(nameof(CardDeck), request.Id);
            }

            _dbContext.Decks.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
