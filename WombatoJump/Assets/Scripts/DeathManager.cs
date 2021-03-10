using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class DeathManager : MonoBehaviour
    {
        public static DeathManager Instance;

        private void Start()
        {
            Instance = this;
        }

        public void OnPlayerDeath()
        {
            ScoreScript.Instance.SaveScorePoints();
            PlayerCoins.Instance.SaveCoins();

            StartCoroutine(OpenDeathScreen());
        }

        private IEnumerator<WaitForSeconds> OpenDeathScreen()
        {
            print("W8");
            yield return new WaitForSeconds(0.5f);
            print("F8");
            SceneManager.LoadScene("AfterDeathScene");
        }
    }
}
