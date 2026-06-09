using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{

    private int _itemCollected = 0;
    private int _playerHP = 10;
    public int MaxItem = 4;

    public TMP_Text HealthText;
    public TMP_Text ItemText;
    public TMP_Text ProgressText;

    public Button winButton;
    public Button loseButton;

    
    void Start()
    {

        ItemText.text = "Items: " + _itemCollected;
        HealthText.text = "Health: " + _playerHP;

        if (winButton != null ) winButton.gameObject.SetActive( false );
        if (loseButton != null) loseButton.gameObject.SetActive( false );
        
    }

    public int Items
    {
       get { return _itemCollected; }
       set {
            _itemCollected = value;
            ItemText.text = "Items = " + _itemCollected;

            //bagian untuk cek item sudah terkumpul
            if ( _itemCollected >= MaxItem  )
            {
                ProgressText.text = "You found all the items!";
                if ( winButton != null )
                {  
                    winButton.gameObject.SetActive( true ); //untuk nyalain tombol win
                    Time.timeScale = 0f; // untuk pause
                }
            }
            else
            {
                int remaining = MaxItem - _itemCollected;
                ProgressText.text = "Item Found, only " + remaining + " More to go!";
            }
         }
    }

    // untuk Manage HP
    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            HealthText.text = "Health " + _playerHP; 

            if (_playerHP == 0)
            {
                UpdateScene("Restart?");
                Time.timeScale = 0f;
                if (loseButton != null ) loseButton.gameObject.SetActive(true);
            }
        }
    }

    public void UpdateScene(string updateText)
    {
        ProgressText.text = updateText;
    }


    public void RestartScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }







}
