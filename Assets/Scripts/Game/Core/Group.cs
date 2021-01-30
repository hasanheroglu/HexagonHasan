using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group : MonoBehaviour
{
    [HideInInspector] public GameObject[] hexagons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void Rotate(bool isClockwise)
    {
        if(isClockwise)
        {
            transform.Rotate(60);
        }
        else
        {
            transform.Rotate(-60);
        }
    }
}
