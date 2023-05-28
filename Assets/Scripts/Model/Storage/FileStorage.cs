using Newtonsoft.Json;
using System.IO;
using UnityEngine;
public class FileStorage : Storage
{
    private const string fileName = "/leaderboard.dat";

    public override LeaderboardData Read()
    {
        string path = Application.persistentDataPath + fileName;

        if (File.Exists(path))
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string contemt = sr.ReadToEnd();

                LeaderboardData data = JsonConvert.DeserializeObject<LeaderboardData>(contemt);
                return data;
            }
        }
        else
        {
            return new LeaderboardData();
        }
    }

    public override void Write(LeaderboardData data)
    {
        string path = Application.persistentDataPath + fileName;
        string content = JsonConvert.SerializeObject(data);

        using (StreamWriter sw = new StreamWriter(path))
        {
            sw.Write(content);
        }
    }
}
