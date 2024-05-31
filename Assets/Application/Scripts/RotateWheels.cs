using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWheels : MonoBehaviour
{
    [SerializeField] private List<GameObject> _wheels;
    [SerializeField] private float _wheelSpeed;
    private bool _canMove = false;

    private void Update()
    {
        _canMove = PlayerMove.Instance.CanMove();

        if(_canMove == true)
        {
            if(_wheels.Count == 4)
            {
                _wheels[0].transform.Rotate(_wheelSpeed * Time.deltaTime, 0, 0);
                _wheels[1].transform.Rotate(_wheelSpeed * Time.deltaTime, 0, 0);
                _wheels[2].transform.Rotate(_wheelSpeed * Time.deltaTime, 0, 0);
                _wheels[3].transform.Rotate(_wheelSpeed * Time.deltaTime, 0, 0);
            }
            else
            {
                _wheels[0].transform.Rotate(_wheelSpeed * Time.deltaTime, 0, 0);
                _wheels[1].transform.Rotate(_wheelSpeed * Time.deltaTime, 0, 0);
            }
        }
    }
}
