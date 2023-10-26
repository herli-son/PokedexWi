using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Injecoes
{
    public interface IFactoryImplementacao
    {
        T CriarInstanciaObjeto<T>(params object[] parametros) where T : class;
        bool InterfaceImplementada<T>();
    }
}
