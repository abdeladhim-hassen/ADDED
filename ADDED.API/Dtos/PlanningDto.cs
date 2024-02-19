using System;

namespace ADDED.API.Dtos
{
    public class PlanningDto
    {
        public int IdReleveur { get; set; }
        public string LibLocalite { get; set; }
        public string TSPUsername { get; set; }
        public int IdPort { get; set; }
        public string MarquePort { get; set; }
        public TourneeDto[] Tournee { get; set; }
        public DateTime DatAffect { get; set; }
    }
}