using UnityEngine;

public class BallTracking : MonoBehaviour
{
    [SerializeField] private Vector3 _directionOffSet;
    [SerializeField] private float _lenght;
    private Ball _ball;
    private Beam _beam;
    private Vector3 _cameraPosition;
    private Vector3 _minimumCameraPosition;


    private void Start()
    {
        _ball = FindObjectOfType<Ball>();
        _beam = FindObjectOfType<Beam>();

        _cameraPosition = _ball.transform.position;
        _minimumCameraPosition = _ball.transform.position;

        TrackingBall();
    }

    private void Update()
    {
        if (_ball.transform.position.y < _minimumCameraPosition.y)
        {
            TrackingBall();
            _minimumCameraPosition = _ball.transform.position;
        }
    }
    private void TrackingBall()
    {
        Vector3 beamPosition = _beam.transform.position;
        beamPosition.y = _ball.transform.position.y;
        _cameraPosition = _ball.transform.position;

        Vector3 direction = (beamPosition- _ball.transform.position) .normalized + _directionOffSet;
        _cameraPosition -= direction * _lenght;
        transform.position = _cameraPosition;
        transform.LookAt(_ball.transform);
    }
}
