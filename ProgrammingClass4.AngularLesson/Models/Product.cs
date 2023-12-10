﻿using System.ComponentModel.DataAnnotations;

namespace ProgrammingClass4.AngularLesson.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }  

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public int? ManufacturerId { get; set; }
        public Manufacturer? Manufacturer { get; set; }
        public int? ProductTypeId { get; set; }
        public ProductType? ProductType { get; set; }
        public int? UnitOfMeasureId { get; set; }
        public UnitOfMeasure? UnitOfMeasure { get;set; }
    }
}
