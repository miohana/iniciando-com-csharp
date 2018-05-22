using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormacaoTalentosFinal.Models
{
    public class Universidade
    {
        // EF identifica por padrão as chaves das tabelas o campos com ID
        // Se eu quiser que um outro campo seja chave coloco um Data Annotation [Key]
        public int UniversidadeID { get; set; }
        public string Nome { get; set; }
        
        public string Cidade { get; set; }
        public string UF { get; set; }
        public virtual ICollection<Curso> Curso { get; set; }
    }
}