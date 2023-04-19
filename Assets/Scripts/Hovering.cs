using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hovering : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject health;
    [SerializeField] GameObject movedesc;
    
    [SerializeField] Text moveName;
    [SerializeField] Text desc;
    [SerializeField] Text type;
    [SerializeField] Text power;
    [SerializeField] Text accuracy;
    [SerializeField] Text mp;

    private Moves move;
    public void OnPointerEnter(PointerEventData eventData)
    {
        move = Skills.GetMove(moveName.text);
        desc.text = move.desc;
        type.text = "Type: " + move.type;
        power.text = "Power: " + move.power.ToString();
        accuracy.text = "Accuracy: " + move.accuracy.ToString();
        mp.text = "MP Cost: " + move.mp.ToString();
        health.SetActive(false);
        movedesc.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        movedesc.SetActive(false);
        health.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        Skills.List();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
