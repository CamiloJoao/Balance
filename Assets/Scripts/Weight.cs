using UnityEngine;

public class Weight : MonoBehaviour
{
    [SerializeField] private float timeToBeRemovable = 5f;
    [SerializeField] private Color removableColor = Color.green;

    private bool isRemovable = false;
    private float timer = 0f;
    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isRemovable) return;

        timer += Time.deltaTime;
        if (timer >= timeToBeRemovable)
        {
            isRemovable = true;
            sr.color = removableColor;
        }
    }

    public bool CanBeRemoved()
    {
        return isRemovable;
    }
}
