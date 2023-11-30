using System.ComponentModel.DataAnnotations;

namespace ProgrammingClass4.AngularLesson.DataTransferObjects
{
    public class ProductTypeDto
    {
        public int Id {  get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        [StringLength(300)]
        public string? Description { get; set; }
    }
}
