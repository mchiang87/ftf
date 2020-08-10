using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishDatabase : MonoBehaviour {
  public List<Dish> dishes = new List<Dish>();
  private void Awake() {
    BuildDatabase();
  }

  public Dish GetDish(int id) {
    return dishes.Find(dish => dish.dishID == id);
  }

  private void BuildDatabase() {
    dishes = new List<Dish>() {
        new Dish(0, 0),
        new Dish(1, 1),
    };
  }
}
