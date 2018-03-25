using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    protected LineRenderer line;
    protected WhiteBall WhiteBall;
    public Text Text;
    protected int Hits = 0;
    protected NormalBall[] balls;

    // Use this for initialization
    void Start () {
        line = FindObjectOfType<LineRenderer>();
        WhiteBall = FindObjectOfType<WhiteBall>();
        Text.text = "Hits: " + Hits;
        balls = FindObjectsOfType<NormalBall>();
    }
	
	// Update is called once per frame
	void Update () {

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var direction = Vector3.zero;

        if (Physics.Raycast(ray, out hit))
        {
            var ballPos = new Vector3(WhiteBall.transform.position.x, 0.1f, WhiteBall.transform.position.z);
            var mousePos = new Vector3(hit.point.x, 0.1f, hit.point.z);
            line.SetPosition(0, mousePos);
            line.SetPosition(1, ballPos);
            direction = (mousePos - ballPos).normalized;
        }

        if (Input.GetMouseButtonDown(0) && line.gameObject.activeSelf)
        {
            Hits++;
            Text.text = "Hits: " + Hits;
            line.gameObject.SetActive(false);
            WhiteBall.GetComponent<Rigidbody>().velocity = direction * 10f;
        }

        if (!line.gameObject.activeSelf && WhiteBall.GetComponent<Rigidbody>().velocity.magnitude < 0.3f)
        {

            line.gameObject.SetActive(true);
        }
    }

    public void Reset()
    {
        WhiteBall.ResetBall();
        foreach (var ball in balls)
        {
            ball.gameObject.SetActive(true);
            ball.ResetBall();
        }
        Hits = 0;
    }

}
