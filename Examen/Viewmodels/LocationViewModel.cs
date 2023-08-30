using examen_DAL.UnitOfWork;
using examen_DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using examen_models;
using System.Linq;

namespace examen_WPF.Viewmodels
{
	internal class LocationViewModel : BaseViewModel, IDisposable
	{
		private IUnitOfWork _uow = new UnitOfWork(new TicketContext());
		public ObservableCollection<Location> Locations { get; set; }
		public LocationViewModel()
		{
			Locations = new ObservableCollection<Location>(_uow.LocationRepo.Ophalen(x => x.Stocks));
		}
		public override string this[string columnName] => throw new NotImplementedException();

		public override bool CanExecute(object parameter)
		{
			return true;
		}
		public override void Execute(object parameter)
		{
			switch (parameter.ToString())
			{
				case "LocationToevoegen": LocationToevoegen(); break;
				case "LocationVerwijderen": LocationVerwijderen(); break;
				case "Annuleren": break;
				case "Bewaren": LocationBewaren(); break;
			}
		}
		public string NewLocationName;
		public Location SelectedLocation;
		private void LocationToevoegen()
		{
			Location location = new Location()
			{
				Name = NewLocationName
			};

			if (location.IsGeldig())
			{
				_uow.LocationRepo.Toevoegen(location);
				int ok = _uow.Save();
				if (ok > 0)
				{
					RefreshData();
				}
			}
		}
		private void LocationVerwijderen()
		{
			if (SelectedLocation!= null)
			{
				_uow.LocationRepo.Verwijderen(SelectedLocation);
				int ok = _uow.Save();
				if (ok > 0)
				{
					RefreshData();
				}
			}
		}
		private void LocationBewaren()
		{
			if (SelectedLocation.IsGeldig())
			{
				_uow.LocationRepo.Aanpassen(SelectedLocation);
				int ok = _uow.Save();
				if (ok > 0 )
				{
					RefreshData();
				}
			}
		}

		private void RefreshData()
		{
			Locations = new ObservableCollection<Location>(_uow.LocationRepo.Ophalen(x => x.Stocks));
		}
		public void Dispose()
		{
			_uow?.Dispose();
		}
	}
}
