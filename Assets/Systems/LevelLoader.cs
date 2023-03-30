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
    internal ScreenTransition screenTransition;
    private Canvas canvas;

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
        canvas = GetComponentInChildren<Canvas>();

        canvas.sortingOrder = 100;
        StartCoroutine(WaitToCommitJank());
    }

    //Used for debugging, works perfectly
    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            LoadLevel("Arman's Scene");
    }*/

    public void LoadLevel(string nextScene)
    {
        canvas.sortingOrder = 100;
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
        canvas.sortingOrder = 0;
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

    private IEnumerator WaitToCommitJank()
    {
        yield return new WaitForSeconds(waitTime);
        canvas.sortingOrder = 0;
    }
}
