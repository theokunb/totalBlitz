using UnityEngine;
using DG.Tweening;
using System.Linq;

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
        _canvasGroup.alpha = 0;

        _canvasGroup.DOFade(1, 0.5f);
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        var datas = ViewModel.Datas.ToArray();

        for (int i = 0; i < datas.Length; i++)
        {
            var dataView = Instantiate(_dataTemplate, _container);
            dataView.Render(datas[i], i + 1);
        }
    }

    public void OnClose()
    {
        _canvasGroup.alpha = 1;

        _canvasGroup.DOFade(0, 0.5f).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }
}
