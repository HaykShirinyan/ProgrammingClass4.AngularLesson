using System.ComponentModel.DataAnnotations;

namespace ProgrammingClass4.AngularLesson.DataTransferObjects
{
    public class UnitOfMeasureDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [StringLength(500)]
        public string? Description { get; set; }
    }
    public class ReferencedUnitOfMeasureDto
    {
        [Required]
        public int? Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }
    }
}
