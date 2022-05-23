using ManagedDoom_extension.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagedDoom_extension.ViewModels
{
    public class ViewModel : INotifyPropertyChanged
    {
        private Logics logics;
        public ViewModel()
        {
            logics = new Logics
            {
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

        public int Skill 
        { 
            get { return logics.Skill; } 
            set { logics.Skill = value;  OnPropertyChange(nameof(Skill)); }
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
