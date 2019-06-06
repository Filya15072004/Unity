using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Enemy : MonoBehaviour
{
	public Transform player;
  public NavMeshAgent agent;
  public Text scoreText;
  static int score;
  	
 	Rigidbody rbenemy;

    void Start()
    {
      rbenemy = GetComponent<Rigidbody>();
      score = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      agent.SetDestination(player.transform.position);  
    }
    void OnCollisionEnter(Collision other)
    {
      if(other.gameObject.tag == "Bullet"){

        score++;
        scoreText.text = "Score " + score;

        Destroy(gameObject);
        if(score >= 4){
          SceneManager.LoadScene(0);
          score = 0;
        }

      }

    }
}
