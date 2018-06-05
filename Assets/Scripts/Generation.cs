using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour {
    float enemySpawnPosZ = 50;
	float ScoreSpawnPosZ = 50f;

	float Offset;
	public const float offset = 46.56f;
	public GameObject pipe;
	public int pipeammount;

    public GameObject enemy_prefab;
    public GameObject point_prefab;

    float time = 0;

    void Start () {
		GenerateScene ();
	}
	
	void Update () {
        time += Time.deltaTime;
        if (time > 3)
        {
            time = 0;
            GenerateScene();
        }
    }
	void GenerateScene(){
		
		//generate pipe	
		for(int i = 0; i < pipeammount; i++){
		GameObject.Instantiate (pipe,new Vector3(transform.position.x,transform.position.y,transform.position.z + Offset),transform.rotation);
			Offset += offset;
		}
        //generate enemy or Point(entity)
		for (int i  = 0; i < pipeammount * 5; i++) {
            //generate enemy with x and y with range from -0.7 to 0.7 
            //every 10 units in z direction
            float EnemyTempX = Random.Range(-2f,2f);
            float EnemyTempY = Random.Range(-2f, 2f);

            GameObject enemy_ob;
            //random number for point or Enemy
            int random_int = Random.Range(0, 2);
            if (random_int == 0) // enemy
            {
                enemy_ob = Instantiate(enemy_prefab, new Vector3(EnemyTempX, EnemyTempY, enemySpawnPosZ), transform.rotation);
                enemySpawnPosZ += 9;
				ScoreSpawnPosZ += 15;
            }
            else // Point
            {
				enemy_ob = Instantiate(point_prefab, new Vector3(EnemyTempX, EnemyTempY, ScoreSpawnPosZ), transform.rotation);
                enemySpawnPosZ += 9;
				ScoreSpawnPosZ += 15;
            }
            //get random size for the spheres
            float randomsize = Random.Range(0.5f, 1f);
            enemy_ob.transform.localScale = new Vector3(randomsize, randomsize, randomsize);
        }
            


        
	}
}
