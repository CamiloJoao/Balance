using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{

    [SerializeField] private string _nextSceneName = "GameplayScene";
   public void StartGameAction()
    {
        SceneManager.LoadScene(_nextSceneName);
    }
    
}
