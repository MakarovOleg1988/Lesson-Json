using Newtonsoft.Json;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace JsonLesson.Editor
{
    public class EditorExtentions
    {
        public static string _filePath = "Balance/Resources";
        private static string _prefabPath = "Unit";

        [MenuItem("Window/Get Data")]
        private static void GetData()
        {
            Debug.Log("Data");
        }

        [MenuItem("Window/Config/Get Data")]
        private static void GetConfig()
        {
            var unit = Resources.Load<UnitController>(_prefabPath);
            var path = string.Concat(Application.dataPath, "/", _filePath,  "/", unit.name, ".json");

            var data = JsonConvert.SerializeObject(unit.baseParamData);

            using (var stream = new StreamWriter(path))
            {
                using (var writer = new JsonTextWriter(stream))
                {
                    writer.WriteValue(data);
                }
            }

            AssetDatabase.Refresh();
            Debug.Log("Get unit");
        }

        [MenuItem("Window/Config/Set Data")]
        private static void SetConfig()
        {
            var unit = Resources.Load<UnitController>(_prefabPath);
            var path = string.Concat(Application.dataPath, "/", _filePath, "/", unit.name, ".json");
            var text = string.Empty;

            using (var stream = new StreamReader(path))
            {
                using (var reader = new JsonTextReader(stream))
                {
                    text = reader.ReadAsString();
                }
            }

            var data = JsonConvert.DeserializeObject<BaseParamData>(text);
            unit.baseParamData = data;

            AssetDatabase.Refresh();
            Debug.Log("Set unit");
        }
    }
}
