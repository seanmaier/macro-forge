using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MacroForge
{
    class FileHandler
    {
        private string saveFolder = "macros";
        private List<MacroData> macros;

        public List<MacroData> Macros { get => macros; set => macros = value; }

        public FileHandler()
        {
            macros = [];
        }

        public void CheckSaveFolder()
        {
            if(!Directory.Exists(saveFolder))
            {
                Directory.CreateDirectory(saveFolder);
                CreateJsonSchema();
            }
        }

        public void CreateJsonSchema()
        {

        }

        public void LoadMacrosFromFiles()
        {
            macros.Clear();

            foreach (string macroFileName in Directory.EnumerateFiles(saveFolder))
            {
                if (macroFileName.EndsWith(".json"))
                {
                    string json = File.ReadAllText(macroFileName);
                    MacroData? macroData = JsonSerializer.Deserialize<MacroData>(json);
                    macros.Add(macroData);
                }
            }

            if (macros.Count == 0)
            {
                throw new FileNotFoundException("Es wurden keine Macrodateien gefunden.");
            }
        }
    }
}
