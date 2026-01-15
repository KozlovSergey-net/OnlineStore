using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace TestsOnlineStore.Helper
{
    public static class Helper
    {
        public static TransactionScope CreateTransactionScope(int sec = 1)
        {
            return new TransactionScope(
                TransactionScopeOption.Required,
                new TimeSpan(0, 0, sec),
                TransactionScopeAsyncFlowOption.Enabled);
        }
    }
}
