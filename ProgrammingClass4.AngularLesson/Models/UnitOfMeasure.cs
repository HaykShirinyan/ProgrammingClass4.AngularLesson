﻿using System.ComponentModel.DataAnnotations;

namespace ProgrammingClass4.AngularLesson.Models
{
    public class UnitOfMeasure
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [StringLength(500)]
        public string? Description { get; set; }

    }
}
