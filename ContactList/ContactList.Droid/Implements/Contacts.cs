using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ContactList.Interfaces;
using ContactList.Models;
using Xamarin.Contacts;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(ContactList.Droid.Implements.Contacts))]
namespace ContactList.Droid.Implements
{
    public class Contacts : IContacts
    {
        public Contacts() { }



        public async Task<List<Contato>> BuscaContatos()
        {
            var book = new AddressBook(Forms.Context);
            List<Contato> ct = new List<Contato>();

            await book.RequestPermission().ContinueWith(t =>
            {
                if (!t.Result)
                {
                    Console.WriteLine("Permission denied by user or manifest");
                }


                Parallel.ForEach(book, contact =>
                {
                    if (contact.Phones.Any())
                        ct.Add(new Contato()
                        {
                            Nome = contact.DisplayName,
                            Telefone = contact.Phones.FirstOrDefault().Number
                        });

                });


            }, TaskScheduler.FromCurrentSynchronizationContext());

            return ct;
        }
    }
}