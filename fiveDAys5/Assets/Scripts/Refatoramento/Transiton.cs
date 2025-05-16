using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transiton : MonoBehaviour
{
    [SerializeField] GameObject obj;

    private void Update()
    {
        if (obj == null)
        {
            StartCoroutine(Time());
        }
    }

    public IEnumerator Time()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("GameOver");
    }
}
