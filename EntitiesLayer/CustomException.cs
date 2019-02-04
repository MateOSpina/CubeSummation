using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class CustomException
    {
        public CustomException(string description)
        {
            CreationDate = DateTimeOffset.Now;
            Description = description;
        }

        public int Id { get; set; }

        public DateTimeOffset CreationDate { get; set; }

        public string Description { get; set; }
    }
}
