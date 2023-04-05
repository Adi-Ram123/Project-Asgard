using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] GameObject mainCanvas;
    [SerializeField] GameObject fightCanvas;

    // Start is called before the first frame update
    void Start()
    {
        fightCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(Keycode.Escape))
        {
            // set all other canvases inactive
            mainCanvas.SetActive(true);
        }

    }

    void FixedUpdate()
    {
        if (Options.selected.Equals("Fight"))
        {
            mainCanvas.SetActive(false);
            fightCanvas.SetActive(true);
            Options.selected = "";
        }
    }
}
