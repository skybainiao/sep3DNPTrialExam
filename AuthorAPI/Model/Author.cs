using System.ComponentModel.DataAnnotations;

namespace AuthorAPI.Model
{
    public class Author
    {
        [Key,MaxLength(300)]
        public int Id { set; get; }
        
        [Required,StringLength(15)]
        public string FirstName { set; get; }
        
        [Required,StringLength(15)]
        public string LastName { set; get; }
    }
}