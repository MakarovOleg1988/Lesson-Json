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
        private static string _SOBalancePath = "NewSOBalance";

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

        [MenuItem("Window/Config/Get Enemy Orc Data")]
        private static void GetEnemyConfig()
        {
            var SO = Resources.Load<SOBalance>(_SOBalancePath);
            var path = string.Concat(Application.dataPath, "/", _filePath, "/", SO.name, ".json");

            var data = JsonConvert.SerializeObject(SO);

            using (var stream = new StreamWriter(path))
            {
                using (var writer = new JsonTextWriter(stream))
                {
                    writer.WriteValue(data);
                }
            }

            AssetDatabase.Refresh();
            Debug.Log("Get Enemy SO");
        }

        [MenuItem("Window/Config/Set Enemy Orc Data")]
        private static void SetEnemyConfig()
        {
            var SO = ScriptableObject.CreateInstance<SOBalance>();
            var path = string.Concat(Application.dataPath, "/", _filePath, "/", "NewSOBalance", ".json");
            var text = string.Empty;

            using (var stream = new StreamReader(path))
            {
                using (var reader = new JsonTextReader(stream))
                {
                    text = reader.ReadAsString(); ;
                }
            }

            var data = JsonConvert.DeserializeObject<SOBalance>(text);

            SO._damageEnemy = data._damageEnemy;
            SO._healthEnemy = data._healthEnemy;
            SO._nameEnemy = data._nameEnemy;

            AssetDatabase.CreateAsset(data, "Assets/Balance//Resources/NewSOBalance2.asset");
            AssetDatabase.Refresh();
            Debug.Log("Set Enemy SOunit");
        }
    }
}
