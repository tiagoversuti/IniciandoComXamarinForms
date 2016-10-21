using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVApp.ViewModels
{
    public class LivrosViewModel :INotifyPropertyChanged
    {
        public ICommand CarregarCommand { get; set; }

        private ObservableCollection<Model.Livro> livros;
        public ObservableCollection<Model.Livro> Livros {
            get { return livros; }
            set
            {
                livros = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Livros)));
            }
        }

        public LivrosViewModel()
        {
            Livros = new ObservableCollection<Model.Livro>();
            Livros.Add(new Model.Livro { Id = 1, Nome = "Primeiro Livro"});

            CarregarCommand = new Xamarin.Forms.Command(
                async () =>
                {
                    //Livros.Add(new Model.Livro { Id = 1, Titulo = $"Livro {Livros.Count}" });

                    var livros = await ApiLivros.Api.GetAsync();

                    Livros = new ObservableCollection<Model.Livro>(livros);
                }
                );
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
