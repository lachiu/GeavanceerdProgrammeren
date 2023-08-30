using examen_DAL.Repositories;
using examen_models;
using System;
using System.Collections.Generic;
using System.Text;

namespace examen_DAL.UnitOfWork
{
	public interface IUnitOfWork : IDisposable
	{
		IRepository<Location> LocationRepo { get; }
		IRepository<Product> ProductRepo { get; }
		IRepository<Stock> StockRepo { get; }
		IRepository<Store> StoreRepo { get; }
		IRepository<Ticket> TicketRepo { get; }
		IRepository<TicketsProducts> TicketsProductsRepo { get; }
		IRepository<VatPercentage> VatPercentageRepo { get; }
	int Save();
	}
}
