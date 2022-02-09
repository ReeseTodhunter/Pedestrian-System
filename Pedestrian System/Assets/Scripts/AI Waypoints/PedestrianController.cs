using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianController : MonoBehaviour
{
    Vector3 destination, currentPosition;
    public bool reachedDestination;
    public float movementSpeed = 5.0f;
    public float distanceFromDestination;
    public int direction;

    void Awake()
    {
        direction = Mathf.RoundToInt(Random.Range(0f, 1f));
    }

    // Start is called before the first frame update
    void Start()
    {
        destination = this.gameObject.transform.position;
        reachedDestination = false;
        distanceFromDestination = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = this.gameObject.transform.position;
        distanceFromDestination = Vector3.Distance(currentPosition, destination);

        if (currentPosition != destination && distanceFromDestination > 0.5f)
        {
            reachedDestination = false;
            this.gameObject.transform.LookAt(destination);
            this.gameObject.transform.position += transform.forward * Time.deltaTime * movementSpeed;
        }
        else
        {
            reachedDestination = true;
        }
    }

    public void SetDestination(Vector3 value)
    {
        destination = value;
    }
}
