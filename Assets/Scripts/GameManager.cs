using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake(){
        if(GameManager.instance != null){
            Destroy(gameObject);
            return;
        }

        PlayerPrefs.DeleteAll();

        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    // Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    // References
    public Player player;
    //public weapon weapon..
    public FloatingTextManager floatingTextManager;

    // Logic
    public int bitcoins;
    public int experience;

    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration){
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }


    // Save state

    public void SaveState(){
        string s = "";

        s += "0" + "|";//playerskin
        s += bitcoins.ToString() + "|";//money
        s += experience.ToString() + "|";//experience
        s += "0";//weaponlevel

        PlayerPrefs.SetString("SaveState", s);

        Debug.Log("SaveState");
    }

    public void LoadState(Scene s, LoadSceneMode mode){
        
        if(!PlayerPrefs.HasKey("SaveState"))
        return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        //playerskin
        bitcoins = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        //weaponlevel

        Debug.Log("LoadState");
    }
}
