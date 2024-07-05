using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class GeradorZumbi : MonoBehaviour
{
    public GameObject zumbi;

    private float contador = 0;
    public float tempoGerar = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        contador += Time.deltaTime;

        if( contador >= tempoGerar)
        {
            Instantiate(zumbi, transform.position, transform.rotation);

            contador = 0;
        }
    }
}
