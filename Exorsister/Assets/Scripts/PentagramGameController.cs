using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
[RequireComponent(typeof(LineRenderer))]
public class PentagramGameController : MinigameController {
    // Use this for initialization
    public GameObject pentPoint;
    private List<GameObject> points;
    private List<Vector3> clearedPoints;
    private LineRenderer lineRenderer;
    public bool lineUnbroken = false;
    public float radius = 10;
    public int phase = 1;
    public Text timeRemaining;
    public float timeLimit = 30;
	void Start () {
        Debug.Log("Start");
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetVertexCount(0);
        lineRenderer.SetColors(Color.white, Color.white);
        float sevenTwo = 72 * Mathf.Deg2Rad;
        points = new List<GameObject>();
        clearedPoints = new List<Vector3>();
        for (int i = 0; i < 5; i++)
        {
            float ang = Mathf.PI * 3 / 2 + sevenTwo * i;
            Vector3 pos = new Vector3(Mathf.Cos(ang), Mathf.Sin(ang), 0) * radius;
            GameObject newPoint = GameObject.Instantiate(pentPoint);
            newPoint.transform.position = pos;
            newPoint.GetComponent<PentagramPointController>().controller = this;
            points.Add(newPoint);
        }

        for (int i = 0; i < 5; i++)
        {
            points[i].GetComponent<PentagramPointController>().pair = points[(i + 3) % 5].GetComponent<PentagramPointController>();
        }

        points[0].GetComponent<PentagramPointController>().select(true);
        nextScene = "FlyInfoScene";
    }

    public void AddPoint(PentagramPointController p)
    {
        clearedPoints.Add(p.transform.position);
        lineRenderer.SetVertexCount(clearedPoints.Count);
        lineRenderer.SetPositions(clearedPoints.ToArray());
        
        if (clearedPoints.Count == 6)
        {
            List<PentagramPointController> circlePoints = new List<PentagramPointController>();
            float sevenTwo = 72 * Mathf.Deg2Rad;
            for (int i = 0; i < points.Count; i++)
            {
                float ang = Mathf.PI * 3 / 2 + sevenTwo * i;
                GameObject go = points[i];
                go.GetComponent<PentagramPointController>().reset();
                circlePoints.Add(go.GetComponent<PentagramPointController>());

                for (int j = 0; j < 2; j++)
                {
                    ang += sevenTwo / 3;
                    GameObject newPoint = GameObject.Instantiate(pentPoint);
                    newPoint.transform.position = new Vector3(Mathf.Cos(ang), Mathf.Sin(ang), 0) * radius;
                    newPoint.GetComponent<PentagramPointController>().controller = this;
                    circlePoints.Add(newPoint.GetComponent<PentagramPointController>());
                }

            }

            for (int i = 0; i < circlePoints.Count; i++)
            {
                //circlePoints[i].pair = circlePoints[(i + 1) % circlePoints.Count];
                circlePoints[i].pair = circlePoints[(i - 1 + circlePoints.Count) % circlePoints.Count];
            }
            phase++;
            circlePoints[0].select(true);
        } else if (clearedPoints.Count == 22)
        {
            phase++;
            Invoke("Win", 3.0f);
        }
    }

    public void RemovePoint(PentagramPointController p)
    {
        clearedPoints.Remove(p.transform.position);
    }

    // Update is called once per frame
    void Update () {
        if (phase < 3)
        {
            timeLimit -= Time.deltaTime;
        }

        if (timeLimit <= 0)
        {
            Lose();
        }

        timeRemaining.text = "Time Remanining: " + Mathf.FloorToInt(timeLimit);
	}
}
