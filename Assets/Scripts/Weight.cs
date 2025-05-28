using UnityEngine;

public class Weight : MonoBehaviour
{
    [SerializeField] private float timeToBeRemovable = 10f;
    [SerializeField] private Color removableColor = new Color(0f, 1f, 0.5f);

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
