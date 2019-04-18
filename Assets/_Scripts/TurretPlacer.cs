using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlacer : MonoBehaviour {

    private GridTD grid;
    public GameObject turret;
    public int xSize;
    public int zSize;
    public GameObject shopMenu;

	// Use this for initialization
	void Start () {
        grid = FindObjectOfType<GridTD>();
        shopMenu = GameObject.Find("ShopMenu");
        shopMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hitInfo))
            {
                PlaceCubeNear(hitInfo.point);
            }
        }

        transform.localScale = new Vector3(xSize * grid.size, grid.size, zSize* grid.size);
        var hitCollidersColour = Physics.OverlapBox(gameObject.transform.position, new Vector3((xSize * grid.size)/2, grid.size * 10, (zSize * grid.size)/2), Quaternion.identity);
        if(hitCollidersColour.Length <= 1)
        {
            //GetComponent<Renderer>().material.
            GetComponent<Renderer>().material.color = new Color(0, 1, 0, 0.39f);
        }
        else
        {
            GetComponent<Renderer>().material.color = new Color(1, 0, 0, 0.39f);
        }
    }

    private void PlaceCubeNear(Vector3 clickPoint)
    {
        var finalPosition = grid.GetNearestPointOnGrid(clickPoint);
        var hitColliders = Physics.OverlapBox(gameObject.transform.position, new Vector3((xSize * grid.size)/2, grid.size * 10, (zSize * grid.size)/2), Quaternion.identity);
        if(hitColliders.Length <= 1)
        {
            GameObject newObject = Instantiate(turret, finalPosition, Quaternion.identity) as GameObject;
            newObject.transform.localScale = new Vector3(xSize * grid.size, 1 * grid.size, zSize * grid.size);
            shopMenu.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
