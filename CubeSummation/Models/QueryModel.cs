using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommonLayer;
namespace CubeSummation.Models
{
    public class QueryModel
    {
        public Enumerations.Query QueryType { get; set; }

        public int NumberOfRow { get; set; }

        public int NumberOfEndRow { get; set; }

        public int Value { get; set; }
    }
}