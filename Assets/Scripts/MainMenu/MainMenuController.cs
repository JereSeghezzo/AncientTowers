using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public GameObject menuCanv;
    public GameObject levelCanv;

    private void Start()
    {
        menuCanv.SetActive(true);
        levelCanv.SetActive(false);
    }
    public void ChooseLevel()
    {
        menuCanv.SetActive(false);
        levelCanv.SetActive(true);
    }

    public void PlayLevel1()
    {
        SceneManager.LoadScene("Level 1"); // Reemplaza "GameScene" con el nombre de tu escena de juego
    }

    public void PlayLevel2()
    {
        SceneManager.LoadScene("Level 2"); // Reemplaza "GameScene" con el nombre de tu escena de juego
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    

}
