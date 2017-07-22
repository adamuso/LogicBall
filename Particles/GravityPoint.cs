using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicBall.Particles
{
    public class GravityPoint : ParticleForce
    {
        private Vector2 point;
        private float force;
        private bool inverted;

        public GravityPoint(Vector2 point, float force, bool inverted)
            : base()
        {
            this.point = point;
            this.force = force;
            this.inverted = inverted;
        }

        public override void Update(Particle particle, GameTime gt)
        {
            float dir = 0f;

            if (inverted)
                dir = (float)Math.Atan2(particle.Position.Y - point.Y, particle.Position.X - point.X);
            else
                dir = (float)Math.Atan2(point.Y - particle.Position.Y, point.X - particle.Position.X);

            particle.Velocity += new Vector2((float)Math.Cos(dir), (float)Math.Sin(dir)) * force;
        }
    }
}
