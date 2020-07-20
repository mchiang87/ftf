using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    // Textfields
    public Text levelText,
        hitPointText,
        marksText,
        upgradeCostText,
        expText;

    // Logic 
    private int currentCharacterSelection = 0;
    public Image characterSelectionSprite,
        weaponSprite;

    public RectTransform expBar;

    // Character Selection
    public void OnArrowClick(bool right)
    {
        if (right)
        {
            currentCharacterSelection++;

            // If out of bounds
            if (currentCharacterSelection == GameManager.instance.playerSprites.Count)
            {
                currentCharacterSelection = 0;
            }

            OnSelectionChange();
        } else {
            currentCharacterSelection--;

            // If out of bounds
            if (currentCharacterSelection < 0)
            {
                currentCharacterSelection = GameManager.instance.playerSprites.Count - 1;
            }

            OnSelectionChange();
        }
    }

    private void OnSelectionChange()
    {
        characterSelectionSprite.sprite = GameManager.instance.playerSprites[currentCharacterSelection];
        GameManager.instance.player.SwapSprite(currentCharacterSelection);
    }

    // Weapon Upgrade
    public void OnUpgradeClick()
    {
        if (GameManager.instance.UpgradeWeapon())
        {
            UpdateMenu();
        }
    }

    // Text Updates
    public void UpdateMenu()
    {
        // Weapon
        weaponSprite.sprite = GameManager.instance.weaponSprites[GameManager.instance.weapon.weaponLevel];
        if (GameManager.instance.weapon.weaponLevel == GameManager.instance.weaponPrices.Count) 
        {
        upgradeCostText.text = "FULLY UPGRADED";
        } else {
            upgradeCostText.text = GameManager.instance.weaponPrices[GameManager.instance.weapon.weaponLevel].ToString();
        }

        // Meta
        levelText.text = GameManager.instance.GetCurrentLevel().ToString();
        hitPointText.text = GameManager.instance.player.hitPoint.ToString();
        marksText.text = GameManager.instance.marks.ToString();

        // Exp bar
        int curLevel = GameManager.instance.GetCurrentLevel();
        if (curLevel == GameManager.instance.expTable.Count)
        {
            expText.text = GameManager.instance.experience.ToString() + " total experience points";
            expBar.localScale = Vector3.one;
        } else {
            int prevLevelExp = GameManager.instance.GetExpToLevel(curLevel - 1);
            int curLevelExp = GameManager.instance.GetExpToLevel(curLevel);

            int diff = curLevelExp - prevLevelExp;
            int curExpIntoLevel = GameManager.instance.experience - prevLevelExp;

            float completionRatio = (float)curExpIntoLevel / (float)diff;
            expBar.localScale = new Vector3(completionRatio, 1, 1);
            expText.text = curExpIntoLevel.ToString() + " / " + diff;
        }
    }
}
