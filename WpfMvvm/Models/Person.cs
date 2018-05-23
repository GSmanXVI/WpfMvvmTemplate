using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMvvm.Tools;

namespace WpfMvvm.Models
{
    class Person : ObservableObject, IDataErrorInfo
    {
        
        public string Name { get; set; }

        public string this[string columnName] => this.Validate(columnName);
        public string Error => throw new NotImplementedException();
    }
}
