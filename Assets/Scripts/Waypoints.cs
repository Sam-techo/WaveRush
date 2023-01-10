using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }

    [SerializeField] Tower defencePrefab;
    void OnMouseDown()
    {
        if (isPlaceable)
        {
            bool isPlaced = defencePrefab.CreateTower(defencePrefab, transform.position);

            isPlaceable = !isPlaced;
        }
        
    }

}
