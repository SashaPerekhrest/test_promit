using System;
using MediatR;

namespace TestPromIT.Application.CardDecks.Queries.GetDeckDetails
{
    public class GetDeckDetailsQuary : IRequest<DeckDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
