using System.ComponentModel.DataAnnotations;

namespace AuthorAPI.Model
{
    public class Book : Author
    {
        [MaxLength(100)]
        public int ISBN { set; get; }
        
        [Required,StringLength(40)]
        public string Title { set; get; }
        
        public int PublicationYear{ set; get; }
        
        public int NumOfPages{ set; get; }
        
        public string Genre{ set; get; }
        
        
    }
}