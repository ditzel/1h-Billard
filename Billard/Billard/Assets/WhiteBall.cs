using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBall : MonoBehaviour {

    protected Vector3 Startpos;
    protected bool ResetIt;

    // Use this for initialization
    void Start()
    {
        Startpos = transform.position;
    }

    // Update is called once per frame
    void Update () {
        if (transform.position.y < -0.1f)
        {
            transform.position = new Vector3(0, 0.08f, 0);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        if (ResetIt)
        {
            ResetIt = false;
            transform.position = Startpos;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
    public void ResetBall()
    {
        ResetIt = true;
    }
}
