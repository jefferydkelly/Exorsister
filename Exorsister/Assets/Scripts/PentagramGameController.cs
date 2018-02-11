using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
[RequireComponent(typeof(LineRenderer))]
public class PentagramGameController : MinigameController {
    // Use this for initialization
    public GameObject pentPoint;
    private List<PentagramPointController> points;
    private List<Vector3> clearedPoints;
    private LineRenderer lineRenderer;
    public bool lineUnbroken = false;
    public float radius = 10;
    public int phase = 1;

	void Start () {
        base.Start();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
        lineRenderer.startColor = Color.white;
        lineRenderer.endColor = Color.white;
        float sevenTwo = 72 * Mathf.Deg2Rad;
        points = new List<PentagramPointController>();
        clearedPoints = new List<Vector3>();
        for (int i = 0; i < 5; i++)
        {
            float ang = Mathf.PI * 3 / 2 + sevenTwo * i;
            Vector3 pos = new Vector3(Mathf.Cos(ang), Mathf.Sin(ang), 0) * radius;
            PentagramPointController newPoint = Instantiate(pentPoint).GetComponent<PentagramPointController>();
            newPoint.transform.position = pos;
            newPoint.controller = this;
            points.Add(newPoint);
        }

        for (int i = 0; i < 5; i++)
        {
            points[i].pair = points[(i + 3) % 5];
        }

        points[0].IsSelected = true;

     
        gameTimer.OnComplete.AddListener(Lose);
    }

    public void AddPoint(PentagramPointController p)
    {
        clearedPoints.Add(p.transform.position);
        lineRenderer.positionCount = clearedPoints.Count;
        lineRenderer.SetPositions(clearedPoints.ToArray());
        
        if (clearedPoints.Count == 6)
        {
            List<PentagramPointController> circlePoints = new List<PentagramPointController>();
            float sevenTwo = 72 * Mathf.Deg2Rad;
            for (int i = 0; i < points.Count; i++)
            {
                float ang = Mathf.PI * 3 / 2 + sevenTwo * i;
                PentagramPointController point = points[i];
                circlePoints.Add(point);

                for (int j = 0; j < 2; j++)
                {
                    ang += sevenTwo / 3;
                    PentagramPointController newPoint = Instantiate(pentPoint).GetComponent<PentagramPointController>();
                    newPoint.transform.position = new Vector3(Mathf.Cos(ang), Mathf.Sin(ang), 0) * radius;
                    newPoint.controller = this;
                    circlePoints.Add(newPoint);
                }

            }

            for (int i = 0; i < circlePoints.Count; i++)
            {
                //circlePoints[i].pair = circlePoints[(i + 1) % circlePoints.Count];
                circlePoints[i].pair = circlePoints[(i - 1 + circlePoints.Count) % circlePoints.Count];
            }
            phase++;
            circlePoints[0].IsSelected = true;
        } else if (clearedPoints.Count == 22)
        {
            phase++;
            Win();
        }
    }

    public void RemovePoint(PentagramPointController p)
    {
        clearedPoints.Remove(p.transform.position);
    }
}
