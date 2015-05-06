using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class AccountBUS
    {
        private TurboFilmsEntities db = new TurboFilmsEntities();

        public List<Account> getAllAccount()
        {
            return db.Account.ToList();
        }

    }
}
