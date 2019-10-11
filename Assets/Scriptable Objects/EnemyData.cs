using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Data", menuName = "Kei Tools/ Create New Enemy Data", order = 151)]
public class EnemyData : ScriptableObject
{
    public string EnemyName;
    public int AttackPower;
    public int MaxHealth;
}