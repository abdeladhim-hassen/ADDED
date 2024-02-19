using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADDED.API.SonedeModels
{
    [Table("BASECPTR")]
    public partial class Basecptr
    {
        [Column("DIST")]
        public int Dist { get; set; }
        [Column("TOU")]
        public int Tou { get; set; }
        [Column("ORD")]
        public int Ord { get; set; }
        [Column("CODCTR")]
        public int? Codctr { get; set; }
        [Column("CODMARQ")]
        public int? Codmarq { get; set; }
        [Column("CLE3")]
        [StringLength(17)]
        public string Cle3 { get; set; }
    }
}
