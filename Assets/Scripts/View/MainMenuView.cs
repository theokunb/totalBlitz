using DG.Tweening;
using System;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class MainMenuView : BaseView<MainMenuViewModel>
{
    [SerializeField] private Game _game;

    private CanvasGroup _canvasGroup;

    public static MainMenuView Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(Instance.gameObject);
        }
        else
        {
            Instance = this;
        }

        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        _game.StopTime();

        _canvasGroup.DOFade(1, 0.5f)
            .SetUpdate(true);
    }

    private void OnDisable()
    {
        _game.StartTime();
    }

    private void Start()
    {
        _game.StopTime();
    }

    public void OnPlay()
    {
        _canvasGroup.DOFade(0, 0.5f)
            .SetUpdate(true)
            .OnComplete(() =>
            {
                Instance.gameObject.SetActive(false);
            });
    }

    public void OnExit()
    {
        Application.Quit();
    }

    public void OnLeaderboard()
    {
        ViewModel.LeaderBoardCommand.Execute();
    }
}