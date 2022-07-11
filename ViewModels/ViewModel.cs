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
        public string PathToWadorDeh
        {
            get { return logics.PathToWadorDeh; }
            set { logics.PathToWadorDeh = value; OnPropertyChange(nameof(PathToWadorDeh)); }
        }

        public string PathToAdditionalFile
        {
            get { return logics.PathToAdditionalFile; }
            set { logics.PathToAdditionalFile = value; OnPropertyChange(nameof(PathToAdditionalFile)); }
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

        public bool Deathmatch
        {
            get { return logics.Deathmatch; }
            set { logics.Deathmatch = value; OnPropertyChange(nameof(Deathmatch)); }
        }

        public bool AltDeathmatch
        {
            get { return logics.AltDeathmatch; }
            set { logics.AltDeathmatch = value; OnPropertyChange(nameof(AltDeathmatch)); }
        }

        public ObservableCollection<ItemCombobox> Skills
        {
            get { return skills; }
            set { skills = value; OnPropertyChange(nameof(Skills)); }
        }

        public ItemCombobox SelectedItemSkill
        {
            get { return logics.SelectedItemSkill; }
            set { logics.SelectedItemSkill = value; OnPropertyChange(nameof(SelectedItemSkill)); }
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

        public bool CheckBoxWarp
        {
            get { return logics.CheckBoxWarp; }
            set { logics.CheckBoxWarp = value; OnPropertyChange(nameof(CheckBoxWarp)); }
        }

        public bool CheckBoxMod
        {
            get { return logics.CheckBoxMod; }
            set { logics.CheckBoxMod = value; OnPropertyChange(nameof(CheckBoxMod)); }
        }

        public string Warp
        {
            get { return logics.Warp; }
            set
            {
                if (logics.Warp != value)
                {
                    logics.Warp = value;
                    OnPropertyChange(nameof(Warp));
                }
            }
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

        public bool SoloNet
        {
            get { return logics.SoloNet; }
            set { logics.SoloNet = value; OnPropertyChange(nameof(SoloNet)); }
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

        private RelayCommand checkPathToWadOrDeh;
        public RelayCommand CheckPathToWadOrDeh
        {
            get { return checkPathToWadOrDeh ??= new RelayCommand(obj =>
            {
                PathToWadorDeh = logics.CheckPathWadorDeh();
            }); }
        }

        private RelayCommand checkPathToAdditionalFile;
        public RelayCommand CheckPathToAdditionalFile
        { 
            get { return checkPathToAdditionalFile ??= new RelayCommand(obj => 
            {
                PathToAdditionalFile = logics.CheckPathAdditionalFile();
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

        private RelayCommand isChangedEpisode;
        public RelayCommand IsChangedEpisode
        {
            get
            {
                return isChangedEpisode ??= new RelayCommand(obj =>
                {
                    logics.IsChangedItemEpisode();
                });
            }
        }

        private RelayCommand isChangedWarp;
        public RelayCommand IsChangedWarp
        {
            get
            {
                return isChangedWarp ??= new RelayCommand(obj =>
                {
                    logics.CheckWarp();
                });
            }
        }

        private RelayCommand isChangedModStatus;
        public RelayCommand IsChangedModStatus
        {
            get
            {
                return isChangedModStatus ??= new RelayCommand(obj =>
                {
                    logics.CheckAdditionalFile();
                });
            }
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

        private RelayCommand showAbout;
        public RelayCommand ShowAbout
        {
            get {
                return showAbout ??= new RelayCommand(obj =>
            {
                logics.AboutProgram();
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
