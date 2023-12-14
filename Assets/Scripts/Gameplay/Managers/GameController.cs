using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public void levelRestart(float seconds)
    {
        StartCoroutine(restart(seconds));
    }

    public IEnumerator restart(float seconds)
    {
        yield return new WaitForSeconds(seconds);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        yield return null;
	}
}
