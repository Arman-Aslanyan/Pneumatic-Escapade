using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public delegate void Change();
    public static event Change TimeChanged;
    [SerializeField] private string nextScene; //The scene that should be loaded next
    private float waitTime = 1 / 0.75f; //How long to wait until scene transition
    private ScreenTransition screenTransition;

    public static LevelLoader Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        screenTransition = GetComponentInChildren<ScreenTransition>();
    }

    //Used for debugging, works perfectly
    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            LoadLevel("Arman's Scene");
    }*/

    public void LoadLevel(string nextScene)
    {
        this.nextScene = nextScene;
        screenTransition.StartTransition("CrossFade");
        StartCoroutine(TimeChangedScene());
    }

    //Wait waitTime seconds before change to nextScene
    IEnumerator TimeChangedScene()
    {
        yield return new WaitForSeconds(waitTime);

        //Call the event
        TimeChanged();
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(nextScene);
        screenTransition.EndTransition("CrossFade");
    }

    void OnEnable()
    {
        TimeChanged += ChangeScene;
    }

    void OnDisable()
    {
        TimeChanged -= ChangeScene;
    }
}
