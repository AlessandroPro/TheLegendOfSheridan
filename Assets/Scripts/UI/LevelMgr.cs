using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMgr : MonoBehaviour
{
    public static LevelMgr instance;
    private Scene GlobalScene;  // the scene with our entry point to our game.  all the singletons, managers, etc we need to run
    private Scene CurrentScene; // the current gameplay scene.

    // called zero
    void Awake()
    {
        if (instance == null)
            instance = this;
    
        Debug.Log("Awake");

        // init
        GlobalScene = SceneManager.GetActiveScene();
    }

    // called first
    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene == GlobalScene)
            return;
 
        if (scene != GlobalScene)
        {
            if (CurrentScene.name != null)
                SceneManager.UnloadSceneAsync(CurrentScene);
        }
        CurrentScene = scene;

        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
    }

    private void OnSceneUnloaded(Scene current)
    {
        // if scene just finished loaded is not the actually current
        // loaded scene, it means scene just changed, so update...
        if (current != CurrentScene)
        {
            SceneManager.UnloadSceneAsync(current);
        }
        
        Debug.Log("OnSceneUnloaded: " + current);
    }

    public void UnloadCurrentScene()
    {
        SceneManager.UnloadSceneAsync(CurrentScene);
    }

    public void LoadGameplayScene(string s)
    {
        SceneManager.LoadSceneAsync(s, LoadSceneMode.Additive);
    }

    private void LvlMgrUpdate()
    {

    }

    public void Update()
    {
        LvlMgrUpdate();
    }

    // called third
    void Start()
    {
        Debug.Log("Start");
    }

    // called when the game is terminated
    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }
}
