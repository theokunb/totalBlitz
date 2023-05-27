using System;
using System.Collections.Generic;

public class ServiceLocator
{
    private static ServiceLocator _instance;
    private Dictionary<string, IService> _services = new Dictionary<string, IService>();

    public static ServiceLocator Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ServiceLocator();
            }

            return _instance;
        }
    }

    public void Bind<T1, T2>(T1 view, T2 viewModel) where T1 : BaseView<T2> where T2 : BaseViewModel
    {
        string name = typeof(T1).Name;

        if (_services.ContainsKey(name))
        {
            return;
        }

        view.Init(viewModel);
        _services.Add(name, view);
    }

    public void Register<T>(T service) where T : IService
    {
        string name = typeof(T).Name;

        if (_services.ContainsKey(name))
        {
            return;
        }

        _services.Add(name, service);
    }

    public void Unregister<T>(T service) where T : IService
    {
        string name = typeof(T).Name;

        if (_services.ContainsKey(name))
        {
            _services.Remove(name);
        }
    }

    public T Get<T>() where T : IService
    {
        string name = typeof(T).Name;

        if (_services.ContainsKey(name))
        {
            return (T)_services[name];
        }
        else
        {
            throw new InvalidOperationException();
        }
    }
}

public interface IService
{

}