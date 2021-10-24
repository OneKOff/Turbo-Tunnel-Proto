using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{

    [SerializeField] private int _pooledPartsCount = 6;

    [SerializeField] private List<GameObject> _tubePartsPrefs = null;
    [SerializeField] private Queue<GameObject> _tubePartsPool = null;


    private GameObject GetRandomPart() {

        return _tubePartsPrefs[Random.Range(0, _tubePartsPrefs.Count)];    
    }

    private void Awake()
    {
        for (int i = 0; i < _pooledPartsCount; i++) {

            _tubePartsPool.Enqueue(GetRandomPart());
        }
    }


    public void Next() {

        _tubePartsPool.Dequeue();
        _tubePartsPool.Enqueue(GetRandomPart());
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
