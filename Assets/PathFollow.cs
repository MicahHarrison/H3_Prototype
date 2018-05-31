using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : MonoBehaviour {

    public Node [] PathNode;

    public GameObject Player;

    public float MoveSpeed;

    float Timer;

    static Vector3 CurrentPositionHolder;

    public int Curr;

    public List<Vector3> Positions;

    public SoundManager Manager;





    // Use this for initialization
    void Start () {
        PathNode = GetComponentsInChildren<Node>();
        //SwitchAudio(AudioSource clip)
        //for (int i = 0; i < PathNode.Length; i++)
        //{
        //    Positions.Add( PathNode[i].transform.position);
        //}
        CheckNode();
        
        
	}

    void DrawLine()
    {
        for (int i = 0; i < PathNode.Length - 1; i++)
        {
            Debug.DrawLine(PathNode[i].transform.position, PathNode[i + 1].transform.position, Color.blue);
        }
    }

    //Check if node is currnode
    public void CheckNode()
    { 
        if (Curr < PathNode.Length) { 
            Timer = 0;
            CurrentPositionHolder = PathNode[Curr].transform.position;
        }
    }

   
    // Update is called once per frame
    void Update () {
        Timer = 0;
        //DrawLine();
        Timer = Time.deltaTime * MoveSpeed;
        if (Input.GetKeyDown("d") && Player.transform.position == CurrentPositionHolder)
        {
            if (Curr < PathNode.Length - 1)
            {
                Curr++;
                CurrentPositionHolder = PathNode[Curr].transform.position;
            }

        }
        else if (Input.GetKeyDown("a") && Player.transform.position == CurrentPositionHolder)
        {
            if (Curr > 0)
            {
                Curr--;
                CurrentPositionHolder = PathNode[Curr].transform.position;
            }
            
        }
        if (Player.transform.position != CurrentPositionHolder)
        {
            Player.transform.position = Vector3.Lerp(Player.transform.position, CurrentPositionHolder, Timer);
        }
    }
    public void ClickMove(Vector3 dest)
    {
        int destnum = 0;
        Timer = Time.deltaTime * MoveSpeed;
        for (int i = 0; i < PathNode.Length - 1; i++)
        {
            if (PathNode[i].transform.position == dest)
            {
                destnum = i;
                Debug.Log(i);
            }
        }
        while (destnum != Curr) {
           
            
                if (Curr < destnum)
                {
                    Curr++;

                }
                else if (Curr > destnum)
                {
                    Curr--;
                }
                Debug.Log(Curr);
                CurrentPositionHolder = PathNode[Curr].transform.position;
            
        }
    }
}
