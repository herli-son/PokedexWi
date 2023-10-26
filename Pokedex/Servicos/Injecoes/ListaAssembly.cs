using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Injecoes
{
    public static class ListaAssembly
    {
        private const string EXTENSAO = "*.dll";
        private static object assemblySegura = new object();
        private static object implementacaoSegura = new object();
        private static List<Assembly> assemblysConhecidas;
        private static List<IFactoryImplementacao> componentesInjecao;
        private static List<IFactoryMultiImplementacao> componenteMultiplaInjecao;
        private static string path { get => new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)).LocalPath; }
        public static List<Assembly> AssemblysConhecidas
        {
            get
            {
                lock (assemblySegura)
                {
                    if (assemblysConhecidas == null)
                    {
                        assemblysConhecidas = CarregarTodasAssemblys();
                    }
                }
                return assemblysConhecidas;
            }
        }
        public static List<IFactoryImplementacao> ComponentesInjecao
        {
            get
            {
                lock (implementacaoSegura)
                {
                    componentesInjecao = CarregarTodasImplementacoesFactory();
                }
                return componentesInjecao;
            }
        }
        public static List<IFactoryMultiImplementacao> ComponenteMultiplaInjecao
        {
            get
            {
                lock (implementacaoSegura)
                {
                    componenteMultiplaInjecao = CarregarTodasMultiImplementacoesFactory();
                }
                return componenteMultiplaInjecao;
            }
        }
        private static List<Assembly> CarregarTodasAssemblys()
        {
            var lista = System.IO.Directory.GetFiles(path, EXTENSAO, System.IO.SearchOption.TopDirectoryOnly).Select(Assembly.LoadFrom).ToList();
            return lista;
        }
        private static List<IFactoryImplementacao> CarregarTodasImplementacoesFactory()
        {
            var objetoImplementaFactory = (from assembly in AssemblysConhecidas
                                           where !assembly.IsDynamic
                                           from type in assembly.GetExportedTypes()
                                           where !type.IsAbstract
                                           where !type.IsGenericTypeDefinition
                                           where typeof(IFactoryImplementacao).IsAssignableFrom(type)
                                           select type).ToArray();
            return objetoImplementaFactory.Select(t => Activator.CreateInstance(t) as IFactoryImplementacao).ToList();
        }
        private static List<IFactoryMultiImplementacao> CarregarTodasMultiImplementacoesFactory()
        {
            var objetoImplementaFactory = (from assembly in AssemblysConhecidas
                                           where !assembly.IsDynamic
                                           from type in assembly.GetExportedTypes()
                                           where !type.IsAbstract
                                           where !type.IsGenericTypeDefinition
                                           where typeof(IFactoryMultiImplementacao).IsAssignableFrom(type)
                                           select type).ToArray();
            return objetoImplementaFactory.Select(t => Activator.CreateInstance(t) as IFactoryMultiImplementacao).ToList();
        }
    }
}
