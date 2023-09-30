using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestPromIT.Domain;

namespace TestPromIT.Application.interfaces
{
    public interface ITestDbContext
    {
        DbSet<Card> Cards { get; set; }
        DbSet<CardDeck> Decks { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
