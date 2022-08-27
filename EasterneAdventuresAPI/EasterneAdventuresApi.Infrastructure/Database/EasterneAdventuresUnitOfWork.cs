using EasterneAdventuresApi.Core.Interfaces;
using EasterneAdventuresApi.Core.Models;
using EasterneAdventuresApi.Infrastructure.Database;
using System.Collections.Generic;
using System.Data;
using IEasterneAdventuresContext = EasterneAdventuresApi.Infrastructure.Database.IEasterneAdventuresContext;

namespace EntityConfigurationBase
{
	public class EasterneAdventuresUnitOfWork : IEasterneAdventuresUnitOfWork
	{
		private readonly IEasterneAdventuresContext _context;

		
		private IRepository<Client> _client;
		private IRepository<Employee> _employee;
		private IRepository<Activity> _activities;
		private IRepository<Equipment> _equipment;
		private IRepository<ActivityEquipment> _activityEquipments;


		public EasterneAdventuresUnitOfWork(IEasterneAdventuresContext context)
		{
			_context = context;

		}

		public IRepository<Client> Client => _client ?? (_client = new Repository<Client>(_context));
		public IRepository<Employee> Employee => _employee ?? (_employee = new Repository<Employee>(_context));
		public IRepository<Activity> Activity => _activities ?? (_activities = new Repository<Activity>(_context));
		public IRepository<Equipment> Equipment => _equipment ?? (_equipment = new Repository<Equipment>(_context));
		public IRepository<ActivityEquipment> ActivityEquipment => _activityEquipments ?? (_activityEquipments = new Repository<ActivityEquipment>(_context));
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
