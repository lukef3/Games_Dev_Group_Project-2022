using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    enum NPC_States { Patrol, Idle, Search, Chase, Attack, Flee }
    enum NPC_Transitions { Hear_Something, See_Something, Nothing, Within_Melee }
    NPC_States currentState = NPC_States.Patrol;

    public Transform transformToFollow;
    //NavMesh Agent variable
    UnityEngine.AI.NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        currentState = NPC_States.Chase;
    }

    // Update is called once per frame
    void Update()
    {
        NPC_Transitions currentChange = NPC_Transitions.Nothing;

        //  Thinking Phase

        switch (currentState)
        {

            case NPC_States.Idle:

                break;

            case NPC_States.Chase:
            {
                //Follow the player
                agent.destination = transformToFollow.position;
                break;
            }

           case NPC_States.Patrol:
                switch (currentChange)
                {
                    case NPC_Transitions.Hear_Something:
                        currentState = NPC_States.Search;

                        break;
                    case NPC_Transitions.See_Something:
                        currentState = NPC_States.Chase;

                        break;
                }

                break;

        }


        // Action Phase

        switch (currentState)
        {
            case NPC_States.Idle:
                // ensure idle animation
                // timer to stop idle

                break;

        }

    }
}
