using System;
using AutoMapper;
using TestPromIT.Application.Common.Mappings;
using TestPromIT.Domain;

namespace TestPromIT.Application.CardDecks.Queries.GetDeckDetails
{
    public class DeckDetailsVm : IMapWith<CardDeck>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Shuffle { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public ICollection<Card> Cards { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CardDeck, DeckDetailsVm>()
                .ForMember(deckVm => deckVm.Name, opt => opt.MapFrom(deck => deck.Name))
                .ForMember(deckVm => deckVm.Shuffle, opt => opt.MapFrom(deck => deck.Shuffle))
                .ForMember(deckVm => deckVm.Id, opt => opt.MapFrom(deck => deck.Id))
                .ForMember(deckVm => deckVm.Created, opt => opt.MapFrom(deck => deck.Created))
                .ForMember(deckVm => deckVm.Updated, opt => opt.MapFrom(deck => deck.Updated))
                .ForMember(deckVm => deckVm.Cards, opt => opt.MapFrom(deck => deck.Cards));
        }
    }
}
