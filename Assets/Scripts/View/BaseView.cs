using UnityEngine;

public abstract class BaseView<T> : MonoBehaviour, IService where T : BaseViewModel
{
    protected T ViewModel { get; private set; }

    public void Init(T viewModel)
    {
        ViewModel = viewModel;
        OnInitialized();
    }

    protected virtual void OnDestroy()
    {
        ViewModel?.Unsubscribe();
    }

    protected abstract void OnInitialized();
}
