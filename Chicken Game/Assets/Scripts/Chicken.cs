using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "New Chicken", menuName = "Objects/Chicken", order = 1)]
public class Chicken : ScriptableObject {
    public new string name;
    public int speed = 20;
}
