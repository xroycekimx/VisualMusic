using UnityEngine;
using System.Collections;

public class VisualMusic : MonoBehaviour
{
    ParticleSystem firstGold;
    ParticleSystem.EmissionModule em;
    ParticleSystem.ColorOverLifetimeModule col;
    Gradient grad;
    GameObject[] spheres = new GameObject[10];
    GameObject[] bricks = new GameObject[10];

    // Use this for initialization
    void Start()
    {
        Screen.SetResolution(800, 600, false, 60);
        initSphere();
        initBricks();
        initGold();
    }

    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 125, 20), "Press 'Esc' to close");
    }

    /* Timings in sec.
    Music starts ~4
    
    [Start]
    ~9.5 -> Black dust in orbit -> ~13
    ~17 -> Cascades down like a parachute -> ~19
    ~24 -> Bricks on my shoulders -> ~28.5
    ~32 -> This gravity hurts when you know the truth -> ~35.5

    [Chorus]
    ~37 -> I’m pulling my weight in gold -> ~44
    ~46 -> Call me anxious, call me broke -> ~49.5
    ~50 -> But I can’t lift this on my own -> ~53
    ~54 -> Pulling my weight in gold -> ~60
    ~62 -> Call me anxious, call me broke -> ~65
    ~65.5 -> But I can’t lift this on my own -> ~70

    [Verse 2]
    ~76 -> We dreamt like martyrs -> ~78
    ~80 -> I never thought I was bold enough -> ~84.5
    ~88 -> You pushed me farther -> ~91.5
    ~94 -> And I take the blame for the both of us -> ~97

    [Chorus]
    ~98 -> I’m pulling my weight in gold -> ~103.5
    ~104.5 -> Call me anxious, call me broke -> ~105.5
    ~106 -> But I can’t lift this on my own -> ~109.5
    ~110 -> Pulling my weight in gold -> ~114
    ~115 -> Call me anxious, call me broke -> ~118
    ~118.5 -> But I can’t lift this on my own -> ~121

    [Bridge]
    ~128.5 -> Oh, Universe, hold me up -> ~131
    ~131.5 -> You tried your best, is it ever enough -> ~136
    ~136.5 -> When it’s already dragging me down? -> ~141

    [Chorus]
    ~141 -> I’m pulling my weight in gold -> ~146.5
    ~147.5 -> Call me anxious, call me broke -> ~148.5
    ~149 -> But I can’t lift this on my own -> ~152.5
    ~153 -> Pulling my weight in gold -> ~157
    ~158 -> Call me anxious, call me broke -> ~161
    ~161.5 -> But I can’t lift this on my own -> ~164
    */

    // Update is called once per frame
    void Update()
    {
        //print(Time.fixedTime);

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (Time.fixedTime < 1)
        {
            spheres[0].transform.position = new Vector3(0, 2.5f, 0);
        }
        else if (Time.fixedTime < 2)
        {
            spheres[0].transform.position = new Vector3(0, 2, 0);
            spheres[1].transform.position = new Vector3(0, 2, 0);
            spheres[2].transform.position = new Vector3(0, 2, 0);
        }
        else if (Time.fixedTime < 3)
        {
            spheres[0].transform.position = new Vector3(0, 1.5f, 0);
            spheres[1].transform.position = new Vector3(1, 1.5f, 0);
            spheres[2].transform.position = new Vector3(-1, 1.5f, 0);
            spheres[3].transform.position = new Vector3(0, 1.5f, 1);
            spheres[4].transform.position = new Vector3(0, 1.5f, -1);
        }
        else if (Time.fixedTime < 4)
        {
            spheres[0].transform.position = new Vector3(0, 1, 0);
            spheres[1].transform.position = new Vector3(1, 1, 0);
            spheres[2].transform.position = new Vector3(-1, 1, 0);
            spheres[3].transform.position = new Vector3(0, 1, 1);
            spheres[4].transform.position = new Vector3(0, 1, -1);
            spheres[5].transform.position = new Vector3(1, 1, 1);
            spheres[6].transform.position = new Vector3(-1, 1, -1);
            spheres[7].transform.position = new Vector3(-1, 1, 1);
            spheres[8].transform.position = new Vector3(1, 1, -1);
        }
        else if (Time.fixedTime < 9.5)
        {
            StartCoroutine(oscillate(1.0f, 1.0f));
            StartCoroutine("rise");
        }
        else if (Time.fixedTime < 13)
        {
            em.enabled = true;
            StartCoroutine(oscillate(1.0f, 1.0f));
            for (int i = 1; i < 9; i++)
            {
                spheres[i].transform.position = new Vector3(0, -10, 0);
            }
        }
        else if (Time.fixedTime < 17)
        {
            StartCoroutine(oscillate(1.0f, 1.0f));
        }
        else if (Time.fixedTime < 19)
        {
            StartCoroutine(oscillate(1.0f, 1.0f));
            em.enabled = false;
        }
        else if (Time.fixedTime < 25)
        {
            StartCoroutine(oscillate(1.0f, 1.0f));
        }
        else if (Time.fixedTime < 26)
        {
            spheres[0].transform.position = new Vector3(0, -10, 0);
            bricks[0].transform.position = new Vector3(0, 2.0f, 0);
        }
        else if (Time.fixedTime < 27)
        {
            bricks[1].transform.position = new Vector3(2.0f, 2.0f, 0);
            bricks[2].transform.position = new Vector3(-2.0f, 2.0f, 0);
            bricks[3].transform.position = new Vector3(0, 2.0f, 2.0f);
            bricks[4].transform.position = new Vector3(0, 2.0f, -2.0f);
        }
        else if (Time.fixedTime < 28.5)
        {
            bricks[5].transform.position = new Vector3(2.0f, 2.0f, 2.0f);
            bricks[6].transform.position = new Vector3(-2.0f, 2.0f, -2.0f);
            bricks[7].transform.position = new Vector3(-2.0f, 2.0f, 2.0f);
            bricks[8].transform.position = new Vector3(2.0f, 2.0f, -2.0f);
        }
        else if (Time.fixedTime < 35)
        {
            StartCoroutine("sink");
        }

        //Chorus
        else if (Time.fixedTime < 35.5)
        {
            for (int i = 0; i < 3; i++)
            {
                bricks[i].transform.position = new Vector3(0, -3, 5);
                bricks[i].transform.localScale = new Vector3(10, 3, 0.1f);
            }
        }
        else if (Time.fixedTime < 37)
        {
            for (int i = 0; i < 3; i++)
            {
                bricks[i].GetComponent<Renderer>().material.color = new Color(255, 215, 0, 0);
                if (bricks[i].transform.position.y < 1.5)
                {
                    bricks[i].transform.position = new Vector3(bricks[i].transform.position.x, bricks[i].transform.position.y + 0.05f, bricks[i].transform.position.z);
                }
            }
        }
        else if (Time.fixedTime < 39)
        {
            //Pause
        }
        else if (Time.fixedTime < 42)
        {
            bricks[0].transform.position = new Vector3(bricks[0].transform.position.x, bricks[0].transform.position.y, bricks[0].transform.position.z - 0.1f);
            if (bricks[0].transform.position.z < -5)
            {
                bricks[0].transform.position = new Vector3(0, -10, 0);
            }
        }
        else if (Time.fixedTime < 44)
        {
            bricks[1].transform.position = new Vector3(bricks[1].transform.position.x, bricks[1].transform.position.y, bricks[1].transform.position.z - 0.1f);
            if (bricks[1].transform.position.z < -5)
            {
                bricks[1].transform.position = new Vector3(0, -10, 0);
            }
        }
        else if (Time.fixedTime < 46)
        {
            bricks[2].transform.position = new Vector3(bricks[2].transform.position.x, bricks[2].transform.position.y, bricks[2].transform.position.z - 0.1f);
            if (bricks[2].transform.position.z < -5)
            {
                bricks[2].transform.position = new Vector3(0, -10, 0);
            }
        }
        else if (Time.fixedTime < 46.5)
        {
            for (int i = 0; i < 7; i++)
            {
                spheres[i].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
            }
            spheres[0].transform.position = new Vector3(0, 1, 0);
            spheres[0].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 47)
        {
            spheres[1].transform.position = new Vector3(2.5f, 1, 2.5f);
            spheres[1].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 47.5)
        {
            spheres[2].transform.position = new Vector3(-2.5f, 1, 2.5f);
            spheres[2].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 48)
        {
            spheres[3].transform.position = new Vector3(2.5f, 1, -2.5f);
            spheres[3].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 48.5)
        {
            spheres[4].transform.position = new Vector3(-2.5f, 1, -2.5f);
            spheres[4].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 49)
        {
            spheres[5].transform.position = new Vector3(1, 1, 0);
            spheres[5].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 49.5)
        {
            spheres[6].transform.position = new Vector3(-1, 1, 0);
            spheres[6].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 53)
        {
            for (int i = 0; i < 7; i++)
            {
                spheres[i].transform.position = new Vector3(spheres[i].transform.position.x, Mathf.Sin(Time.time) * 2 + 1, spheres[i].transform.position.z);
                spheres[i].transform.localScale = new Vector3(Mathf.Sin(Time.time), Mathf.Sin(Time.time), Mathf.Sin(Time.time));
            }
        }
        else if (Time.fixedTime < 53.5)
        {
            for (int i = 0; i < 3; i++)
            {
                bricks[i].transform.position = new Vector3(0, -3, -5);
                bricks[i].transform.localScale = new Vector3(10, 3, 0.1f);
                bricks[i].GetComponent<Renderer>().material.color = new Color(255, 215, 0, 0);
            }
        }
        else if (Time.fixedTime < 55)
        {
            for (int i = 0; i < 3; i++)
            {
                if (bricks[i].transform.position.y < 1.5)
                {
                    bricks[i].transform.position = new Vector3(bricks[i].transform.position.x, bricks[i].transform.position.y + 0.1f, bricks[i].transform.position.z);
                }
            }
            for (int i = 0; i < 7; i++)
            {
                if (spheres[i].transform.position.y < 4)
                {
                    spheres[i].transform.position = new Vector3(spheres[i].transform.position.x, spheres[i].transform.position.y + 1, spheres[i].transform.position.z);
                }
            }
        }
        else if ((Time.fixedTime) < 56)
        {
            for (int i = 0; i < 7; i++)
            {
                spheres[i].transform.position = new Vector3(0, -10, 0);
            }
        }
        else if (Time.fixedTime < 58)
        {

            bricks[0].transform.position = new Vector3(bricks[0].transform.position.x, bricks[0].transform.position.y, bricks[0].transform.position.z + 0.1f);
            if (bricks[0].transform.position.z > 5)
            {
                bricks[0].transform.position = new Vector3(0, -10, 0);
            }
        }
        else if (Time.fixedTime < 60)
        {
            bricks[1].transform.position = new Vector3(bricks[1].transform.position.x, bricks[1].transform.position.y, bricks[1].transform.position.z + 0.1f);
            if (bricks[1].transform.position.z > 5)
            {
                bricks[1].transform.position = new Vector3(0, -10, 0);
            }
        }
        else if (Time.fixedTime < 62)
        {
            bricks[2].transform.position = new Vector3(bricks[2].transform.position.x, bricks[2].transform.position.y, bricks[2].transform.position.z + 0.1f);
            if (bricks[2].transform.position.z > 5)
            {
                bricks[2].transform.position = new Vector3(0, -10, 0);
            }
        }
        else if (Time.fixedTime < 63)
        {
            //Pause
        }
        else if (Time.fixedTime < 64)
        {
            for (int i = 0; i < 7; i++)
            {
                spheres[i].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
            }
            spheres[0].transform.position = new Vector3(0, 2, 0);
            spheres[0].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 64.5)
        {
            spheres[1].transform.position = new Vector3(2.5f, 2, 2.5f);
            spheres[1].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 65)
        {
            spheres[2].transform.position = new Vector3(-2.5f, 2, 2.5f);
            spheres[2].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 65.5)
        {
            spheres[3].transform.position = new Vector3(2.5f, 2, -2.5f);
            spheres[3].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 66)
        {
            spheres[4].transform.position = new Vector3(-2.5f, 2, -2.5f);
            spheres[4].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 66.5)
        {
            spheres[5].transform.position = new Vector3(1, 2, 0);
            spheres[5].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 67)
        {
            spheres[6].transform.position = new Vector3(-1, 2, 0);
            spheres[6].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 72)
        {
            for (int i = 0; i < 7; i++)
            {
                spheres[i].transform.position = new Vector3(spheres[i].transform.position.x, -Mathf.Sin(Time.time) * 2 + 1, spheres[i].transform.position.z);
                spheres[i].transform.localScale = new Vector3(Mathf.Sin(Time.time), Mathf.Sin(Time.time), Mathf.Sin(Time.time));
            }
        }
        else if (Time.fixedTime < 73)
        {
            for (int i = 0; i < 7; i++)
            {
                spheres[i].transform.position = new Vector3(spheres[i].transform.position.x, spheres[i].transform.position.y - 0.5f, spheres[i].transform.position.z);
            }
        }
        //End Chorus

        else if (Time.fixedTime < 74)
        {
            //Pause
        }
        else if (Time.fixedTime < 75)
        {
            setGold();
            em.enabled = true;
        }
        else if (Time.fixedTime < 77)
        {
            spheres[0].transform.position = new Vector3(0, 2, 0);
        }
        else if (Time.fixedTime < 78)
        {
            spheres[0].transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Time.fixedTime < 79)
        {
            spheres[0].transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        else if (Time.fixedTime < 80.5)
        {
            spheres[0].transform.localScale = new Vector3(2, 2, 2);
        }
        else if (Time.fixedTime < 83)
        {
            if (spheres[0].transform.localScale.x > 0)
            {
                spheres[0].transform.localScale = new Vector3(spheres[0].transform.localScale.x - 0.02f, spheres[0].transform.localScale.y - 0.02f, spheres[0].transform.localScale.z - 0.02f);
            }
        }
        else if (Time.fixedTime < 85)
        {
            spheres[0].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            spheres[0].transform.position = new Vector3(0, -10, 0);
        }
        else if (Time.fixedTime < 85.5)
        {
            for (int i = 0; i < 9; i++)
            {
                bricks[i].transform.localScale = new Vector3(1, 1, 1);
                bricks[i].transform.position = new Vector3(0, 2, 0);
                bricks[i].GetComponent<Renderer>().material.color = new Color(0, 0, 100, 0.5f);
            }
        }
        else if (Time.fixedTime < 86)
        {
            bricks[0].transform.position = new Vector3(0, 2.0f, 0);
            bricks[1].transform.position = new Vector3(2.0f, 2.0f, 0);
            bricks[2].transform.position = new Vector3(-2.0f, 2.0f, 0);
            bricks[3].transform.position = new Vector3(0, 2.0f, 2.0f);
            bricks[4].transform.position = new Vector3(0, 2.0f, -2.0f);
            bricks[5].transform.position = new Vector3(2.0f, 2.0f, 2.0f);
            bricks[6].transform.position = new Vector3(-2.0f, 2.0f, -2.0f);
            bricks[7].transform.position = new Vector3(-2.0f, 2.0f, 2.0f);
            bricks[8].transform.position = new Vector3(2.0f, 2.0f, -2.0f);
        }
        else if (Time.fixedTime < 91)
        {
            em.enabled = false;
            for (int i = 0; i < 9; i++)
            {
                if (bricks[i].transform.localScale.x > 0)
                {
                    bricks[i].transform.localScale = new Vector3(bricks[i].transform.localScale.x - 0.002f, bricks[i].transform.localScale.y - 0.002f, bricks[i].transform.localScale.z - 0.002f);
                    bricks[i].GetComponent<Renderer>().material.color = new Color(0, 0, 100, bricks[i].GetComponent<Renderer>().material.color.a - 0.001f);
                }
            }
        }
        else if (Time.fixedTime < 93)
        {
            bricks[0].transform.localScale = new Vector3(bricks[0].transform.localScale.x, bricks[0].transform.localScale.y, bricks[0].transform.localScale.z);
        }
        else if (Time.fixedTime < 94)
        {
            bricks[0].transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        else if (Time.fixedTime < 95)
        {
            bricks[0].transform.localScale = new Vector3(2, 2, 2);
        }
        else if (Time.fixedTime < 96)
        {
            bricks[0].transform.localScale = new Vector3(bricks[0].transform.localScale.x + 0.002f, bricks[0].transform.localScale.y + 0.002f, bricks[0].transform.localScale.z + 0.002f);
        }
        else if (Time.fixedTime < 98)
        {
            if (bricks[0].transform.localScale.x > 0)
            {
                bricks[0].transform.localScale = new Vector3(bricks[0].transform.localScale.x - 0.01f, bricks[0].transform.localScale.y - 0.01f, bricks[0].transform.localScale.z - 0.01f);
            }
        }
        else if (Time.fixedTime < 101)
        {
            setBlack();
            em.enabled = true;
            for (int i = 0; i < 9; i++)
            {
                if (bricks[i].transform.localScale.x > 0)
                {
                    bricks[i].transform.localScale = new Vector3(bricks[i].transform.localScale.x - 0.01f, bricks[i].transform.localScale.y - 0.01f, bricks[i].transform.localScale.z - 0.01f);
                }
            }
        }
        else if (Time.fixedTime < 102)
        {
            spheres[1].transform.position = new Vector3(0, 2, 0);

        }
        else if (Time.fixedTime < 104)
        {
            em.enabled = false;
            if (spheres[1].transform.position.y > -1)
            {
                spheres[1].transform.position = new Vector3(0, spheres[1].transform.position.y - 0.02f, 0);
            }
        }
        //Chorus
        else if (Time.fixedTime < 104.5)
        {
            for (int i = 0; i < 3; i++)
            {
                bricks[i].transform.position = new Vector3(0, -3, 5);
                bricks[i].transform.localScale = new Vector3(10, 3, 0.1f);
            }
        }
        else if (Time.fixedTime < 106)
        {
            for (int i = 0; i < 3; i++)
            {
                bricks[i].GetComponent<Renderer>().material.color = new Color(255, 215, 0, 0);
                if (bricks[i].transform.position.y < 1.5)
                {
                    bricks[i].transform.position = new Vector3(bricks[i].transform.position.x, bricks[i].transform.position.y + 0.05f, bricks[i].transform.position.z);
                }
            }
        }
        else if (Time.fixedTime < 107)
        {
            //Pause
        }
        else if (Time.fixedTime < 110)
        {
            bricks[0].transform.position = new Vector3(bricks[0].transform.position.x, bricks[0].transform.position.y, bricks[0].transform.position.z - 0.1f);
            if (bricks[0].transform.position.z < -5)
            {
                bricks[0].transform.position = new Vector3(0, -10, 0);
            }
        }
        else if (Time.fixedTime < 112)
        {
            bricks[1].transform.position = new Vector3(bricks[1].transform.position.x, bricks[1].transform.position.y, bricks[1].transform.position.z - 0.1f);
            if (bricks[1].transform.position.z < -5)
            {
                bricks[1].transform.position = new Vector3(0, -10, 0);
            }
        }
        else if (Time.fixedTime < 114)
        {
            bricks[2].transform.position = new Vector3(bricks[2].transform.position.x, bricks[2].transform.position.y, bricks[2].transform.position.z - 0.1f);
            if (bricks[2].transform.position.z < -5)
            {
                bricks[2].transform.position = new Vector3(0, -10, 0);
            }
        }
        else if (Time.fixedTime < 114.5)
        {
            for (int i = 0; i < 7; i++)
            {
                spheres[i].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
            }
            spheres[0].transform.position = new Vector3(0, 1, 0);
            spheres[0].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 115)
        {
            spheres[1].transform.position = new Vector3(2.5f, 1, 2.5f);
            spheres[1].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 115.5)
        {
            spheres[2].transform.position = new Vector3(-2.5f, 1, 2.5f);
            spheres[2].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 116)
        {
            spheres[3].transform.position = new Vector3(2.5f, 1, -2.5f);
            spheres[3].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 116.5)
        {
            spheres[4].transform.position = new Vector3(-2.5f, 1, -2.5f);
            spheres[4].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 117)
        {
            spheres[5].transform.position = new Vector3(1, 1, 0);
            spheres[5].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 117.5)
        {
            spheres[6].transform.position = new Vector3(-1, 1, 0);
            spheres[6].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 121)
        {
            for (int i = 0; i < 7; i++)
            {
                spheres[i].transform.position = new Vector3(spheres[i].transform.position.x, -Mathf.Sin(Time.time) * 2 + 1, spheres[i].transform.position.z);
                spheres[i].transform.localScale = new Vector3(Mathf.Sin(Time.time), Mathf.Sin(Time.time), Mathf.Sin(Time.time));
            }
        }
        else if (Time.fixedTime < 121.5)
        {
            for (int i = 0; i < 3; i++)
            {
                bricks[i].transform.position = new Vector3(0, -3, -5);
                bricks[i].transform.localScale = new Vector3(10, 3, 0.1f);
                bricks[i].GetComponent<Renderer>().material.color = new Color(255, 215, 0, 0);
            }
        }
        else if (Time.fixedTime < 123)
        {
            for (int i = 0; i < 3; i++)
            {
                if (bricks[i].transform.position.y < 1.5)
                {
                    bricks[i].transform.position = new Vector3(bricks[i].transform.position.x, bricks[i].transform.position.y + 0.1f, bricks[i].transform.position.z);
                }
            }
            for (int i = 0; i < 7; i++)
            {
                if (spheres[i].transform.position.y < 5)
                {
                    spheres[i].transform.position = new Vector3(spheres[i].transform.position.x, spheres[i].transform.position.y + 1, spheres[i].transform.position.z);
                }
            }
        }
        else if ((Time.fixedTime) < 124)
        {
            for (int i = 0; i < 7; i++)
            {
                spheres[i].transform.position = new Vector3(0, -10, 0);
            }
        }
        else if (Time.fixedTime < 126)
        {

            bricks[0].transform.position = new Vector3(bricks[0].transform.position.x, bricks[0].transform.position.y, bricks[0].transform.position.z + 0.1f);
            if (bricks[0].transform.position.z > 5)
            {
                bricks[0].transform.position = new Vector3(0, -10, 0);
            }
        }
        else if (Time.fixedTime < 128)
        {
            bricks[1].transform.position = new Vector3(bricks[1].transform.position.x, bricks[1].transform.position.y, bricks[1].transform.position.z + 0.1f);
            if (bricks[1].transform.position.z > 5)
            {
                bricks[1].transform.position = new Vector3(0, -10, 0);
            }
        }
        else if (Time.fixedTime < 130)
        {
            bricks[2].transform.position = new Vector3(bricks[2].transform.position.x, bricks[2].transform.position.y, bricks[2].transform.position.z + 0.1f);
            if (bricks[2].transform.position.z > 5)
            {
                bricks[2].transform.position = new Vector3(0, -10, 0);
            }
        }
        else if (Time.fixedTime < 131)
        {
            //Pause
        }
        else if (Time.fixedTime < 132)
        {
            for (int i = 0; i < 7; i++)
            {
                spheres[i].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
            }
            spheres[0].transform.position = new Vector3(0, 2, 0);
            spheres[0].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 132.5)
        {
            spheres[1].transform.position = new Vector3(2.5f, 2, 2.5f);
            spheres[1].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 133)
        {
            spheres[2].transform.position = new Vector3(-2.5f, 2, 2.5f);
            spheres[2].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 133.5)
        {
            spheres[3].transform.position = new Vector3(2.5f, 2, -2.5f);
            spheres[3].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 134)
        {
            spheres[4].transform.position = new Vector3(-2.5f, 2, -2.5f);
            spheres[4].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 134.5)
        {
            spheres[5].transform.position = new Vector3(1, 2, 0);
            spheres[5].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 135)
        {
            spheres[6].transform.position = new Vector3(-1, 2, 0);
            spheres[6].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 140)
        {
            for (int i = 0; i < 7; i++)
            {
                spheres[i].transform.position = new Vector3(spheres[i].transform.position.x, Mathf.Sin(Time.time) * 2 + 1, spheres[i].transform.position.z);
                spheres[i].transform.localScale = new Vector3(Mathf.Sin(Time.time), Mathf.Sin(Time.time), Mathf.Sin(Time.time));
            }
        }
        else if (Time.fixedTime < 141)
        {
            for (int i = 0; i < 7; i++)
            {
                spheres[i].transform.position = new Vector3(spheres[i].transform.position.x, spheres[i].transform.position.y - 0.5f, spheres[i].transform.position.z);
            }
        }
        //End Chorus
        else if (Time.fixedTime < 142)
        {
            setRainbow();
            em.enabled = true;
            for (int i = 1; i < 9; i++)
            {
                spheres[i].transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
                spheres[i].transform.position = new Vector3(0, 1, 0);
            }
            spheres[1].GetComponent<Renderer>().material.color = Color.white;
            spheres[2].GetComponent<Renderer>().material.color = Color.red;
            spheres[3].GetComponent<Renderer>().material.color = Color.yellow;
            spheres[4].GetComponent<Renderer>().material.color = Color.green;
            spheres[5].GetComponent<Renderer>().material.color = Color.cyan;
            spheres[6].GetComponent<Renderer>().material.color = Color.blue;
            spheres[7].GetComponent<Renderer>().material.color = Color.magenta;
            spheres[8].GetComponent<Renderer>().material.color = Color.black;
        }
        else if (Time.fixedTime < 148)
        {
            StartCoroutine("universe");
        }
        else if (Time.fixedTime < 148.5)
        {
            StartCoroutine("universe");
            bricks[0].transform.position = new Vector3(4.5f, -1, 4.5f);
            bricks[1].transform.position = new Vector3(-4.5f, -1, 4.5f);
            bricks[2].transform.position = new Vector3(4.5f, -1, -4.5f);
            bricks[3].transform.position = new Vector3(-4.5f, -1, -4.5f);
            for (int i = 0; i < 4; i++)
            {
                bricks[i].transform.localScale = new Vector3(1, 3, 1);
                bricks[i].GetComponent<Renderer>().material.color = Color.black;
            }
        }
        else if (Time.fixedTime < 152)
        {
            StartCoroutine("universe");
            for (int i = 0; i < 4; i++)
            {
                if (bricks[i].transform.position.y < 1.5)
                {
                    bricks[i].transform.position = new Vector3(bricks[i].transform.position.x, bricks[i].transform.position.y + 0.01f, bricks[i].transform.position.z);
                }
            }
        }
        else if (Time.fixedTime < 157)
        {
            StartCoroutine("universe");
            if (bricks[0].transform.localScale.x < 10 && bricks[0].transform.position.x > 0)
            {
                bricks[0].transform.position = new Vector3(bricks[0].transform.position.x - 0.02f, bricks[0].transform.position.y, bricks[0].transform.position.z);
                bricks[0].transform.localScale = new Vector3(bricks[0].transform.localScale.x + 0.05f, bricks[0].transform.localScale.y, bricks[0].transform.localScale.z);
            }
            if (bricks[1].transform.localScale.z < 10 && bricks[1].transform.position.z > 0)
            {
                bricks[1].transform.position = new Vector3(bricks[1].transform.position.x, bricks[1].transform.position.y, bricks[1].transform.position.z - 0.02f);
                bricks[1].transform.localScale = new Vector3(bricks[1].transform.localScale.x, bricks[1].transform.localScale.y, bricks[1].transform.localScale.z + 0.05f);
            }
            if (bricks[2].transform.localScale.z < 10 && bricks[2].transform.position.z < 0)
            {
                bricks[2].transform.position = new Vector3(bricks[2].transform.position.x, bricks[2].transform.position.y, bricks[2].transform.position.z + 0.02f);
                bricks[2].transform.localScale = new Vector3(bricks[2].transform.localScale.x, bricks[2].transform.localScale.y, bricks[2].transform.localScale.z + 0.05f);
            }
            if (bricks[3].transform.localScale.x < 10 && bricks[3].transform.position.x < 0)
            {
                bricks[3].transform.position = new Vector3(bricks[3].transform.position.x + 0.02f, bricks[3].transform.position.y, bricks[3].transform.position.z);
                bricks[3].transform.localScale = new Vector3(bricks[3].transform.localScale.x + 0.05f, bricks[3].transform.localScale.y, bricks[3].transform.localScale.z);
            }
        }
        else if (Time.fixedTime < 162)
        {
            StartCoroutine("universe");
            for (int i = 1; i < 9; i++)
            {
                if (spheres[i].transform.localScale.x > 0)
                {
                    spheres[i].transform.localScale = new Vector3(spheres[i].transform.localScale.x - 0.001f, spheres[i].transform.localScale.y - 0.001f, spheres[i].transform.localScale.z - 0.001f);
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (bricks[i].transform.position.y > -3)
                {
                    bricks[i].transform.position = new Vector3(bricks[i].transform.position.x, bricks[i].transform.position.y - 0.01f, bricks[i].transform.position.z);
                }
            }
        }
        //Chorus
        else if (Time.fixedTime < 162.5)
        {
            setGold();
            for (int i = 1; i < 9; i++)
            {
                spheres[i].transform.position = new Vector3(0, -10, 0);
            }
            for (int i = 0; i < 4; i++)
            {
                bricks[i].transform.position = new Vector3(0, -3, 5);
                bricks[i].transform.localScale = new Vector3(10, 3, 0.1f);
            }
        }
        else if (Time.fixedTime < 164)
        {
            for (int i = 0; i < 3; i++)
            {
                bricks[i].GetComponent<Renderer>().material.color = new Color(255, 215, 0, 0);
                if (bricks[i].transform.position.y < 1.5)
                {
                    bricks[i].transform.position = new Vector3(bricks[i].transform.position.x, bricks[i].transform.position.y + 0.05f, bricks[i].transform.position.z);
                }
            }
        }
        else if (Time.fixedTime < 166)
        {
            bricks[0].transform.position = new Vector3(bricks[0].transform.position.x, bricks[0].transform.position.y, bricks[0].transform.position.z - 0.1f);
            if (bricks[0].transform.position.z < -5)
            {
                bricks[0].transform.position = new Vector3(0, -10, 0);
            }
        }
        else if (Time.fixedTime < 168)
        {
            bricks[1].transform.position = new Vector3(bricks[1].transform.position.x, bricks[1].transform.position.y, bricks[1].transform.position.z - 0.1f);
            if (bricks[1].transform.position.z < -5)
            {
                bricks[1].transform.position = new Vector3(0, -10, 0);
            }
        }
        else if (Time.fixedTime < 170)
        {
            bricks[2].transform.position = new Vector3(bricks[2].transform.position.x, bricks[2].transform.position.y, bricks[2].transform.position.z - 0.1f);
            if (bricks[2].transform.position.z < -5)
            {
                bricks[2].transform.position = new Vector3(0, -10, 0);
            }
        }
        else if (Time.fixedTime < 171)
        {
            //Pause
        }
        else if (Time.fixedTime < 171.5)
        {
            for (int i = 0; i < 7; i++)
            {
                spheres[i].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
            }
            spheres[0].transform.position = new Vector3(0, 1, 0);
            spheres[0].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 172)
        {
            spheres[1].transform.position = new Vector3(2.5f, 1, 2.5f);
            spheres[1].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 172.5)
        {
            spheres[2].transform.position = new Vector3(-2.5f, 1, 2.5f);
            spheres[2].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 173)
        {
            spheres[3].transform.position = new Vector3(2.5f, 1, -2.5f);
            spheres[3].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 173.5)
        {
            spheres[4].transform.position = new Vector3(-2.5f, 1, -2.5f);
            spheres[4].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 174)
        {
            spheres[5].transform.position = new Vector3(1, 1, 0);
            spheres[5].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 174.5)
        {
            spheres[6].transform.position = new Vector3(-1, 1, 0);
            spheres[6].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 178)
        {
            for (int i = 0; i < 7; i++)
            {
                spheres[i].transform.position = new Vector3(spheres[i].transform.position.x, -Mathf.Sin(Time.time) * 2 + 1, spheres[i].transform.position.z);
                spheres[i].transform.localScale = new Vector3(Mathf.Sin(Time.time), Mathf.Sin(Time.time), Mathf.Sin(Time.time));
            }
        }
        else if (Time.fixedTime < 178.5)
        {
            for (int i = 0; i < 3; i++)
            {
                bricks[i].transform.position = new Vector3(0, -3, -5);
                bricks[i].transform.localScale = new Vector3(10, 3, 0.1f);
                bricks[i].GetComponent<Renderer>().material.color = new Color(255, 215, 0, 0);
            }
        }
        else if (Time.fixedTime < 179.5)
        {
            for (int i = 0; i < 3; i++)
            {
                if (bricks[i].transform.position.y < 1.5)
                {
                    bricks[i].transform.position = new Vector3(bricks[i].transform.position.x, bricks[i].transform.position.y + 0.1f, bricks[i].transform.position.z);
                }
            }
            for (int i = 0; i < 7; i++)
            {
                if (spheres[i].transform.position.y < 5)
                {
                    spheres[i].transform.position = new Vector3(spheres[i].transform.position.x, spheres[i].transform.position.y + 1, spheres[i].transform.position.z);
                }
            }
        }
        else if ((Time.fixedTime) < 180)
        {
            for (int i = 0; i < 7; i++)
            {
                spheres[i].transform.position = new Vector3(0, -10, 0);
            }
        }
        else if (Time.fixedTime < 182)
        {

            bricks[0].transform.position = new Vector3(bricks[0].transform.position.x, bricks[0].transform.position.y, bricks[0].transform.position.z + 0.1f);
            if (bricks[0].transform.position.z > 5)
            {
                bricks[0].transform.position = new Vector3(0, -10, 0);
            }
        }
        else if (Time.fixedTime < 184)
        {
            bricks[1].transform.position = new Vector3(bricks[1].transform.position.x, bricks[1].transform.position.y, bricks[1].transform.position.z + 0.1f);
            if (bricks[1].transform.position.z > 5)
            {
                bricks[1].transform.position = new Vector3(0, -10, 0);
            }
        }
        else if (Time.fixedTime < 186)
        {
            bricks[2].transform.position = new Vector3(bricks[2].transform.position.x, bricks[2].transform.position.y, bricks[2].transform.position.z + 0.1f);
            if (bricks[2].transform.position.z > 5)
            {
                bricks[2].transform.position = new Vector3(0, -10, 0);
            }
        }
        else if (Time.fixedTime < 187)
        {
            //Pause
        }
        else if (Time.fixedTime < 188)
        {
            for (int i = 0; i < 7; i++)
            {
                spheres[i].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
            }
            spheres[0].transform.position = new Vector3(0, 2, 0);
            spheres[0].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 188.5)
        {
            spheres[1].transform.position = new Vector3(2.5f, 2, 2.5f);
            spheres[1].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 189)
        {
            spheres[2].transform.position = new Vector3(-2.5f, 2, 2.5f);
            spheres[2].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 189.5)
        {
            spheres[3].transform.position = new Vector3(2.5f, 2, -2.5f);
            spheres[3].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 190)
        {
            spheres[4].transform.position = new Vector3(-2.5f, 2, -2.5f);
            spheres[4].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 190.5)
        {
            spheres[5].transform.position = new Vector3(1, 2, 0);
            spheres[5].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 191)
        {
            spheres[6].transform.position = new Vector3(-1, 2, 0);
            spheres[6].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Time.fixedTime < 196)
        {
            for (int i = 0; i < 7; i++)
            {
                spheres[i].transform.position = new Vector3(spheres[i].transform.position.x, Mathf.Sin(Time.time) * 2 + 1, spheres[i].transform.position.z);
                spheres[i].transform.localScale = new Vector3(Mathf.Sin(Time.time), Mathf.Sin(Time.time), Mathf.Sin(Time.time));
            }
        }
        else if (Time.fixedTime < 197)
        {
            for (int i = 0; i < 7; i++)
            {
                spheres[i].transform.position = new Vector3(spheres[i].transform.position.x, spheres[i].transform.position.y - 0.5f, spheres[i].transform.position.z);
            }
        }
        //End Chorus
        else if (Time.fixedTime > 204)
        {
            Application.Quit();
        }
    }

    void initGold()
    {
        firstGold = GetComponent<ParticleSystem>();
        firstGold.GetComponent<ParticleSystem>().Play();
        em = firstGold.emission;
        em.enabled = false;
        col = firstGold.colorOverLifetime;
        col.enabled = true;
        firstGold.GetComponent<ParticleSystem>().transform.position = new Vector3(0, 4.25f, 0);
    }

    void setGold()
    {
        grad = new Gradient();
        Color gold = new Color(255, 215, 0, 1);
        grad.SetKeys(new GradientColorKey[] { new GradientColorKey(gold, 0.0f), new GradientColorKey(Color.white, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });
        col.color = new ParticleSystem.MinMaxGradient(grad);
    }

    void setRainbow()
    {
        grad = new Gradient();
        grad.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.black, 0.0f), new GradientColorKey(Color.blue, 0.25f), new GradientColorKey(Color.green, 0.45f), new GradientColorKey(Color.yellow, 0.65f), new GradientColorKey(Color.red, .80f), new GradientColorKey(Color.white, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(1.0f, 1.0f) });
        col.color = new ParticleSystem.MinMaxGradient(grad);
    }

    void setBlack()
    {
        grad = new Gradient();
        grad.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.black, 0.0f), new GradientColorKey(Color.white, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });
        col.color = new ParticleSystem.MinMaxGradient(grad);
    }

    void initSphere()
    {
        for (int i = 0; i < 10; i++)
        {
            spheres[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            spheres[i].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            spheres[i].transform.position = new Vector3(0, -10, 0);
        }
        spheres[0].GetComponent<Renderer>().material.color = new Color(255, 0, 0, 1);
        spheres[1].GetComponent<Renderer>().material.color = new Color(0, 0, 255, 1);
        spheres[2].GetComponent<Renderer>().material.color = new Color(0, 0, 255, 1);
        spheres[3].GetComponent<Renderer>().material.color = new Color(0, 0, 255, 1);
        spheres[4].GetComponent<Renderer>().material.color = new Color(0, 0, 255, 1);
        spheres[5].GetComponent<Renderer>().material.color = new Color(0, 0, 255, 1);
        spheres[6].GetComponent<Renderer>().material.color = new Color(0, 0, 255, 1);
        spheres[7].GetComponent<Renderer>().material.color = new Color(0, 0, 255, 1);
        spheres[8].GetComponent<Renderer>().material.color = new Color(0, 0, 255, 1);
    }

    void initBricks()
    {
        for (int i = 0; i < 10; i++)
        {
            bricks[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            bricks[i].transform.localScale = new Vector3(1.0f, 0.5f, 0.5f);
            bricks[i].transform.position = new Vector3(0, -10, 0);
            bricks[i].GetComponent<Renderer>().material.color = new Color(100, 0, 0, 1);
        }
    }

    IEnumerator oscillate(float radius, float speed)
    {
        spheres[0].transform.position = new Vector3(Mathf.Cos(Time.time * speed) * radius, 1, Mathf.Sin(Time.time * speed) * radius);
        yield return null;
    }

    IEnumerator rise()
    {
        for (int i = 1; i < 9; i++)
        {
            spheres[i].transform.position = new Vector3(spheres[i].transform.position.x, spheres[i].transform.position.y + 0.01f, spheres[i].transform.position.z);
        }
        yield return null;
    }

    IEnumerator sink()
    {
        for (int i = 0; i < 9; i++)
        {
            bricks[i].transform.position = new Vector3(bricks[i].transform.position.x, bricks[i].transform.position.y - 0.006f, bricks[i].transform.position.z);
        }
        yield return null;
    }

    IEnumerator universe()
    {
        for (int i = 1; i < 9; i++)
        {
            spheres[i].transform.position = new Vector3(Mathf.Cos(Time.time * i / 4) * i / 3, 1, Mathf.Sin(Time.time * i / 4) * i / 3);
        }
        yield return null;
    }
    /*
    IEnumerator RepeatingFunction () {
        while(true) {
              //execute code here.
              yield return new WaitForSeconds(repeatTime);
        }
    }
    */
}