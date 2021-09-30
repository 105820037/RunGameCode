using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    //movement var
    Rigidbody2D rb2D;
    public float speed = 50f;
	public bool grounded;
	public float maxSpeed = 5f;
	public float jumpPower = 100f;
    public bool headed;
    public bool finaltag;
    public bool stop = false;
    public bool death = false;
        
	//scene item var
	GameObject walkOverItem;
    GameObject arm;
    GameObject pistol;
    public GameObject save;


    //graphic var
    Animator anim;
    [SerializeField]
    RuntimeAnimatorController animPistol;
	bool faceRight = true;
    Transform playerGraphic;

    //player stats
    bool ownPistol = false;
    
    

    void Awake()
	{
		playerGraphic = transform.Find ("Graphic");
        arm = GameObject.Find("Arm");
        pistol = GameObject.Find("Pistol");

    }


	void Start () 
	{
		rb2D = gameObject.GetComponent<Rigidbody2D> ();
		anim = transform.Find("Graphic").gameObject.GetComponent<Animator> ();


		//arm.SetActive (false);
	}


	void Update()
	{
        //*********************************************************************************************
        //  Movement
        //*********************************************************************************************
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb2D.velocity.x));
        if (!finaltag)
        {
            if (!death)
            {
                if (Input.GetAxis("Horizontal") < 0 && faceRight)
                {
                    Flip();
                }

                if (Input.GetAxis("Horizontal") > 0 && !faceRight)
                {
                    Flip();
                }
                if (Input.GetKeyDown(KeyCode.UpArrow) && grounded && !headed && !stop)
                {
                    rb2D.AddForce(new Vector2(0f, jumpPower));
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    StartCoroutine(TIMERECODE());
                }
                
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (stop)
                {
                    stop = false;
                }
                else 
                {
                    stop = true;
                }
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button7))
            {
                if (stop)
                {
                    stop = false;
                }
                else
                {
                    stop = true;
                }
            }
        }
    }


	void FixedUpdate () 
	{
        if (!finaltag)
        {
            if (!death)
            {
                float h = Input.GetAxis("Horizontal");
                rb2D.AddForce(Vector2.right * speed * h);
                if (rb2D.velocity.x > maxSpeed)
                {
                    rb2D.velocity = new Vector2(maxSpeed, rb2D.velocity.y);
                }
                if (rb2D.velocity.x < -maxSpeed)
                {
                    rb2D.velocity = new Vector2(-maxSpeed, rb2D.velocity.y);
                }
            }
        }
	}


	public void Flip()
	{
        if (!finaltag)
        {
            if (!death)
            {
                faceRight = !faceRight;
                Vector3 theScale = playerGraphic.localScale;
                theScale.x *= (-1);
                playerGraphic.localScale = theScale;
            }
        }
	}
    


    void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "final") 
		{
            finaltag = true;
            anim.enabled = false;
        }
        if (col.gameObject.tag == "savepoint")
        {
            save.transform.position = new Vector3(col.gameObject.transform.position.x, col.gameObject.transform.position.y, col.gameObject.transform.position.z);
        }
    }

	void OnTriggerExit2D(Collider2D col)
	{

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collison");
        switch (collision.gameObject.tag)
        {
            case "death":
                death = true;
                anim.enabled = false;
                StartCoroutine("TimeAction");
                break;
            default:
                break;
        }
    }
    IEnumerator TIMERECODE()
    {
        rb2D.tag = "triger";
        yield return new WaitForSeconds(1);
        rb2D.tag = "Player";
    }
    IEnumerator TimeAction()
    {
        yield return new WaitForSeconds(1);
        transform.position = new Vector3(save.transform.position.x, save.transform.position.y, save.transform.position.z);
        death = false;
        anim.enabled = true;
    }
}
