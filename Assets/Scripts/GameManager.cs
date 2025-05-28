using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [Header("HUD")]
    [SerializeField] private TMP_Text _timeHUD;
    [SerializeField] private TMP_Text _scoreHUD;

    [Header("Game Settings")]
    [SerializeField] private float _startTime = 0f;
    

    private bool _isGameOver;
    private float _currentTime;
    private float _score;
    private float _recordTime;
    private float _recordScore;
    private float _scorePerSecond = 5f;

    private void Start()
    {
        _currentTime = _startTime;
        _score = 0;
    }

    private void Update()
    {
        if (_isGameOver) return;

        // Tempo
        _currentTime += Time.deltaTime;
        _timeHUD.text = $"Time: {_currentTime:0.00}";

        // Score
        _score += _scorePerSecond * Time.deltaTime;
        _scoreHUD.text = $"Score: {(int)_score}";
    }

    public void SetGameOver()
    {
        _isGameOver = true;

        //salvar dados para usar na próxima cena
        PlayerPrefs.SetFloat("FinalTime", _currentTime);
        PlayerPrefs.SetInt("FinalScore", (int)_score);

        //verifica se há um recorde salvo e se o novo tempo é melhor (menor tempo)
        if (!PlayerPrefs.HasKey("RecordTime") || _currentTime > PlayerPrefs.GetFloat("RecordTime"))
            PlayerPrefs.SetFloat("RecordTime", _currentTime);

        if (!PlayerPrefs.HasKey("RecordScore") || _score > PlayerPrefs.GetInt("RecordScore"))
            PlayerPrefs.SetInt("RecordScore", (int)_score);


        PlayerPrefs.Save(); // salva de forma persistente
           
        

        SceneManager.LoadScene("EndingScene");
    }
}

