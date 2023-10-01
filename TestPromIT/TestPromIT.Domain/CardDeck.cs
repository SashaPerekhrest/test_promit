namespace TestPromIT.Domain
{
    public class CardDeck
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Shuffle { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public ICollection<Card> Cards { get; set;}
    }
}
