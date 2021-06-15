using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMove : MonoBehaviour 
{
    [SerializeField] GameObject player, scoreBoard, scoreText, obstacleGen, blurImg, gpButtonCan, playAudio, deadAudio;
    [SerializeField] SpriteRenderer playerSprite;
    [SerializeField] SpriteRenderer[] floor;
    [SerializeField] Text[] textColorChange;
    [SerializeField] Image background;
    [SerializeField] float speed = 4f;
    [HideInInspector] public int timer;
    TrailRenderer playerEff;
    Sprite themeBG, groundTile;
    Text score_Text;
    int themeBgVal, currentScore, highScore; 
    Animator anim;
    float min_X = -2.2f, max_X = 2.2f;

    void Awake ()
    {
        themeBgVal = PlayerPrefs.GetInt("ThemeIndex");
        if (themeBgVal == 1)
        {
            themeBG = Resources.Load<Sprite>("Environment/Backgrounds/Forest");
            background.sprite = themeBG;
            groundTile = Resources.Load<Sprite>("Environment/Grounds/ForestFloor");
            for (int i = 0; i < floor.Length; i++)
            {
                floor[i].sprite = groundTile;
            }
            for (int j = 0; j < textColorChange.Length - 1; j++)
            {
                textColorChange[j].color = new Color(0f,0f,0f);
            }
        }
        else if (themeBgVal == 2)
        {
            themeBG = Resources.Load<Sprite>("Environment/Backgrounds/InsideHill");
            background.sprite = themeBG;
            groundTile = Resources.Load<Sprite>("Environment/Grounds/InsideHillFloor");
            for (int i = 0; i < floor.Length; i++)
            {
                floor[i].sprite = groundTile;
            }
            for (int j = 0; j < textColorChange.Length - 1; j++)
            {
                textColorChange[j].color = new Color(0f, 0.878f, 1f);
            }
        }
        else if (themeBgVal == 3)
        {
            themeBG = Resources.Load<Sprite>("Environment/Backgrounds/Lunar");
            background.sprite = themeBG;
            groundTile = Resources.Load<Sprite>("Environment/Grounds/LunarHillFloor");
            for (int i = 0; i < floor.Length; i++)
            {
                floor[i].sprite = groundTile;
            }
            for (int j = 0; j < textColorChange.Length - 1; j++)
            {
                textColorChange[j].color = new Color(1f, 1f, 1f);
            }
        }
        else if (themeBgVal == 4)
        {
            themeBG = Resources.Load<Sprite>("Environment/Backgrounds/Solar");
            background.sprite = themeBG;
            groundTile = Resources.Load<Sprite>("Environment/Grounds/SolarFloor");
            for (int i = 0; i < floor.Length; i++)
            {
                floor[i].sprite = groundTile;
            }
            for (int j = 0; j < textColorChange.Length - 1; j++)
            {
                textColorChange[j].color = new Color(0f, 0f, 0f);
            }
        }
        else if (themeBgVal == 5)
        {
            themeBG = Resources.Load<Sprite>("Environment/Backgrounds/SunnyDay");
            background.sprite = themeBG;
            groundTile = Resources.Load<Sprite>("Environment/Grounds/SunnyDayFloor");
            for (int i = 0; i < floor.Length; i++)
            {
                floor[i].sprite = groundTile;
            }
            for (int j = 0; j < textColorChange.Length - 1; j++)
            {
                textColorChange[j].color = new Color(0f, 0f, 0f);
            }
        }
        else
        {
            themeBG = Resources.Load<Sprite>("Environment/Backgrounds/Winter");
            background.sprite = themeBG;
            groundTile = Resources.Load<Sprite>("Environment/Grounds/WinterFloor");
            for (int i = 0; i < floor.Length; i++)
            {
                floor[i].sprite = groundTile;
            }
            for (int j = 0; j < textColorChange.Length - 1; j++)
            {
                textColorChange[j].color = new Color(0f, 0f, 0f);
            }
        }
        anim = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
    }
    void Start() 
    {
        playerEff = player.GetComponent<TrailRenderer>();
        highScore = PlayerPrefs.GetInt("HighScore"); 
        score_Text = scoreText.GetComponent<Text>();
        obstacleGen.SetActive(true);
        StartCoroutine(CountTime());
        timer = 0;
        playAudio.SetActive(true);
        deadAudio.SetActive(false);
    }
	void Update () 
    {
        HoriMovement();
        PlayerLimits();
    }
    void PlayerLimits() 
    {
        Vector3 playPos = transform.position;
        if(playPos.x > max_X)
        {
            playPos.x = max_X;
        }
        else if(playPos.x < min_X) 
        {
            playPos.x = min_X;
        }
        transform.position = playPos;
    }
	void HoriMovement() 
    {
        float horiVal = CrossPlatformInputManager.GetAxis("Horizontal");
        Vector3 temp = transform.position;
        if(horiVal > 0) 
        {
            temp.x += speed * Time.deltaTime;
            playerSprite.flipX = false;
            anim.SetBool("Walk", true);
        } 
        else if(horiVal < 0) 
        {
            temp.x -= speed * Time.deltaTime;
            playerSprite.flipX = true;
            anim.SetBool("Walk", true);
        } 
        else if(horiVal == 0) 
        {
            anim.SetBool("Walk", false);
        }
        transform.position = temp;
	}
	void OnTriggerEnter2D(Collider2D target) 
    {
        playerEff.enabled = false;
        if(target.tag == "Knife")
        {            
            obstacleGen.SetActive(false);
            playAudio.SetActive(false);
            gpButtonCan.SetActive(false);
            deadAudio.SetActive(true);
            blurImg.SetActive(true);
            anim.SetBool("Die", true);
            GameObject[] destroyKnife;
            destroyKnife = GameObject.FindGameObjectsWithTag("Knife");
            for (int i = 0; i < destroyKnife.Length; i++)
            {
                Destroy(destroyKnife[i].gameObject);
            }
            StartCoroutine(ScoreBoard());
        }
	}
    IEnumerator CountTime()
    {
        yield return new WaitForSeconds(1f);
        timer++;
        textColorChange[0].text = "Survived " + timer + " sec(s)";
        //Debug.Log(timer); //Display the timer running behind the gameplay
        StartCoroutine(CountTime());
    }
    IEnumerator ScoreBoard()
    {
        yield return new WaitForSeconds(1f);
        currentScore = timer;
        if (currentScore >= highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            textColorChange[3].color = new Color(1f, 0f, 0f);
        }
        scoreBoard.SetActive(true);
        score_Text.text = "Level Score: " + timer;
        textColorChange[3].text = "High Score: " + PlayerPrefs.GetInt("HighScore");
    }
}































