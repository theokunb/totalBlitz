using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private MainMenuView _mainMenuView;
    [SerializeField] private LeaderboardView _leaderboardView;

    private Storage _storage;

    private void Awake()
    {
        _storage = new FileStorage();

        ServiceLocator.Instance.Register(_storage);
        ServiceLocator.Instance.Bind(_mainMenuView, new MainMenuViewModel());
        ServiceLocator.Instance.Bind(_leaderboardView, new LeaderboardViewModel());
    }

    private void OnDestroy()
    {
        ServiceLocator.Instance.Unregister<MainMenuView>();
        ServiceLocator.Instance.Unregister<LeaderboardView>();
        ServiceLocator.Instance.Unregister<Storage>();
    }
}
