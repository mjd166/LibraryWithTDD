using Microsoft.EntityFrameworkCore;
using System;
using System.Transactions;

namespace Library.Infrastracture.IntegrationTests
{
    public class RealDatabaseFixture:IDisposable
    {
        public LibraryContext context;
        private readonly  TransactionScope _scope;
        public RealDatabaseFixture()
        {
            var option = new DbContextOptionsBuilder<LibraryContext>()
                .UseSqlServer("server=.;database=LibraryDb;user=sa;password=123;")
                .Options;
            context = new LibraryContext(option);
            _scope = new TransactionScope();
        }

        public void Dispose()
        {
            context.Dispose(); 
            //_scope.Dispose();
        }
    }
}
