using System;

namespace ADDED.API.Dtos
{
    public class IndexDto
    {
        
        public int Tour { get; set; }
        public int Ordre { get; set; }
        public string Police { get; set; }
        public decimal AncienIndex { get; set; }
        public decimal NouvIndex { get; set; }
        public DateTime DatIndex { get; set; }
       
    }
}