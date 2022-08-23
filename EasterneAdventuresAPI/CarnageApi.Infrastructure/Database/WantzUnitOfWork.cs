using CarnageApi.Core.Interfaces;
using CarnageApi.Core.Models;
using CarnageApi.Infrastructure.Database;
using System.Collections.Generic;
using System.Data;
using IWantzContext = CarnageApi.Infrastructure.Database.IWantzContext;

namespace EntityConfigurationBase
{
	public class WantzUnitOfWork : IWantzUnitOfWork
	{
		private readonly IWantzContext _context;

		
		private IRepository<Permission> _Permission;
		private IRepository<Site> _Site;
		private IRepository<User> _User;
		private IRepository<UserSiteRoll> _UserSiteRoll;

		public WantzUnitOfWork(IWantzContext context)
		{
			_context = context;

		}

		public IRepository<Permission> Permission => _Permission ?? (_Permission = new Repository<Permission>(_context));
		public IRepository<Site> Site => _Site ?? (_Site = new Repository<Site>(_context));
		public IRepository<User> User => _User ?? (_User = new Repository<User>(_context));
		public IRepository<UserSiteRoll> UserSiteRoll => _UserSiteRoll ?? (_UserSiteRoll = new Repository<UserSiteRoll>(_context));
        public void Save()
		{
			_context.SaveChanges();
		}

		public void RollbackTransaction()
		{
			_context.RollbackTransaction();
		}

		public void BeginTransaction()
		{
			_context.BeginTransaction();
		}

		public void CommitTransaction()
		{
			_context.CommitTransaction();
		}

		

		public List<T> FetchDtoList<T>(
		   string spName,
		   IEnumerable<IDataParameter> parameters)
		   where T : new()
		{
			return _context.FetchDtoList<T>(spName, parameters);
		}

		//public T QueryDatabaseStoredProcedure<T>(string query)
		//{
		//    return _context.Database.SqlQuery<T>(query).FirstOrDefault();
		//}

		//public void ExecuteDatabaseStoredProcedure(string query)
		//{
		//    _context.Database.ExecuteSqlCommand(query);
		//}

		//public List<T> QueryDatabaseStoredProcedureList<T>(string query)
		//{
		//    return _context.Database.SqlQuery<T>(query).ToList();
		//}

	}
}
