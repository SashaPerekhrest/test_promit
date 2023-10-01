using MediatR;

namespace TestPromIT.Application.CardDecks.Commands.DeleteDeck
{
    public class DeleteDeckCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
