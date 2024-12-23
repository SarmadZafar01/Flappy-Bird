using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class pipeSpawner : MonoBehaviour
{
    [SerializeField] private float maxTime = 1;
    private float timer =0;
    [SerializeField] private float height;
    public GameObject GameObjectPipe;
    void Start()
    {
        GameObject newPipe = Instantiate(GameObjectPipe);
        newPipe.transform.position += new Vector3(0, Random.Range(-height, height), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer>maxTime)
        {
            GameObject newPipe = Instantiate(GameObjectPipe);
            newPipe.transform.position += new Vector3(0, Random.Range(-height, height), 0);

            Destroy(newPipe, 15);


            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
