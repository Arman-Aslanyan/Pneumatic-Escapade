using UnityEngine;
using UnityEngine.SceneManagement;

//adapted from brackeys tutorial
public class MainMenu : MonoBehaviour
{
    public void PlayLVL1()
    {
        SceneManager.LoadScene("Center C City", LoadSceneMode.Single);
    }
    public void PlayLVL2()
    {
        SceneManager.LoadScene("Port-Folo", LoadSceneMode.Single);
    }
    public void PlayLVL3()
    {
        SceneManager.LoadScene("Koutetsu-Reikon", LoadSceneMode.Single);
    }
    public void PlayLVL4()
    {
        SceneManager.LoadScene("Muteki-Mugen", LoadSceneMode.Single);
    }
    public void PlayLVL5()
    {
        SceneManager.LoadScene("Meganeka Outpost", LoadSceneMode.Single);
    }

    public void PlaySandbox()
    {
        SceneManager.LoadScene("gm_grassbox", LoadSceneMode.Single);
    }
    public void PlaySandboxFULL()
    {
        SceneManager.LoadScene("gm_grassbox COMPLETE", LoadSceneMode.Single);
    }
    public void PlayS1()
    {
        SceneManager.LoadScene("Last Night", LoadSceneMode.Single);
    }
    public void PlayS1Final()
    {
        SceneManager.LoadScene("Last Knight", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
