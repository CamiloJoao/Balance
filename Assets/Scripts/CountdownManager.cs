using TMPro;
using UnityEngine;

public class CountdownManager : MonoBehaviour
{
    [SerializeField] private TMP_Text countdownText;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Player player;
    [SerializeField] private WeightSpawner weight;//referencia ao GameManager

    [SerializeField] private float countdownTime = 3f; //tempo da contagem
    private float timer;
    private bool countdownFinished = false;

    private void Start()
    {
        timer = countdownTime;
        countdownText.gameObject.SetActive(true);
        gameManager.enabled = false;
        player.enabled = false;
        weight.enabled = false;//desativa o controle do jogo
    }

    private void Update()
    {
        if (countdownFinished) return;

        timer -= Time.deltaTime;

        if (timer > 0f)
        {
            countdownText.text = Mathf.Ceil(timer).ToString(); //mostra 3, 2, 1
        }
        else if (timer == 0f)
        {
            countdownText.text = "GO!";
        }
        else
        {
            countdownText.gameObject.SetActive(false);
            gameManager.enabled = true; //ativa o jogo
            player.enabled = true;
            weight.enabled = true;
            countdownFinished = true;
        }
    }
}
