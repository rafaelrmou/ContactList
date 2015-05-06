using ContactList.Interfaces;
using ContactList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ContactList.Views
{
    public partial class ListaContatos : ContentPage
    {
        public ListaContatos()
        {
            InitializeComponent();



            var dependency = DependencyService.Get<IContacts>();

            dependency.BuscaContatos().ContinueWith(t =>
             {
                 if (t.IsFaulted)
                 {
                     DisplayAlert("Erro", "Falha ao buscar os contatos", "OK");
                 }
                 else
                 {
                     lstContatos.ItemsSource = t.Result;
                 }
             });




        }

        List<Contato> getList()
        {
            return new List<Contato>{
                new Contato(){Nome="Arthur",Telefone="+55 (31) 1111-1111", UltimoContato = DateTime.Now},
                new Contato(){Nome="Daniel",Telefone="+55 (31) 2222-2222", UltimoContato = DateTime.Now},
                new Contato(){Nome="Micaella",Telefone="+55 (31) 3333-3333", UltimoContato = DateTime.Now},
                new Contato(){Nome="Rafael",Telefone="+55 (31) 4444-4444", UltimoContato = DateTime.Now},
            };
        }
    }
}
