using DG.Tweening;
using System.Collections;
using UnityEngine;

public class LeaderboardView : BaseView<LeaderboardViewModel>
{
    [SerializeField] private Transform _container;
    [SerializeField] private DataView _dataTemplate;

    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        ViewModel?.RemoveData();
        ViewModel?.LoadData();

        _canvasGroup.alpha = 0;
        _canvasGroup.DOFade(1, 0.5f)
            .SetUpdate(true);
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        ViewModel.Datas.CollectionChanged += OnDataChanged;

        ViewModel.LoadData();
    }

    private void OnDataChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        switch (e.Action)
        {
            case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                InstantiateLine(e.NewItems);
                break;
            case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                ClearData();
                break;
        }
    }

    private void InstantiateLine(IList datas)
    {
        for(int i = 0; i < datas.Count; i++)
        {
            Data data = datas[i] as Data;

            if (data != null)
            {
                DataView dataView = Instantiate(_dataTemplate, _container);
                dataView.Render(data, ViewModel.Datas.Count);
            }
        }
    }

    public void OnClose()
    {
        _canvasGroup.alpha = 1;

        _canvasGroup.DOFade(0, 0.5f)
            .SetUpdate(true)
            .OnComplete(() =>
            {
                gameObject.SetActive(false);
            });
    }

    private void ClearData()
    {
        foreach (Transform child in _container)
        {
            Destroy(child.gameObject);
        }
    }
}
