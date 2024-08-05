using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger: MonoBehaviour
{
    [SerializeField] AudioSource pressSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SceneZero()
    {
        pressSound.Play();
        SceneManager.LoadScene(0);
    }
    public void SceneOne()
    {
        pressSound.Play();
        SceneManager.LoadScene(1);
    }
    public void SceneTwo()
    {
        pressSound.Play();
        SceneManager.LoadScene(2);
    }
    public void SceneThree()
    {
        pressSound.Play();
        SceneManager.LoadScene(3);
    }

}
