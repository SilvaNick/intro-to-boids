using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Avoidance")]
public class AvoidanceBehavior : FilteredFlockBehavior
{
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        // if no neighbors, return no adjustment
        if (context.Count == 0)
            return Vector2.zero;

        //add all the points together and average
        Vector2 avoidanceMove = Vector2.zero;
        int nAvoid = 0;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in filteredContext)
        {

            Vector2 t = Physics2D.ClosestPoint(agent.transform.position, item.GetComponentInParent<Collider2D>());


            if (Vector2.SqrMagnitude((Vector3)t - agent.transform.position) < flock.SquareAvoidanceRadius)
            {
                nAvoid++;
                avoidanceMove += (Vector2)(agent.transform.position - item.position);
            }

            Debug.DrawLine(agent.transform.position, t, Random.ColorHSV(0f,1f,1f,1f,1f,1f,1f,1f), 1f);

        }
        if (nAvoid > 0)
            avoidanceMove /= nAvoid;

        return avoidanceMove;

    }
}
