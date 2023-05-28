using System.Collections.Generic;
using System.Linq;

public class LeaderboardViewModel : BaseViewModel
{
    private List<Data> _datas;

    public IEnumerable<Data> Datas => _datas;

    public LeaderboardViewModel()
    {
        _datas = new List<Data>();
        var storage = ServiceLocator.Instance.Get<Storage>();

        foreach(var data in storage.Read().GetData())
        {
            _datas.Add(data);
        }
    }
}
