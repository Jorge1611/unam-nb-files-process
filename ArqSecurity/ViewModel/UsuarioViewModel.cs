using ArqSecurity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ArqSecurity.ViewModel
{
    public class UsuarioViewModel
    {
        public string Email { get; private set; }
        public string IDictionary { get; private set; }
        public string Puesto { get; private set; }
        public string UserName { get; private set; }

        public static implicit operator UsuarioViewModel(ApplicationUser _entity)
        {
                return new UsuarioViewModel
                {
                    UserName = _entity.UserName,
                    Email = _entity.Email,
                    //Puesto =  (_entity.Usuario.Puesto == null ? _entity.Usuario.Puesto:"ad"),
                    IDictionary = _entity.Id
                };
           
        }
    }
}
