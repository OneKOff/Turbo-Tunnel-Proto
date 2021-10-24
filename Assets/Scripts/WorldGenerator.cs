using System;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{

    //[SerializeField] private Vector3 _startSpawnPosition = default;
    //[SerializeField] private Vector3 _spawnAddend = new Vector3(0.0f, 0.0f, 30.0f);
    
    [SerializeField] private int _pooledPartsCount = 6;

    [SerializeField] private List<int> _tubePartsPrefsId = null;
    private Queue<PooledObject> _tubePartsPool = null;

    //[SerializeField] Vector3 currentPosition
    [SerializeField] private Spawn _spawner = default;

    [Serializable]
    public class Spawn {

        public Vector3 _startSpawnPosition = default;
        public Vector3 _spawnAddend = new Vector3(0.0f, 0.0f, 30.0f);
        public Vector3 _currentPosition = default; 
    }


    private PooledObject SpawnTubePart(Vector3 position, Quaternion rotation) {

        int randomId = _tubePartsPrefsId[UnityEngine.Random.Range(0, _tubePartsPrefsId.Count)];

        return PoolsManager.GetObject(randomId, position, rotation).GetComponent<PooledObject>();             
    }

    private void Awake()
    {
        Vector3 currentPosition = _spawner._startSpawnPosition;

        for (int i = 0; i < _pooledPartsCount; i++) {

            _tubePartsPool.Enqueue(SpawnTubePart(currentPosition, Quaternion.identity));
            currentPosition += _spawner._spawnAddend;
        }
    }


    public void Next() {

        PooledObject _deletedObject = _tubePartsPool.Dequeue();
        _deletedObject.ReturnToPool();
        
        _tubePartsPool.Enqueue(SpawnTubePart(_spawner._currentPosition, Quaternion.identity));
    }

    private void OnDestroy()
    {
        
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
