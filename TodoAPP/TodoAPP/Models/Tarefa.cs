using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPP.Models
{
    public class Tarefa
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Insira um nome!")]
        [MaxLength(100, ErrorMessage = "Limite máximo de caracteres excedido")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Insira uma data para conclusão!")]
        [DataType(DataType.Date)]
        public DateTime DataConclusao { get; set; }
        public bool Concluido { get; set; }

        public Tarefa()
        {
        }

        public Tarefa(int id, string nome, DateTime dataConclusao, bool concluido)
        {
            Id = id;
            Nome = nome;
            DataConclusao = dataConclusao;
            Concluido = concluido;
        }
    }
}
