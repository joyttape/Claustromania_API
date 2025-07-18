﻿using System;
using Claustromania.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Claustromania.Models
{
    [Table("unidade")]
    public class Unidade
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("nome")]
        public string Nome { get; set; }

        [Column("capacidade")]
        public int? Capacidade { get; set; }

        [Column("horario_abertura")]
        public TimeSpan? HorarioAbertura { get; set; }

        [Column("horario_fechamento")]
        public TimeSpan? HorarioFechamento { get; set; }

        [Column("telefone")]
        public string Telefone { get; set; }

        [Column("cnpj")]
        public string Cnpj { get; set; }

        [Column("diafunci")]
        public string DiaFunci { get; set; }


        [Column("ativa")]
        public bool Ativa { get; set; } = true;

        [ForeignKey("FkEndereco")]
        public Endereco Endereco { get; set; }
        [Column("fk_endereco")]
        public Guid? FkEndereco { get; set; }



        [ForeignKey("FkFuncionario")]
        public Funcionario Funcionario { get; set; }
        [Column("fk_funcionario")]
        public Guid? FkFuncionario
        {
            get; set;
        }
    }
}
