﻿using ManagedDoom_extension.Models;
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
        private ObservableCollection<ItemCombobox> skills;
        private ObservableCollection<ItemCombobox> episodes;
        public ViewModel()
        {
            logics = new Logics
            {

            };

            skills = new ObservableCollection<ItemCombobox>()
            {
                new ItemCombobox(){Id = 1, Item="1 - Baby"},
                new ItemCombobox(){Id = 2, Item="2 - Easy"},
                new ItemCombobox(){Id = 3, Item="3 - Medium"},
                new ItemCombobox(){Id = 4, Item="4 - Hard"},
                new ItemCombobox(){Id = 5, Item="5 - Nightmare"}
            };

            episodes = new ObservableCollection<ItemCombobox>()
            {
                new ItemCombobox(){Id = 1, Item="1 episode"},
                new ItemCombobox(){Id = 2, Item="2 episode"},
                new ItemCombobox(){Id = 3, Item="3 episode"},
                new ItemCombobox(){Id = 4, Item="4 episode"}
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

        public ObservableCollection<ItemCombobox> Skills
        {
            get { return skills; }
            set { skills = value; OnPropertyChange(nameof(Skills)); }
        }

        public ItemCombobox SelectedItemSkill
        {
            get { return logics.SelectedSkill; }
            set { logics.SelectedSkill = value; OnPropertyChange(nameof(SelectedItemSkill)); }
        }

        public ObservableCollection<ItemCombobox> Episodes
        {
            get { return episodes; }
            set { skills = value; OnPropertyChange(nameof(Episodes)); }
        }

        public ItemCombobox SelectedItemEpisode
        {
            get { return logics.SelectedItemEpisode; }
            set { logics.SelectedItemEpisode = value; OnPropertyChange(nameof(SelectedItemEpisode)); }
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

        private RelayCommand isChangedSkill;
        public RelayCommand IsChangedSkill
        {
            get {
                return isChangedSkill ??= new RelayCommand(obj =>
            {
                logics.IsChangedItemSkill();
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
