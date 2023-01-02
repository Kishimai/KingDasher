using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public List<GameObject> _spawnPos = new List<GameObject>(); // List of the Spawn Locations: used for spawning in the right position
    public List<GameObject> _spawned = new List<GameObject>(); // used to get the spawned boxes/enemies for deletion
    [Space]
    public float _countdown = 2; // Countdown for each turn of Boxes flying in.
    public GameObject _box;
    [Space]
    public int _points; // Points are given each time the Row of Box is deleted
    [Space]
    public int _currentWave = 1; // tallied by each 5 passed row

    public void SpawnBarrier() {
        RowTally++;

        foreach(GameObject _obj in _spawnPos){ // Spawns the Boxes in position, with a randomized Height, Size and Such
            GameObject _spawnedBox = Instantiate(_box, new Vector3(_obj.transform.position.x, Random.Range(8, 11), _obj.transform.position.z), 
            Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));

            _spawned.Add(_spawnedBox);
        }

        _spawned[Random.Range(1, _spawned.Count)].transform.gameObject.SetActive(false); // A random box that was spawned will be disabled.
        foreach(GameObject _obj in _spawned){
            _obj.GetComponent<Rigidbody>().AddForce(Vector3.forward * Random.Range(50, 70), ForceMode.Impulse); // Adds random force.
        }
    }

    int RowTally = 0; // Used to Count Waves
    void Update(){
        _countdown -= Time.deltaTime;
        if(_countdown <= 0){
            DelSpawned();
            _countdown = 3.5f;
            SpawnBarrier();
        }

        if(RowTally >= 5){ // For each 5 passed row a Wave is counted
            RowTally = 0;
            _currentWave++;
        }
    }

    public void DelSpawned(){
        _points += 5;
        foreach(GameObject _obj in _spawned){
            _spawned.Remove(_obj);
            Destroy(_obj);
        }
    }
}
