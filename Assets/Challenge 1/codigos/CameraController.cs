using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private new Camera camera;
    private float initialFOV;
    [SerializeField] private ControlaJogador Aviao;
    [SerializeField] private float turboFOV;
    [SerializeField] private float fovSpeed = 10;

    private Coroutine fovTransition;

    private void Awake()
    {
        camera = GetComponent<Camera>();
        initialFOV = camera.fieldOfView;
    }

    private void OnEnable()
    {
        Aviao.TurboOff += OnTurboOff;
        Aviao.TurboOn += OnTurboOn;

    }
    private void OnDisable()
    {
        Aviao.TurboOff -= OnTurboOff;
        Aviao.TurboOn -= OnTurboOn;
    }

    private void OnTurboOn()
    {
        UpdateFov(turboFOV);
    }

    private void OnTurboOff()
    {
        UpdateFov(initialFOV);


    }

    private void UpdateFov(float fov)
    {
        if (fovTransition != null) StopCoroutine(fovTransition);
        fovTransition = StartCoroutine(FovCoroutine(fov));
    }

    private IEnumerator FovCoroutine(float fov)
    {
        float releaseTiem = 0;
        while (releaseTiem < 1)
        {

            camera.fieldOfView = Mathf.MoveTowards(camera.fieldOfView, fov, releaseTiem);
            releaseTiem += Time.deltaTime * fovSpeed;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }


}
