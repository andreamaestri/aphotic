using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class csInsanitySystem : MonoBehaviour
{
    // Variable Initialization
    public bool colisionLight;
    public bool colisionDarkness;

    private bool countFinish = false;



    public GUISkin gameSkin;


    public int countMax;
    public int sanityDifficulty = 2;
    public int sanityRestore = 2;

    private int sanity = 100;
    private int count = 0;


    void OnGUI()
    {
        // GUI Initialization
        GUI.skin = gameSkin;

        // Show Sanity In-Game
        string sanityText = "Sanity: " + sanity;
        GUI.Box(new Rect(Screen.width - 150, 40, 130, 23), sanityText);
    }


    void OnTriggerEnter2D (Collider2D other)
    {
        // Debug.Log ("Collision Detected");

        if (other.gameObject.CompareTag ("Light"))
        {
            colisionDarkness = true;
            colisionLight = false;
        }

        else
        {
            colisionDarkness = false;
            colisionLight = true;
        }
    }

    void OnTriggerExit2D (Collider2D other)
    {
        if (other.gameObject.CompareTag ("Light"))
        {
            colisionLight = false;
            colisionDarkness = true;
        }
    }


    void sanityGain ()
    {
        if (countFinish && sanity <= 98)
        {
            count = 0;
            countFinish = false;
            sanity += 2;
        }

        else if (countFinish && sanity == 99)
        {
            sanity = 100;
        }

        else if (sanity == 100)
        {
            sanity = 100;
        }
    }


    void sanityLoss ()
    {
        if (sanity <= 0)
        {
            sanity = 0;
                  levelRestart ();
        }

        else if (countFinish)
        {
            count = 0;
            countFinish = false;
            sanity -= 5;
        }
    }


    void update ()
    {
        Debug.Log("Working");
        if (colisionLight)
        {
            sanityLoss ();
        }

        if (colisionDarkness)
        {
            sanityGain ();
        }

        if (count < countMax)
        {
            count++;
            Debug.Log ("Current Count: " + count);
            Debug.Log ("Max Count: " + countMax);
        }

        else
        {
            countFinish = true;
            count = 0;
        }
    }


    void levelRestart ()
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
    }

    void start ()
    {
        Debug.Log(sanity);
    }
}
