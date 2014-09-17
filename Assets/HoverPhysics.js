var forwardPower: float;
var steerPower: float;
var landingPower: float;
var jumpingPower: float;
var hoverHeight: float;
var stability: float = 1;
var body: GameObject;
var dist: float = 0;

public var speedUpdate:float;

private var hitNormals:Vector3[] = new Vector3[5];
private var rotation:Quaternion;
private var increment:float;
private var lastNormals:Vector3[] = new Vector3[5];
private var physicsSetup:boolean = false;
private var boxDimensions: Vector3;
private var cornersPoint:Vector3[] = new Vector3[5];
private var corners:Transform[] = new Transform[5];
private var boxCollider:BoxCollider;
private var yBounce:float;
private var lastPosition:Vector3;
private var distance:float;
private var average:Vector3;


function Awake () {
	InitializePhysics();
}

function Update () {
	CalculateSpeed();
}

function FixedUpdate () {
	if(physicsSetup) {
		var hit:RaycastHit;
		
		for(var i:int = 0;  i <= corners.length-1; i++){
			if(Physics.Raycast(corners[i].position, -corners[i].up, hit, hoverHeight+100)){
				hitNormals[i] = body.transform.InverseTransformDirection(hit.normal);
				if(lastNormals[i] != hitNormals[i]){
					increment = 0;
					lastNormals[i] = hitNormals[i];
				}
				dist = hit.distance;
				if(hit.distance < hoverHeight){
					rigidbody.AddForce((-average+transform.up) * rigidbody.mass * jumpingPower * rigidbody.drag * Mathf.Min(hoverHeight, hoverHeight/hit.distance));
				}
			}
		}
		average = -(hitNormals[0] + hitNormals[1] + hitNormals[2] + hitNormals[3] + hitNormals[4])/2;
		
		if(increment != 10){
			increment += 0.03;
		}
		
		rotation = Quaternion.Slerp(body.transform.localRotation, Quaternion.Euler(average * Mathf.Rad2Deg), increment);
		body.transform.localRotation = rotation;
		body.transform.localRotation.y = transform.up.y * Mathf.Deg2Rad;
	}
}

function OnDrawGizmos(){
	if(corners[0] != null){ Gizmos.DrawWireSphere(corners[0].position, 1);}
	if(corners[1] != null){ Gizmos.DrawWireSphere(corners[1].position, 1);}
	if(corners[2] != null){ Gizmos.DrawWireSphere(corners[2].position, 1);}
	if(corners[3] != null){ Gizmos.DrawWireSphere(corners[3].position, 1);}
	if(corners[4] != null){ Gizmos.DrawWireSphere(corners[4].position, 1);}
}

function CalculateSpeed(){
	if(lastPosition != transform.position) {
		var distance:float = Vector3.Distance(transform.position, lastPosition);
		speedUpdate = (distance/1000)/(Time.deltaTime/3600);
	}
}

function InitializePhysics(){
	//boxdimensions
	boxCollider = body.AddComponent(BoxCollider);
	
	boxDimensions = Vector3(boxCollider.size.x*body.transform.localScale.x, boxCollider.size.y*body.transform.localScale.y, boxCollider.size.z*body.transform.localScale.z)*stability;
	cornersPoint[0] = Vector3(transform.position.x - boxDimensions.x/2, transform.position.y - boxDimensions.y/2, transform.position.z + boxDimensions.z/2);
	cornersPoint[1] = Vector3(transform.position.x + boxDimensions.x/2, transform.position.y - boxDimensions.y/2, transform.position.z + boxDimensions.z/2);
	cornersPoint[2] = Vector3(transform.position.x + boxDimensions.x/2, transform.position.y - boxDimensions.y/2, transform.position.z - boxDimensions.z/2);
	cornersPoint[3] = Vector3(transform.position.x - boxDimensions.x/2, transform.position.y - boxDimensions.y/2, transform.position.z - boxDimensions.z/2);
	cornersPoint[4] = transform.position;
	Destroy(boxCollider);
	
	for (var i:int = 0; i <= cornersPoint.length-1; i++){
		var stablePlatform: GameObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		stablePlatform.name = "StablePlatform" + "(" + i + ")";
		stablePlatform.transform.parent = body.transform;
		stablePlatform.transform.localPosition = transform.InverseTransformPoint(cornersPoint[i]);
		corners[i] = stablePlatform.transform;
		Destroy(stablePlatform.GetComponent(MeshRenderer));
		Destroy(stablePlatform.GetComponent(Collider));
	}
	cornersPoint = null;
	physicsSetup = true;

}