using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControll : MonoBehaviour {

    private Rigidbody2D rb;
    private Animator anim;
    private float moveSpeed;
    private float dirX;

    public ColorChanger CC;

    public Camera cam;

    public bool isHard;

    public bool Endless;

    public int score;

    public int life;

    public Text scoreText;

    public Text lifeText;

    public GameObject PlayScene;

    public GameObject GameOver;

    public Text totalScore;

    private string firstString = "";

    private string[] colors = new string[6];

    private int colorNow;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        moveSpeed = 10f;
        score = 0;
        life = 3;
        colors[0] = "red";
        colors[1] = "yellow";
        colors[2] = "blue";
        colors[3] = "orange";
        colors[4] = "purple";
        colors[5] = "green";
	}

    // Update is called once per frame
    void Update()
    {
        colorNow = CC.colorCount;
        if (Input.touchCount > 0)
        {
            anim.SetBool("hasDied", false);
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;
            if (touchPosition.x < 0)
            {
                dirX = -1 * moveSpeed;
                anim.SetBool("Left", true);
                anim.SetBool("Right", false);
            }
            else
            {
                dirX = 1 * moveSpeed;
                anim.SetBool("Left", false);
                anim.SetBool("Right", true);
            }
        } else
        {
            dirX = 0f;
            anim.SetBool("Left", false);
            anim.SetBool("Right", false);
        }

        if (Endless)
        {
            scoreText.text = score.ToString();
        } else
        {
            scoreText.text = score.ToString() + "/50";
        }
        lifeText.text = life.ToString();


        if (life <= 0)
        {
            cam.backgroundColor = Color.white;
            PlayScene.SetActive(false);
            GameOver.SetActive(true);
            totalScore.text = "Your Score: " + score.ToString();
        }

        if (!Endless && score == 50)
        {
            if (!isHard)
            {
                SceneManager.LoadScene(8);
            }
            else
            {
                SceneManager.LoadScene(9);
            }

        }
    }

    void FixedUpdate()
    {
        if ((dirX < 0 && transform.position.x >= -8) || (dirX > 0 && transform.position.x < 8))
        {
            rb.velocity = new Vector2(dirX, 0);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "life")
        {
            life++;
        } else {
            if (!isHard) {
                if (other.tag == colors[colorNow])
                {
                    score++;
                    CC.canChange = true;
                }
                else
                {
                    life--;
                    anim.SetBool("hasDied", true);
                    CC.canChange = true;
                }
            } else
            {
                if (other.tag == colors[colorNow])
                {
                    score++;
                    CC.canChange = true;
                } else if (colors[colorNow] == "red" || colors[colorNow] == "blue" || colors[colorNow] == "yellow")
                {
                    life--;
                    anim.SetBool("hasDied", true);
                    CC.canChange = true;
                } else if (colors[colorNow] == "purple")
                {
                    if (other.tag == "yellow")
                    {
                        life--;
                        anim.SetBool("hasDied", true);
                        CC.canChange = true;
                    }
                    else if (firstString == "")
                    {
                        firstString = other.tag;
                    } else if (firstString == "red")
                    {
                        if (other.tag == "blue")
                        {
                            score += 2;
                        } else
                        {
                            life--;
                            anim.SetBool("hasDied", true);
                        }
                        firstString = "";
                        CC.canChange = true;
                    } else if (firstString == "blue") {
                        if (other.tag == "red")
                        {
                            score += 2;
                        } else
                        {
                            life--;
                            anim.SetBool("hasDied", true);
                        }
                        firstString = "";
                        CC.canChange = true;
                    }
                } else if (colors[colorNow] == "green")
                {
                    if (other.tag == "red")
                    {
                        life--;
                        anim.SetBool("hasDied", true);
                        CC.canChange = true;
                    }
                    else if (firstString == "")
                    {
                        firstString = other.tag;
                    }
                    else if (firstString == "yellow")
                    {
                        if (other.tag == "blue")
                        {
                            score += 2;
                        }
                        else
                        {
                            life--;
                            anim.SetBool("hasDied", true);
                        }
                        firstString = "";
                        CC.canChange = true;
                    }
                    else if (firstString == "blue")
                    {
                        if (other.tag == "yellow")
                        {
                            score += 2;
                        }
                        else
                        {
                            life--;
                            anim.SetBool("hasDied", true);
                        }
                        firstString = "";
                        CC.canChange = true;
                    }
                }
                else if (colors[colorNow] == "orange")
                {
                    if (other.tag == "blue")
                    {
                        life--;
                        anim.SetBool("hasDied", true);
                        CC.canChange = true;
                    }
                    else if (firstString == "")
                    {
                        firstString = other.tag;
                    }
                    else if (firstString == "red")
                    {
                        if (other.tag == "yellow")
                        {
                            score += 2;
                        }
                        else
                        {
                            life--;
                            anim.SetBool("hasDied", true);
                        }
                        firstString = "";
                        CC.canChange = true;
                    }
                    else if (firstString == "yellow")
                    {
                        if (other.tag == "red")
                        {
                            score += 2;
                        }
                        else
                        {
                            life--;
                            anim.SetBool("hasDied", true);
                        }
                        firstString = "";
                        CC.canChange = true;
                    }
                }
            }
        }
        Destroy(other.gameObject);       
    }
}
