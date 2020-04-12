namespace Evolution.Messages
{
    public class SpeciesMessage
    {
        public int Id { get; set; }
        public int Ancestor_Id { get; set; }
        public string Classification { get; set; }
        public string Timespan { get; set; }
        public int Pressure_Id { get; set; }
        public string SpeciesName { get; set; }
        public string CommonName { get; set; }
        public string Adaption { get; set; }
        public string Info { get; set; }
    }
}
