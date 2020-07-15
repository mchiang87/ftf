using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        // singleton here, TODO port load to preload scene later
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            Destroy(player.gameObject);
            Destroy(floatingTextManager.gameObject);
            Destroy(hud);
            Destroy(menu);
            return;
        }

        instance = this;
        SceneManager.sceneLoaded += LoadState;
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    // Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> expTable;

    // References
    public Player player;
    public Weapon weapon;
    public FloatingTextManager floatingTextManager;
    public RectTransform hitPointBar;
    public Animator deathMenuAnim;
    public GameObject hud;
    public GameObject menu;
    // Logic
    public int marks;
    public int experience;

    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    // Upgrade Weapon
    public bool UpgradeWeapon()
    {
        // Is weapon max level
        if (weaponPrices.Count <= weapon.weaponLevel)
        {
            return false;
        }

        if (marks >= weaponPrices[weapon.weaponLevel])
        {
            marks -= weaponPrices[weapon.weaponLevel];
            weapon.Upgrade();
            return true;
        }
        return false;
    }

    // Health Bar
    public void OnHitPointChange()
    {
        float ratio = (float)player.hitPoint / (float)player.maxHitPoint;
        hitPointBar.localScale = new Vector3(1, ratio, 1);
    }

    // Leveling System
    public int GetCurrentLevel()
    {
        int level = 0;
        int add = 0;
        
        while (experience >= add)
        {
            add += expTable[level];
            level++;

            if (level == expTable.Count)
            {
                return level;
            }
        }
        return level;
    }

    public int GetExpToLevel(int level)
    {
        int r = 0;
        int exp = 0;

        while (r < level)
        {
            exp += expTable[r];
            r++;
        }
        return exp;
    }

    public void GrantExp(int exp)
    {
        int curLevel = GetCurrentLevel();
        experience += exp;
        if (curLevel < GetCurrentLevel())
        {
            OnLevelUp();
        }
    }

    public void OnLevelUp()
    {
        player.OnLevelUp();
        OnHitPointChange();
    }

    // on Scene Load
    public void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        player.transform.position = GameObject.Find("SpawnPoint").transform.position;
    }

    // Death Menu and respawn
    public void Respawn()
    {
        deathMenuAnim.SetTrigger("Hide");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
        player.Respawn();
    }

    /*
    * INT preferredSkin
    * INT marks
    * INT experience
    * INT weaponLevel
    */
    public void SaveState()
    {
        string s = "";
        s += "0" + "|";
        s += marks.ToString() + "|";
        s += experience.ToString() + "|";
        s += weapon.weaponLevel.ToString();

        PlayerPrefs.SetString("SaveState", s);
    }

    public void LoadState(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= LoadState;

        if (!PlayerPrefs.HasKey("SaveState"))
        {
            return;
        }

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        
        marks = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        if (GetCurrentLevel() != 1)
        {
        player.SetLevel(GetCurrentLevel());
        }
        weapon.SetWeaponLevel(int.Parse(data[3]));

        player.transform.position = GameObject.Find("SpawnPoint").transform.position;
    }
}
