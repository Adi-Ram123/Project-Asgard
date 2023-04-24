using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hovering : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] GameObject health;
    [SerializeField] GameObject movedesc;
    
    [SerializeField] Text moveName;
    [SerializeField] Text desc;
    [SerializeField] Text type;
    [SerializeField] Text power;
    [SerializeField] Text accuracy;
    [SerializeField] Text mp;

    [SerializeField] GameObject player;

    private Moves move;

    private Lerp lerp;

    public void OnPointerClick(PointerEventData eventData)
    {
        lerp.SetMove(true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
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
        Skills.StoreList();
        move = Skills.GetMove(moveName.text);
        lerp = player.GetComponent<Lerp>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
