using UnityEngine;
using UnityEngine.SceneManagement;
using Asteroids;
using Asteroids.Events;

/// <summary>
/// GameManager manages game flow and state.
/// </summary>
public class GameManager : Singleton<GameManager>
{
    private GameState gameState;

    public GameState GameState { get; }

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneLoadedHandler;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneLoadedHandler;
    }

    private void SceneLoadedHandler(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == Constants.MENU_SCENE)
        {
            gameState = GameState.Menu;
        }
        else
        {
            gameState = GameState.Running;
        }
    }
}