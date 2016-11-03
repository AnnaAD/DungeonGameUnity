#pragma strict
var plane : Plane = new Plane(Vector3.up, Vector3.zero);;
 
function LateUpdate()
{
    if (Input.GetMouseButton(0))
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
 
        var ent : float = 100.0;
        if (plane.Raycast(ray, ent))
        {
            Debug.Log("Plane Raycast hit at distance: " + ent);
            var hitPoint = ray.GetPoint(ent);
           
            var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
go.transform.position = hitPoint;
            Debug.DrawRay (ray.origin, ray.direction * ent, Color.green);
        }
        else
            Debug.DrawRay (ray.origin, ray.direction * 10, Color.red);
 
    }
}

function Start () {

}

function Update () {

}