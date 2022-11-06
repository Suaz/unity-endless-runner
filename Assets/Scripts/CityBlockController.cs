using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityBlockController : MonoBehaviour
{

    private int speed = 5;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, speed * -Time.deltaTime));

        if(transform.position.z < -12)
        {
            Destroy(this.gameObject);
            LevelController.Instance.AddBlockAtEnd();
        }
    }
}
