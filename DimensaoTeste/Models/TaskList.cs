using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DimensaoTeste.Models
{
    public class TaskList
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "O título deve ter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 6)]
        [Display(Name = "Título")]
        public string Titulo { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Situação")]
        public Boolean Situacao{ get; set; }
        public virtual ApplicationUser Usuario { get; set; }
    }
}