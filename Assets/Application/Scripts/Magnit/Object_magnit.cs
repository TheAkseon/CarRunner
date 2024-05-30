using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_magnit : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100.0f;

    private void FixedUpdate()
    {
        float currentRotation = transform.rotation.eulerAngles.y;
        float newRotation = currentRotation + rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(0f, newRotation, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        foreach (Transform child in other.transform)
        {
            Debug.Log("123");
            if (child.tag == "Magnit")
            {
                child.GetComponent<Magnit>().On();
            }
        }
    }
}
