﻿using System.IO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Books
{
    public class ConfigManager
    {
        private readonly string path = Path.Combine(Environment.ExpandEnvironmentVariables(@"%PROGRAMDATA%\KindleManager\"), "Settings.conf");

        public Config config;

        public ConfigManager()
        {
            string json;
            if (!File.Exists(path))
            {
                config = new Config();
                json = JsonConvert.SerializeObject(config);
                File.WriteAllText(path, json);
            }

            json = File.ReadAllText(path);
            config = JsonConvert.DeserializeObject<Config>(json);
        }

        public void Write()
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(this));
        }

        public class Config
        {
            public Config() { }

            /// <summary>
            /// Copy constructor
            /// </summary>
            public Config(Config c)
            {
                LibraryDir = c.LibraryDir;
                LibraryFormat = c.LibraryFormat;
            }

            private string _LibraryDir = Environment.ExpandEnvironmentVariables(@"%PROGRAMDATA%\KindleManager\Library\");
            public string LibraryDir
            {
                get => _LibraryDir;
                set { _LibraryDir = value; }
            }

            private string _LibraryFormat = "{Author}\\{Series}\\";
            public string LibraryFormat
            {
                get => _LibraryFormat;
                set { _LibraryFormat = value; }
            }

            private List<string> _HiddenColumns = new List<string>() { "Id", "Language", "ISBN", "FilePath", "Contributor", "Subject", "Description", "Rights" };
            public List<string> HiddenColumns
            {
                get => _HiddenColumns;
                set { _HiddenColumns = value; }
            }

        }

    }
}
