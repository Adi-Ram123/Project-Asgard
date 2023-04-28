using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour
{
    [SerializeField] private Vector3 goalPosition;
    [SerializeField] private float speed;
    [SerializeField] private Vector3 startPos;
    private float cur, tar;
    private bool move;
    private Animator anime;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Transform>().position = startPos;
        anime = GetComponent<Animator>();
        move = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (move)
            tar = 1;

        cur = Mathf.MoveTowards(cur, tar, speed * Time.deltaTime);

        transform.position = Vector3.Lerp(startPos, goalPosition, cur);
        if (cur == 1)
        {

            if(gameObject.name.Equals("slime"))
            {
                StartCoroutine(EnemyLerp(0.8f));
            }

            else if(gameObject.name.Equals("Barb"))
                SlashAnimation();
        }


    }

    public void SetMove(bool move)
    {
        this.move = move;

    }

    IEnumerator EnemyLerp(float time)
    {
        yield return new WaitForSeconds(time);
        tar = 0;
        move = false;
    }

    void SlashAnimation()
    {
       anime.SetBool("Slash", true);
       
    }

    void AEEndSlash()
    {
        anime.SetBool("Slash", false);
        tar = 0;
        move = false;

    }
}
