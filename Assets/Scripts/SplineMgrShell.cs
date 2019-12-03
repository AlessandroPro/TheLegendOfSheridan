using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SplineMgrShell : MonoBehaviour {
	
	public List<GameObject> ControlPoints;
	public float dt = 0.05f;
	public float t = 0.0f;
	public int nHead = 0;
	public int exitNodeIndex;
	
	public enum eSplineState
	{
		invalid = -1,
		none = 0,
		started = 1,
		finished = 2,
		paused = 3
	};
	
	public eSplineState state;
	private eSplineState prevTickState;
	
	public Vector3 vOut;
	
	public enum eSplineType
	{
		ST_CATMULLROM
	}
	public eSplineType spline_type = eSplineType.ST_CATMULLROM;
	public GameObject HeadObj;
	
	public enum eEvaluatorMode
	{
		EM_CONSTANT = 0,
		EM_MANUAL = 1,
		EM_LOOP = 2,
		EM_PINGPONG = 3,
		EM_REVERSE = 4
	}
	public eEvaluatorMode evalMode = eEvaluatorMode.EM_CONSTANT;
	
	// Use this for initialization
	void Start () {
		reset ();
	}
	
	public void reset()
	{
		init ();
	}
	
	public void init()
	{
		nHead = 0;
	}
	
	public void pause()
	{
		state = eSplineState.paused;
	}
	
	public void begin()
	{
		t = 0.0f;
		state = eSplineState.started;
	}
	
	public void set_tval(float newt)
	{
		t = newt;
	}
	
	public void set_dtval(float newdt)
	{
		dt = newdt;
	}
	
	public void set_headval(int newHead)
	{
		nHead = newHead;
	}
	
	Vector3 PointOnCurve(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
	{
		//
		//	The spline passes through all of the control points.
		//	The spline is C1 continuous, meaning that there are no discontinuities in the tangent direction and magnitude.
		//	The spline is not C2 continuous.  The second derivative is linearly interpolated within each segment, causing the curvature to vary linearly over the length of the segment.
		//	Points on a segment may lie outside of the domain of P1 -> P2.
		Vector3 vOut = new Vector3(0.0f, 0.0f, 0.0f);
		
		float t2 = t * t;
		float t3 = t2 * t;
		
		//vOut = 0.5f * (2.0f*p1) + (-p0 + p2)*t + (2.0f*p0 - 5.0f*p1 + 4.0f*p2 - p3)*t2 + 
		//			(-p0 + 3.0f*p1 - 3.0f*p2 + p3) * t3;
		vOut.x = 0.5f * ( ( 2.0f * p1.x ) +( -p0.x + p2.x ) * t +( 2.0f * p0.x - 5.0f * p1.x + 4 * p2.x - p3.x ) * t2 +
		                 ( -p0.x + 3.0f * p1.x - 3.0f * p2.x + p3.x ) * t3 );
		vOut.y = 0.5f * ( ( 2.0f * p1.y ) +( -p0.y + p2.y ) * t + ( 2.0f * p0.y - 5.0f * p1.y + 4 * p2.y - p3.y ) * t2 +
		                 ( -p0.y + 3.0f * p1.y - 3.0f * p2.y + p3.y ) * t3 );
		vOut.z = 0.5f * ( ( 2.0f * p1.z ) +( -p0.z + p2.z ) * t + ( 2.0f * p0.z - 5.0f * p1.z + 4 * p2.z - p3.z ) * t2 +
		                 ( -p0.z + 3.0f * p1.z - 3.0f * p2.z + p3.z ) * t3 );
		
		return vOut;
	}
	
	// Update is called once per frame
	void Update () {
		
		switch(evalMode)
		{
			case(eEvaluatorMode.EM_CONSTANT):
			{
				if (state == eSplineState.started)
				{
					// update state, wrap when t exceeds end of curve segment
					t += dt;
                    if (t > 1.0f)
                    {
                        t -= 1.0f;
                        nHead++;

                        if (nHead == exitNodeIndex)
                        {
                            state = eSplineState.finished;
                        }

                        if (nHead == exitNodeIndex - 10)
                        {
                            var particleSystems = HeadObj.gameObject.GetComponentsInChildren<ParticleSystem>();
                            foreach (var ps in particleSystems)
                            {
                                ps.Stop();
                            }
                        }
                    }
                        

				}
				break;
			}

			case(eEvaluatorMode.EM_MANUAL):
			{
				break;
			}

		}
		
		if (state == eSplineState.started)
		{
			if (nHead == -1)
			{
				t = 0.0f;
				nHead = ControlPoints.Count-2-1;
			}		
		}
		
		// extract interpolated point from spline
		//Vector3 vOut = new Vector3(0.0f, 0.0f, 0.0f);
		if (state == eSplineState.started)
		{
			//Vector3 vOut = new Vector3(0.0f, 0.0f, 0.0f);
			Vector3 p0 = ControlPoints[nHead].transform.position;
			Vector3 p1 = ControlPoints[nHead+1].transform.position;
			Vector3 p2 = ControlPoints[nHead+2].transform.position;
			Vector3 p3 = ControlPoints[nHead+3].transform.position;
			vOut = PointOnCurve(t, p0, p1, p2, p3);
			
			if (HeadObj)
				HeadObj.transform.position = vOut;
		}
	}
}

