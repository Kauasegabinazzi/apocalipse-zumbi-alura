using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject player;
    Vector3 distanciaCompensar;

    // Start is called before the first frame update
    void Start()
    {
        //roda só uma vez
        distanciaCompensar = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + distanciaCompensar;
    }
}
