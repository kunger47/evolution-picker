namespace Evolution.Models
{
    public class Timescale
    {
        public int Id { get; set; }
        public int? Parent_Id { get; set; }
        public int ScaleID { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
    }
}
