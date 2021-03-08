namespace WESTDemo.Domain.Models
{
    public class Centre : Entity
    {
        public string Name { get; set; }
        public int OrganisationId { get; set; }

        // Navigation Properties
        public Organisation Organisation { get; set; }
        
    }
}