using TestPromIT.Application.Common.Mappings;
using TestPromIT.Domain;
using AutoMapper;

namespace TestPromIT.Application.CardDecks.Queries.GetDeckList
{
    public class DeckLookupDto : IMapWith<CardDeck>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<CardDeck, DeckLookupDto>()
                .ForMember(deckDto => deckDto.Id, opt => opt.MapFrom(deck => deck.Id))
                .ForMember(deckDto => deckDto.Name, opt => opt.MapFrom(deck => deck.Name));
        }
    }
}
