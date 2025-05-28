using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingSceneManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _finalTimeText;
    [SerializeField] private TMP_Text _finalScoreText;
    [SerializeField] private TMP_Text _recordTimeText;
    [SerializeField] private TMP_Text _recordScoreText;



    private void Start()
    {
        //recupera os dados salvos
        float finalTime = PlayerPrefs.GetFloat("FinalTime", 0);
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        float recordTime = PlayerPrefs.GetFloat("RecordTime", 0f);
        int recordScore = PlayerPrefs.GetInt("RecordScore", 0);

        //atualiza o HUD
        _finalTimeText.text = $"Time: {finalTime:0.00}";
        _finalScoreText.text = $"Score: {finalScore}";
        _recordTimeText.text = $"Record Time: {recordTime:0.00}";
        _recordScoreText.text = $"Record Score: {recordScore}";


    }

    public void ResetRecords()
    {
        PlayerPrefs.DeleteKey("RecordTime");
        PlayerPrefs.DeleteKey("RecordScore");

        PlayerPrefs.Save(); 

        _recordTimeText.text = "Record Time: 0.00";
        _recordScoreText.text = "Record Score: 0";
    }



}
