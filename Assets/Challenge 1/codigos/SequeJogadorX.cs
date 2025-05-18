using System;
using UnityEngine;


public class SequeJogadorX : MonoBehaviour
{
    [SerializeField] private ControlaJogador Aviao;

    [SerializeField] private Vector3 offset;
    [SerializeField] private float followSpeed;
    [SerializeField] private float rotationSpeed;
    // pra não focar no centro do alvo, mas um pouco acima, dando uma visão melhor da amplitude de visão ao jogador.
    [SerializeField] private float upFocusOffset = 1;

    private void Start()
    {
        transform.position = Aviao.transform.position;
    }

    private void OnTurboOn()
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        ApplyRotation(Aviao.transform);
        ApplyTranslation(Aviao.transform);
    }


    private void ApplyRotation(Transform target)
    {
        //transform.LookAt(target, target.up);

        //Troquei, suavizando a rotação aqui:
        Vector3 direction = target.position - transform.position + target.up * upFocusOffset;
        Quaternion targetRotation = Quaternion.LookRotation(direction, target.up);
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );
    }

    private void ApplyTranslation(Transform target)
    {
        //Aviao.position + Aviao.up * offset.y + Aviao.forward * offset.z + Aviao.right * offset.x;
        transform.position = Vector3.Lerp(transform.position, target.TransformPoint(offset), followSpeed * Time.deltaTime);

    }

}
