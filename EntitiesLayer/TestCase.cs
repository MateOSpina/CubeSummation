using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EntitiesLayer
{
    public class TestCase
    {
        public int Id { get; set; }

        [Required]
        [Range(1,50)]
        public int Cases { get; set; }

        public int Executed { get; set; }

        public List<Matriz> Matriz { get; set; }
    }
}
