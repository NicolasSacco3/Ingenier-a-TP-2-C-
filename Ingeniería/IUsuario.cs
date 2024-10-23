using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingenieria
{
    public interface IUsuario
    {
        string Nombre { get; set; }
        string Email { get; set; }
        bool ValidarEmail();
    }
}
