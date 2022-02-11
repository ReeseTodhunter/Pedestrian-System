using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject pedestrianPrefab;

    [SerializeField]
    private int pedestriansToSpawn;

    [SerializeField]
    private float maxMoveSpeed = 10, minMoveSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        int count = 0;
        while (count < pedestriansToSpawn)
        {
            GameObject obj = Instantiate(pedestrianPrefab);
            Transform child = transform.GetChild(Random.Range(0, transform.childCount - 1));
            obj.GetComponent<WaypointNavigator>().currentWaypoint = child.GetComponent<Waypoint>();
            obj.transform.position = child.position;
            obj.GetComponent<PedestrianController>().movementSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);

            yield return new WaitForEndOfFrame();

            count++;
        }
    }
}
