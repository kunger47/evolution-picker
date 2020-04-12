namespace Evolution.Models
{
    public class Classification
    {
        public int Id { get; set; }
        public int? Parent_Id { get; set; }
        public int Classification_Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
    }
}
