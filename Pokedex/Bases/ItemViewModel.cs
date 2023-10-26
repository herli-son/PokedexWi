using Injecoes;
using Mvvm.Base.Eventos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mvvm.Base.ViewModelBase
{
    public class ItemViewModel<TModel> : INotifyPropertyChanged where TModel : class
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ItemViewModel()
        {
            Item = FabricaServicos.CriarInstanciaObjeto<TModel>();
        }
        public virtual TModel Item {get; set;}
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
