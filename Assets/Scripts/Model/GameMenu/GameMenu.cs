using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(CanvasGroup))]
public class GameMenu : BaseView<GameMenuViewModel>
{
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

    public void OnReplay()
    {
        ViewModel.ReplayCommand.Execute();
    }

    public void OnExit()
    {
        ViewModel.ExitCommand.Execute();
    }
}
