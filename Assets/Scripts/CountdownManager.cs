using TMPro;
using UnityEngine;

public class CountdownManager : MonoBehaviour
{
    [SerializeField] private TMP_Text countdownText;
    [SerializeField] private GameManeger gameManager;
    [SerializeField] private Player player;
    [SerializeField] private WeightSpawner weight;// Referência ao seu GameManager

    [SerializeField] private float countdownTime = 3f; // Tempo da contagem
    private float timer;
    private bool countdownFinished = false;

    private void Start()
    {
        timer = countdownTime;
        countdownText.gameObject.SetActive(true);
        gameManager.enabled = false;
        player.enabled = false;
        weight.enabled = false;// Desativa o controle do jogo
    }

    private void Update()
    {
        if (countdownFinished) return;

        timer -= Time.deltaTime;

        if (timer > 0f)
        {
            countdownText.text = Mathf.Ceil(timer).ToString(); // Mostra 3, 2, 1
        }
        else if (timer == 0f)
        {
            countdownText.text = "GO!";
        }
        else
        {
            countdownText.gameObject.SetActive(false);
            gameManager.enabled = true; // Ativa o jogo
            player.enabled = true;
            weight.enabled = true;
            weight.ResetDeleteTimer();
            countdownFinished = true;
        }
    }
}
