namespace Fitsense.Models
{
    public class CompletedSet : SensorModel
    {
        public int SetID { get; set; }
        public Set Set { get; set; }
        public long Time { get; set; }
        public int Duration { get; set; }
        public int UserID { get; set; }
        public User User {get;set;}
    }
}
