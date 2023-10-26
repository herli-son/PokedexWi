using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Injecoes
{
    public static class FabricaServicos
    {
        public static T CriarInstanciaObjeto<T>(params object[] parametros) where T : class
        {
            var novo = InProcFactory.ObterInstanciaInterfaceMultiImplementada<T>("", parametros);
            if (novo != null) return novo;

            var item = InProcFactory.ObterInstanciaInterfaceImplementada<T>(parametros);
            if (item != null) return item;

            return InProcFactory.ObterInstanciaImplementaInterfaceObsoleta<T>();
        }
        public static T CriarInstanciaObjetoMultiplo<T>(string nomeClasse, params object[] parametros) where T : class
        {
            var novo = InProcFactory.ObterInstanciaInterfaceMultiImplementada<T>(nomeClasse, parametros);
            if (novo != null) return novo;

            var item = InProcFactory.ObterInstanciaInterfaceImplementada<T>(parametros);
            if (item != null) return item;

            return InProcFactory.ObterInstanciaImplementaInterfaceObsoleta<T>();
        }
    }
}
