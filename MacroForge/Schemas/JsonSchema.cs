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


        static private string completeJsonString =
    "{" +
//"\r\n  \"$schema\": \"http://json-schema.org/draft-04/schema#\"," + hab das gesehen weis net ob wir das brauchen weil wir den string direkt hier haben und nicht auf website gehen muessten
"\r\n  \"type\": \"object\"," +
"\r\n  \"properties\": {" +
"\r\n    \"Name\": {" +
"\r\n      \"type\": \"string\"" +
"\r\n    }," +
"\r\n    \"CreatedAt\": {" +
"\r\n      \"type\": \"string\"" +
"\r\n    }," +
"\r\n    \"LastChanged\": {" +
"\r\n      \"type\": \"string\"" +
"\r\n    }," +
"\r\n    \"Shortcut\": {" +
"\r\n      \"type\": [\"array\", \"null\"]," +
"\r\n      \"items\": {" +
"\r\n        \"type\": \"string\"" +
"\r\n      }," +
"\r\n      \"minItems\": 0," +
"\r\n      \"uniqueItems\": true" +
"\r\n    }," +
"\r\n    \"Description\": {" +
"\r\n      \"type\": [\"string\", \"null\"]" +
"\r\n    }," +
"\r\n    \"MacroSteps\": {" +
"\r\n      \"type\": [\"array\", \"null\"]," +
"\r\n      \"items\": [" +
"\r\n        {" +
"\r\n          \"type\": \"object\"," +
"\r\n          \"properties\": {" +
"\r\n            \"StepNumber\": {" +
"\r\n              \"type\": \"integer\"" +
"\r\n            }," +
"\r\n            \"CommandType\": {" +
"\r\n              \"type\": \"integer\"" +
"\r\n            }," +
"\r\n            \"Parameter\": {" +
"\r\n              \"type\": \"string\"" +
"\r\n            }," +
"\r\n            \"Delay\": {" +
"\r\n              \"type\": \"integer\"" +
"\r\n            }" +
"\r\n          }," +
"\r\n          \"required\": [" +
"\r\n            \"StepNumber\"," +
"\r\n            \"CommandType\"," +
"\r\n            \"Parameter\"," +
"\r\n            \"Delay\"" +
"\r\n          ]" +
"\r\n        }," +
"\r\n        {" +
"\r\n          \"type\": \"object\"," +
"\r\n          \"properties\": {" +
"\r\n            \"StepNumber\": {" +
"\r\n              \"type\": \"integer\"" +
"\r\n            }," +
"\r\n            \"CommandType\": {" +
"\r\n              \"type\": \"integer\"" +
"\r\n            }," +
"\r\n            \"Parameter\": {" +
"\r\n              \"type\": \"string\"" +
"\r\n            }," +
"\r\n            \"Delay\": {" +
"\r\n              \"type\": \"integer\"" +
"\r\n            }" +
"\r\n          }," +
"\r\n          \"required\": [" +
"\r\n            \"StepNumber\"," +
"\r\n            \"CommandType\"," +
"\r\n            \"Parameter\"," +
"\r\n            \"Delay\"" +
"\r\n          ]" +
"\r\n        }," +
"\r\n        {" +
"\r\n          \"type\": \"object\"," +
"\r\n          \"properties\": {" +
"\r\n            \"StepNumber\": {" +
"\r\n              \"type\": \"integer\"" +
"\r\n            }," +
"\r\n            \"CommandType\": {" +
"\r\n              \"type\": \"integer\"" +
"\r\n            }," +
"\r\n            \"Parameter\": {" +
"\r\n              \"type\": \"string\"" +
"\r\n            }," +
"\r\n            \"Delay\": {" +
"\r\n              \"type\": \"integer\"" +
"\r\n            }" +
"\r\n          }," +
"\r\n          \"required\": [" +
"\r\n            \"StepNumber\"," +
"\r\n            \"CommandType\"," +
"\r\n            \"Parameter\"," +
"\r\n            \"Delay\"" +
"\r\n          ]" +
"\r\n        }" +
"\r\n      ]" +
"\r\n    }" +
"\r\n  }," +
"\r\n  \"required\": [" +
"\r\n    \"CreatedAt\"" +
"\r\n  ]" +
"\r\n}";

    }
}
