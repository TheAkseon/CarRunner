using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_of_player : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private int radian_angle = 150;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 newDir = Vector3.RotateTowards(transform.forward, target.transform.position - transform.position, radian_angle, 0.0F);
        transform.rotation = Quaternion.LookRotation(newDir);
    }
}
