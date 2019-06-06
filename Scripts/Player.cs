using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public Text zdText;
    int zd;
    Rigidbody rb;
    public GameObject bullet;
    Rigidbody rbbullet;
	GameObject clonebul;

    void Start()
    {
        zd = 5;
       rb = GetComponent<Rigidbody>();
    }

   
    void Update()
    {
        float mVertical = Input.GetAxis("Vertical");
        rb.AddForce(transform.forward * mVertical * 15f);

        float mHorizontal = Input.GetAxis("Horizontal") * 5f;
        transform.Rotate(0,mHorizontal,0);

		if(Input.GetKeyDown("space")){
		 clonebul = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
		  rbbullet = clonebul.GetComponent<Rigidbody>();
            rbbullet.AddForce(transform.forward * 800f);
		}      
    }
    void OnCollisionEnter(Collision player){
        if(player.gameObject.tag == "Enemy"){
             zd--;

            zdText.text = "HP " + zd;

            if(zd <= 0){
                SceneManager.LoadScene(1);
                zd = 5;
            }
        }
    }

}