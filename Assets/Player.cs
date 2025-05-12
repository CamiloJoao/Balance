using UnityEngine;

public class Player : MonoBehaviour
{
    public float torqueForce = 100f; // forca aplicada para girar a gangorra
    public float maxAngularVelocity = 50f; // evita a gangorra rodar rapido demais
    private Rigidbody2D rb; //pega o rigidbody2d da gangorra

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //pega o rigidbody2d da gangorra quando o jogo comeca 
    }

    void FixedUpdate()
    {
        float input = 0f;
        if (Input.GetKey(KeyCode.LeftArrow)) input = 1f;
        if (Input.GetKey(KeyCode.RightArrow)) input = -1f;

        //verifica se a rotacao atual esta dentro do limite permitido
        if (Mathf.Abs(rb.angularVelocity) < maxAngularVelocity)
        {
            rb.AddTorque(input * torqueForce); //aplica a forca de rotacao (torque)
        }
    }
}
