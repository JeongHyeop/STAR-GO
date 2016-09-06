using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public GameObject player;

    //애니메이션 변수 할당
    private Animator animator;
   
  
    public float speed = 10.0f;
    Vector2 moveLeftRight = Input.acceleration;
	void Start () {
        //애니메이션
        animator = GameObject.Find("PlayerSprite").GetComponent<Animator>();
       
	}
	
	// Update is called once per frame
	void Update () {
#if UNITY_ANDROID     
        Vector2 dir = Vector2.zero;
        dir.x = Input.acceleration.x;
        if (dir.sqrMagnitude > 1)
        {
            dir.Normalize();
        }            
        dir *= Time.deltaTime;
        player.transform.Translate(dir * speed);
#endif
       if (Input.GetMouseButtonDown(0))
        {
            player.transform.Translate(new Vector2(0, 0.5f));
            AnimationController(true);
          
        }
        else
        {
            AnimationController(false);         
        }
       

	}

    void AnimationController(bool check)
    {
        if (check == true)
        {
            animator.SetBool("AnimStart", true);
        }
        else if (check == false)
        {
            animator.SetBool("AnimStart", false);
        }
      
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Mine")
        {
            Debug.Log("dd");
        }
    }
      
}
