using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation2 : MonoBehaviour {
    public GameObject Player_ob;

    public GameObject Pipe_Prefab;
    public GameObject Enemy_Prefab;
    public GameObject Point_Prefab;

    float const_pipeSizeZ;
    float pipeSpawnPosZ = 0;

    float time;
    void Start () {
        Player_ob = GameObject.Find("Player");

        //ja zemash goleminata na cevkata po z-axis
        const_pipeSizeZ = Pipe_Prefab.GetComponent<MeshFilter>().sharedMesh.bounds.size.z * Pipe_Prefab.transform.localScale.z;

        
        Generate(5);
        Generate(5);
        Generate(5);
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        while (time >= const_pipeSizeZ/ (MovementScript.ForwardSpeed)) {
            time = 0;
            Generate(5);
        }
	}

    void Generate(int number_of_enteties) {
        //pipe generation
        Instantiate(Pipe_Prefab, new Vector3(transform.position.x, transform.position.y, pipeSpawnPosZ),transform.rotation);
        pipeSpawnPosZ += const_pipeSizeZ;

        //enemy generation
        float lenght_between_enemies = const_pipeSizeZ / number_of_enteties;
        for (int i = 0; i < number_of_enteties;i++) {
            //radiusot na tunelot e okolu 3 
            //PosX + PosY = radius
            

            int random_int = Random.Range(0,5);
            float EnemyPosX;
            float EnemyPosY;
            if (random_int > 4) {//spawn enemy in players path
                EnemyPosX = Player_ob.transform.position.x;
                EnemyPosY = Player_ob.transform.position.y;
            }
            else {              //spawn enemy randomly

                 EnemyPosX = Random.Range(-2.8f, 2.8f);
                 //Debug.Log(EnemyPosX);
                 EnemyPosY =Random.Range((2.8f - Mathf.Abs(EnemyPosX)) * -1, 2.8f - Mathf.Abs(EnemyPosX));

                //random za moznost na dobivanje negativen y kordinat
                random_int = Random.Range(0, 2);
                if (random_int == 0) {
                    //EnemyPosY *= -1;
                }
            }

            Vector3 enemySpawnPos = new Vector3(EnemyPosX, EnemyPosY, i * lenght_between_enemies + pipeSpawnPosZ - const_pipeSizeZ/2);
            random_int = Random.Range(0, 2);
            if (random_int == 0) {
                //EnemyPosY *= -1;
                Instantiate(Enemy_Prefab, enemySpawnPos, transform.rotation);
            }
            else {
                Instantiate(Point_Prefab, enemySpawnPos, transform.rotation);
            }
        }


    }
}
