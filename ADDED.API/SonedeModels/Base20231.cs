using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADDED.API.SonedeModels
{
    [Table("BASE20231")]
    public partial class Base20231
    {
        [Column("ZAN")]
        public int? Zan { get; set; }
        [Column("ZTRI")]
        public int? Ztri { get; set; }
        [Column("ZTIER")]
        public int? Ztier { get; set; }
        [Column("ZSIX")]
        public int? Zsix { get; set; }
        [Column("DIST")]
        public int? Dist { get; set; }
        [Column("TOU")]
        public int Tou { get; set; }
        [Column("ORD")]
        public int? Ord { get; set; }
        [Column("POL")]
        public string Pol { get; set; }
        [Column("POSIT")]
        public int? Posit { get; set; }
        [Column("CATEG")]
        public int? Categ { get; set; }
        [Column("NOMADR")]
        public string Nomadr { get; set; }
        [Column("CODONAS")]
        public int? Codonas { get; set; }
        [Column("CODCTR")]
        public int? Codctr { get; set; }
        [Column("CODMARQ")]
        public int? Codmarq { get; set; }
        [Column("NUMCTR")]
        public string Numctr { get; set; }
        [Column("CODONAN")]
        public int? Codonan { get; set; }
        [Column("AINDEX", TypeName = "numeric(6, 0)")]
        public decimal? Aindex { get; set; }
        [Column("RELEVE", TypeName = "numeric(6, 0)")]
        public decimal? Releve { get; set; }
        [Column("CONSMOY", TypeName = "numeric(6, 0)")]
        public decimal? Consmoy { get; set; }
    }
}
