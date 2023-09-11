using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] float zoom;
    [SerializeField] CinemachineVirtualCamera cinemachineVirtual;

    private float orthograpicSize;

    private void Start()
    {
        orthograpicSize = cinemachineVirtual.m_Lens.OrthographicSize;
    }
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector3(horizontalInput, verticalInput).normalized;
        transform.Translate(movement * speed * Time.deltaTime);

        orthograpicSize += Input.mouseScrollDelta.y * zoom;
        cinemachineVirtual.m_Lens.OrthographicSize = orthograpicSize;
    }
}
