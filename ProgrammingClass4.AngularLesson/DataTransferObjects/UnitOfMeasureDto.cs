using System.ComponentModel.DataAnnotations;

namespace ProgrammingClass4.AngularLesson.DataTransferObjects
{
    public class UnitOfMeasureDto
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        
        [StringLength(100)]
        public string? Description { get; set; }
    }
}
