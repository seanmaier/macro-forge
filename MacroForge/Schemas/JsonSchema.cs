using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace MacroForge.Schemas
{
    class JsonSchema
    {
        private JSchema jsonSchema;
        private static readonly string _fileName = "MacroJsonSchema.v1.json";

        public string FileName => _fileName;
        public string CompleteJsonString => SchemaLoader.ReadSchema("MacroForge.Schemas.MacroJsonSchema.v1.json");

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
            return macro.IsValid(jsonSchema, out errormessages);
        }
    }
}
