using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public List<Transform> points;
    public int nextId;
    private int idchangevalue = 1;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        MoveToNextPoint();

        if(Vector2.Distance(transform.position, player.position)< 5f)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

        else
        {
            MoveToNextPoint();
        }
    }
    void MoveToNextPoint()
    {
        Transform goalPoint = points[nextId];
        if(goalPoint.transform.position.x > transform.position.x )
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, goalPoint.position) <1f)
        {
            if(nextId == points.Count -1)
            {
                idchangevalue = -1;
            }
            if (nextId == 0)
            {
                idchangevalue = 1;
            }
            nextId += idchangevalue;
        }
        
    }
}
