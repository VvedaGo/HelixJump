using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TowerRotation : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
        if (Input.touchCount> 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float torgue = touch.deltaPosition.x * Time.deltaTime * _rotateSpeed;
                _rigidbody.AddTorque(Vector3.up * torgue);
            }
        }
    }

}
