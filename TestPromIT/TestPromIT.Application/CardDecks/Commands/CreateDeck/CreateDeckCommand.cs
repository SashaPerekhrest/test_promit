using MediatR;

namespace TestPromIT.Application.CardDecks.Commands.CreateDeck
{
    public class CreateDeckCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Shuffle { get; set; }
        public int CountCard { get; set; }
    }
}
