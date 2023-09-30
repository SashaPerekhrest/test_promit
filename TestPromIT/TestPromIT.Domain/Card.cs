using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPromIT.Domain
{
    public class Card
    {
        public Guid Id { get; set; }
        public string CardSuit { get; set; }
        public string CardRank { get; set; }
    }
}
