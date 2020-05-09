using System;

namespace SamuraiApp.Domain
{
    public class Battle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StarDate { get; set; }
        public DateTime EndDate { get; set; }
        public SamuraiBattle SamuraiBattle { get; set; }
    }
}