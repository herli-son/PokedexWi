using Injecoes;
using Mvvm.Base.Eventos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mvvm.Base.ViewModelBase
{
    public abstract class ListaViewModel<TModel> : INotifyPropertyChanged where TModel : class
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ListaViewModel()
        {
            Itens = new ObservableCollection<TModel>();
        }
        public virtual ObservableCollection<TModel> Itens { get; set; }
        public virtual int Index { get; set; }
        public virtual TModel Item { 
            get {
                if (Itens.Count == 0 || Index >= Itens.Count || Index < 0) 
                    return FabricaServicos.CriarInstanciaObjeto<TModel>();
                return Itens[Index];
            } 
        }
        public virtual void NotifyPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public virtual Command RegistrarCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            return new Command(execute, canExecute);
        }
    }
}
