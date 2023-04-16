using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Answer{

    public string answer;
    public GameObject obj;
    public int code;

    public Answer(string a, GameObject o, int c){
        code = c;
        obj = o;
        answer = a;
    }
}
