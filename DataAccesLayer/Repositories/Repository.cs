using DataAccesLayer.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccesLayer.Repositories
{
    public class Repository : IDisposable
    {
        protected EthereumBettingContext Context { get; }

        public Repository(EthereumBettingContext context)
        {
            //Connection = new SqlConnection(connectionString);
            Context = context;
        }
        public void Dispose()
        {

        }
    }
}
