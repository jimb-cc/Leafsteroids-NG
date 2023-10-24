using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class GameOver : MonoBehaviour
{
    public endGameSwitcher endgameswitcher;
    public void gameOver()
    {
        Debug.Log("############## GAME OVER ###############");
        endgameswitcher.NextScene("EndGame");

        
    }
}
