using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Injecoes
{
    public interface IFactoryMultiImplementacao
    {
        string AssemblyName { get; }
        Type[] ObterTipoImplementacao<T>(string classeEspecifica = "") where T : class;
        T CriarInstanciaObjeto<T>(Type tipo, params object[] parametros) where T : class;
        bool InterfaceImplementada<T>();
    }
}
