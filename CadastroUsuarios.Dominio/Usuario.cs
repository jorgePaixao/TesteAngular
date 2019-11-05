using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroUsuarios.Dominio
{
    public class Usuario
    {

        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        [EmailAddress]
        public string  Email { get; set; }         
        public DateTime DataNascimento { get; set; }
        public int Escolaridade { get; set; }        


        public void ValidarDataNascimento()
        {
            if (DataNascimento > DateTime.Now)
            {
                throw new Exception("Data de nascimento deve ser menor que hoje!");
            }
        }
    }
}