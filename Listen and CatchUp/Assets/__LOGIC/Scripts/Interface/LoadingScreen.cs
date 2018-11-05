using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : SingletonBehaviour<LoadingScreen>
{
    public GameObject Screen;

    private readonly List<Component> _components = new List<Component>();
 

    private void Update()
    {
        if (Screen.activeSelf)
        {
            GameManager.Instance.State = GameState.Window;
        }
    }

    public void Wait(Component component)
    {
        if (_components.Count == 0)
        {
            Screen.SetActive(true);
        }
        _components.Add(component);

    }

    public void SetDone(Component component)
    {
        _components.Remove(component);
        if (_components.Count == 0)
        {
            GameManager.Instance.State = GameState.Menu;
            Screen.SetActive(false);
        }
    }

}
