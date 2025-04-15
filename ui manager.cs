using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class uimanager : MonoBehaviour
{

    public GameObject gameovertext;
    public GameObject gamewintext;
    public GameObject winT;
    
    public void gameover()                        //GameOver text
    {

        gameovertext.SetActive(true);
    }
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);           //Restart game after Gameover
    }

    public void win()                             //Level 1 win-text
    {
        gamewintext.SetActive(true);
    }

    public void nextLevel()                    //loading level 2
    {
        SceneManager.LoadScene("Level2");
    }

    public void winTxt()                      //Level 2 win-text
    {
        winT.SetActive(true);   
    }
}
