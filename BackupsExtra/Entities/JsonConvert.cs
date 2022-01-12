using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Backups.Entities;

namespace BackupsExtra
{
    public class JsonConvert
    {
        public void SerializeJson(RestorePoint restorePoint, string path)
        {
            string json = JsonSerializer.Serialize<RestorePoint>(restorePoint);
            File.AppendAllText(path, json);
        }

        public RestorePoint DeserializeJson(string json)
        {
            RestorePoint restorePoint = JsonSerializer.Deserialize<RestorePoint>(json);
            return restorePoint;
        }
    }
}