using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody rb;
    private GameObject player;

    private bool isStunned = false;
    private float stunTimer = 0f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isStunned)
        {
            stunTimer -= Time.deltaTime;

            rb.linearVelocity = Vector3.zero;

            if (stunTimer <= 0f)
            {
                isStunned = false;
            }

            return;
        }
        Vector3 dir = player.transform.position - transform.position;
        dir.Normalize();
        rb.AddForce(dir * speed);
    }

    public void Stun(float time)
    {
        isStunned = true;
        stunTimer = time;
        rb.linearVelocity = Vector3.zero; 
    }
}
