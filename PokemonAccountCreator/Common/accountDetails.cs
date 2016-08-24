using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAccountCreator.Common
{
    class currentAccountDetails
    {
       public static accountDetails info = new accountDetails();
    }
    class accountDetails
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }
    }
}
