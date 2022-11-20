using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadController : MonoBehaviour
{
    [SerializeField] private Transform foot;
    [SerializeField] private Transform ball;
    [SerializeField] public Vector3 distance;

    // Update is called once per frame
    void Update()
    {
        Vector3 relativePos =transform.position- foot.position;

        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;
    }
}
