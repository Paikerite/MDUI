using ManagedDoom_extension.Views;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;

namespace ManagedDoom_extension.Models
{ 
    sealed class Logics
    {
        // Main vars
        private List<string> Command = new List<string>() { "", "" }; // reserved for PathToSourcePort and PathToWadorDeh
        private int LastSelectedEpisode { get; set; } = -1;
        private int LastSelectedSkill { get; set; } = -1; // to remove last skill from command
        private int IndexOfWarp { get; set; } = -1;
        private int IndexOfMod { get; set; } = -1;
        private string SelectedItem { get; set; }

        //Paths
        public string PathToSourcePort { get; set; }
        public string PathToWadorDeh { get; set; }
        public string PathToAdditionalFile { get; set; }

        // Settings vars
        public bool FastMonsters { get; set; }
        public bool NoMonsters { get; set; }
        public bool Respawn { get; set; }
        public bool Deathmatch { get; set; }
        public bool AltDeathmatch { get; set; }
        public ItemCombobox SelectedItemSkill { get; set; }
        public ItemCombobox SelectedItemEpisode { get; set; }
        public bool CheckBoxWarp { get; set; }
        public bool CheckBoxMod { get; set; }
        public string Warp { get; set; }

        // Other settings vars
        public bool NoMouse { get; set; }
        public bool NoSound { get; set; }
        public bool NoSfx { get; set; }
        public bool NoMusic { get; set; }
        public bool NoDeh { get; set; }
        public bool SoloNet { get; set; }

        public Logics()
        {
            //Get source engine and .wad\.deh if exists in currect directory

            FileInfo fileInfo = new(@"managed-doom.exe");
            if (fileInfo.Exists)
            {
                PathToSourcePort = fileInfo.FullName;
                Command[0] = PathToSourcePort;
            }
            string[] tmparray = Directory.GetFiles(Directory.GetCurrentDirectory());

            foreach (string item in tmparray)
            {
                string FileExtension = Path.GetExtension(item);

                if (FileExtension == ".wad" || FileExtension == ".WAD")
                {
                    PathToWadorDeh = item;
                    Command[1] = "-iwad " + PathToWadorDeh;
                }
                else if (FileExtension == ".deh" || FileExtension == ".DEH")
                {
                    PathToWadorDeh = item;
                    Command[1] = "-deh " + PathToWadorDeh;
                }
            }
        }

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

            if (Deathmatch)
            {
                if (!Command.Contains("-deathmatch")) Command.Add("-deathmatch");
            }
            else
            {
                if (Command.Contains("-deathmatch"))
                {
                    Command.Remove("-deathmatch");
                }
            }

            if (AltDeathmatch)
            {
                if (!Command.Contains("-altdeath")) Command.Add("-altdeath");
            }
            else
            {
                if (Command.Contains("-altdeath"))
                {
                    Command.Remove("-altdeath");
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

            if (SoloNet)
            {
                if (!Command.Contains("-solo-net")) Command.Add("-solo-net");
            }
            else
            {
                if (Command.Contains("-solo-net"))
                {
                    Command.Remove("-solo-net");
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

            Command[0] = PathToSourcePort;

            return PathToSourcePort;
        }

        public string CheckPathWadorDeh()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "wad files (*.wad; *.WAD)|*.wad;*.WAD|dehacked files (*.deh; *.DEH)|*.deh;*.DEH";
            bool? response = ofd.ShowDialog();
            if (response == true)
            {
                string filepth = ofd.FileName;
                FileInfo fileInfo = new FileInfo(filepth);
                string fileExtension = fileInfo.Extension;
                PathToWadorDeh = filepth;

                if (fileExtension == ".wad" || fileExtension == ".WAD")
                {
                    Command[1] = "-iwad " + PathToWadorDeh;
                }
                else if (fileExtension == ".deh" || fileExtension == ".DEH")
                {
                    Command[1] = "-deh " + PathToWadorDeh;
                }
            }

            return PathToWadorDeh;
        }

        public string CheckPathAdditionalFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "wad files (*.wad; *.WAD)|*.wad;*.WAD";
            bool? response = ofd.ShowDialog();
            if (response == true)
            {
                string filepth = ofd.FileName;
                FileInfo fileInfo = new FileInfo(filepth);
                string fileExtension = fileInfo.Extension;
                PathToAdditionalFile = filepth;
                CheckAdditionalFile();

            }

            return PathToAdditionalFile;
        }

        public void CheckAdditionalFile()
        {
            if (CheckBoxMod == true)
            {

                SelectedItem = "-file " + PathToAdditionalFile;
                if (!Command.Contains(SelectedItem))
                {
                    if (IndexOfMod == -1)
                    {
                        Command.Add(SelectedItem);
                        IndexOfMod = Command.IndexOf(SelectedItem);
                    }
                    else
                    {
                        Command[IndexOfMod] = SelectedItem;
                    }
                }
            }
            else
            {
                Command.RemoveAt(IndexOfMod);
                IndexOfMod = -1;
            }
        }

        public void CheckWarp()
        {
            if (CheckBoxWarp == true)
            {
                SelectedItem = "-warp " + Warp;
                if (!Command.Contains(SelectedItem))
                {
                    if (IndexOfWarp == -1)
                    {
                        Command.Add(SelectedItem);
                        IndexOfWarp = Command.IndexOf(SelectedItem);
                    }
                    else
                    {
                        Command[IndexOfWarp] = SelectedItem;
                    }
                }
            }
            else
            {
                Command.RemoveAt(IndexOfWarp);
                IndexOfWarp = -1;
            }
        }

        public void IsChangedItemSkill()
        {
            //LastSelectedSkill = "-skill " + SelectedSkill.Id.ToString();
            SelectedItem = "-skill " + SelectedItemSkill.Id.ToString();
            if (!Command.Contains(SelectedItem))
            {
                if (LastSelectedSkill == -1)
                {
                    Command.Add(SelectedItem);
                    LastSelectedSkill = Command.IndexOf(SelectedItem);
                }
                else
                {
                    Command[LastSelectedSkill] = SelectedItem;
                }
            }
        }

        public void IsChangedItemEpisode()
        {
            SelectedItem = "-episode " + SelectedItemEpisode.Id.ToString();
            if (!Command.Contains(SelectedItem))
            {
                if (LastSelectedEpisode == -1)
                {
                    Command.Add(SelectedItem);
                    LastSelectedEpisode = Command.IndexOf(SelectedItem);
                }
                else
                {
                    Command[LastSelectedEpisode] = SelectedItem;
                }
            }
        }

        public void CheckFullCommand()
        {
            MessageBox.Show(string.Join(' ', Command), "Info", MessageBoxButton.OK);
        }

        public void AboutProgram()
        {
            About about = new About();
            about.Show();
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
