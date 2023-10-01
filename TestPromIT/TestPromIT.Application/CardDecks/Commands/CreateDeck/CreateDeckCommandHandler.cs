using MediatR;
using TestPromIT.Application.interfaces;
using TestPromIT.Domain;

namespace TestPromIT.Application.CardDecks.Commands.CreateDeck
{
    public class CreateDeckCommandHandler : IRequestHandler<CreateDeckCommand, Guid>
    {
        private readonly ITestDbContext _dbContext;

        public CreateDeckCommandHandler(ITestDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateDeckCommand request, CancellationToken cancellationToken)
        {
            var deck = new CardDeck
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Shuffle = request.Shuffle,
                Created = DateTime.UtcNow,
                Cards = new List<Card>()
            };

            deck.Cards = new List<Card>()
            {
                new Card() {CardSuit = "clubs", CardRank = "6", Id = Guid.NewGuid()},
                new Card() {CardSuit = "clubs", CardRank = "7", Id = Guid.NewGuid()},
                new Card() {CardSuit = "clubs", CardRank = "8", Id = Guid.NewGuid()},
                new Card() {CardSuit = "clubs", CardRank = "9", Id = Guid.NewGuid()},
                new Card() {CardSuit = "clubs", CardRank = "10", Id = Guid.NewGuid()},
                new Card() {CardSuit = "clubs", CardRank = "Jack", Id = Guid.NewGuid()},
                new Card() {CardSuit = "clubs", CardRank = "Queen", Id = Guid.NewGuid()},
                new Card() {CardSuit = "clubs", CardRank = "King", Id = Guid.NewGuid()},
                new Card() {CardSuit = "clubs", CardRank = "Ace", Id = Guid.NewGuid()},
                new Card() {CardSuit = "diamonds", CardRank = "6", Id = Guid.NewGuid()},
                new Card() {CardSuit = "diamonds", CardRank = "7", Id = Guid.NewGuid()},
                new Card() {CardSuit = "diamonds", CardRank = "8", Id = Guid.NewGuid()},
                new Card() {CardSuit = "diamonds", CardRank = "9", Id = Guid.NewGuid()},
                new Card() {CardSuit = "diamonds", CardRank = "10", Id = Guid.NewGuid()},
                new Card() {CardSuit = "diamonds", CardRank = "Jack", Id = Guid.NewGuid()},
                new Card() {CardSuit = "diamonds", CardRank = "Queen", Id = Guid.NewGuid()},
                new Card() {CardSuit = "diamonds", CardRank = "King", Id = Guid.NewGuid()},
                new Card() {CardSuit = "diamonds", CardRank = "Ace", Id = Guid.NewGuid()},
                new Card() {CardSuit = "hearts", CardRank = "6", Id = Guid.NewGuid()},
                new Card() {CardSuit = "hearts", CardRank = "7", Id = Guid.NewGuid()},
                new Card() {CardSuit = "hearts", CardRank = "8", Id = Guid.NewGuid()},
                new Card() {CardSuit = "hearts", CardRank = "9", Id = Guid.NewGuid()},
                new Card() {CardSuit = "hearts", CardRank = "10", Id = Guid.NewGuid()},
                new Card() {CardSuit = "hearts", CardRank = "Jack", Id = Guid.NewGuid()},
                new Card() {CardSuit = "hearts", CardRank = "Queen", Id = Guid.NewGuid()},
                new Card() {CardSuit = "hearts", CardRank = "King", Id = Guid.NewGuid()},
                new Card() {CardSuit = "hearts", CardRank = "Ace", Id = Guid.NewGuid()},
                new Card() {CardSuit = "spades", CardRank = "6", Id = Guid.NewGuid()},
                new Card() {CardSuit = "spades", CardRank = "7", Id = Guid.NewGuid()},
                new Card() {CardSuit = "spades", CardRank = "8", Id = Guid.NewGuid()},
                new Card() {CardSuit = "spades", CardRank = "9", Id = Guid.NewGuid()},
                new Card() {CardSuit = "spades", CardRank = "10", Id = Guid.NewGuid()},
                new Card() {CardSuit = "spades", CardRank = "Jack", Id = Guid.NewGuid()},
                new Card() {CardSuit = "spades", CardRank = "Queen", Id = Guid.NewGuid()},
                new Card() {CardSuit = "spades", CardRank = "King", Id = Guid.NewGuid()},
                new Card() {CardSuit = "spades", CardRank = "Ace", Id = Guid.NewGuid()},
            };

            foreach (var card in deck.Cards)
                await _dbContext.Cards.AddAsync(card, cancellationToken);

            await _dbContext.Decks.AddAsync(deck, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return deck.Id;
        }
    }
}
