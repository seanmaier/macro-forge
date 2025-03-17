using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroForge
{
    

    class MacroDataList
    {
        private List<MacroData> macros;
        public List<MacroData> Macros { get => macros; set => macros = value; }

        public MacroDataList()
        {
            macros = [];
        }

        public MacroData? AddMacro(MacroData? macroData) 
        {
            // hinzufuegen eines macros zur kiste                                                                                           P.s. K ist mit absicht
            if (macroData != null)
            {
                macros.Add(macroData);
            }

            return macroData;
        }

        public MacroData? AddNewMacro()
        {
            // erstellein und hinzufuegen eines macros zur liste
            string name = GenerateDefaultName();
            MacroData macroData = new MacroData(name); 

            return AddMacro(macroData);
        }

        public string GenerateDefaultName()
        {
            return GenerateDefaultName(null);
        }

        public string GenerateDefaultName(string? failedName)
        {
            // suche aller exisitierenden namen entsprechend dem default
            List<MacroData> potentialDefaultNameMacros = macros.Where(macro => macro.Name.StartsWith("Macro", StringComparison.CurrentCultureIgnoreCase)).ToList();

            int number = 0;
            int parsed = 0;

            foreach (MacroData macro in potentialDefaultNameMacros)
            {
                // ueberpruefen der nummer des macro und suchen des hoechsten
                string numberPart = macro.Name.Substring(5);
                _ = int.TryParse(numberPart, out parsed);
                number = number < parsed ? parsed : number;
            }

            // nehmen einen hoeher als hoechsten 
            number++;
            string name = $"Macro{number}";
            if (name.Equals(failedName))
            {
                // sollte aus irgendeinem grund ein name nicht funktionieren dann nimm eins hoeher
                number++;
                return $"Macro{number}";
            }
            else
            {
                return name;
            }

        }
    }
}
