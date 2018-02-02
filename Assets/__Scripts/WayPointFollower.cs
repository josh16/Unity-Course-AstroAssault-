using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


namespace LearnProgrammingAcademy.AstroAssault
{
    [RequireComponent(typeof(Rigidbody2D))] // This script needs a rigidbody2D in order to work
    public class WayPointFollower : MonoBehaviour{
        
        // == fields == 
        //List for waypoints where the enemy will move to
        private IList<Vector3> waypoints = new List<Vector3>();

        //We need a 'Current way point' where the player moves to currently and then proceeds to the next
        private Vector3 currentWayPoint;
        private float speed;

        //RigidBody2D of the miniShip
        private Rigidbody2D body;

        // == Properties  ==
        public float Speed{
            get { return speed; }
            set { speed = value; }
        }





        // == Messages==
        private void Start()
        {
            body = GetComponent<Rigidbody2D>();
            NextWaypoint();
        }


        //Use fixed updates because we are using physics
        private void FixedUpdate()
        {
            if(HasMorePoints())
            {
                //We will call our move Method
                Move();
            }
        }


        //== Public Methods ==
        public void Addwaypoint(Vector3 point)
        {
            waypoints.Add(point); //
        }

        // == Private Methods
        private void NextWaypoint()
        {
            if(HasMorePoints())
            {
                currentWayPoint = waypoints.First();
            }
        }
    
        //If the waypoints count is not equal to 0, go to the next way point
        private bool HasMorePoints() 
        {
            return waypoints.Count != 0;
        }
    
        private void Move()
        {
            //Move the body position
            // the body will have its current position, move to a new position at a specific speed
            body.position = Vector3.MoveTowards(body.position, currentWayPoint, Time.deltaTime * speed);


            //We want to check to see if something is close to another Vector3
            // We do this by using ' Distance' which check between 'Point A' and 'Point B'
            if(Vector3.Distance(body.position,currentWayPoint)<0.001f)
            {
                //We are almost at the current way point
                body.position = new Vector2(currentWayPoint.x, currentWayPoint.y);

                //Once we reach current destination, we want to remove current waypoint
                waypoints.Remove(currentWayPoint);


                //If there is still more waypoints available, proceed to the next one and if not, destination
                // reached!
                if(HasMorePoints())
                {
                    NextWaypoint();//Calls this function
                }

            }
        
        }
    
    }
}