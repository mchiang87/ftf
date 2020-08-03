using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest {
    public int questID;
    public string description;
    public List<string> objectives;
    public int rewardID;

    public Quest(int questID, string description, List<string> objectives, int rewardID) {
        this.questID = questID;
        this.description = description;
        this.objectives = objectives;
        this.rewardID = rewardID;
    }
}
