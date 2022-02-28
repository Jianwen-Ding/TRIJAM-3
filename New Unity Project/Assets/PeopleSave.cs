using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PeopleSave : MonoBehaviour
{
    public static int PeopleSaved;
    public float speed;
    public GameObject[] People = new GameObject[5];
    public GameObject Heli;
    public float x;
    public float leeWay;
    public bool isGrabbing;
    public float time;
    public float timeGrab;
    public float timeLeft;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        speed += (Time.deltaTime * 0.01f);
        if(isGrabbing == false && Input.GetKeyDown("space"))
        {
            isGrabbing = true;
            timeLeft = time;
            Heli.GetComponent<Animator>().SetBool("Grabbing", true);
        }
        if(isGrabbing && Mathf.Abs(timeLeft - timeGrab)< 0.1)
        {
            for (int i = 0; i < People.Length; i++)
            {
                if (Mathf.Abs(People[i].transform.position.x - x) < leeWay)
                {
                    People[i].transform.position = new Vector3(Random.Range(-1.6f,-0.5f), People[i].transform.position.y);
                }
            }
        }
        if (timeLeft < 0)
        {
            isGrabbing = false;
            Heli.GetComponent<Animator>().SetBool("Grabbing", false);
        }
        for(int i = 0; i < People.Length; i++)
        {
            People[i].transform.position = new Vector3(People[i].transform.position.x + (speed * Time.deltaTime), People[i].transform.position.y);
            if (People[i].transform.position.x > 10)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
