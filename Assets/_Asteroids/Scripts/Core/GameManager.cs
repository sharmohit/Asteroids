using UnityEngine;
using UnityEngine.SceneManagement;
using Asteroids;
using Asteroids.Audio;
using Asteroids.Actions;

/// <summary>
/// GameManager manages game flow and state.
/// </summary>
public class GameManager : Singleton<GameManager>
{
    public GameState GameState { get; private set; }

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
        Time.timeScale = 1;
        GameActions.GamePaused(false);

        if (scene.name == Constants.Scenes.MENU_SCENE)
        {
            GameState = GameState.Menu;
        }
        else
        {
            GameState = GameState.Running;
        }
    }

    public void PauseGame()
    {
        if (GameState == GameState.Pause)
        {
            Time.timeScale = 1;
            GameActions.GamePaused(false);
            GameState = GameState.Running;
        }
        else
        {
            Time.timeScale = 0;
            GameActions.GamePaused(true);
            GameState = GameState.Pause;
        }
    }

    public void GameCompleted()
    {
        GameState = GameState.Result;
        GameActions.GameCompleted();
    }
}