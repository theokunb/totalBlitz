using TMPro;
using UnityEngine;

public class DataView : BaseView<BaseViewModel>
{
    [SerializeField] private TMP_Text _rank;
    [SerializeField] private TMP_Text _date;
    [SerializeField] private TMP_Text _score;

    public void Render(Data data, int rank)
    {
        _rank.text = $"{rank}.";
        _date.text = data.Date.ToString("dddd, dd MMMM yyyy");
        _score.text = data.Score.ToString();
    }
}
