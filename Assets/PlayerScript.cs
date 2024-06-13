using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rd;
    private bool isBlock = true;
    private AudioSource audioSource;
    public GameObject bombParticle;
    public Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "COIN")
        {
            other.gameObject.SetActive(false);
            audioSource.Play();
            GameManagerScript.score += 1;
            Instantiate(bombParticle, transform.position, Quaternion.identity);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        transform.rotation = Quaternion.Euler(0, 90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        const float moveSpeed = 5.0f;
        const float jumpSpeed = 7.0f;
        Vector3 v = rd.velocity;
        v.x = 0;
        float stick = Input.GetAxis("Horizontal");
        animator.SetBool("mode",false);
        if(GoalScript.isGameClear == false)
        {
            if (Input.GetKey(KeyCode.RightArrow) || stick > 0)
            {
                v.x = moveSpeed;
                transform.rotation = Quaternion.Euler(0, 90, 0);
                animator.SetBool("mode", true);
            }
            if (Input.GetKey(KeyCode.LeftArrow) || stick < 0)
            {
                v.x = -moveSpeed;
                transform.rotation = Quaternion.Euler(0, -90, 0);
                animator.SetBool("mode", true);
            }
        }
        Vector3 rayPosition = transform.position + new Vector3(0.0f,0.8f,0.0f);
        Ray ray = new Ray(rayPosition, Vector3.down);
        float distance = 0.9f;
        Debug.DrawRay(rayPosition, Vector3.down * distance, Color.red);
        isBlock = Physics.Raycast(ray, distance);
        if (GoalScript.isGameClear == false)
        {
            if (isBlock == true)
            {
                //Debug.DrawRay(rayPosition, Vector3.down * distance, Color.red);
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump"))
                {
                    v.y = jumpSpeed;
                }
                animator.SetBool("Jump", false);
            }
            else
            {
                //Debug.DrawRay(rayPosition, Vector3.down * distance, Color.yellow);
                animator.SetBool("Jump", true);
            }
        } 
        rd.velocity = v;
    }
}
