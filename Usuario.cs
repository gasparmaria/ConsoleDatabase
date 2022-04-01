using System;

namespace AppDatabaseDominio
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string UsuarioNome { get; set; }
        public string UsuarioCargo { get; set; }
        public DateTime UsuarioDataNasc { get; set; }


        public Usuario()
        {

        }

        public Usuario(int usuarioId, string usuarioNome, string usuarioCargo, DateTime usuarioDataNasc)
        {
            UsuarioId = usuarioId;
            UsuarioNome = usuarioNome;
            UsuarioCargo = usuarioCargo;
            UsuarioDataNasc = usuarioDataNasc;
        }
    }
}