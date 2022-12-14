using EasterneAdventuresApi.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Reflection;

namespace EasterneAdventuresApi.Infrastructure.Database
{
	public interface IEasterneAdventuresContext
	{
		DbSet<TEntity> Set<TEntity>() where TEntity : class;
		void BeginTransaction();
		void CommitTransaction();
		void RollbackTransaction();
		int SaveChanges();
		
		DbSet<Employee> Employees { get; set; }
		DbSet<Client> Clients { get; set; }
		DbSet<Activity> Activities { get; set; }
		DbSet<Equipment> Equipments { get; set; }
		DbSet<ActivityEquipment> ActivityEquipments { get; set; }
		DbSet<Payment> Payments { get; set; }
		DbSet<Booking> Bookings { get; set; }
		List<T> FetchDtoList<T>(
             string spName,
             IEnumerable<IDataParameter> parameters)
             where T : new();
    }

	public class EasterneAdventuresContext : DbContext, IEasterneAdventuresContext
	{
		public EasterneAdventuresContext(DbContextOptions<EasterneAdventuresContext> options)
		: base(options)
		{ }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

            base.OnModelCreating(modelBuilder);
			var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
              .Where(type => !String.IsNullOrEmpty(type.Namespace))
              .Where(type => type.BaseType != null && type.BaseType.IsGenericType)
              .Where(type => type.Namespace == "EasterneAdventuresApi.Infrastructure.Database.Mappings");

            foreach (var type in typesToRegister)
            {
                dynamic configInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configInstance);
            }
        }


		public DbSet<Client> Clients { get; set; }
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Activity> Activities { get; set; }
		public DbSet<ActivityEquipment> ActivityEquipments { get; set; }
		public DbSet<Equipment> Equipments { get; set; }
		public DbSet<Booking> Bookings { get; set; }
		public DbSet<Payment> Payments { get; set; }


		public List<T> FetchDtoList<T>(
             string spName,
             IEnumerable<IDataParameter> parameters)
             where T : new()
        {
            List<T> resultList = new List<T>();

			try
			{
				var cmd = Database.GetDbConnection().CreateCommand();
				cmd.CommandText = spName;
				cmd.CommandType = System.Data.CommandType.StoredProcedure;

				PopulateParameters(cmd, parameters);

				Database.OpenConnection();

				using (IDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						T result = new T();

						foreach (var property in typeof(T).GetProperties())
						{
							if (!IsMapped(property))
							{
								continue;
							}

							var value = GetValue(reader[property.Name]);
							if (value == null)
							{
								property.SetValue(result, null, null);
								continue;
							}

							try
							{
								if (property.PropertyType == typeof(Boolean))
									value = (int)value == 1 ? true : false;

								property.SetValue(result, value, null);

							}
							catch (ArgumentException)
							{
								property.SetValue(result, Activator.CreateInstance(property.MemberType.GetType(), value), null);
							}
							catch (InvalidCastException)
							{
								property.SetValue(result, value, null);
							}
						}

						resultList.Add(result);
					}
				}

				return resultList;
			}
			finally
			{
				Database.CloseConnection();
			}
		}

		private void PopulateParameters(
	IDbCommand command,
	IEnumerable<IDataParameter> parameters)
		{
			if (parameters != null)
			{
				foreach (var parameter in parameters)
				{
					command.Parameters.Add(parameter);
				}
			}
		}

		private bool IsMapped(
		PropertyInfo property)
		{
			return !property.GetCustomAttributes(true).Any(x => x is NotMappedAttribute);
		}
		public object GetValue(
		   object value)
		{
			return (value == null || value is DBNull) ? null : value;
		}


		public void BeginTransaction()
		{
			Database.BeginTransaction();
		}

		public void CommitTransaction()
		{
			Database.CommitTransaction();
		}

		public void RollbackTransaction()
		{
			Database.RollbackTransaction();
			var changedEntriesCopy = this.ChangeTracker.Entries()
				.Where(e => e.State == EntityState.Added ||
				   e.State == EntityState.Modified ||
				   e.State == EntityState.Deleted)
				.ToList();

			foreach (var entry in changedEntriesCopy)
				entry.State = EntityState.Detached;
		}
	}

}
