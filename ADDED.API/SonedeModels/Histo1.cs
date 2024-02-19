using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADDED.API.SonedeModels
{
    [Table("HISTO1")]
    public partial class Histo1
    {
        
        [Column("ZDIS")]
        public int Zdis { get; set; }
        [Column("ZTOU")]
        public int Ztou { get; set; }
        [Column("ZORD")]
        public int Zord { get; set; }
        [Column("ZPOL")]
        public string Zpol { get; set; }
        [Column("ZTRIM")]
        public int Ztrim { get; set; }
        [Column("ZANNE")]
        public int Zanne { get; set; }
        [Column("ZCONS", TypeName = "decimal(6,0)")]
        public decimal? Zcons { get; set; }
    }
}
