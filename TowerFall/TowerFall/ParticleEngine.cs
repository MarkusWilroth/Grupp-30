using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerFall {
    public class ParticleEngine { //Har i stort sett bara kopierat från tutorian som finns på it'slearning marker de värden jag ändrade
        private Random random;
        public Vector2 EmitterLocation { get; set;
        }
        private List<Particle> particles;
        private List<Texture2D> textures;

        public ParticleEngine(List<Texture2D> textures, Vector2 loaction) {
            EmitterLocation = EmitterLocation;
            this.textures = textures;
            this.particles = new List<Particle>();
            random = new Random();
        }

        public void Update() { //Ändrade några värden här men kommer inte ihåg vad
            int total = 1;
            for (int i = 0; i < total; i++) {
                particles.Add(GenerateNewParticle());
            }
            for (int particle = 0; particle < particles.Count; particle++) {
                particles[particle].Update();
                if (particles[particle].TTL <= 0) {
                    particles.RemoveAt(particle);
                    particle--;

                }
            }
        }

        private Particle GenerateNewParticle() {
            Texture2D texture = textures[random.Next(textures.Count)];
            Vector2 position = EmitterLocation;
            Vector2 velocity = new Vector2(1f * (float)(random.NextDouble() * 2 - 1), 1f * (float)(random.NextDouble() * 2 - 1));
            float angle = 0;
            float angularVelocity = 0.1f * (float)(random.NextDouble() * 2 - 1);
            Color color = Color.White; //Ändrade
            float size = 0.2f; //Ändrade
            int ttl = 2; //Ändrade

            return new Particle(texture, position, velocity, angle, angularVelocity, color, size, ttl);
        }

        public void Draw(SpriteBatch spriteBatch) {
            for (int index = 0; index < particles.Count; index++) {
                particles[index].Draw(spriteBatch);
            }
        }
    }
}
