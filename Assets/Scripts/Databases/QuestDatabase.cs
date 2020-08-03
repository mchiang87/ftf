using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDatabase : MonoBehaviour
{
    public List<Quest> quests = new List<Quest>();
    private void Awake() {
        BuildDatabase();
        Debug.Log("Quest Database Awakening");
    }

    public Quest GetItem(int id) {
        return quests.Find(quest => quest.questID == id);
    }

    private void BuildDatabase() {
        quests = new List<Quest>() {
            new Quest(0, "Find me a gem", new List<string>() {"Find a gem", "Come back with a gem"}, 0, false),
            new Quest(1, "Find me a heart", new List<string>() {"Find a heart", "Come back with a heart"}, 1, false),
        };
        Debug.Log(quests);
    }

}
