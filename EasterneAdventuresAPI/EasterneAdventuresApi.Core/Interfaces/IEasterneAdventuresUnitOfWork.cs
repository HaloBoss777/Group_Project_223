﻿using EasterneAdventuresApi.Core.Models;
using System.Collections.Generic;
using System.Data;
using EasterneAdventuresApi.Core.Interfaces;

namespace EasterneAdventuresApi.Core.Interfaces
{
    public interface IEasterneAdventuresUnitOfWork
    {
      
		IRepository<Employee> Employee { get; }
		IRepository<Activity> Activity { get; }

        void Save();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();

        List<T> FetchDtoList<T>(
          string spName,
          IEnumerable<IDataParameter> parameters)
          where T : new();

		//T QueryDatabaseStoredProcedure<T>(string query);
		//void ExecuteDatabaseStoredProcedure(string query);
		//List<T> QueryDatabaseStoredProcedureList<T>(string query);
	}
}
