using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int _levelCount;
    [SerializeField] private GameObject _beam;
    [SerializeField] private SpawnPlatform _spawnPlanform;
    [SerializeField] private Platform [] _planform;
    [SerializeField] private FinishPlatform _finishPlanform;
   

    private float _startAndFinishAdditionalScale = 0.5f;
    public float BeamScaleY => _levelCount + _startAndFinishAdditionalScale;

    private void Awake()
    {
        Build();
    }

    private void Build()
    {
        GameObject beam= Instantiate(_beam, transform);
        beam.transform.localScale = new Vector3(1, BeamScaleY, 1);

        Vector3 spawnPosition = beam.transform.position;
        spawnPosition.y += beam.transform.localScale.y;

        SpawnPlatform(_spawnPlanform, ref spawnPosition,transform);
        for (int i = 0; i< _levelCount; i++)
        {
            SpawnPlatform(_planform[Random.Range(0, _planform.Length)],ref spawnPosition, transform);
        }

        SpawnPlatform(_finishPlanform, ref spawnPosition, transform);
    }

    private void SpawnPlatform(Platform platform, ref Vector3 spawnPlatform, Transform parent)
    {
        Instantiate(platform,spawnPlatform, Quaternion.Euler(0,Random.Range(0,360),0), parent);
        spawnPlatform.y -= 2;


    }

}
