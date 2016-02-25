using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class csInsanitySystem : MonoBehaviour
{
    // Variable Initialization
    public bool hasTorch = false;
    public bool colLight;
    public bool colDark;
    public bool maxSanity = false;
    public bool countFin = false;

    public GUISkin gameSkin;

    private int sanityDifficulty = 2;
    private int sanityRestore = 2;
    private int sanity = 100;
    private int count = 0;
    public int countMax;

    void OnGUI ( )
    {
        // Initialize the GUI
        GUI.skin = gameSkin;

        // Show Sanity In-Game
        string sanityText = "Sanity: " + sanity;
        GUI.Box (new Rect (Screen.width - 150, 40, 130, 23), sanityText);

        // Show Count In-Game
        string countText = "Count: " + count;
        GUI.Box (new Rect (Screen.width - 150, 80, 130, 23), countText);

        // Show Count Finish In-Game
        string countFinText = "Fin: " + countFin;
        GUI.Box (new Rect (Screen.width - 150, 120, 130, 23), countFinText);

        // Show Dark Collision In-Game
        string colDarkText = "Dark: " + colDark;
        GUI.Box (new Rect (Screen.width - 150, 160, 130, 23), colDarkText);

        // Show Light Collision In-Game
        string colLightText = "Light: " + colLight;
        GUI.Box (new Rect (Screen.width - 150, 200, 130, 23), colLightText);
    }

    // Update is called once per frame
    void Update ( )
    {
        if (colLight == true)
        {
            sanityGain();
        }

        else if (colDark == true)
        {
            sanityLoss();
        }

        if (count < countMax)
        {
            count++;
            print("Current: " + count);
            print("Max: " + countMax);
        }

        else
        {
            countFin = true;
            count = 0;
        }
    }

    // Detect 2D Collision Enter
    void OnTriggerEnter2D ( Collider2D other )
    {
        // Debug.Log ("Collision Detected!");

        if (other.gameObject.CompareTag ("Player"))
        {
			colDark = false;
            colLight = true;
        }

        else
        {
            colDark = true;
            colLight = false;
        }
    }

    // Detect 2D Collision Exit
    void OnTriggerExit2D( Collider2D other )
    {
        if (other.gameObject.CompareTag ("Player"))
        {
            colDark = true;
            colLight = false;
        }
    }

    void sanityGain ( )
    {
        if (countFin && sanity <= 98)
        {
            count = 0;
            countFin = false;
            sanity += 2;
        }

        else if (countFin && sanity == 99)
        {
            sanity = 100;
        }
    }

    void sanityLoss ( )
    {
        if (sanity <= 0)
        {
            sanity = 0;
            maxSanity = false;
            levelRestart ();
        }

        else if (hasTorch && countFin)
        {
            count = 0;
            countFin = false;
            sanity -= 2;
        }

        else if (countFin)
        {
            count = 0;
            countFin = false;
            sanity -= 5;
        }
    }

    void levelRestart()
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
    }
}
