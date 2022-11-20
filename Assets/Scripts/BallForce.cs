using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallForce : MonoBehaviour
{
    [SerializeField] private GameObject retryPanel;
    public static BallForce instance;
    [HideInInspector] public Rigidbody rb;
    private void Awake()
    {
        instance = this;

    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }
    public void AddForceToBall(float hInput)
    {
       
        rb.AddForce(Vector3.up * (100*(hInput)));
        Debug.Log("force used"+hInput*100);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            retryPanel.SetActive(true);
            Debug.Log("Oyun bitti " + FootController.instance.bounceCount);
        }
    }
}
