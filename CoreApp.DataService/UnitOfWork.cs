using CoreApp.DataProvider.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.DataService
{
    public class UnitOfWork : IDisposable
    {
        private readonly DatabaseContext _context;

        public UnitOfWork()
        {
            _context = new DatabaseContext();
        }

        public DatabaseContext GetContext() => _context;

        #region IDisposable
        public void Dispose()
        {
            _context?.Dispose();
        }
        #endregion
    }
}
