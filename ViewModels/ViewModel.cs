using ManagedDoom_extension.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagedDoom_extension.ViewModels
{
    public class ViewModel : INotifyPropertyChanged
    {
        private Logics logics;
        private ObservableCollection<Skills> skills;
        public ViewModel()
        {
            logics = new Logics
            {

            };

            skills = new ObservableCollection<Skills>()
            {
                new Skills(){Id = 1, Skill="1 - Baby"},
                new Skills(){Id = 2, Skill="2 - Easy"},
                new Skills(){Id = 3, Skill="3 - Medium"},
                new Skills(){Id = 4, Skill="4 - Hard"},
                new Skills(){Id = 5, Skill="5 - Nightmare"}
            };
        }
        //Paths
        public string PathToSourcePort
        {
            get { return logics.PathToSourcePort; }
            set { logics.PathToSourcePort = value; OnPropertyChange(nameof(PathToSourcePort)); }
        }
        public string PathToWad
        {
            get { return logics.PathToWad; }
            set { logics.PathToWad = value; OnPropertyChange(nameof(PathToWad)); }
        }

        // Settings vars
        public bool FastMonsters
        {
            get { return logics.FastMonsters; }
            set { logics.FastMonsters = value; OnPropertyChange(nameof(FastMonsters)); } 
        }

        public bool NoMonsters
        {
            get { return logics.NoMonsters; }
            set { logics.NoMonsters = value; OnPropertyChange(nameof(NoMonsters)); }
        }

        public bool Respawn
        {
            get { return logics.Respawn; }
            set { logics.Respawn = value; OnPropertyChange(nameof(Respawn)); }
        }

        public ObservableCollection<Skills> Skills
        {
            get { return skills; }
            set { skills = value; OnPropertyChange(nameof(Skills)); }
        }
        private Skills selectedItem = new Skills();
        public Skills SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value; OnPropertyChange(nameof(SelectedItem)); }
        }

        public int Episode
        {
            get { return logics.Episode; }
            set { logics.Episode = value; OnPropertyChange(nameof(Episode)); }
        }

        //Other settings vars
        public bool NoMouse
        {
            get { return logics.NoMouse; }
            set { logics.NoMouse = value; OnPropertyChange(nameof(NoMouse)); }
        }

        public bool NoSound
        {
            get { return logics.NoSound; }
            set { logics.NoSound = value; OnPropertyChange(nameof(NoSound)); }
        }

        public bool NoSfx
        {
            get { return logics.NoSfx; }
            set { logics.NoSfx = value; OnPropertyChange(nameof(NoSfx)); }
        }

        public bool NoMusic
        {
            get { return logics.NoMusic; }
            set { logics.NoMusic = value; OnPropertyChange(nameof(NoMusic)); }
        }

        public bool NoDeh
        {
            get { return logics.NoDeh; }
            set { logics.NoDeh = value; OnPropertyChange(nameof(NoDeh)); }
        }

        //Functions and Commands
        private RelayCommand checkPathToSourcePort;
        public RelayCommand CheckPathToSourcePort
        {
            get { return checkPathToSourcePort ??= new RelayCommand(obj =>
            {
                PathToSourcePort = logics.CheckPathSourcePort();
            }); }
        }

        private RelayCommand checkPathToWad;
        public RelayCommand CheckPathToWad
        {
            get { return checkPathToWad ??= new RelayCommand(obj =>
            {
                PathToWad = logics.CheckPathWad();
            }); }
        }

        private RelayCommand isChangedSettings;
        public RelayCommand IsChangedSettings
        {
            get { return isChangedSettings ??= new RelayCommand(obj =>
                    {
                        logics.IsChangedSettingsCheckBox();
                    }); }
        }

        private RelayCommand checkFullCommandButton;
        public RelayCommand CheckFullCommandButton 
        { 
            get { return checkFullCommandButton ??= new RelayCommand(obj =>
                    {
                        logics.CheckFullCommand();
                    }); }
        }

        private RelayCommand playDoomFuckYea;
        public RelayCommand PlayDoomFuckYea
        {
            get { return playDoomFuckYea ??= new RelayCommand(obj =>
            {
                logics.Play();
            }); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
