using Claro.Rechazo.Common.Extensions;
using Claro.Rechazo.Common.Interfaces.Behavior;
using Claro.Rechazo.Common.Interfaces.DTO;
using Claro.Rechazo.DataAccess.Entities;

namespace Claro.Rechazo.DataAccess.DAL
{
    public partial class UsuarioDAL : IUsuarioBehavior
    {
        public IUsuarioDTO ConsultarUsuario(IUsuarioDTO usuario)
        {
            Usuario u = new Usuario();
            u.id = 1;
            u.nombre = "Prueba";

            return u.MapperToObject<Usuario, IUsuarioDTO>();
           
        }
    }
}
