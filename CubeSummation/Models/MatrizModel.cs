using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntitiesLayer;
using System.ComponentModel.DataAnnotations;

namespace CubeSummation.Models
{
    public class MatrizModel
    {
        public Matriz Matriz { get; set; }

        [Required]
        [Range(1,100)]
        public int NumberOfRows { get; set; }
    }
}