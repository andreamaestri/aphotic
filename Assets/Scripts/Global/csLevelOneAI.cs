    using UnityEngine;
    using System.Collections;
    using UnityEngine.SceneManagement;

public class csLevelOneAI : MonoBehaviour
{
    public Transform target;
    public int moveSpeed;
    public int rotationSpeed;
    Animator anim;
    Rigidbody2D rbody;
    private Transform myTransform;

    // Use this for initialization
    void Awake()
    {
        myTransform = transform;
    }

    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = go.transform;
    }

    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    void Update () {
 
            Vector3 dir = target.position - myTransform.position;
            dir.z = 0.0f; // Only needed if objects don't share 'z' value
            if (dir != Vector3.zero)
            anim.SetBool("IsWalking", true);
      
        {
                myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
                                                         Quaternion.FromToRotation(Vector3.right, dir), rotationSpeed * Time.deltaTime);
            }

            //Move Towards Target
            myTransform.position += (target.position - myTransform.position).normalized * moveSpeed * Time.deltaTime;
        }
    }

     