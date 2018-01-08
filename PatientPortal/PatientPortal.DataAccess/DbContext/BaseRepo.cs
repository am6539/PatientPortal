using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace PatientPortal.DataAccess.DbContext
{
    public abstract class BaseRepo
    {
        private static TransactionOptions transactionOptions = new TransactionOptions()
        {
            IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted
        };

        static BaseRepo()
        {
            // AutoMapperConfig.SetAutoMapperConfiguration();

        }

        protected virtual TransactionScope GetTransactionScope()
        {
            return new TransactionScope(TransactionScopeOption.Required, transactionOptions);
        }
    }
}
