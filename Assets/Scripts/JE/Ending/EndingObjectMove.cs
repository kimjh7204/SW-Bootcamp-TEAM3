using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingObjectMove : MonoBehaviour
{
    private float speed = 1f;
    public Transform target;
    public Image endingBlackPanel;
    public bool temp = true;

    void Update()
    {
        
        target.position = new Vector3(target.position.x, target.position.y, target.position.z - speed * Time.deltaTime);
        if (target.position.z <= -10)
        {
            endingBlackPanel.gameObject.SetActive(true);
            StartCoroutine(FadeOutStart());
        }

    }

    public IEnumerator FadeOutStart()
    {
        endingBlackPanel.gameObject.SetActive(true);
        for (float f = 0f; f < 1; f += 0.005f)
        {
            Color c = endingBlackPanel.color;
            c.a = f;
            endingBlackPanel.color = c;
            yield return null;
        }
        SceneManager.LoadScene(3);
    }


}
