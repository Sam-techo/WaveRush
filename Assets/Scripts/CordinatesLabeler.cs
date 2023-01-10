using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CordinatesLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color placedColor = Color.gray;

    TextMeshPro label;
    Vector2Int cordinates = new Vector2Int();

    Waypoints waypoint;
    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;

        waypoint = GetComponentInParent<Waypoints>();

        DisplayCordinates();
    }
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCordinates();
            ChangeObjectName();
            label.enabled = true;
        }

        ChangeCordinatesColor();
        ToggleCordinates();

    }

    void ToggleCordinates()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

    void ChangeCordinatesColor()
    {
        if (waypoint.IsPlaceable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = placedColor;
        }
    }

    void DisplayCordinates()
    {
        cordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        cordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        label.text = cordinates.x + "," + cordinates.y;
    }
    
    void ChangeObjectName()
    {
        transform.parent.name = cordinates.ToString();
    }
}
