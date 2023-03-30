using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaModel
{
    public class Usuario
    {
        [DisplayName("Código do Usuário")]
        [Required(ErrorMessage = "Código do Usuário é Obrigatório")]
        public int UsuId { get; set; }

        [DisplayName("Nome do Usuário")]
        [Required(ErrorMessage = "Nome do Usuário é Obrigatório")]
        [StringLength(50, ErrorMessage = "O Nome do Usuário não deve ter mais de 50 caracteres")]
        public string Nome { get; set; }

        [DisplayName("Cargo do Usuário")]
        [Required(ErrorMessage = "Cargo do usuário é Obrigatório")]
        [StringLength(30, ErrorMessage = "O Cargo do Usuário não deve ter mais de 30 caracteres")]
        public string Cargo { get; set; }

        [DisplayName("Data de Nascimento")]
        [Required(ErrorMessage="Digite a data de nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Nasc { get; set; }
    }
}
