using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitNumber : MonoBehaviour
{
    public float speed, lifetime;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0f, speed, 0f);
    }
}
