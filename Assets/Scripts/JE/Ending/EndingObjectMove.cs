using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class EndingObjectMove : MonoBehaviour
{
    private float speed = 2f;
    private Transform target;
    public Image endingBlackPanel;
    public bool temp = true;
    public GameObject targetPrefab;
    public GameObject player;

    public GameObject endingCAM;


    public static EndingObjectMove instance;

    private void Start()
    {
        instance = this;
    }

    public void ShowEnding()
    {
        target = Instantiate<GameObject>(targetPrefab, new Vector3(0, 0.153f, 0), Quaternion.Euler(new Vector3(0, 180f, 0))).GetComponent<Transform>();
        player.SetActive(false);
        endingCAM.SetActive(true);
        StartCoroutine(MoveObj());
        
    }


    private void Update()
    {
        if (target == null) return;
        if (target.position.z <= -10)
        {
            endingBlackPanel.gameObject.SetActive(true);
            StartCoroutine(FadeOutStart());
        }
    }



    private IEnumerator MoveObj()
    {
        float timer = Time.deltaTime;
        while (true)
        {
            target.position = new Vector3(target.position.x, target.position.y, target.position.z - speed * (Time.deltaTime - timer));

            yield return null;
        }
    }

    private IEnumerator FadeOutStart()
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
