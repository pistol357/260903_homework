using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _boxPrefabs;
    [SerializeField] private Transform _boxRoot;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private float _beltSpeed;
    [SerializeField] private float _lifeSeconds;
    // 1로 바꿔 재생하면 상자가 벨트의 1/5 지점에서 사라지고, 20으로 바꿔 재생하면 상자가 벨트를 한참 넘어가 사라집니다.
    private float _elapsed;
    private int _nextIndex;
    private int NextIndex
    {
        get
        {
            return _nextIndex;
        }

        set
        {
            _nextIndex = value;
            if(_nextIndex >= _boxPrefabs.Length)
            {
                _nextIndex = 0;
            }
        }
    }

    private void Update()
    {
        ReadSpawnKey();
        CountTime();
    }

    private void ReadSpawnKey()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnOne();
        }
    }

    private void SpawnOne()
    {
        GameObject box = Instantiate(_boxPrefabs[_nextIndex], transform.position, Quaternion.identity, _boxRoot);
        BeltMover beltMover = box.AddComponent<BeltMover>();
        beltMover.MeterPerSecond = _beltSpeed;
        Destroy(box, _lifeSeconds);
        NextIndex++;
    }

    private void CountTime()
    {
        _elapsed += Time.deltaTime;
        if(_elapsed >= _spawnInterval)
        {
            SpawnOne();
            _elapsed = 0;
        }
    }
}