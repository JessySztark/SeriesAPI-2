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

namespace SeriesAPI_2.ViewModels
{
    public class AjoutSerieViewModel : ObservableObject
    {
        public IRelayCommand BtnAjoutSerie { get; }

        public AjoutSerieViewModel()
        {
            GetDataOnLoadAsync();
            Serie serieToAdd = new Serie();
            OnPropertyChanged(nameof(serieToAdd));
            BtnAjoutSerie = new RelayCommand(ActionSetConversion);
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

        private String titre;

        public String Titre
        {
            get { return titre; }
            set
            {
                titre = value;
                OnPropertyChanged();
            }
        }

        private String resume;

        public String Resume
        {
            get { return resume; }
            set
            {
                resume = value;
                OnPropertyChanged();
            }
        }

        private int nbSaisons;

        public int NbSaisons
        {
            get { return nbSaisons; }
            set
            {
                nbSaisons = value;
                OnPropertyChanged();
            }
        }

        private int nbEpisodes;

        public int NbEpisodes
        {
            get { return nbEpisodes; }
            set
            {
                nbEpisodes = value;
                OnPropertyChanged();
            }
        }

        private int anneeCreation;

        public int AnneeCreation
        {
            get { return anneeCreation; }
            set
            {
                anneeCreation = value;
                OnPropertyChanged();
            }
        }

        private String network;

        public String Network
        {
            get { return network; }
            set
            {
                network = value;
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
                if (Titre is null)
                    throw new ArgumentOutOfRangeException("Veuillez entrer un titre.");
                if (Resume is null)
                    throw new ArgumentOutOfRangeException("Veuillez entrer un résumé.");
                if (NbSaisons <=0)
                    throw new ArgumentOutOfRangeException("La série doit comporter au moins une saison.");
                if (NbEpisodes <= 0)
                    throw new ArgumentOutOfRangeException("La série doit comporter au moins un épisode.");
                if (AnneeCreation < 1900)
                    throw new ArgumentOutOfRangeException("La série doit comporter une date valide.");
                if (Network is null)
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
