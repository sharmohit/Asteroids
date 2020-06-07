using UnityEngine.SceneManagement;
using Asteroids;
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
            GameActions.GamePaused(false);
            gameState = GameState.Running;
        }
        else
        {
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