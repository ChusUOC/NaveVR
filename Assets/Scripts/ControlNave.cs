using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlNave : MonoBehaviour
{

    public float velocidad = 5.0f;
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float movimientoHorizontal = Input.GetKey(KeyCode.A) ? -1.0f : (Input.GetKey(KeyCode.D) ? 1.0f : 0.0f);
        float movimientoVertical = Input.GetKey(KeyCode.W) ? -1.0f : (Input.GetKey(KeyCode.S) ? 1.0f : 0.0f);

        Vector3 direcciones = new Vector3(horizontal, 0.0f, vertical).normalized;
        GetComponent <Rigidbody>().AddForce (direcciones*velocidad*Time.deltaTime);

        Vector3 newPosition = transform.position + direcciones * velocidad * Time.deltaTime*20;
        GetComponent<Rigidbody>().MovePosition(newPosition);


    }
}
