using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Line : MonoBehaviour
{
    public static Line Instance;
    
    public List<Transform> points;
 
    private LineRenderer _renderer;
        
        private void Start() {
            _renderer = GetComponent<LineRenderer>();
        }

        void Update() {
            _renderer.positionCount = points.Count;
            _renderer.SetPositions(points.Select(p=>p.position).ToArray());
        }
        
        //I didn't write this!! I grabbed it from
        //https://forum.unity.com/threads/how-to-draw-a-line-on-a-distance-joint-2d.1058774/
        //and made it a static 
        //so that I can make my life easier by making the joints visible and make sure I get them right
        //but I don't understand how this or the line renderer works
        
        //...okay so after an hour of trying
        //it didn't make my life easier; I cannot add item to the list from the collision script
        //line 71&72 from Collision.cs doesn't work. 
}
