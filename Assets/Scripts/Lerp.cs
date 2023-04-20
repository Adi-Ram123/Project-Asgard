using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour
{
    [SerializeField] private Vector3 goalPosition;
    [SerializeField] private float speed;
    private float cur, tar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            tar = tar == 0 ? 1 : 0;

        cur = Mathf.MoveTowards(cur, tar, speed * Time.deltaTime);
        transform.position = Vector3.Lerp(Vector3.zero, goalPosition, cur);
    }
}
