using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour
{
    [SerializeField] private Vector3 goalPosition;
    [SerializeField] private float speed;
    [SerializeField] private Vector3 startPos;
    private float cur, tar;
    private bool atk, move;
    private Animator anime;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Transform>().position = startPos;
        anime = GetComponent<Animator>();
        atk = move = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (move)
            tar = 1;

        cur = Mathf.MoveTowards(cur, tar, speed * Time.deltaTime);

        transform.position = Vector3.Lerp(startPos, goalPosition, cur);
        if (!atk && cur == 1)
        {
            atk = true;
            StartCoroutine(SlashAnimation());
        }

        else
            atk = false;

    }

    public void SetMove(bool move)
    {
        this.move = move;

    }

    IEnumerator SlashAnimation()
    {
        anime.SetBool("Slash", true);
        yield return new WaitForSeconds(1f);
        anime.SetBool("Slash", false);
        tar = 0;
        move = false;
    }
}
