using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Confirm : MonoBehaviour
{
    Hero player;
    Hero enemy;

    private int[,] teamHeroIds; //teamHeroIds[英雄阵营，英雄Id]
    public static Hero hero; 
    public static bool IsClickHero = false; //当前是否选择英雄

    public Text nametext;

    void Start()
    {
        teamHeroIds = new int[2,4];
        

    }
    void Update()
    {
        nametext.text = Game.Instance.player.username;
        Istrue();
    }
    public void Istrue()
    {
        if (IsClickHero)
        {
            this.GetComponent<Button>().interactable = true;
        }
    }
    public void AddHeroesId()
    {
        teamHeroIds[0, 0] = hero.id;

        // int n = Random.Range(1, 4); // We have not enough prefabs
        int n = Random.Range(0, 2);
        do
        {
            n = Random.Range(0, 2); 
        }
        while (n == hero.id);
        teamHeroIds[1, 0] = n;
        Game.Instance.teamHeroIds = teamHeroIds;
        SceneManager.LoadScene("Loading");
    }
    
}
