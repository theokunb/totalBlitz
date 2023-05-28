using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class Data
{
    public DateTime Date { get; set; }
    public int Score { get; set; }
}

[Serializable]
public class LeaderboardData
{
    [JsonProperty("TopCount")] private int _topCount;
    [JsonProperty("Datas")] private List<Data> _datas;

    public LeaderboardData() 
    {
        _topCount = 10;
        _datas = new List<Data>();
    }

    public IEnumerable<Data> GetData() => _datas;

    public bool TryAdd(Data data)
    {
        var sorted = _datas.OrderByDescending(element => element.Score)
            .Take(_topCount)
            .ToList();

        var lowerThanCurrent = sorted.Where(element => element.Score < data.Score).FirstOrDefault();

        if(lowerThanCurrent != null)
        {
            int index = sorted.IndexOf(lowerThanCurrent);

            sorted.Insert(index, data);

            while(sorted.Count > _topCount)
            {
                sorted.RemoveAt(sorted.Count - 1);
            }

            _datas = sorted;
            return true;
        }
        else
        {
            if(sorted.Count < _topCount)
            {
                _datas.Add(data);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}