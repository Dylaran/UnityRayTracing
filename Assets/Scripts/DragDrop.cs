using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private Vector3 offset;

    private float zCoord;

    private void OnMouseDown()
    {
        var rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            rb.angularVelocity = new Vector3(0, rb.angularVelocity.y, 0);
        }
        zCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        Vector3 newOffset = Input.mousePosition;
        newOffset.z = zCoord;

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(newOffset);
    }

    private void OnMouseUp()
    {
        GetComponent<Rigidbody>().useGravity = true;
    }

    private void OnMouseDrag()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = zCoord;

        transform.position = Camera.main.ScreenToWorldPoint(pos) + offset;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
