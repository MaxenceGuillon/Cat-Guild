using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fight_Manager : MonoBehaviour
{
    // Cats list to use in fight
    public List<CatInstance> guildTeam = new List<CatInstance>();
    public List<CatInstance> ennemiTeam = new List<CatInstance>();

    public List<CatInstance> guildTeamTempo = new List<CatInstance>();
    public List<CatInstance> ennemiTeamTempo = new List<CatInstance>();

    public int maxOfCatsInTeam = 6;

    public bool whoIsAttack;
    public int catSelectToAttack = 0;
    public int catSelectToDefend = 0;

    // Team trust = addition of defense of all cats 
    public int guildTeamTrust;
    public int ennemiTeamTrust;

    // Team vivacity = addition of vivacity of all cats 
    public int guildTeamVivacity;
    public int ennemiTeamVivacity;
    public bool whoIsFirst;

    //Alpha cat in two team
    public CatInstance guildAlphaCat;
    public CatInstance ennemiAlphaCat;

   public void DeterminateFirst()
    {
        int vivacityTempo = 0; 

        // Determinate guild team's vivacity in function of omega stat of all cat instances
        for (int i = 0; i < maxOfCatsInTeam; i++)
        {
            vivacityTempo = vivacityTempo + guildTeam[i].omegaStat;
        }
        guildTeamVivacity = vivacityTempo / guildTeam.Count;

        vivacityTempo = 0;

        // Determinate ennemi team's vivacity in function of omega stat of all cat instances
        for (int i = 0; i < maxOfCatsInTeam; i++)
        {
            vivacityTempo = vivacityTempo + ennemiTeam[i].omegaStat;
        }
        ennemiTeamVivacity = vivacityTempo / ennemiTeam.Count;

        // Select first team
        if (guildTeamVivacity > ennemiTeamVivacity) whoIsFirst = true;
        if (ennemiTeamVivacity > guildTeamVivacity) whoIsFirst = false;
    }

    public void DeterminateTrust()
    {
        int trustTempo = 0;

        // Determinate guild team's trust in function of omega stat of all cat instances
        for (int i = 0; i < guildTeam.Count; i++)
        {
            trustTempo = trustTempo + guildTeam[i].omegaStat;
        }
        guildTeamTrust = trustTempo;

        trustTempo = 0;

        // Determinate ennemi team's trust in function of omega stat of all cat instances
        for (int i = 0; i < ennemiTeam.Count; i++)
        {
            trustTempo = trustTempo + ennemiTeam[i].omegaStat;
        }
        ennemiTeamTrust = trustTempo;
    }

    public void StartFight()
    {
        DeterminateFirst();
        whoIsAttack = whoIsFirst;
        guildTeamTempo = guildTeam;
        ennemiTeamTempo = ennemiTeam;

        // Selection of the first figther
        if (whoIsAttack == true) catSelectToAttack = Random.Range(0, guildTeamTempo.Count);
        if (whoIsAttack == false) catSelectToAttack = Random.Range(0, ennemiTeamTempo.Count);

        AttackPhase();
    }

    public void AttackPhase()
    {
        if ((guildTeamTrust <= 0) || (ennemiTeamTrust <= 0))
        {
            EndFight();
            return;
        }

        if (whoIsAttack == true) // Guild team attack
        {
            catSelectToDefend = Random.Range(0, ennemiTeamTempo.Count);

            ennemiTeamTrust = ennemiTeamTrust - (guildTeam[catSelectToAttack].alphaStat - ennemiTeam[catSelectToDefend].betaStat);
            catSelectToDefend = catSelectToAttack;
            guildTeamTempo.Remove(guildTeamTempo[catSelectToAttack]);
        }

        if (whoIsAttack == false) // Ennemi team attack
        {
            catSelectToDefend = Random.Range(0, guildTeamTempo.Count);

            guildTeamTrust = guildTeamTrust - (ennemiTeam[catSelectToAttack].alphaStat - guildTeam[catSelectToDefend].betaStat);
            catSelectToDefend = catSelectToAttack;
            ennemiTeamTempo.Remove(guildTeamTempo[catSelectToAttack]);
        }

        // Switch of attacker
        if (whoIsAttack == true) whoIsAttack = false;
        if (whoIsAttack == false) whoIsAttack = true;

        // Relauch AttackPhase
        AttackPhase();
    }

    public void EndFight()
    {
        return;
    }
}
