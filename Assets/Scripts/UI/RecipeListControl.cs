using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RecipeListControl : MonoBehaviour {

  [SerializeField]
  private GameObject recipe;
  [SerializeField]
  private RecipeDatabase recipeDatabase;
  private MenuManager menuManager;  
  private LearnedRecipes learnedRecipes;
  private Recipe recipeDisplayed;
  private List<GameObject> textItems;
  private bool displayed;
  private bool onSubMenu;
  // public Sprite itemPortrait;
  public Text recipeFlavorText;
  public Image recipeFirstIngredientSprite;
  public Image recipeSecondIngredientSprite;
  public Image recipeThirdIngredientSprite;
  public GameObject selector;
  public GameObject subSelector;
  public float yOffsetMenu;
  public float yOffsetSubMenu;
  public Vector3 originalMenuSelectPos;
    public Vector3 originalSubMenuSelectPos;
  public int menuItemIndex;
  private int menuItemCount;
  public int subMenuItemIndex;
  
  public void Start() {
    onSubMenu = false;
    displayed = false;
    textItems = new List<GameObject>();
    learnedRecipes = FindObjectOfType<LearnedRecipes>();
    menuManager = FindObjectOfType<MenuManager>();
    originalMenuSelectPos = new Vector3(selector.transform.position.x,selector.transform.position.y, 0f);
    originalSubMenuSelectPos = new Vector3(subSelector.transform.position.x,subSelector.transform.position.y, 0f);
    for(int i = 0; i < recipeDatabase.recipes.Count; i++) {
      CreateTextEntry("???", Color.white, i);
    }
  }

  public void Update() {
    if(textItems.Any() && displayed == false) {
      displayed = true;
      SetRecipeFlavorText(0);
    };
    menuItemCount = textItems.Count();
    // Menu Navigation
      // select down
      if (displayed == true && !onSubMenu) {
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
          if (menuItemIndex < menuItemCount - 1) {
            menuItemIndex++;
            Vector3 position = selector.transform.position;
            position.y -= yOffsetMenu;
            selector.transform.position = position;
            SetRecipeFlavorText(menuItemIndex);
          }
        }

        // select up
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
          if (menuItemIndex > 0) {
            menuItemIndex--;
            Vector3 position = selector.transform.position;
            position.y += yOffsetMenu;
            selector.transform.position = position;
            SetRecipeFlavorText(menuItemIndex);
          }
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
          // Select menu item and use for submenu if exist
          onSubMenu = true;
          menuManager.onMenuTab = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
          menuManager.onMenuTab = true;
        }

      } else if (onSubMenu) {
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
          if (subMenuItemIndex <  2) {
            subMenuItemIndex++;
            Vector3 position = subSelector.transform.position;
            position.y -= yOffsetSubMenu;
            subSelector.transform.position = position;
          }
        }

        // select up
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
          if (subMenuItemIndex > 0) {
            subMenuItemIndex--;
            Vector3 position = subSelector.transform.position;
            position.y += yOffsetSubMenu;
            subSelector.transform.position = position;
          }
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
          onSubMenu = false;
          menuManager.onMenuTab = true;
        }

      } else {
      menuItemIndex = 0;
      selector.transform.position = originalMenuSelectPos;
      subSelector.transform.position = originalSubMenuSelectPos;
    }
  }

  // Creates a new text Entry
  public void CreateTextEntry(string newText, Color newColor, int id) {
    GameObject listRecipe = Instantiate(recipe) as GameObject;
    listRecipe.SetActive(true);
    listRecipe.GetComponent<ListText>().SetText(newText, newColor, id);
    listRecipe.transform.SetParent(recipe.transform.parent, false);
    textItems.Add(listRecipe.gameObject);
  }

  public void UpdateTextEntry(string newText, Color newColor, int id) {
    GameObject entryToUpdate = textItems.Find(entry => entry.GetComponent<ListText>().id == id);
    entryToUpdate.GetComponent<ListText>().UpdateText(newText, newColor);
  }

  public void SetRecipeFlavorText(int index) {
    recipeDisplayed = learnedRecipes.learnedRecipes.Find(it => it.ID == index);
    if (recipeDisplayed != null) {
      recipeFlavorText.text = recipeDisplayed.flavorText;
    } else {
      recipeFlavorText.text = "Not yet discovered!";
    }
    // recipePortrait = recipeDisplayed.portrait;
  }
}
