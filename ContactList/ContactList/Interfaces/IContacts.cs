using ContactList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.Interfaces
{
    public interface IContacts
    {
        Task<List<Contato>> BuscaContatos();
    }
}
