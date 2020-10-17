namespace MercuryApi.Data.Models
{
    public sealed class Session : Auditable
    {
        public string Name { get; set; }

        public int Capacity { get; set; }

        public int CurrentCount { get; set; }

        public string ShortSessionCode { get; set; }
    }
}