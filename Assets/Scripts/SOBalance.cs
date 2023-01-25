using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JsonLesson
{
    [CreateAssetMenu(fileName ="newSOBalance", menuName = "Balance", order = 1)]
    [JsonObject(MemberSerialization.OptIn)]
    public class SOBalance : ScriptableObject
    {
        [JsonProperty("BaseNameEnemy")]
        public string _nameEnemy;
        [JsonProperty("BaseDamageEnemy")]
        public float _damageEnemy;
        [JsonProperty("BaseHelthEnemy")]
        public float _healthEnemy;
    }
}
