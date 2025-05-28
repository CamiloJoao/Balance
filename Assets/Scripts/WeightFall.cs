using UnityEngine;

public class WeightFall : MonoBehaviour
{
    [SerializeField] private string groundTag = "Ground";
    [SerializeField] private GameManager gm;
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(groundTag) && gm != null)
        {
            gm.SetGameOver();
        }
    }
}
