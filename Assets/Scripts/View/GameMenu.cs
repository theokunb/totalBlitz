using DG.Tweening;
using System;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class GameMenu : BaseView<GameMenuViewModel>
{
    [SerializeField] private Game _game;

    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        FadeIn(0.5f);
    }

    public void OnReplay()
    {
        FadeOut(0.5f, () =>
        {
            _game.NewGame();
        });
    }

    public void OnExit()
    {
        FadeOut(0.5f, () =>
        {
        });
    }

    public void FadeIn(float duration, Action onComplete = null)
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.DOFade(1, duration)
            .SetUpdate(true).OnComplete(() =>
            {
                onComplete?.Invoke();
            });
    }

    public void FadeOut(float duration, Action onConplete = null)
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.DOFade(0, duration)
            .SetUpdate(true)
            .OnComplete(() =>
            {
                onConplete?.Invoke();
            });
    }
}
