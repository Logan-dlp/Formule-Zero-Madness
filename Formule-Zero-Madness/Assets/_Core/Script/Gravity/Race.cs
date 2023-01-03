using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Race : MonoBehaviour
{
    private void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.up * 10, Color.red);

        if (Physics.Raycast(transform.position, transform.up, out hit, 10))
        {
            hit.transform.position = transform.position;
        }
    }
}
