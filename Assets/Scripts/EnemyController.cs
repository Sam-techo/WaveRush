using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] List<Waypoints> path = new List<Waypoints>();
    [SerializeField] [Range(0f, 5f)] float speed = 1f;

    Enemy enemy;
    void OnEnable()
    {
        FollowPath();
        ReturnToStart();
        StartCoroutine(PrintWaypoints());
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
        
    }

    void FollowPath()
    {
        path.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        foreach (Transform child in parent.transform)
        {
            Waypoints waypoint = child.GetComponent<Waypoints>();
            if (waypoint != null)
            {
                path.Add(waypoint);
            }
            
        }
    }

    void FinishPath()
    {
        gameObject.SetActive(false);
        enemy.StealGold();
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }
    IEnumerator PrintWaypoints()
    {
        foreach (Waypoints wayPoint in path)
        {
           
            Vector3 startPosition = transform.position;
            Vector3 endPosition = wayPoint.transform.position;

            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;

                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                
                yield return new WaitForEndOfFrame();

            }
            
        }

        FinishPath();
        
    }

   
}
