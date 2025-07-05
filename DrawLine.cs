using UnityEngine;
using System.Collections.Generic;

public class DrawLine : MonoBehaviour
{
    public LineRenderer linePrefab;
    private LineRenderer currentLine;
    private List<Vector2> points;
    public float pointSpacing = 0.1f;
    private Rigidbody2D rb;
    public Rigidbody2D playerRb;
    private GameManagerBehavior gameManager;
    private bool isCreatedLine = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isCreatedLine)
        {
            CreateLine();
            
        }
        if (Input.GetMouseButton(0) && !isCreatedLine)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (points.Count == 0 || Vector2.Distance(points[^1], mousePos) > pointSpacing)
            {
                AddPoint(mousePos);
            }
        }

        if (Input.GetMouseButtonUp(0) && !isCreatedLine)
        {
            rb.simulated = true;
            playerRb.simulated = true;
            gameManager.isGameStart = true;
            isCreatedLine = true;
        }
    }

    void CreateLine()
    {
        currentLine = Instantiate(linePrefab);
        points = new List<Vector2>();
        rb = currentLine.GetComponent<Rigidbody2D>();
    }

    void AddPoint(Vector2 point)
    {
        points.Add(point);
        currentLine.positionCount = points.Count;
        currentLine.SetPosition(points.Count - 1, point);

        if (currentLine.TryGetComponent<EdgeCollider2D>(out var col))
        {
            col.points = points.ToArray();
        }
    }
    private void Start()
    {
        playerRb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
    }
}
