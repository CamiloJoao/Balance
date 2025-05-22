using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingSceneManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _finalTimeText;
    [SerializeField] private TMP_Text _finalScoreText;
    [SerializeField] private TMP_Text _recordTimeText;
    [SerializeField] private TMP_Text _recordScoreText;

    [SerializeField] private string _SceneName = "GameManager"; // Nome da sua cena de menu ou inicial

    private void Start()
    {
        // Recupera os dados salvos
        float finalTime = PlayerPrefs.GetFloat("FinalTime", 0);
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        float recordTime = PlayerPrefs.GetFloat("RecordTime", 0f);
        int recordScore = PlayerPrefs.GetInt("RecordScore", 0);

        // Atualiza o HUD
        _finalTimeText.text = $"Time: {finalTime:0.00}";
        _finalScoreText.text = $"Score: {finalScore}";
        _recordTimeText.text = $"Record Time: {recordTime:0.00}";
        _recordScoreText.text = $"Record Score: {recordScore}";


    }

  
}
