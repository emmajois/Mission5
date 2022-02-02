using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Models
{
    public class FavoriteMovie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        public bool Edited { get; set; }

        public string Lent { get; set; }

        //Making sure that notes can only ever be 25 characters long
        [MaxLength(25)]
        public string Notes { get; set; }

        //Build Foreign Key relationship
        //[ForeignKey("CategoryModel")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
