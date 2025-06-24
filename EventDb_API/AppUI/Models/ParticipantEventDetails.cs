namespace AppUI.Models
{
    public class ParticipantEventDetails
    {
        public int Id { get; set; }
        public string ParticipantEmailId { get; set; }
        public int EventId { get; set; }
        public string IsAttended { get; set; }  // Yes or No
    }
}
