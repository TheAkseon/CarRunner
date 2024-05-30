using UnityEngine;

public class CatMagnit : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject Walk;
    [SerializeField] private GameObject Sit;

    [SerializeField] private float _moveSpeed = 15f;
    private int radian_angle = 150;

    private void Start()
    {
        playerTransform = FindObjectOfType<Player>().transform;
        Sit.SetActive(false);
        Walk.SetActive(true);
        // Walk.GetComponent<Animator>().SetBool("On", true);
    }

    void Update()
    {
        Vector3 newDir = Vector3.RotateTowards(transform.forward, (playerTransform.position - transform.position) * -1, radian_angle, 0.0F);
        transform.rotation = Quaternion.LookRotation(newDir);
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position,
            _moveSpeed * Time.deltaTime);
    }

}