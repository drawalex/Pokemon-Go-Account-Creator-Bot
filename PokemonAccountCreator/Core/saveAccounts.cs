using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonAccountCreator.Core
{
    class saveAccounts
    {
        public static async Task save()
        {
                File.AppendAllLines("PokemonAccounts.txt", Data.settings.AccountsList);
        }
    }
}
