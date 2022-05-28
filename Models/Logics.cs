using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ManagedDoom_extension.Models
{
    sealed class Logics
    {
        // Main vars
        private List<string> Command = new List<string>();
        private int LastSelectedSkill { get; set; } // to remove last skill from command

        //Paths
        public string PathToSourcePort { get; set; }
        public string PathToWad { get; set; }

        // Settings vars
        public bool FastMonsters { get; set; }
        public bool NoMonsters { get; set; }
        public bool Respawn { get; set; }
        public ItemCombobox SelectedSkill { get; set; }
        public ItemCombobox SelectedItemEpisode { get; set; }

        // Other settings vars
        public bool NoMouse { get; set; }
        public bool NoSound { get; set; }
        public bool NoSfx { get; set; }
        public bool NoMusic { get; set; }
        public bool NoDeh { get; set; }

        //Functions
        public void IsChangedSettingsCheckBox()
        {
            //———————————No switches?———————————
            //⠀⣞⢽⢪⢣⢣⢣⢫⡺⡵⣝⡮⣗⢷⢽⢽⢽⣮⡷⡽⣜⣜⢮⢺⣜⢷⢽⢝⡽⣝
            //⠸⡸⠜⠕⠕⠁⢁⢇⢏⢽⢺⣪⡳⡝⣎⣏⢯⢞⡿⣟⣷⣳⢯⡷⣽⢽⢯⣳⣫⠇
            //⠀⠀⢀⢀⢄⢬⢪⡪⡎⣆⡈⠚⠜⠕⠇⠗⠝⢕⢯⢫⣞⣯⣿⣻⡽⣏⢗⣗⠏⠀
            //⠀⠪⡪⡪⣪⢪⢺⢸⢢⢓⢆⢤⢀⠀⠀⠀⠀⠈⢊⢞⡾⣿⡯⣏⢮⠷⠁⠀⠀
            //⠀⠀⠀⠈⠊⠆⡃⠕⢕⢇⢇⢇⢇⢇⢏⢎⢎⢆⢄⠀⢑⣽⣿⢝⠲⠉⠀⠀⠀⠀
            //⠀⠀⠀⠀⠀⡿⠂⠠⠀⡇⢇⠕⢈⣀⠀⠁⠡⠣⡣⡫⣂⣿⠯⢪⠰⠂⠀⠀⠀⠀
            //⠀⠀⠀⠀⡦⡙⡂⢀⢤⢣⠣⡈⣾⡃⠠⠄⠀⡄⢱⣌⣶⢏⢊⠂⠀⠀⠀⠀⠀⠀
            //⠀⠀⠀⠀⢝⡲⣜⡮⡏⢎⢌⢂⠙⠢⠐⢀⢘⢵⣽⣿⡿⠁⠁⠀⠀⠀⠀⠀⠀⠀
            //⠀⠀⠀⠀⠨⣺⡺⡕⡕⡱⡑⡆⡕⡅⡕⡜⡼⢽⡻⠏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            //⠀⠀⠀⠀⣼⣳⣫⣾⣵⣗⡵⡱⡡⢣⢑⢕⢜⢕⡝⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            //⠀⠀⠀⣴⣿⣾⣿⣿⣿⡿⡽⡑⢌⠪⡢⡣⣣⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            //⠀⠀⠀⡟⡾⣿⢿⢿⢵⣽⣾⣼⣘⢸⢸⣞⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            //⠀⠀⠀⠀⠁⠇⠡⠩⡫⢿⣝⡻⡮⣒⢽⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            //——————————————————————————————————

            if (FastMonsters == true)
            {
                if (!Command.Contains("-fast")) Command.Add("-fast");
            }
            else
            {
                if (Command.Contains("-fast"))
                {
                    Command.Remove("-fast");
                }
            }

            if (NoMonsters == true)
            {
                if (!Command.Contains("-nomonsters")) Command.Add("-nomonsters");
            }
            else
            {
                if (Command.Contains("-nomonsters"))
                {
                    Command.Remove("-nomonsters");
                }
            }

            if (Respawn == true)
            {
                if (!Command.Contains("-respawn")) Command.Add("-respawn");
            }
            else
            {
                if (Command.Contains("-respawn"))
                {
                    Command.Remove("-respawn");
                }
            }

            if (NoSound == true)
            {
                if (!Command.Contains("-nosound")) Command.Add("-nosound");
            }
            else
            {
                if (Command.Contains("-nosound"))
                {
                    Command.Remove("-nosound");
                }
            }

            if (NoSfx == true)
            {
                if (!Command.Contains("-nosfx")) Command.Add("-nosfx");
            }
            else
            {
                if (Command.Contains("-nosfx"))
                {
                    Command.Remove("-nosfx");
                }
            }

            if (NoMusic == true)
            {
                if (!Command.Contains("-nomusic")) Command.Add("-nomusic");
            }
            else
            {
                if (Command.Contains("-nomusic"))
                {
                    Command.Remove("-nomusic");
                }
            }

            if (NoMouse == true)
            {
                if (!Command.Contains("-nomouse")) Command.Add("-nomouse");
            }
            else
            {
                if (Command.Contains("-nomouse"))
                {
                    Command.Remove("-nomouse");
                }
            }

            if (NoDeh == true)
            {
                if (!Command.Contains("-nodeh")) Command.Add("-nodeh");
            }
            else
            {
                if (Command.Contains("-nodeh"))
                {
                    Command.Remove("-nodeh");
                }
            }
        }

        public string CheckPathSourcePort()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "exe files (*.exe)|*.exe";
            bool? response = ofd.ShowDialog();
            if (response == true)
            {
                string filepth = ofd.FileName;
                PathToSourcePort = filepth;
            }

            if (Command.ElementAtOrDefault(0) != null)
            {
                Command[0] = PathToSourcePort;
            }
            else
            {
                Command.Insert(0, PathToSourcePort);
            }

            return PathToSourcePort;
        }

        public string CheckPathWad()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "wad files (*.wad; *.WAD)|*.wad;*.WAD";
            bool? response = ofd.ShowDialog();
            if (response == true)
            {
                string filepth = ofd.FileName;
                PathToWad = filepth;
            }

            if (Command.ElementAtOrDefault(1) != null)
            {
                Command[1] = "-iwad " + PathToWad;
            }
            else
            {
                Command.Insert(1, "-iwad " + PathToWad);
            }

            return PathToWad;
        }

        public void IsChangedItemSkill()
        {
            //LastSelectedSkill = "-skill " + SelectedSkill.Id.ToString();
            string ss = "-skill " + SelectedSkill.Id.ToString();
            if (!Command.Contains(ss))
            {
                Command.Add(ss);
                LastSelectedSkill = Command.IndexOf(ss);
            }
            else
            {
                Command[LastSelectedSkill] = ss;
            }
        }

        public void CheckFullCommand()
        {
            MessageBox.Show(string.Join(' ', Command), "Info", MessageBoxButton.OK);
        }

        public void Play()
        {
            try
            {
                using (Process myProcess = new Process())
                {
                    myProcess.StartInfo.UseShellExecute = false;
                    myProcess.StartInfo.FileName = PathToSourcePort;
                    myProcess.StartInfo.CreateNoWindow = false;
                    myProcess.StartInfo.Arguments = string.Join(' ', Command);
                    myProcess.Start();
                    // This code assumes the process you are starting will terminate itself.
                    // Given that it is started without a window so you cannot terminate it
                    // on the desktop, it must terminate itself or you can do it programmatically
                    // from this application using the Kill method.
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
