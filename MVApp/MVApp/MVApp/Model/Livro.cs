using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVApp.Model
{
    public class Livro : INotifyPropertyChanged
    {
        private int id;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
            }
        }

        private string titulo;
        public string Titulo {
            get { return titulo; }
            set {
                titulo = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Titulo)));
            }
        }

        public Autor Autor { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
