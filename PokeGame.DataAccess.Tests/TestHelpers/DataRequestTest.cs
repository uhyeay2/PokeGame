﻿using PokeGame.DataAccess.Abstraction.Interfaces;
using PokeGame.DataAccess.Implementation;
using System.Text;

namespace PokeGame.DataAccess.Tests.TestHelpers
{
    public abstract class DataRequestTest
    {
        protected readonly IDataAccess _dataAccess;

        protected readonly RequestFactory _requests = new RequestFactory();

        protected readonly Seeder _seeder;

        protected readonly Guid _testGuid = Guid.NewGuid();

        protected readonly byte[] _testBytes = Encoding.UTF8.GetBytes(Guid.NewGuid().ToString());

        public DataRequestTest()
        {
            _dataAccess = new Implementation.DataAccess(new DbConnectionFactory(Hidden.TestDatabaseConnectionString));

            _requests = new RequestFactory();

            _seeder = new Seeder(_dataAccess, _testGuid);
        }
    }
}
