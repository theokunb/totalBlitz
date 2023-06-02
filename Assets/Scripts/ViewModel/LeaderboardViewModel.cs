using System.Collections.ObjectModel;

public class LeaderboardViewModel : BaseViewModel
{
    public ObservableCollection<Data> Datas { get; set; }

    public LeaderboardViewModel()
    {
        Datas = new ObservableCollection<Data>();
    }

    public void LoadData()
    {
        var storage = ServiceLocator.Instance.Get<Storage>();

        foreach (var data in storage.Read().GetData())
        {
            Datas.Add(data);
        }
    }

    public void RemoveData()
    {
        Datas.Clear();
    }
}
