using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    private Text fight;
    // Start is called before the first frame update
    void Start()
    {
        fight = canvas.GetComponent<Transform>().Find("Fight").GetComponent<Text>();
        fight.text = "Test";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
