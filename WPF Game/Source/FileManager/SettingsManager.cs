using System;
using System.Collections.Generic;
using System.IO;

namespace WPF_Game.Source.FileManagers
{
    public class SettingsManager
    {
        static public SettingsManager GetSettingsManager()
        {
            if(Instance == null)
                Instance = new SettingsManager();
            return Instance;
        }
        static SettingsManager Instance;
        SettingsManager()
        {
            Settings = new Dictionary<string, string>();
        }

        public Dictionary<string, string> Settings { get; }

        private readonly char endSetting = '\n';
        private readonly char delimSetting = ':';
        private readonly string PATH = Environment.CurrentDirectory + @"\..\Settings.txt"; /*@"C:\Users\Admin\Documents\MyEngine\Settings.txt";*/

        public void ReadSettings()
        {
            FileStream fileStream;
            if (File.Exists(PATH))
            {
                fileStream = File.OpenRead(PATH);
            }
            else
            {
                fileStream = File.Create(PATH);
            }
            StreamReader reader = new StreamReader(fileStream);
            while (!reader.EndOfStream)
            {
                string key = default;
                string value = default;
                string line = reader.ReadLine();
                if (line == null) break;
                line.Trim();
                int iter = 0;
                for (int i = iter; i < line.Length; i++) 
                {
                    var c = line[i];
                    if(c == delimSetting)
                    {
                        iter = i + 1;
                        break;
                    }
                    key += c;
                }
                for (int i = iter; i < line.Length; i++)
                {
                    var c = line[i];
                    if (c == endSetting)
                    {
                        break;
                    }
                    value += c;
                }
                Settings.Add(key, value);
            }
            reader.Close();
        }
        public void WriteSettings()
        {
            FileStream fileStream;
            if (File.Exists(PATH))
            {
                fileStream = File.OpenWrite(PATH);
            }
            else
            {
                fileStream = File.Open(PATH, FileMode.OpenOrCreate, FileAccess.Write);
            }
            StreamWriter writer = new StreamWriter(fileStream);
            foreach (var set in Settings)
            {
                string line = set.Key + delimSetting + set.Value + endSetting;
                writer.Write(line);
            }
            writer.Close();
        }
    }
}
