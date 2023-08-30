using examen_DAL.Repositories;
using examen_models;
using System;
using System.Collections.Generic;
using System.Text;

namespace examen_DAL.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private IRepository<Location> _locationRepo;
		private IRepository<Product> _productRepo;
		private IRepository<Stock> _stockRepo;
		private IRepository<Store> _storeRepo;
		private IRepository<Ticket> _ticketRepo;
		private IRepository<TicketsProducts> _ticketsProductsRepo;
		private IRepository<VatPercentage> _vatPercentagesRepo;


		public UnitOfWork(TicketContext ctx)
		{
			Context = ctx;
		}

		private TicketContext Context { get; }
		public IRepository<Location> LocationRepo
		{
			get
			{
				if (_locationRepo == null)
				{
					_locationRepo = new Repository<Location>(Context);
				}
				return _locationRepo;
			}
		}
		public IRepository<Product> ProductRepo
		{
			get
			{
				if (_productRepo == null)
				{
					_productRepo = new Repository<Product>(Context);
				}
				return _productRepo;
			}
		}
		public IRepository<Stock> StockRepo
		{
			get
			{
				if (_stockRepo == null)
				{
					_stockRepo = new Repository<Stock>(Context);
				}
				return _stockRepo;
			}
		}
		public IRepository<Store> StoreRepo
		{
			get
			{
				if (_storeRepo == null)
				{
					_storeRepo = new Repository<Store>(Context);
				}
				return _storeRepo;
			}
		}
		public IRepository<Ticket> TicketRepo
		{
			get
			{
				if (_ticketRepo == null)
				{
					_ticketRepo = new Repository<Ticket>(Context);
				}
				return _ticketRepo;
			}
		}
		public IRepository<TicketsProducts> TicketsProductsRepo
		{
			get
			{
				if (_ticketsProductsRepo == null)
				{
					_ticketsProductsRepo = new Repository<TicketsProducts>(Context);
				}
				return _ticketsProductsRepo;
			}
		}
		public IRepository<VatPercentage> VatPercentageRepo
		{
			get
			{
				if (_vatPercentagesRepo == null)
				{
					_vatPercentagesRepo = new Repository<VatPercentage>(Context);
				}
				return _vatPercentagesRepo;
			}
		}

		public void Dispose()
		{
			Context.Dispose();
		}

		public int Save()
		{
			return Context.SaveChanges();
		}
	}
}
