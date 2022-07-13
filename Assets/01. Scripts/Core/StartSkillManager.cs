using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class StartSkillManager : MonoBehaviour
{
    public Skill[] randomSkillArr;

    public Skill[] skillArr;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Select();
        }
    }

    private void Select()
    {
        ShuffleArray(skillArr);
        skillArr[0] = randomSkillArr[0];
        skillArr[1] = randomSkillArr[1];
        skillArr[2] = randomSkillArr[2];
    }

    private T[] ShuffleArray<T>(T[] array)
    {
        int random1, random2;
        T temp;

        for (int i = 0; i < array.Length; ++i)
        {
            random1 = Random.Range(0, array.Length);
            random2 = Random.Range(0, array.Length);

            temp = array[random1];
            array[random1] = array[random2];
            array[random2] = temp;
        }

        return array;
    }
}
