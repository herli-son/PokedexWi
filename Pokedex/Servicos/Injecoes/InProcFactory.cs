using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Injecoes
{
    public static class InProcFactory
    {
        public static T ObterInstanciaInterfaceMultiImplementada<T>(string nomeClasseEspecifica, params object[] parametros) where T : class
        {
            var fabrica = ListaAssembly.ComponenteMultiplaInjecao.Where(f => f.InterfaceImplementada<T>()).ToArray();
            if(fabrica ==  null || fabrica.Length == 0) return null;

            var tipos = fabrica.SelectMany(x=>x.ObterTipoImplementacao<T>(nomeClasseEspecifica)).ToArray();

            if (tipos.Length > 1)
                throw new DuplicateWaitObjectException("Mais de um objeto implementa a mesma interface.");
            if (tipos.Length == 0)
                throw new DuplicateWaitObjectException("Nenhum objeto implementa a interface.");

            var construtor = fabrica.Where(x => x.AssemblyName == tipos[0].Assembly.FullName).FirstOrDefault();

            if (construtor == null)
                throw new ApplicationException($"Assembly {tipos[0].Assembly.FullName} não foi encontrada.");

            return construtor.CriarInstanciaObjeto<T>(tipos[0], parametros);
        }
        public static T ObterInstanciaInterfaceImplementada<T>(params object[] parametros) where T : class
        {
            var fabrica = ListaAssembly.ComponentesInjecao.Where(f => f.InterfaceImplementada<T>()).ToArray();
            if (fabrica == null || fabrica.Length == 0) return null;

            if (fabrica.Length > 1)
                throw new DuplicateWaitObjectException("Mais de um objeto implementa a mesma interface.");
            if (fabrica.Length == 1)
                return fabrica[0].CriarInstanciaObjeto<T>(parametros);
                
            return null;
        }
        public static T ObterInstanciaImplementaInterfaceObsoleta<T>() where T : class
        {
            var tipo = ObterTipoImplementaInterfaceObsoleta<T>();
            if (tipo == null) return null;

            return (T)Activator.CreateInstance(tipo);
        }
        public static Type ObterTipoImplementaInterfaceObsoleta<T>() where T : class
        {
            var assemblyes = ListaAssembly.AssemblysConhecidas;

            var classeServico = (from assembly in assemblyes
                                 where !assembly.IsDynamic
                                 from type in assembly.GetExportedTypes()
                                 where !type.IsAbstract
                                 where !type.IsGenericTypeDefinition
                                 where typeof(T).IsAssignableFrom(type)
                                 select type).FirstOrDefault();
            return classeServico;
        }
    }
}
