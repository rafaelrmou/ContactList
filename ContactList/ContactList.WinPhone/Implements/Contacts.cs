using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ContactList.Interfaces;
using ContactList.Models;
using Xamarin.Contacts;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(ContactList.WinPhone.Implements.Contacts))]
namespace ContactList.WinPhone.Implements
{
    public class Contacts : IContacts
    {
        public Contacts() { }



        public async Task<List<Contato>> BuscaContatos()
        {
            var book = new AddressBook();
            List<Contato> ct = new List<Contato>();

            await book.RequestPermission().ContinueWith(t =>
            {
                if (!t.Result)
                {
                    Console.WriteLine("Permission denied by user or manifest");
                }


                foreach (var contact in book)
                {
                    if (contact.Phones.Any())
                        ct.Add(new Contato()
                        {
                            Nome = contact.DisplayName,
                            Telefone = contact.Phones.FirstOrDefault().Number
                        });
                }


            }, TaskScheduler.FromCurrentSynchronizationContext());

            return ct;
        }
    }
}