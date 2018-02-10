using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phone : MonoBehaviour {
    public Text text;
    public AudioClip audioclip;
    List<int> number = new List<int>();
    int a = 1;

    public AudioSource source;

    // Use this for initialization
    void Start () {
        number.Clear();
        text.text = "";
        source.clip = audioclip;
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void press1()
    {
        number.Add(1);
        text.text = text.text + 1.ToString();
    }

    public void press2()
    {
        number.Add(2);
        text.text = text.text + 2.ToString();
    }

    public void press3()
    {
        number.Add(3);
        text.text = text.text + 3.ToString();
    }

    public void press4()
    {
        number.Add(4);
        text.text = text.text + 4.ToString();
    }

    public void press5()
    {
        number.Add(5);
        text.text = text.text + 5.ToString();
    }

    public void press6()
    {
        number.Add(6);
        text.text = text.text + 6.ToString();
    }

    public void press7()
    {
        number.Add(7);
        text.text = text.text + 7.ToString();
    }

    public void press8()
    {
        number.Add(8);
        text.text = text.text + 8.ToString();
    }

    public void press9()
    {
        number.Add(9);
        text.text = text.text + 9.ToString();
    }

    public void press0()
    {
        number.Add(0);
        text.text = text.text + 0.ToString();
    }

    public void clear()
    {
        number.Clear();
        text.text = "";
    }

    public void call()
    {
        List<int> correct = new List<int>();
        correct.Add(6);
        correct.Add(1);
        correct.Add(7);
        correct.Add(7);
        correct.Add(6);
        correct.Add(3);
        correct.Add(4);
        correct.Add(7);
        correct.Add(8);
        correct.Add(6);

        bool yes = this.com(number, correct);

        if(yes)
        {
            source.Play();
        }
    }

    private bool com(List<int> a, List<int> b)
    {
        if(a.Count != b.Count)
        {
            return false;
        }

        for(int i = 0; i < a.Count; i++)
        {
            if(a[i] != b[i])
            {
                return false;
            }
        }
        return true;
    }


}
