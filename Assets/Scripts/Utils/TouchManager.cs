using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Core;

public class TouchManager : MonoBehaviour
{

    public Camera Camera;
    public GameObject GroupPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        #if UNITY_EDITOR
        HandleEditorTouch();
        #else 
        HandleMobileTouch();
        #endif
    }

    private void HandleEditorTouch()
    {
        if (Input.GetMouseButtonUp(0)) 
        {
            Vector2 mousePosition = Input.mousePosition;
            Vector3 mouseWorldPosition = Camera.ScreenToWorldPoint(mousePosition);
            var hit = Physics2D.OverlapPoint(mouseWorldPosition) as PolygonCollider2D;
            KeyValuePair<Corner, Vector2> groupPoint = hit.gameObject.GetComponent<Cell>().GetClosestGroupPoint(new Vector2(mouseWorldPosition.x, mouseWorldPosition.y));
            GroupPoint.GetComponent<Group>().SetPosition(new Vector3(groupPoint.Value.x, groupPoint.Value.y, -1.0f));
        }

        if (Input.GetKeyDown(KeyCode.R)) 
        {
            GroupPoint.GetComponent<Group>().Rotate(true);
            //Rotate clockwise
        }

        if (Input.GetKeyDown(KeyCode.E)) 
        {
            GroupPoint.GetComponent<Group>().Rotate(false);
            //Rotate counter-clockwise
        }
    }

    private void HandleMobileTouch() 
    {
        Touch touch = Input.GetTouch(0);
        Debug.Log(touch.position);
    }

    
}
