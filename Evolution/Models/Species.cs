namespace Evolution.Models
{
    public class Species
    {
        public int Id { get; set; }
        public int Ancestor_Id { get; set; }
        public int Classification_Id { get; set; }
        public int Timespan_Id { get; set; }
        public int Pressure_Id { get; set; }
        public string SpeciesName { get; set; }
        public string CommonName { get; set; }
        public string Adaption { get; set; }
        public string Info { get; set; }
    }
}
