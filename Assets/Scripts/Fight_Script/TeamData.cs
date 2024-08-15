using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Team", menuName = "Teams/New Team")]

// AI ennemi team 
public class TeamData : ScriptableObject
{
    // Mains Informations
    public string teamName;
    public Sprite visualTeamBoss;
    public int teamLevel;

    public List<CatInstance> catsTeam = new List<CatInstance>();

    public int maxCatsInTeam = 6;

    public int teamTrust;
}
