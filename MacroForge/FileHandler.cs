using Microsoft.Win32;
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
        private string savePath = "macros/{0}.json";
        

        public FileHandler()
        {
        }

        public void CheckSaveFolder()
        {
            // check ob der saveFolder existiert sonst erstellen und schema anlegen
            if(!Directory.Exists(saveFolder))
            {
                Directory.CreateDirectory(saveFolder);
                CreateJsonSchema();
            }
        }

        public void CreateJsonSchema()
        {
            // json schema anlegen

            // TODO mach schema
        }

        public void LoadMacrosFromFiles(MacroDataList mdl)
        {
            // checke savefolder
            CheckSaveFolder();

            // dateien im folder durchgehen
            foreach (string macroFileName in Directory.EnumerateFiles(saveFolder))
            {
                if (macroFileName.EndsWith(".json"))
                {
                    // wenn datein json ist dann versuchen in macrodata zu serialisieren
                    string json = File.ReadAllText(macroFileName);
                    MacroData? macroData = JsonSerializer.Deserialize<MacroData>(json);

                    // TODO wenn eins nicht erstellt werden konnte dann sollten wir das wahrscheinlicha noch ausgeben aber wies noch net wie ausgaben werden

                    if (macroData != null)
                    {
                        // wenn macroData erstellt werden konnte, ueberpruefe den namen und pack in liste falls der name uebereinstimmt
                        string fileName = macroFileName.Substring(7, macroFileName.IndexOf(".json") - 7);
                        if (!fileName.Equals(macroData.Name))
                        {
                            throw new MismatchException("Der Name der Datei und der Name des Makros müssen übereinstimmen.");
                        }
                        mdl.AddMacro(macroData);
                    }
                }
            }

            if (mdl.Macros.Count == 0)
            {
                // weis net ob wir vielleicht meldun machen bei keine gefunden?
                //throw new FileNotFoundException("Es wurden keine Macrodateien gefunden.");
            }
        }

        public void SaveMacrosToFiles(MacroDataList mdl)
        {
            // alle macros der Liste in json dateien speichern
            CheckSaveFolder();
            foreach (MacroData macroData in mdl.Macros)
            {
                SaveMacroToFile(macroData, false);
            }
        }

        public void SaveMacroToFile(MacroData macroData)
        {
            SaveMacroToFile(macroData, true);
        }

        public void SaveMacroToFile(MacroData macroData, bool checkSaveFolder)
        {
            // speichern eines macros in json datei
            if (checkSaveFolder)
            {
                CheckSaveFolder();
            }
            string json = JsonSerializer.Serialize(macroData);
            File.WriteAllText(string.Format(savePath, macroData.Name), json);
        }
    }

    [Serializable]
    internal class MismatchException : Exception
    {
        public MismatchException()
        {
        }

        public MismatchException(string? message) : base(message)
        {
        }

        public MismatchException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
