using UnityEngine;
using TMPro;

public class ZombieKillCounter : MonoBehaviour
{
    public TextMeshProUGUI killText;
    private int killCount = 0;

    public void AddKill()
    {
        killCount++;
        killText.text = "Zombies Eliminados: " + killCount;
    }
}
