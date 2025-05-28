using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{

    [SerializeField] private string _nextSceneName = "GameplayScene";
    [SerializeField] private string _backtoMenu = "Menu";
    public void StartGameAction()
    {
        SceneManager.LoadScene(_nextSceneName);
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene(_backtoMenu);
    }

    public void QuitGame()
    {
        Debug.Log("Saindo do jogo..."); 
        Application.Quit();             
    }

}
