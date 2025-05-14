using UnityEngine;

public class WeightFall : MonoBehaviour
{
    [SerializeField] private string groundTag = "Ground";
    [SerializeField] private GameManeger gm;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(groundTag) && gm != null)
        {
            gm.SetGameOver();
        }
    }
}
