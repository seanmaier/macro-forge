using System.IO;
using System.Text.Json;
using MacroForge.Schemas;

namespace MacroForge
{
    class FileHandler
    {
        static private string saveFolder = "macros";
        static private string savePath   = saveFolder + "\\";
        static private string saveFormat = savePath   + "{0}.json";

        private JsonSchema jSchema = new();
        

        public FileHandler()
        {
        }

        public void CheckSaveFolder()
        {
            // check ob der saveFolder existiert sonst erstellen und schema anlegen
            if(!Directory.Exists(saveFolder))
            {
                Directory.CreateDirectory(saveFolder);
            }
        }

        public void LoadMacrosFromFiles(MacroDataList mdl)
        {
            // checke savefolder
            CheckSaveFolder();

            // dateien im folder durchgehen
            foreach (string macroFileName in Directory.EnumerateFiles(saveFolder))
            {
                if (macroFileName.Equals(savePath + jSchema.FileName))
                {
                    // jsonschema ueberspringen
                    continue;
                }

                if (macroFileName.EndsWith(".json"))
                {
                    // wenn datein json ist dann versuchen in macrodata zu serialisieren
                    string json = File.ReadAllText(macroFileName);
                    IList<string> messages;
                    if (!jSchema.Validate(json,out messages))
                    {
                        throw new Exception();
                    }
                    MacroData? macroData = JsonSerializer.Deserialize<MacroData>(json);

                    // TODO wenn eins nicht erstellt werden konnte dann sollten wir das wahrscheinlicha noch ausgeben aber wies noch net wie ausgaben werden

                    if (macroData != null)
                    {
                        // wenn macroData erstellt werden konnte, ueberpruefe den namen und pack in liste falls der name uebereinstimmt
                        string fileName = macroFileName.Substring(7, macroFileName.LastIndexOf(".json") - 7);
                        if (macroData.Name != "" && !fileName.Equals(macroData.Name))
                        {
                            throw new MismatchException($"Der Name der Datei {macroFileName.Substring(7)} und der Name des Makros {macroData.Name} stimmen nicht überein. Es wird der Name der Datei übernommen.");
                        }
                        macroData.Name = fileName;
                        mdl.AddMacro(macroData);
                    }
                }
            }

            if (mdl.Macros.Count == 0)
            {
                // TODO weis net ob wir vielleicht meldun machen bei keine gefunden?
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
            File.WriteAllText(string.Format(saveFormat, macroData.Name), json);
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
