using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using SeriesAPI.Models.EntityFramework;
using SeriesAPI_2.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.AllJoyn;

namespace SeriesAPI_2.ViewModels
{
    public class AjoutSerieViewModel : ObservableObject
    {
        public IRelayCommand BtnAjoutSerie { get; }
        public AjoutSerieViewModel()
        {
            Serie serieToAdd = new Serie();
            GetDataOnLoadAsync();
            BtnAjoutSerie = new RelayCommand(ActionSetConversion);
            OnPropertyChanged(nameof(serieToAdd));
        }

        public Serie SerieToAdd
        {
            get { return serieToAdd; }
            set { serieToAdd = value; }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name){
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private ObservableCollection<Serie> lesSeries;

        public ObservableCollection<Serie> LesSeries
        {
            get { return lesSeries; }
            set
            {
                lesSeries = value;
                OnPropertyChanged();
            }
        }

        private async void GetDataOnLoadAsync()
        {
            try
            {
                WSService service = new WSService("https://localhost:7293/api/");
                List<Serie> result = await service.GetSeriesAsync("series");
                if (result == null)
                    throw new ArgumentException("API n'est pas disponible");
                else
                    LesSeries = new ObservableCollection<Serie>(result);
            }
            catch (Exception ex)
            {
                DisplayMessageBox(ex);
            }
        }

        private void ActionSetConversion()
        {
            try
            {
                if (SerieToAdd.Titre is null)
                    throw new ArgumentOutOfRangeException("Veuillez entrer un titre.");
                if (SerieToAdd.Resume is null)
                    throw new ArgumentOutOfRangeException("Veuillez entrer un résumé.");
                if (SerieToAdd.NbSaisons <=0)
                    throw new ArgumentOutOfRangeException("La série doit comporter au moins une saison.");
                if (SerieToAdd.NbEpisodes <= 0)
                    throw new ArgumentOutOfRangeException("La série doit comporter au moins un épisode.");
                if (SerieToAdd.AnneeCreation < 1900)
                    throw new ArgumentOutOfRangeException("La série doit comporter une date valide.");
                if (SerieToAdd.Network is null)
                    throw new ArgumentOutOfRangeException("Veuillez entrer une chaîne.");
            }
            catch (Exception ex)
            {
                DisplayMessageBox(ex);
            }
        }

        private async void DisplayMessageBox(Exception ex)
        {
            ContentDialog messageBox = new ContentDialog
            {
                XamlRoot = App.MainRoot.XamlRoot,
                Title = "Erreur",
                Content = ex.Message,
                CloseButtonText = "Ok"
            };
            ContentDialogResult result = await messageBox.ShowAsync();
        }
    }
}
