using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public void levelRestart(float seconds)
    {
        StartCoroutine("restart", seconds);
    }

    public IEnumerator restart()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        yield return null;
	}
}
