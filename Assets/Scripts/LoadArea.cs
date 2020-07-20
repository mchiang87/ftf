using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadArea : Collidable {
    public string sceneToLoad;

    public string exitPoint;

    protected override void OnCollide(Collider2D coll) {
        if (coll.name == "Player")
        {
            // Teleport Player
            GameManager.instance.SaveState();
            // string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
            GameManager.instance.currentScene = sceneToLoad;
            GameManager.instance.startPoint = exitPoint;
        }
    }
}
