using examen_DAL;
using examen_DAL.UnitOfWork;
using examen_WPF.Viewmodels;
using examen_WPF.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace examen_WPF.Viewmodels
{
	internal class MainViewModel : BaseViewModel, IDisposable
	{
		private IUnitOfWork _uow = new UnitOfWork(new TicketContext());

		public override string this[string columnName] => throw new NotImplementedException();

		public override bool CanExecute(object parameter)
		{
			return true;
		}

		public override void Execute(object parameter)
		{
			switch (parameter.ToString())
			{
				case "OpenLocationView": OpenLocationView(); break;
			}
		}
		private void OpenLocationView()
		{
			LocationView view = new LocationView();
			LocationViewModel viewModel = new LocationViewModel();
			view.DataContext = viewModel;
			view.Show();
		}
		private void OpenProductView()
		{
			ProductView view = new ProductView();
			ProductViewModel viewModel = new ProductViewModel();
			view.DataContext = viewModel;
			view.Show();
		}
		private void OpenStockView()
		{
			StockView view = new StockView();
			StockViewModel viewModel = new StockViewModel();
			view.DataContext = viewModel;
			view.Show();
		}
		private void OpenStoreView()
		{
			StoreView view = new StoreView();
			StoreViewModel viewModel = new StoreViewModel();
			view.DataContext = viewModel;
			view.Show();
		}
		private void OpenTicketView()
		{
			TicketView view = new TicketView();
			TicketViewModel viewModel = new TicketViewModel();
			view.DataContext = viewModel;
			view.Show();
		}
		public void Dispose()
		{
			_uow?.Dispose();
		}
	}
}
