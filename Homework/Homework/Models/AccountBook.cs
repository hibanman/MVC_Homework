namespace Homework.Models
{
    using Homework.ValidateAttribute;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccountBook")]
    public partial class AccountBook
    {
        public Guid Id { get; set; }


        [Required(AllowEmptyStrings = false)]
        public int Categoryyy { get; set; }

        [Range(0, int.MaxValue)]
        public int Amounttt { get; set; }

        [DayRange]
        public DateTime Dateee { get; set; }

        [Required]
        [StringLength(500)]
        public string Remarkkk { get; set; }
    }
}
