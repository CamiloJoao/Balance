using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManeger : MonoBehaviour
{
    [SerializeField] private TMP_Text _timeHUD;

    [SerializeField] private float _startTime = 0f;

    [SerializeField] private string _nextSceneName = "EndingScene";


    private bool _isGameOver;
    private float _currentTime;

    private void Start()
    {
        _currentTime = _startTime;

    }

   
    private void Update()
    {
        if (_isGameOver)
        {
            return;
        }


        _currentTime += Time.deltaTime;
        _timeHUD.text = $"Time: {_currentTime:0.00}";
    }

    public void SetGameOver()
    {
        _isGameOver = true;
        SceneManager.LoadScene(_nextSceneName);
    }
}
