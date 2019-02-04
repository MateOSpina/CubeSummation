using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EntitiesLayer
{
    public class Matriz
    {
        public int Id { get; set; }

        public List<Row> Rows { get; set; }

        [Required]
        [Range(1, 1000)]
        public int Operations { get; set; }

        public int Executed { get; set; }
    }
}
