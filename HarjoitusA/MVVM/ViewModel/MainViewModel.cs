using WPFharjoituksia.Core;
using WPFharjoituksia.MVVM.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFharjoituksia.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {

        public RelayCommand HomeViewCommand { get; set; }   
        public RelayCommand DiscoveryViewCommand { get; set; }
        public RelayCommand MatopeliViewCommand { get; set; }
        public RelayCommand NoteViewCommand { get; set; }
        public RelayCommand BrowseViewCommand { get; set; }
        public RelayCommand DrawViewCommand { get; set; }


        public HomeViewModel HomeVM { get; set; }

        public DiscoveryViewModel DiscoveryVM { get; set; }

        public MatopeliViewModel MatopeliVM { get; set; }

        public NoteViewModel NoteVM { get; set; }
        public BrowseViewModel BrowserVM { get; set; }
        public DrawViewModel DrawVM { get; set; }



        private object _currentView;


        public object CurrentView 
        { 
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            } 
        } 
        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            DiscoveryVM = new DiscoveryViewModel();
            MatopeliVM = new MatopeliViewModel();
            NoteVM = new NoteViewModel();
            BrowserVM = new BrowseViewModel(); 
            DrawVM = new DrawViewModel();


            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });
            DiscoveryViewCommand = new RelayCommand(o =>
            {
                CurrentView = DiscoveryVM;
            });
            MatopeliViewCommand = new RelayCommand(o =>
            {
                CurrentView = MatopeliVM;
            });
            NoteViewCommand = new RelayCommand(o =>
            {
                CurrentView = NoteVM;
            });
            BrowseViewCommand = new RelayCommand(o =>
            {
                CurrentView = BrowserVM;
            });
            DrawViewCommand = new RelayCommand(o =>
            {
                CurrentView = DrawVM;
            });
        }
    }
}
