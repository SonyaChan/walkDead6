using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class managerAgent : MonoBehaviour
{
     public GameObject[] enemys;
       NavMeshAgent[] agents;// from enemy so dont need puplic
      public GameObject[] targets;
      List<NavMeshAgent> agentForEnemy = new List<NavMeshAgent>();
      int i = 0;
      // Start is called before the first frame update
      void Start()
      {
        agents = new NavMeshAgent[enemys.Length]; // to solve nullRefrenceException and IndexOutOfRangeException.
        for ( i =0; i< enemys.Length; i++) //becuose its array
        {
          agents[i] = enemys[i].GetComponent<NavMeshAgent>(); // for all enemy objects
          agentForEnemy.Add(agents[i]);
        }
      }

    // Update is called once per frame
      void Update()
      {
        foreach (GameObject target in targets)

        {
            //need list to put the enemys in agents?
            foreach (NavMeshAgent agents in agentForEnemy)
            {
                agents.SetDestination(target.transform.position);//the type is gameObject so need transform inside()
            }
        }
          
        // i need become the target&move randomly?***********************


      }

  
}
