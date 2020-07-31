using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipDatabase : MonoBehaviour
{
    public List<Equip> equips = new List<Equip>();
    private void Awake() {
        BuildDatabase();
        Debug.Log("Equip Database Awakening");
    }

    public Equip GetEquip(int id) {
        return equips.Find(equip => equip.equipID == id);
    }

    private void BuildDatabase() {
        equips = new List<Equip>() {
            new Equip(0, 0),
            new Equip(1, 1),
        };
        Debug.Log(equips);
    }

}
