using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TestPromIT.Application.CardDecks.Commands.UpdateDeck
{
    public class UpdateDeckCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Shuffle { get; set; }
    }
}
