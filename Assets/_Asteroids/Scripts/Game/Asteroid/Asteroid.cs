﻿using UnityEngine;
using Asteroids.Actions;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// Asteroid object.
    /// </summary>
    public class Asteroid : SpaceObject
    {
        public string nextAsteroidTag;
        public int rewardScore;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == Constants.Tags.PLAYER_BULLET_TAG)
            {
                SpaceObject spaceObject = collision.GetComponent<SpaceObject>();
                health -= spaceObject.damage;
                collision.gameObject.SetActive(false);

                if (health <= 0)
                {
                    GameActions.AddScore(rewardScore);
                    GameActions.DestroyAsteroid(gameObject);
                }
            }
            else if(collision.tag == Constants.Tags.PLAYER_TAG)
            {
                GameActions.AddScore(rewardScore);
                GameActions.DestroyAsteroid(gameObject);
                GameActions.DestroyPlayer();
            }
        }
    }
}