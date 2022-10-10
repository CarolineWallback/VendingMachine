using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal interface IVending
    {
        Products Purchase(string productName);
        void ShowAll();
        void InsertMoney();
        void EndTransaction();

    }
}
