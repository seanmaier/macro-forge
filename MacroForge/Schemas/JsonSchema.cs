using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace MacroForge.Schemas
{
    class JsonSchema
    {
        private JSchema jsonSchema;
        private static string fileName = "MacroJsonSchema.json";

        public string FileName => fileName;
        public string CompleteJsonString => File.ReadAllText(fileName);

        public JsonSchema()
        {
            // jsonschema fuer validierung aus string
            jsonSchema = JSchema.Parse(CompleteJsonString);
        }



        public bool Validate(string validateString)
        {
            // valiedierung eines string aus einer json ob dieser mit dem jsonschema uebereinstimmt
            JObject macro = JObject.Parse(validateString);
            return macro.IsValid(jsonSchema);
        }
        public bool Validate(string validateString, out IList<string> errormessages)
        {
            // valiedierung eines string aus einer json ob dieser mit dem jsonschema uebereinstimmt und rueckgabe von fehlern
            JObject macro = JObject.Parse(validateString);
            errormessages = null;
            return macro.IsValid(jsonSchema,out errormessages);
        }
    }
}
