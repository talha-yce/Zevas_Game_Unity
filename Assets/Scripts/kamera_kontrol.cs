using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera_kontrol : MonoBehaviour
{

    public Transform target; // Takip edilecek hedef (karakterin transformu)
    public float smoothSpeed = 0.125f; // Takip etme yumu�akl���
    public Vector3 offset; // Kamera ve karakter aras�ndaki ba�lang�� mesafesi

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
