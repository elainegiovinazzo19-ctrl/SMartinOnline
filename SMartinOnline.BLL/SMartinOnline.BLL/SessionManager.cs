using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMartinOnline.Entidades;

namespace SMartinOnline.BLL
{
    public class SessionManager
    {
        private static SessionManager _instancia;
        private Usuario _usuarioActual;

        private SessionManager() { }

        public static SessionManager Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new SessionManager();
                return _instancia;
            }
        }

        public Usuario UsuarioActual
        {
            get { return _usuarioActual; }
        }

        public void IniciarSesion(Usuario usuario)
        {
            _usuarioActual = usuario;
        }

        public void CerrarSesion()
        {
            _usuarioActual = null;
        }

        public bool HaySesionActiva()
        {
            return _usuarioActual != null;
        }
    }
}
