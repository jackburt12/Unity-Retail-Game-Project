#pragma strict


function Update () {
    

    var screenPoint = Input.mousePosition;
    screenPoint.z = 10.0f; //distance of the plane from the camera
    transform.position = Camera.main.ScreenToWorldPoint(screenPoint);


}