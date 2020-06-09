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
        Time.timeScale = 1;
        GameActions.GamePaused(false);

        if (scene.name == Constants.Scenes.MENU_SCENE)
        {
            gameState = GameState.Menu;
        }
        else
        {
            gameState = GameState.Running;
        }
    }

    public void PauseGame()
    {
        if(gameState == GameState.Pause)
        {
            Time.timeScale = 1;
            GameActions.GamePaused(false);
            gameState = GameState.Running;
        }
        else
        {
            Time.timeScale = 0;
            GameActions.GamePaused(true);
            gameState = GameState.Pause;
        }
    }

    public void GameCompleted()
    {
        gameState = GameState.Result;
        GameActions.GameCompleted();
    }
}