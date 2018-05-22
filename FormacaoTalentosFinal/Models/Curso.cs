using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FormacaoTalentosFinal.Models
{
    public class Curso
    {
        public int CursoID { get; set; }
        public string Nome { get; set; }
        public int UniversidadeID { get; set; }

        [ForeignKey("UniversidadeID")]
        public virtual Universidade Universidade { get; set; }
    }
}