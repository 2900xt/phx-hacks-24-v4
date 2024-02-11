using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public int cost, buildingType;
    public const int TYPE_WHEAT_FARM = 1, TYPE_MILK_FARM = 2, TYPE_EGG_FARM = 3, TYPE_BREAD_FACTORY = 4;
    public const int TYPE_NEB_FACTORY = 5, TYPE_SOL_FACTORY = 6, TYPE_SHINY_FACTORY = 7, TYPE_TACHYON_FACTORY = 8;
    public float timer;
    public static float wheatGenTime = 15, eggGenTime = 5, milkGenTime = 5, breadGenTime = 5;
    public static GameManager gameMgr;
    void Start()
    {
        gameMgr = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public float GetProgress()
    {
        float denominator = 0;
        timer -= Time.deltaTime;

        switch(buildingType)
        {
            case TYPE_WHEAT_FARM:
            {
                denominator = wheatGenTime;
                break;
            }
            case TYPE_MILK_FARM:
            {
                denominator = milkGenTime;
                break;
            }
            case TYPE_EGG_FARM:
            {
                denominator = eggGenTime;
                break;
            }
            case TYPE_BREAD_FACTORY:
            {
                denominator = breadGenTime;
                break;
            }
            default: break;
        }

        return (denominator - timer) / denominator;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        switch(buildingType)
        {
            case TYPE_WHEAT_FARM:
            {
                if(timer < 0)
                {
                    timer = wheatGenTime;
                    gameMgr.userWheat += 5;
                }
                break;
            }
            case TYPE_MILK_FARM:
            {
                if(timer < 0)
                {
                    timer = milkGenTime;
                    gameMgr.userMilk += 5;
                }
                break;
            }
            case TYPE_EGG_FARM:
            {
                if(timer < 0)
                {
                    timer = eggGenTime;
                    gameMgr.userEggs += 5;
                }
                break;
            }
            case TYPE_BREAD_FACTORY:
            {
                if(timer < 0)
                {
                    timer += Time.deltaTime;
                    if(gameMgr.userEggs >= 2 && gameMgr.userMilk >= 1 && gameMgr.userWheat >= 3)
                    {
                        timer = breadGenTime;
                        gameMgr.userBread++;

                        gameMgr.userEggs -= 2;
                        gameMgr.userMilk -= 1;
                        gameMgr.userWheat -= 3;
                        if(gameMgr.prestiegeLevel == 1)
                        {
                            gameMgr.userPrestiegeCount++;
                        }
                    }
                }
                break;
            }
            case TYPE_SHINY_FACTORY:
            {
                if(timer < 0)
                {
                    timer += Time.deltaTime;
                    if(gameMgr.userBread >= 3)
                    {
                        timer = breadGenTime;
                        gameMgr.userShinyBread++;
                        
                        gameMgr.userBread -= 3;
                        if(gameMgr.prestiegeLevel == 2)
                        {
                            gameMgr.userPrestiegeCount++;
                        }
                    }
                }
                break;
            }
            case TYPE_SOL_FACTORY:
            {
                if(timer < 0)
                {
                    timer += Time.deltaTime;
                    if(gameMgr.userShinyBread >= 3)
                    {
                        timer = breadGenTime;
                        gameMgr.userSolarBread++;

                        gameMgr.userShinyBread -= 3;
                        if(gameMgr.prestiegeLevel == 3)
                        {
                            gameMgr.userPrestiegeCount++;
                        }
                    }
                }
                break;
            }
            case TYPE_NEB_FACTORY:
            {
                if(timer < 0)
                {
                    timer += Time.deltaTime;
                    if(gameMgr.userSolarBread >= 3)
                    {
                        timer = breadGenTime;
                        gameMgr.userNebulaBread++;

                        gameMgr.userSolarBread -= 3;
                        if(gameMgr.prestiegeLevel == 4)
                        {
                            gameMgr.userPrestiegeCount++;
                        }
                    }
                }
                break;
            }
            case TYPE_TACHYON_FACTORY:
            {
                if(timer < 0)
                {
                    timer += Time.deltaTime;
                    if(gameMgr.userNebulaBread >= 3)
                    {
                        timer = breadGenTime;
                        gameMgr.userTachyonBread++;

                        gameMgr.userNebulaBread -= 3;
                        if(gameMgr.prestiegeLevel == 5)
                        {
                            gameMgr.userPrestiegeCount++;
                        }
                    }
                }
                break;
            }
            default:
                break;
        }
    }
}
