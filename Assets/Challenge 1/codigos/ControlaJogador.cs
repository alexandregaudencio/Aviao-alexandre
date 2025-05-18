using System;
using UnityEngine;


public class ControlaJogador : MonoBehaviour
{
    private const string VERTICAL_AXIS = "Vertical";
    public float Velocidade;
    public float VelRotação;
    private float verticalInput;
    public Transform helice;

    public float velocidadeTurbo;
    public event Action TurboOn;
    public event Action TurboOff;

    private float currentSpeed;

    private void Start()
    {
        currentSpeed = Velocidade;
    }
    private void Update()
    {
        // pega o input vertical do jogador
        verticalInput = Input.GetAxis(VERTICAL_AXIS);

        // move o jogador a uma velocidade constante para frente 
        transform.Translate(currentSpeed * Vector3.forward * Time.deltaTime);

        // rotaciona o jogador para cima ou para baixo a depender do input vertical
        transform.Rotate(verticalInput * VelRotação * Time.deltaTime * Vector3.right);

        helice.Rotate(Time.deltaTime * currentSpeed * 200 * Vector3.forward);

        UpdateSpeed();

    }


    private void UpdateSpeed()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TurboOn.Invoke();
            currentSpeed = velocidadeTurbo;

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            currentSpeed = Velocidade;
            TurboOff.Invoke();
        }
    }

}
